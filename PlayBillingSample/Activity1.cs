using System;
using System.Linq;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;
using play.billing.v3;

namespace PlayBillingSample
{
	[Activity(Label = "play.billing.v3", MainLauncher = true, Icon = "@drawable/icon")]
	public class Activity1 : Activity, IPlayListener
	{
		BillingService m_service;
		int m_requestId = 1;

		//For testing, put your applicatin key in m_sig
		// if you are not using the static responses, you will need this to verify purchase requests
		string m_sig = "";
			
		protected override void OnCreate(Bundle bundle)
		{
			System.Threading.Tasks.TaskScheduler.UnobservedTaskException += new EventHandler<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>(TaskScheduler_UnobservedTaskException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			//Change this to true if you expect signed responses 
			// This would occur when installing a signed APK on your device and have already uploaded the signed APK to Google Play
			//  see: http://developer.android.com/guide/google/play/billing/billing_testing.html
			Security.ExpectSignature = false;


			m_service = new BillingService(this, this, m_sig);
			var connTask = m_service.Connect();

			//Load inventory on start-up
			connTask.ContinueWith(t =>
				{
					if (t.Result)
					{
						//Existing purchases
						m_service.SendRequest<GetPurchasesResponse>(new GetPurchases(Consts.ITEM_TYPE_INAPP, m_requestId++));
						//All SKUs that have or could be purchased
						m_service.SendRequest<GetSkuDetailsResponse>(new GetSkuDetails(Consts.ITEM_TYPE_INAPP, m_requestId++, new List<string>() { "play.billing.v3.item_2" }));
					}
				});


			//BUY (use android.test.purchased for a static response)
			var pButton = FindViewById<Button>(Resource.Id.PurchaseButton);
			pButton.Click += delegate { SendBuyRequest("play.billing.v3.item_2"); };

			//CANCEL
			var cButton = FindViewById<Button>(Resource.Id.CancelButton);
			cButton.Click += delegate { SendBuyRequest("android.test.canceled"); };
					
			//ITEM UNAVAILABLE
			var uButton = FindViewById<Button>(Resource.Id.UnavailableButton);
			uButton.Click += delegate { SendBuyRequest("android.test.item_unavailable"); };


			//GET SKU DETAILS
			var skuButton = FindViewById<Button>(Resource.Id.SkuButton);
			skuButton.Click += delegate 
			{
				m_service.SendRequest<GetSkuDetailsResponse>(new GetSkuDetails(Consts.ITEM_TYPE_INAPP, m_requestId++, new List<string>() { "play.billing.v3.item_2" })).ContinueWith(t =>
					{
						this.RunOnUiThread(() =>
						{
							if (t.Result.Success)
								Toast.MakeText(this, "GetSkuDetail: " + (t.Result.Details.Count > 0 ? t.Result.Details.First().ToString() : "Not Found"), ToastLength.Long).Show();
							else
								Toast.MakeText(this, "GetSkuDetail failure. Error: " + t.Result.Message, ToastLength.Long).Show();
						});
					});
			};


			//CONSUME
			var consumeButton = FindViewById<Button>(Resource.Id.ConsumeButton);
			consumeButton.Click += delegate
			{
				var p = m_service.CurrentInventory.Purchases.Where(x => x.Sku == "play.billing.v3.item_2").FirstOrDefault();
				
				if (p == null)
				{
					Toast.MakeText(this, "There are no purchases to consume.", ToastLength.Long).Show();
					return;
				}
								
				System.Diagnostics.Debug.WriteLine("Attemping to consume: " + p.Sku);

				m_service.SendRequest<Response>(new ConsumePurchase(p, m_requestId++)).ContinueWith(t =>
					{
						this.RunOnUiThread(() =>
						{
							if (t.Result.Success)
							{
								//p.Token?
								m_service.CurrentInventory.ErasePurchase(p.Sku);
								Toast.MakeText(this, "Consume complete. Item: " + p.Sku, ToastLength.Long).Show();
							}
							else
								Toast.MakeText(this, "Consume failure. Error: " + t.Result.Message, ToastLength.Long).Show();
						});
					});
			};


			//GET PURCHASES
			var invButton = FindViewById<Button>(Resource.Id.InventoryButton);
			invButton.Click += delegate
			{
				m_service.SendRequest<GetPurchasesResponse>(new GetPurchases(Consts.ITEM_TYPE_INAPP, m_requestId++)).ContinueWith(t =>
					{
						this.RunOnUiThread(() =>
						{
							if (t.Result.Success)
							{
								var sb = new StringBuilder();
								sb.Append("Purchases: ");
								t.Result.PurchasedItems.Select(x => x.Sku).ToList().ForEach(x => sb.AppendFormat("{0},", x));
								sb.Remove(sb.Length - 1, 1);
								Toast.MakeText(this, sb.ToString(), ToastLength.Long).Show();
							}
							else
								Toast.MakeText(this, "Purchases request failure. Error: " + t.Result.Message, ToastLength.Long).Show();
						});
					});
			};
		}


		protected override void OnDestroy()
		{
			Android.Util.Log.Debug("Activity1", "OnDestroy.");
			if (m_service != null)
				m_service.Dispose();

			base.OnDestroy();
		}


		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var ex = e.ExceptionObject as Exception;
			System.Diagnostics.Debug.WriteLine("Unhandled Exception. Message: {0}, Stack: {1}", ex.Message, ex.StackTrace);
		}


		void TaskScheduler_UnobservedTaskException(object sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
		{
			e.SetObserved();
			System.Diagnostics.Debug.WriteLine("Unobserved Exception. Message: {0}, Stack: {1}", e.Exception.Message, e.Exception.StackTrace);
		}


		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (!m_service.HandleActivityResult(requestCode, (int)resultCode, data))
				base.OnActivityResult(requestCode, resultCode, data);
		}


		public void Connected()
		{			
			Toast.MakeText(this, "Connected.", ToastLength.Long).Show();
		}


		public void Disconnected()
		{
			Toast.MakeText(this, "Disconnected.", ToastLength.Long).Show();

			//TODO: attempt reconnect periodically (until connected) if not closing the app
			// If the user were to clear cache data from Google Play, or force it to stop, the InAppService will get disconnected
		}
		

		void SendBuyRequest(string sku)
		{
			var req = new Buy(sku, m_requestId++);

			m_service.SendRequest<Response>(req).ContinueWith(t =>
			{
				this.RunOnUiThread(() =>
				{
					if (t.Result.Success)
						Toast.MakeText(this, "Purchase complete. Item: " + req.Sku, ToastLength.Long).Show();
					else
						Toast.MakeText(this, "Purchase failure. Error: " + t.Result.Message, ToastLength.Long).Show();
				});
			});	
		}
	}
}