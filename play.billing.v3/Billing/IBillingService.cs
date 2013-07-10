using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Android.Vending.Billing;

namespace play.billing.v3
{
	public interface IBillingService
	{
		/// <summary>
		/// The license key for your application (used to verify in-app purchases)
		/// </summary>
		string AppKey { get; }
		
		/// <summary>
		/// The activity that is launching the buy intent
		/// </summary>
		Activity MainActivity { get; }

		/// <summary>
		/// The context of the application
		/// </summary>
		Context MainContext { get; }

		/// <summary>
		/// The IInAppBillingService implementation
		/// </summary>
		IInAppBillingService InAppService { get; }

		/// <summary>
		/// Indicates whether or not the InAppService is connected.
		/// </summary>
		bool Connected { get; }


		/// <summary>
		/// Indicates if v3 is supported
		/// </summary>
		bool PurchasesSupported { get; }


		/// <summary>
		/// Indicates whether or not the InAppService supports subscriptions.
		/// </summary>
		bool SubscriptionsSupported { get; }

		/// <summary>
		/// The current purchased inventory for the application, as well as available SKUs. You should request GetPurchases on app-startup.
		/// </summary>
		Inventory CurrentInventory { get; set; }
	}
}