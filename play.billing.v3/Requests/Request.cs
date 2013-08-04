using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace play.billing.v3
{
	public interface IBillingRequest
	{
		int Id { get; }
	}

	public abstract class BillingRequest<T> : IBillingRequest where T : Response
	{
		public int Id { get; protected set; }

		public TaskCompletionSource<T> TCS;

		public BillingRequest(int requestId)
		{
			this.Id = requestId;
		}

		public abstract Task<T> Execute(IBillingService service);
	}

	public class Response
	{
		public int ResponseCode;
		public string Message;
		public Exception Exception;

		public Response()
		{
			this.ResponseCode = Consts.BILLING_RESPONSE_RESULT_OK;
			this.Message = "Success.";
		}

		public Response(int responseCode, Exception ex = null)
		{
			this.ResponseCode = responseCode;
			this.Message = Utils.GetResponseDesc(responseCode);
			this.Exception = ex;
		}

		public bool Success
		{
			get
			{
				return ResponseCode == Consts.BILLING_RESPONSE_RESULT_OK;
			}
		}
	}

	public class GetSkuDetailsResponse : Response
	{
		public List<SkuDetail> Details;
				
		public GetSkuDetailsResponse(List<SkuDetail> details) : base(Consts.BILLING_RESPONSE_RESULT_OK)
		{
			this.Details = details;
		}

		public GetSkuDetailsResponse(int responseCode, Exception ex = null)
			: base(responseCode, ex)
		{

		}
	}

	public class GetPurchasesResponse : Response
	{
		public List<Purchase> PurchasedItems;
		public List<Purchase> FailedItems;

		public GetPurchasesResponse(List<Purchase> purchasedItems, List<Purchase> failedItems)
			: base(Consts.BILLING_RESPONSE_RESULT_OK)
		{
			this.PurchasedItems = purchasedItems;
			this.FailedItems = failedItems;
		}

		public GetPurchasesResponse(int responseCode, Exception ex = null)
			: base(responseCode, ex)
		{

		}
	}
}