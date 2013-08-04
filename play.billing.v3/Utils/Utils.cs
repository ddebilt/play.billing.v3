using Android.Content;
using Android.OS;
using Java.Lang;

namespace play.billing.v3
{
	public class Utils
	{
		/// <summary>
		/// Workaround to bug where sometimes response codes come as Long instead of Integer
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int GetResponseCodeFromBundle(Bundle b)
		{
			var o = b.Get(Consts.RESPONSE_CODE);
			if (o == null)
			{
				LogDebug("Bundle with null response code, assuming OK (known issue)");
				return Consts.BILLING_RESPONSE_RESULT_OK;
			}
			else if (o is Integer)
				return (int)o;
			else if (o is Long)
				return (int)o;
			else
			{
				LogError("Unexpected type for bundle response code.");
				LogError(o.GetType().Name);
				throw new RuntimeException("Unexpected type for bundle response code: " + o.GetType().Name);
			}
		}

		
		/// <summary>
		/// Workaround to bug where sometimes response codes come as Long instead of Integer
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public static int GetResponseCodeFromIntent(Intent i)
		{
			var o = i.Extras.Get(Consts.RESPONSE_CODE);
			if (o == null)
			{
				LogError("Intent with no response code, assuming OK (known issue)");
				return Consts.BILLING_RESPONSE_RESULT_OK;
			}
			else if (o is Integer)
				return (int)o;
			else if (o is Long)
				return (int)o;
			else
			{
				LogError("Unexpected type for intent response code.");
				LogError(o.GetType().Name);
				throw new RuntimeException("Unexpected type for intent response code: " + o.GetType().Name);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string GetResponseDesc(int code)
		{
			string[] iab_msgs = ("0:OK/1:User Canceled/2:Unknown/" +
					"3:Billing Unavailable/4:Item unavailable/" +
					"5:Developer Error/6:Error/7:Item Already Owned/" +
					"8:Item not owned").Split('/');

			string[] iabhelper_msgs = ("0:OK/-1001:Remote exception during initialization/" +
									   "-1002:Bad response received/" +
									   "-1003:Purchase signature verification failed/" +
									   "-1004:Send intent failed/" +
									   "-1005:User cancelled/" +
									   "-1006:Unknown purchase response/" +
									   "-1007:Missing token/" +
									   "-1008:Unknown error/" +
									   "-1009:Subscriptions not available/" +
									   "-1010:Invalid consumption attempt").Split('/');

			if (code <= Consts.ERROR_BASE)
			{
				int index = Consts.ERROR_BASE - code;
				if (index >= 0 && index < iabhelper_msgs.Length) return iabhelper_msgs[index];
				else return code.ToString() + ":Unknown IAB Helper Error";
			}
			else if (code < 0 || code >= iab_msgs.Length)
				return code.ToString() + ":Unknown";
			else
				return iab_msgs[code];
		}

				
		public static void LogDebug(string msg)
		{
#if DEBUG
			System.Diagnostics.Debug.WriteLine(msg);
#endif
		}

		public static void LogError(string msg)
		{
#if DEBUG
			System.Diagnostics.Debug.WriteLine(msg);
#endif
		}

		public static void LogWarn(string msg)
		{
#if DEBUG
			System.Diagnostics.Debug.WriteLine(msg);
#endif
		}
	}
}