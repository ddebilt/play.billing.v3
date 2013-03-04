using System;
using System.Text;
using System.Collections.Generic;
using Android.Text;
using Android.Widget;

namespace play.billing.v3
{
	public class GetPurchases : BillingRequest<GetPurchasesResponse>
	{
		string m_itemType;

		public GetPurchases(string itemType, int requestId)
			: base(requestId)
		{
			m_itemType = itemType;
		}

		public override System.Threading.Tasks.Task<GetPurchasesResponse> Execute(IBillingService service)
		{
			this.TCS = new System.Threading.Tasks.TaskCompletionSource<GetPurchasesResponse>();

			var responseCode = Consts.BILLING_RESPONSE_RESULT_DEVELOPER_ERROR;

			try
			{

				bool verificationFailed = false;
				string continueToken = null;
				var purchases = new List<Purchase>();

				do
				{
					Utils.LogDebug("GetPurchases.Execute. Continuation token: " + continueToken);

					var purchased = service.InAppService.GetPurchases(3, service.MainContext.PackageName, this.m_itemType, continueToken);

					responseCode = Utils.GetResponseCodeFromBundle(purchased);

					Utils.LogDebug("GetPurchases.Execute response: " + responseCode.ToString());

					if (responseCode != Consts.BILLING_RESPONSE_RESULT_OK)
					{
						Utils.LogDebug("GetPurchases.Execute failed: " + Utils.GetResponseDesc(responseCode));
						this.TCS.SetResult(new GetPurchasesResponse(responseCode));
						return this.TCS.Task;
					}


					if (!purchased.ContainsKey(Consts.RESPONSE_INAPP_ITEM_LIST)
							|| !purchased.ContainsKey(Consts.RESPONSE_INAPP_PURCHASE_DATA_LIST)
							|| !purchased.ContainsKey(Consts.RESPONSE_INAPP_SIGNATURE_LIST))
					{
						Utils.LogError("GetPurchases.Execute. Bundle returned doesn't contain the required fields.");
						this.TCS.SetResult(new GetPurchasesResponse(Consts.BAD_RESPONSE));
						return this.TCS.Task;
					}

					var purchasedSKUs = purchased.GetStringArrayList(Consts.RESPONSE_INAPP_ITEM_LIST);
					var purchaseDataList = purchased.GetStringArrayList(Consts.RESPONSE_INAPP_PURCHASE_DATA_LIST);
					var signatureList = purchased.GetStringArrayList(Consts.RESPONSE_INAPP_SIGNATURE_LIST);


					for (int i = 0; i < purchaseDataList.Count; ++i)
					{
						try
						{
							var purchaseData = purchaseDataList[i];
							var signature = signatureList[i];
							var sku = purchasedSKUs[i];

							if (Security.VerifyPurchase(service.AppKey, purchaseData, signature))
							{
								Utils.LogDebug("Has Purchased: " + sku);
								var purchase = new Purchase(this.m_itemType, purchaseData, signature);

								purchases.Add(purchase);

								if (TextUtils.IsEmpty(purchase.Token))
								{
									Utils.LogWarn("BUG: empty/null token!");
									Utils.LogDebug("Purchased data: " + purchaseData);
								}

								// Record ownership and token
								service.CurrentInventory.AddPurchase(purchase);
							}
							else
							{
								Utils.LogWarn("Purchased signature verification **FAILED**. Not adding item.");
								Utils.LogDebug("   Purchase data: " + purchaseData);
								Utils.LogDebug("   Signature: " + signature);
								verificationFailed = true;
							}
						}
						catch (Exception e)
						{
							Utils.LogError(e.Message);
						}
					}

					continueToken = purchased.GetString(Consts.INAPP_CONTINUATION_TOKEN);
					Utils.LogDebug("Continuation token: " + continueToken);

				} while (!TextUtils.IsEmpty(continueToken));


				if (verificationFailed)
					this.TCS.SetResult(new GetPurchasesResponse(Consts.VERIFICATION_FAILED));
				else
					this.TCS.SetResult(new GetPurchasesResponse(purchases));

			}
			catch (Exception e)
			{
				Utils.LogError("GetPurchases exception. " + e.ToString());
				this.TCS.SetResult(new GetPurchasesResponse(responseCode, e));
			}


			return this.TCS.Task;
		}
	}
}