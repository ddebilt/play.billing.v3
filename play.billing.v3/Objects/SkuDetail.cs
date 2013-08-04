using System.Json;

namespace play.billing.v3
{
	public class SkuDetail
	{
		public string ItemType;
		public string Sku;
		public string Type;
		public string Price;
		public string Title;
		public string Description;
		public string Json;

		public SkuDetail(string itemType, string jsonSkuDetails)
		{
			ItemType = itemType;
			Json = jsonSkuDetails;

			var o = JsonObject.Parse(jsonSkuDetails) as JsonObject;

			Sku = o["productId"];
			Type = o["type"];
			Price = o["price"];
			Title = o["title"];
			Description = o["description"];
		}

		public override string ToString()
		{
			return "SkuDetail:" + Json;
		}
	}
}