using System;
using System.Json;

namespace play.billing.v3
{
	public class Purchase
	{
		public string ItemType;  // ITEM_TYPE_INAPP or ITEM_TYPE_SUBS
		public string OrderId;
		public string PackageName;
		public string Sku;
		public long PurchaseTime;
		public int PurchaseState;
		public string DeveloperPayload;
		public string Token;
		public string OriginalJson;
		public string Signature;

		public Purchase(string itemType, string jsonPurchaseInfo, string signature) 
		{
			ItemType = itemType;
			OriginalJson = jsonPurchaseInfo;

			var o = JsonObject.Parse(OriginalJson) as JsonObject;

			OrderId = o["orderId"];
			PackageName = o["packageName"];
			Sku = o["productId"];
			PurchaseTime = Convert.ToInt64(o["purchaseTime"].ToString());
			Token = o["purchaseToken"];

			//This one is not listed in the aidl file, so we'll assume it's optional
			if (o.ContainsKey("purchaseState"))
				PurchaseState = Convert.ToInt32(o["purchaseState"].ToString());

			//This one doesn't always show up
			if (o.ContainsKey("developerPayload"))
				DeveloperPayload = o["developerPayload"];

			Signature = signature;
		}
  
		public override string ToString()
		{ 
			return "PurchaseInfo(type:" + ItemType + "):" + OriginalJson; 
		}
	}
}