using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;


namespace play.billing.v3
{
	public class GetSkuDetails : BillingRequest<GetSkuDetailsResponse>
	{
		string m_itemType;
		List<string> m_SKUs;

		public GetSkuDetails(string itemType, int requestId, List<string> SKUs)
			: base(requestId)
		{
			m_itemType = itemType;
			m_SKUs = SKUs;

			if (m_SKUs == null || m_SKUs.Count == 0)
				throw new ArgumentException("SKUs should not be null or empty.");

			if (m_SKUs.Count > 20)
				throw new Exception("InAppService only allows a maximum of 20 SKUs at one time. Batch your requests.");
		}

		public override System.Threading.Tasks.Task<GetSkuDetailsResponse> Execute(IBillingService service)
		{
			this.TCS = new System.Threading.Tasks.TaskCompletionSource<GetSkuDetailsResponse>();
			
			var b = new Bundle();
			b.PutStringArrayList(Consts.GET_SKU_DETAILS_ITEM_LIST, m_SKUs);
			var skuDetails = service.InAppService.GetSkuDetails(3, service.MainContext.PackageName, this.m_itemType, b);

			if (!skuDetails.ContainsKey(Consts.RESPONSE_GET_SKU_DETAILS_LIST))
			{
				int response = Utils.GetResponseCodeFromBundle(skuDetails);
				if (response != Consts.BILLING_RESPONSE_RESULT_OK)
				{
					Utils.LogError(string.Format("SkueDetails.Execute failed. Message : {0}", Utils.GetResponseDesc(response)));
					this.TCS.SetResult(new GetSkuDetailsResponse(response));
					return this.TCS.Task;
				}
				else
				{
					Utils.LogError("SkueDetails.Execute failed. Neither an error nor a detail list.");
					this.TCS.SetResult(new GetSkuDetailsResponse(Consts.BAD_RESPONSE));
					return this.TCS.Task; 
				}
			}

			var responseList = skuDetails.GetStringArrayList(Consts.RESPONSE_GET_SKU_DETAILS_LIST);
			var skus = new List<SkuDetail>();

			responseList.ToList().ForEach(x =>
			{
				var d = new SkuDetail(this.m_itemType, x);
				skus.Add(d);
				Utils.LogDebug("SkuDetail: " + d);				
				service.CurrentInventory.AddSkuDetails(d);
			});

			this.TCS.SetResult(new GetSkuDetailsResponse(skus));
			return this.TCS.Task; 
		}
	}
}