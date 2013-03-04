using System.Text;
using Java.Security;
using Android.Util;
using Android.Text;
using Java.Security.Spec;
using Java.Lang;

namespace play.billing.v3
{
	public class Security
	{
		private const string KEY_FACTORY_ALGORITHM = "RSA";
		private const string SIGNATURE_ALGORITHM = "SHA1withRSA";

		public static bool ExpectSignature = true;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="base64PublicKey"></param>
		/// <param name="signedData"></param>
		/// <param name="signature"></param>
		/// <returns></returns>
		public static bool VerifyPurchase(string base64PublicKey, string signedData, string signature)
		{
			if (signedData == null)
			{
				Utils.LogError("Security. data is null");
				return false;
			}

			var verified = !ExpectSignature;

			if (!TextUtils.IsEmpty(signature))
			{
				var key = Security.GeneratePublicKey(base64PublicKey);
				verified = Security.Verify(key, signedData, signature);

				if (!verified)
				{
					Utils.LogWarn("Security. Signature does not match data.");
					return false;
				}
			}
			return true;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="encodedPublicKey"></param>
		/// <returns></returns>
		public static IPublicKey GeneratePublicKey(string encodedPublicKey)
		{
			try
			{
				var keyFactory = KeyFactory.GetInstance(KEY_FACTORY_ALGORITHM);
				return keyFactory.GeneratePublic(new X509EncodedKeySpec(Base64.Decode(encodedPublicKey, 0)));
			}
			catch (NoSuchAlgorithmException e)
			{
				throw new RuntimeException(e);
			}
			catch (InvalidKeySpecException e)
			{
				Utils.LogError("Security. Invalid key specification. " + e.ToString());
				throw new IllegalArgumentException(e);
			}
			catch (Base64DecoderException e)
			{
				Utils.LogError("Security. Base64 decoding failed. " + e.ToString());
				throw new IllegalArgumentException();
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="publicKey"></param>
		/// <param name="signedData"></param>
		/// <param name="signature"></param>
		/// <returns></returns>
		public static bool Verify(IPublicKey publicKey, string signedData, string signature)
		{
			Utils.LogDebug("Signature: " + signature);
			Signature sig;

			try
			{
				sig = Signature.GetInstance(SIGNATURE_ALGORITHM);
				sig.InitVerify(publicKey);
				sig.Update(Encoding.UTF8.GetBytes(signedData));

				if (!sig.Verify(Base64.Decode(signature, 0)))
				{
					Utils.LogError("Security. Signature verification failed.");
					return false;
				}
				return true;
			}
			catch (NoSuchAlgorithmException e)
			{
				Utils.LogError("Security. NoSuchAlgorithmException.");
			}
			catch (InvalidKeyException e)
			{
				Utils.LogError("Security. Invalid key specification.");
			}
			catch (SignatureException e)
			{
				Utils.LogError("Security. Signature exception.");
			}
			catch (Base64DecoderException e)
			{
				Utils.LogError("Security. Base64 decoding failed.");
			}
			return false;
		}
	}
}