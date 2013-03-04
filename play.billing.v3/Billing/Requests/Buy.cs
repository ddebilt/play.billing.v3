using Android.App;
using Android.Content;
using Android.OS;

namespace play.billing.v3
{
	public class Buy : BillingRequest<Response>
	{
		public string Sku;		
		public string ItemType;
		public string ExtraData;

		public Buy(string sku, int requestId, string itemType = Consts.ITEM_TYPE_INAPP, string extraData = "")
			: base(requestId)
		{
			this.Sku = sku;
			this.ItemType = itemType;
			this.ExtraData = extraData;
		}

		public override System.Threading.Tasks.Task<Response> Execute(IBillingService service)
		{
			this.TCS = new System.Threading.Tasks.TaskCompletionSource<Response>();
			
			if (this.ItemType == Consts.ITEM_TYPE_SUBS && !service.SubscriptionsSupported)
			{
				TCS.SetResult(new Response(Consts.SUBSCRIPTIONS_NOT_AVAILABLE));
				return TCS.Task;
			}

			try
			{
				var buyIntentBundle = service.InAppService.GetBuyIntent(3, service.MainContext.PackageName, this.Sku, this.ItemType, this.ExtraData);

				int response = Utils.GetResponseCodeFromBundle(buyIntentBundle);

				if (response != Consts.BILLING_RESPONSE_RESULT_OK)
				{
					Utils.LogError("Unable to buy the item, Error response: " + Utils.GetResponseDesc(response));
					TCS.SetResult(new Response(response));
					return TCS.Task;
				}

				var pendingIntent = buyIntentBundle.GetParcelable(Consts.RESPONSE_BUY_INTENT) as PendingIntent;
				Utils.LogDebug("Launching buy intent for " + this.Sku + ". Request code: " + this.Id);

				service.MainActivity.StartIntentSenderForResult(pendingIntent.IntentSender, this.Id, new Intent(), 0, 0, 0);
			}
			catch (Android.Content.IntentSender.SendIntentException e)
			{
				Utils.LogError(string.Format("SendIntentException while purchasing sku: {0}, message: {1}", this.Sku, e.Message));
				TCS.SetResult(new Response(Consts.SEND_INTENT_FAILED, e));
			}
			catch (RemoteException e)
			{
				Utils.LogError(string.Format("RemoteException while purchasing sku: {0}, message: {1}", this.Sku, e.Message));
				TCS.SetResult(new Response(Consts.REMOTE_EXCEPTION, e));
			}
			catch (System.Exception e)
			{
				Utils.LogError(string.Format("Exception while purchasing sku: {0}, message: {1}", this.Sku, e.Message));
				this.TCS.SetResult(new Response(Consts.ERROR_BASE, e));
			}

			return this.TCS.Task;
		}
	}
}