using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Android.Vending.Billing;
using System.Threading.Tasks;

namespace play.billing.v3
{
	public partial class BillingService : Service, IServiceConnection, IBillingService
	{
		public IInAppBillingService InAppService { get; private set; }
		public Context MainContext { get; private set; }
		public Activity MainActivity { get; private set; }
		public bool PurchasesSupported { get; private set; }
		public bool SubscriptionsSupported { get; private set; }
		public bool Connected { get; private set; }
		public Inventory CurrentInventory { get; set; }
		public string AppKey { get; private set; }

		IPlayListener m_listener;
		IBillingRequest m_curRequest;
		object m_lock = new object();
		TaskCompletionSource<bool> m_connectTcs = null;

		public BillingService(Activity act, IPlayListener listener, string appKey) : base()
		{
			AttachBaseContext(act);			
			MainActivity = act;
			MainContext = act.ApplicationContext;
			CurrentInventory = new Inventory();
			this.AppKey = appKey;
			m_listener = listener;
		}


		/// <summary>
		/// We don't support binding to this service, only starting the service.
		/// </summary>
		/// <param name="intent"></param>
		/// <returns></returns>
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

		
		/// <summary>
		/// Bind to the InAppService
		/// </summary>
		/// <returns></returns>
		public Task<bool> Connect()
		{
			if (this.Connected)
				return Task.Factory.StartNew<bool>(() => { return true; });

			m_connectTcs = new TaskCompletionSource<bool>();

			try
			{
				Utils.LogDebug("Binding to the InAppService.");

				var serviceIntent = new Intent("com.android.vending.billing.InAppBillingService.BIND");
				
				var services = MainContext.PackageManager.QueryIntentServices(serviceIntent, 0);

				if (services.Any())
				{
					if (!this.BindService(serviceIntent, this, Bind.AutoCreate))
					{
						Utils.LogError("Could not bind to the InAppBillingService.");
						m_connectTcs.SetResult(false);
					}
				}
				else
				{
					Utils.LogError("InAppBillingService is not available on this device.");
					m_connectTcs.SetResult(false);
				}
			}
			catch (System.Exception e)
			{
				m_connectTcs.SetResult(false);
				Utils.LogError("Bind Exception: " + e.ToString());
			}

			return m_connectTcs.Task;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="service"></param>
		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			try
			{
				Connected = true;

				InAppService = InAppBillingServiceStub.AsInterface(service);
				var packageName = MainContext.PackageName;

				Utils.LogDebug("InAppService connected. Checking for v3 support.");

				if (InAppService.IsBillingSupported(3, packageName, Consts.ITEM_TYPE_INAPP) != Consts.BILLING_RESPONSE_RESULT_OK)
				{
					//If in-app items are not supported, subscriptions are not as well.
					PurchasesSupported = SubscriptionsSupported = false;
					return;
				}

				PurchasesSupported = true;
				Utils.LogDebug("InAppService v3 is supported.");

				if (InAppService.IsBillingSupported(3, packageName, Consts.ITEM_TYPE_SUBS) != Consts.BILLING_RESPONSE_RESULT_OK)
				{
					Utils.LogDebug("Subscriptions are not available.");
					SubscriptionsSupported = true;
				}
				else
					Utils.LogDebug("Subscriptions are not available.");

				if (m_listener != null)
					m_listener.Connected();
			}
			catch (RemoteException e)
			{
				Utils.LogError("Remote exception occurred in OnServiceConnected; " + e.ToString());
				Connected = false;
			}
			finally
			{
				//Just indicates that the connect request has completed
				// check PurchasesSupported to know whether or not v3 is supported, if successful
				if (m_connectTcs != null)
					m_connectTcs.SetResult(this.Connected);
			}
		}

		
		/// <summary>
		/// Send a request to the InAppService.
		/// </summary>
		/// <typeparam name="T">The type of response expected from the request. (i.e. Response or a sub-class)</typeparam>
		/// <param name="request">The request</param>
		/// <returns></returns>
		public System.Threading.Tasks.Task<T> SendRequest<T>(BillingRequest<T> request) where T : Response
		{
			//Hack...the Buy responses come in through the Activity (See HandleActivityResult below)
			// So, we must track it somewhere in order to complete the Task associated with it
			// Be careful that you only allow one Buy at a time
			if (request is Buy)
				m_curRequest = request;

			return request.Execute(this);
		}


		/// <summary>
		/// This must be called from the Activity's UI thread when the Activity's OnActivityResult is invoked. This is because we invoked
		/// Activity.StartActivityForResult when a Buy request was initiated.
		/// </summary>
		/// <param name="requestCode"></param>
		/// <param name="resultCode"></param>
		/// <param name="data"></param>
		/// <returns></returns>	
		public bool HandleActivityResult(int requestCode, int resultCode, Intent data)
		{
			if (m_curRequest == null || m_curRequest.Id != requestCode || !(m_curRequest is Buy))
				return false;

			var buyReq = m_curRequest as Buy;
			int responseCode = Consts.UNKNOWN_PURCHASE_RESPONSE;

			try
			{
				if (resultCode == (int)Result.Canceled)
				{
					Utils.LogDebug("Purchase cancelled.");
					responseCode = Consts.USER_CANCELLED;
					return true;
				}
				else if (resultCode != (int)Result.Ok)
				{
					Utils.LogError("Purchase error. Unknown result code: " + resultCode);
					return true;
				}
								
				if (data == null)
				{
					Utils.LogError("Data intent parameter is null.");
					return true;
				}

				responseCode = Utils.GetResponseCodeFromIntent(data);
				string purchaseData = data.GetStringExtra(Consts.RESPONSE_INAPP_PURCHASE_DATA);
				string dataSignature = data.GetStringExtra(Consts.RESPONSE_INAPP_SIGNATURE);

				if (responseCode != Consts.BILLING_RESPONSE_RESULT_OK)
				{
					Utils.LogDebug("Result code was OK, but InAppService response was not OK. Response Code: " + Utils.GetResponseDesc(responseCode));
					return true;
				}

				if (purchaseData == null || dataSignature == null)
				{
					Utils.LogError(string.Format("Null data. PurchaseData: {0}, DataSignature: {1}", purchaseData, dataSignature));
					return true;
				}

				Utils.LogDebug(string.Format("Successful purchase. Data: {0}, Signature: {1}, ItemType: {2}", purchaseData, dataSignature, buyReq.ItemType));

				try
				{
					var item = new Purchase(buyReq.ItemType, purchaseData, dataSignature);
					string sku = item.Sku;

					// Verify signature
					if (!Security.VerifyPurchase(this.AppKey, purchaseData, dataSignature))
					{
						Utils.LogError("Purchase signature verification failed. SKU: " + sku);
						return true;
					}
					Utils.LogDebug("Purchase signature verification passed. SKU: " + sku);
					this.CurrentInventory.AddPurchase(item);
				}
				catch
				{
					Utils.LogError("Failed to parse purchase data. SKU: " + buyReq.Sku);
					return true;
				}				
			}
			finally
			{
				buyReq.TCS.SetResult(new Response(responseCode));
			}

			return true;
		}


		/// <summary>
		/// Invoked when the InAppService is disconnected
		/// </summary>
		/// <param name="name"></param>
		public void OnServiceDisconnected(ComponentName name)
		{
			this.Connected = false;
			Utils.LogDebug("InAppService disconnected.");
			
			//The following will get re-initialized in OnServiceConnected
			if (this.InAppService != null)
			{
				InAppService.Dispose();
				InAppService = null;
			}

			if (m_listener != null)
				m_listener.Disconnected();
		}


		/// <summary>
		/// Dispose of all un-managed resources and unbind the service connection
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				base.Dispose(disposing);

				Utils.LogDebug("Disposing.");

				this.UnbindService(this);

				if (this.InAppService != null)
				{
					InAppService.Dispose();
					InAppService = null;
				}

				if (m_listener != null && this.Connected)
					m_listener.Disconnected();
			}
			catch { }
			this.Connected = false;
		}
	}
}