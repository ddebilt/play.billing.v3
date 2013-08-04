using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace play.billing.v3
{
	public class Inventory
	{
		public List<Purchase> Purchases
		{
			get
			{
				return m_purchaseMap.Values.ToList();
			}
		}

		public List<SkuDetail> SkuDetails
		{
			get
			{
				return m_skuMap.Values.ToList();
			}
		}

		ConcurrentDictionary<string, SkuDetail> m_skuMap = new ConcurrentDictionary<string, SkuDetail>();
		ConcurrentDictionary<string, Purchase> m_purchaseMap = new ConcurrentDictionary<string, Purchase>();

		public Inventory() { }


		/// <summary>
		/// Retrieve the SkuDetail of the SKU in Inventory.
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public SkuDetail GetSkuDetails(string sku)
		{
			if (m_skuMap.ContainsKey(sku))
				return m_skuMap[sku];
			return null;
		}

		/// <summary>
		/// Return the Purchase, by SKU, if it exists in Inventory.
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public Purchase GetPurchase(string sku)
		{
			if (m_purchaseMap.ContainsKey(sku))
				return m_purchaseMap[sku];

			return null;
		}


		/// <summary>
		/// Indicates whether or not a Purchase exists with the given SKU.
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public bool HasPurchase(string sku)
		{
			return m_purchaseMap.ContainsKey(sku);
		}


		/// <summary>
		/// Indicates whether or not a SkuDetail object exists for the given SKU.
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public bool HasDetails(string sku)
		{
			return m_skuMap.ContainsKey(sku);
		}

		/// <summary>
		/// Call this after successfully consuming a Purchase. This could be used instead of always re-loading inventory from the InAppService after
		/// Inventory changes on the server.
		/// </summary>
		/// <param name="sku"></param>
		public void ErasePurchase(string sku)
		{
			Purchase p = null;

			if (m_purchaseMap.ContainsKey(sku))
				m_purchaseMap.TryRemove(sku, out p);
		}


		/// <summary>
		/// Add an SkuDetail object.
		/// </summary>
		/// <param name="d"></param>
		public void AddSkuDetails(SkuDetail d)
		{
			m_skuMap[d.Sku] = d;
		}


		/// <summary>
		/// Add a Purchase object.
		/// </summary>
		/// <param name="p"></param>
		public void AddPurchase(Purchase p)
		{
			m_purchaseMap[p.Sku] = p;
		}
	}
}