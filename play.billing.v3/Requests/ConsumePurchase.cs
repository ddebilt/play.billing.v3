using System;
using Android.OS;

namespace play.billing.v3
{
	public class ConsumePurchase : BillingRequest<Response>
	{
		public Purchase Item { get; private set; }

		public ConsumePurchase(Purchase item, int requestId) : base(requestId)
		{
			if (item.ItemType != Consts.ITEM_TYPE_INAPP)
				throw new Exception("Invalid item type to consume.");

			this.Item = item;
		}

		public override System.Threading.Tasks.Task<Response> Execute(IBillingService service)
		{
			this.TCS = new System.Threading.Tasks.TaskCompletionSource<Response>();

			try
			{
				if (string.IsNullOrEmpty(this.Item.Token))
				{
					this.TCS.SetResult(new Response(Consts.MISSING_TOKEN));
					return this.TCS.Task;
				}
					
				Utils.LogDebug(string.Format("Consuming sku: {0}, token: {1}", this.Item.Sku, this.Item.Token));
				
				int response = service.InAppService.ConsumePurchase(3, service.MainContext.PackageName, this.Item.Token);
				
				if (response == Consts.BILLING_RESPONSE_RESULT_OK)					
				{
					Utils.LogDebug(string.Format("Successfully consumed sku: {0}, token: {1}", this.Item.Sku, this.Item.Token));
					this.TCS.SetResult(new Response());
				}
				else
				{
					Utils.LogError(string.Format("Error consuming consuming sku: {0}, token: {1}, message: {2}", this.Item.Sku, this.Item.Token, Utils.GetResponseDesc(response)));
					this.TCS.SetResult(new Response(response));
				}
			}		
			catch (RemoteException e)
			{
				Utils.LogError(string.Format("RemoteException while consuming sku: {0}, token: {1}, message: {2}", this.Item.Sku, this.Item.Token, e.Message));
				TCS.SetResult(new Response(Consts.REMOTE_EXCEPTION, e));
			}
			catch (System.Exception e)
			{
				Utils.LogError(string.Format("Exception while consuming sku: {0}, token: {1}, message: {2}", this.Item.Sku, this.Item.Token, e.Message));
				this.TCS.SetResult(new Response(Consts.ERROR_BASE, e));
			}

			return this.TCS.Task;
		}
	}
}