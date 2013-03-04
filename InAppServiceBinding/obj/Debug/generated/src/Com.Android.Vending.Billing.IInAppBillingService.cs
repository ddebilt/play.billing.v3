using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Android.Vending.Billing {

	[global::Android.Runtime.Register ("com/android/vending/billing/IInAppBillingService$Stub", DoNotGenerateAcw=true)]
	public abstract partial class InAppBillingServiceStub : global::Android.OS.Binder, global::Com.Android.Vending.Billing.IInAppBillingService {

		[global::Android.Runtime.Register ("com/android/vending/billing/IInAppBillingService$Stub$Proxy", DoNotGenerateAcw=true)]
		public partial class Proxy : global::Java.Lang.Object, global::Com.Android.Vending.Billing.IInAppBillingService {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/android/vending/billing/IInAppBillingService$Stub$Proxy", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Proxy); }
			}

			protected Proxy (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static Delegate cb_getInterfaceDescriptor;
#pragma warning disable 0169
			static Delegate GetGetInterfaceDescriptorHandler ()
			{
				if (cb_getInterfaceDescriptor == null)
					cb_getInterfaceDescriptor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInterfaceDescriptor);
				return cb_getInterfaceDescriptor;
			}

			static IntPtr n_GetInterfaceDescriptor (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString (__this.InterfaceDescriptor);
			}
#pragma warning restore 0169

			static IntPtr id_getInterfaceDescriptor;
			public virtual string InterfaceDescriptor {
				[Register ("getInterfaceDescriptor", "()Ljava/lang/String;", "GetGetInterfaceDescriptorHandler")]
				get {
					if (id_getInterfaceDescriptor == IntPtr.Zero)
						id_getInterfaceDescriptor = JNIEnv.GetMethodID (class_ref, "getInterfaceDescriptor", "()Ljava/lang/String;");

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod  (Handle, id_getInterfaceDescriptor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_getInterfaceDescriptor), JniHandleOwnership.TransferLocalRef);
				}
			}

			static Delegate cb_asBinder;
#pragma warning disable 0169
			static Delegate GetAsBinderHandler ()
			{
				if (cb_asBinder == null)
					cb_asBinder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_AsBinder);
				return cb_asBinder;
			}

			static IntPtr n_AsBinder (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.AsBinder ());
			}
#pragma warning restore 0169

			static IntPtr id_asBinder;
			[Register ("asBinder", "()Landroid/os/IBinder;", "GetAsBinderHandler")]
			public virtual global::Android.OS.IBinder AsBinder ()
			{
				if (id_asBinder == IntPtr.Zero)
					id_asBinder = JNIEnv.GetMethodID (class_ref, "asBinder", "()Landroid/os/IBinder;");

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallObjectMethod  (Handle, id_asBinder), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_asBinder), JniHandleOwnership.TransferLocalRef);
			}

			static Delegate cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
			static Delegate GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler ()
			{
				if (cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == null)
					cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_);
				return cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
			}

			static int n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
				int __ret = __this.ConsumePurchase (p0, p1, p2);
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
			[Register ("consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I", "GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler")]
			public virtual int ConsumePurchase (int p0, string p1, string p2)
			{
				if (id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
					id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I");
				IntPtr native_p1 = JNIEnv.NewString (p1);
				IntPtr native_p2 = JNIEnv.NewString (p2);

				int __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallIntMethod  (Handle, id_consumePurchase_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
				else
					__ret = JNIEnv.CallNonvirtualIntMethod  (Handle, ThresholdClass, id_consumePurchase_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				return __ret;
			}

			static Delegate cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
			static Delegate GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
			{
				if (cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
					cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
				return cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
			}

			static IntPtr n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
				string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
				string p4 = JNIEnv.GetString (native_p4, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetBuyIntent (p0, p1, p2, p3, p4));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
			[Register ("getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
			public virtual global::Android.OS.Bundle GetBuyIntent (int p0, string p1, string p2, string p3, string p4)
			{
				if (id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
					id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
				IntPtr native_p1 = JNIEnv.NewString (p1);
				IntPtr native_p2 = JNIEnv.NewString (p2);
				IntPtr native_p3 = JNIEnv.NewString (p3);
				IntPtr native_p4 = JNIEnv.NewString (p4);

				global::Android.OS.Bundle __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3), new JValue (native_p4)), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3), new JValue (native_p4)), JniHandleOwnership.TransferLocalRef);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				return __ret;
			}

			static Delegate cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
			static Delegate GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
			{
				if (cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
					cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_);
				return cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
			}

			static IntPtr n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
				string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetPurchases (p0, p1, p2, p3));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
			[Register ("getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
			public virtual global::Android.OS.Bundle GetPurchases (int p0, string p1, string p2, string p3)
			{
				if (id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
					id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
				IntPtr native_p1 = JNIEnv.NewString (p1);
				IntPtr native_p2 = JNIEnv.NewString (p2);
				IntPtr native_p3 = JNIEnv.NewString (p3);

				global::Android.OS.Bundle __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3)), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3)), JniHandleOwnership.TransferLocalRef);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
				return __ret;
			}

			static Delegate cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
#pragma warning disable 0169
			static Delegate GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler ()
			{
				if (cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == null)
					cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_);
				return cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
			}

			static IntPtr n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
				global::Android.OS.Bundle p3 = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (native_p3, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetSkuDetails (p0, p1, p2, p3));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
			[Register ("getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler")]
			public virtual global::Android.OS.Bundle GetSkuDetails (int p0, string p1, string p2, global::Android.OS.Bundle p3)
			{
				if (id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == IntPtr.Zero)
					id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNIEnv.GetMethodID (class_ref, "getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;");
				IntPtr native_p1 = JNIEnv.NewString (p1);
				IntPtr native_p2 = JNIEnv.NewString (p2);

				global::Android.OS.Bundle __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (p3)), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (p3)), JniHandleOwnership.TransferLocalRef);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				return __ret;
			}

			static Delegate cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
			static Delegate GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler ()
			{
				if (cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == null)
					cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_);
				return cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
			}

			static int n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
			{
				global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub.Proxy> (native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
				int __ret = __this.IsBillingSupported (p0, p1, p2);
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
			[Register ("isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I", "GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler")]
			public virtual int IsBillingSupported (int p0, string p1, string p2)
			{
				if (id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
					id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I");
				IntPtr native_p1 = JNIEnv.NewString (p1);
				IntPtr native_p2 = JNIEnv.NewString (p2);

				int __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallIntMethod  (Handle, id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
				else
					__ret = JNIEnv.CallNonvirtualIntMethod  (Handle, ThresholdClass, id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				return __ret;
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/android/vending/billing/IInAppBillingService$Stub", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (InAppBillingServiceStub); }
		}

		protected InAppBillingServiceStub (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		[Register (".ctor", "()V", "")]
		public InAppBillingServiceStub () : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			if (GetType () != typeof (InAppBillingServiceStub)) {
				SetHandle (global::Android.Runtime.JNIEnv.CreateInstance (GetType (), "()V"), JniHandleOwnership.TransferLocalRef);
				return;
			}

			if (id_ctor == IntPtr.Zero)
				id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
			SetHandle (JNIEnv.NewObject (class_ref, id_ctor), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_asBinder;
#pragma warning disable 0169
		static Delegate GetAsBinderHandler ()
		{
			if (cb_asBinder == null)
				cb_asBinder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_AsBinder);
			return cb_asBinder;
		}

		static IntPtr n_AsBinder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.AsBinder ());
		}
#pragma warning restore 0169

		static IntPtr id_asBinder;
		[Register ("asBinder", "()Landroid/os/IBinder;", "GetAsBinderHandler")]
		public virtual global::Android.OS.IBinder AsBinder ()
		{
			if (id_asBinder == IntPtr.Zero)
				id_asBinder = JNIEnv.GetMethodID (class_ref, "asBinder", "()Landroid/os/IBinder;");

			if (GetType () == ThresholdType)
				return global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallObjectMethod  (Handle, id_asBinder), JniHandleOwnership.TransferLocalRef);
			else
				return global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, id_asBinder), JniHandleOwnership.TransferLocalRef);
		}

		static IntPtr id_asInterface_Landroid_os_IBinder_;
		[Register ("asInterface", "(Landroid/os/IBinder;)Lcom/android/vending/billing/IInAppBillingService;", "")]
		public static global::Com.Android.Vending.Billing.IInAppBillingService AsInterface (global::Android.OS.IBinder p0)
		{
			if (id_asInterface_Landroid_os_IBinder_ == IntPtr.Zero)
				id_asInterface_Landroid_os_IBinder_ = JNIEnv.GetStaticMethodID (class_ref, "asInterface", "(Landroid/os/IBinder;)Lcom/android/vending/billing/IInAppBillingService;");
			global::Com.Android.Vending.Billing.IInAppBillingService __ret = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (JNIEnv.CallStaticObjectMethod  (class_ref, id_asInterface_Landroid_os_IBinder_, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I;
#pragma warning disable 0169
		static Delegate GetOnTransact_ILandroid_os_Parcel_Landroid_os_Parcel_IHandler ()
		{
			if (cb_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I == null)
				cb_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int, bool>) n_OnTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I);
			return cb_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I;
		}

		static bool n_OnTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, int p3)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.OS.Parcel p1 = global::Java.Lang.Object.GetObject<global::Android.OS.Parcel> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Android.OS.Parcel p2 = global::Java.Lang.Object.GetObject<global::Android.OS.Parcel> (native_p2, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.OnTransact (p0, p1, p2, p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I;
		[Register ("onTransact", "(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z", "GetOnTransact_ILandroid_os_Parcel_Landroid_os_Parcel_IHandler")]
		public virtual bool OnTransact (int p0, global::Android.OS.Parcel p1, global::Android.OS.Parcel p2, int p3)
		{
			if (id_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I == IntPtr.Zero)
				id_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I = JNIEnv.GetMethodID (class_ref, "onTransact", "(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z");

			bool __ret;
			if (GetType () == ThresholdType)
				__ret = JNIEnv.CallBooleanMethod  (Handle, id_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I, new JValue (p0), new JValue (p1), new JValue (p2), new JValue (p3));
			else
				__ret = JNIEnv.CallNonvirtualBooleanMethod  (Handle, ThresholdClass, id_onTransact_ILandroid_os_Parcel_Landroid_os_Parcel_I, new JValue (p0), new JValue (p1), new JValue (p2), new JValue (p3));
			return __ret;
		}

		static Delegate cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == null)
				cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_);
			return cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
		}

		static int n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			int __ret = __this.ConsumePurchase (p0, p1, p2);
			return __ret;
		}
#pragma warning restore 0169

		[Register ("consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I", "GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler")]
		public abstract int ConsumePurchase (int p0, string p1, string p2);

		static Delegate cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
			return cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		static IntPtr n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString (native_p4, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetBuyIntent (p0, p1, p2, p3, p4));
			return __ret;
		}
#pragma warning restore 0169

		[Register ("getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		public abstract global::Android.OS.Bundle GetBuyIntent (int p0, string p1, string p2, string p3, string p4);

		static Delegate cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_);
			return cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		static IntPtr n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetPurchases (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		[Register ("getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		public abstract global::Android.OS.Bundle GetPurchases (int p0, string p1, string p2, string p3);

		static Delegate cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
#pragma warning disable 0169
		static Delegate GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler ()
		{
			if (cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == null)
				cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_);
			return cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
		}

		static IntPtr n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Android.OS.Bundle p3 = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetSkuDetails (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		[Register ("getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public abstract global::Android.OS.Bundle GetSkuDetails (int p0, string p1, string p2, global::Android.OS.Bundle p3);

		static Delegate cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == null)
				cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_);
			return cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
		}

		static int n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Android.Vending.Billing.InAppBillingServiceStub __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.InAppBillingServiceStub> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			int __ret = __this.IsBillingSupported (p0, p1, p2);
			return __ret;
		}
#pragma warning restore 0169

		[Register ("isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I", "GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler")]
		public abstract int IsBillingSupported (int p0, string p1, string p2);

	}

	[global::Android.Runtime.Register ("com/android/vending/billing/IInAppBillingService$Stub", DoNotGenerateAcw=true)]
	internal partial class InAppBillingServiceStubInvoker : InAppBillingServiceStub {

		public InAppBillingServiceStubInvoker (IntPtr handle, JniHandleOwnership transfer) : base (handle, transfer) {}

		protected override global::System.Type ThresholdType {
			get { return typeof (InAppBillingServiceStubInvoker); }
		}

		static IntPtr id_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
		[Register ("consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I", "GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler")]
		public override int ConsumePurchase (int p0, string p1, string p2)
		{
			if (id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			int __ret = JNIEnv.CallIntMethod  (Handle, id_consumePurchase_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

		static IntPtr id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		[Register ("getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		public override global::Android.OS.Bundle GetBuyIntent (int p0, string p1, string p2, string p3, string p4)
		{
			if (id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3), new JValue (native_p4)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			JNIEnv.DeleteLocalRef (native_p3);
			JNIEnv.DeleteLocalRef (native_p4);
			return __ret;
		}

		static IntPtr id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		[Register ("getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		public override global::Android.OS.Bundle GetPurchases (int p0, string p1, string p2, string p3)
		{
			if (id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			JNIEnv.DeleteLocalRef (native_p3);
			return __ret;
		}

		static IntPtr id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
		[Register ("getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public override global::Android.OS.Bundle GetSkuDetails (int p0, string p1, string p2, global::Android.OS.Bundle p3)
		{
			if (id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == IntPtr.Zero)
				id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNIEnv.GetMethodID (class_ref, "getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod  (Handle, id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (p3)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

		static IntPtr id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
		[Register ("isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I", "GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler")]
		public override int IsBillingSupported (int p0, string p1, string p2)
		{
			if (id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			int __ret = JNIEnv.CallIntMethod  (Handle, id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

	}


	[Register ("com/android/vending/billing/IInAppBillingService", "", "Com.Android.Vending.Billing.IInAppBillingServiceInvoker")]
	public partial interface IInAppBillingService : global::Android.OS.IInterface {

		[Register ("consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I", "GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler:Com.Android.Vending.Billing.IInAppBillingServiceInvoker, InAppServiceBinding")]
		int ConsumePurchase (int p0, string p1, string p2);

		[Register ("getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.Android.Vending.Billing.IInAppBillingServiceInvoker, InAppServiceBinding")]
		global::Android.OS.Bundle GetBuyIntent (int p0, string p1, string p2, string p3, string p4);

		[Register ("getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;", "GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.Android.Vending.Billing.IInAppBillingServiceInvoker, InAppServiceBinding")]
		global::Android.OS.Bundle GetPurchases (int p0, string p1, string p2, string p3);

		[Register ("getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler:Com.Android.Vending.Billing.IInAppBillingServiceInvoker, InAppServiceBinding")]
		global::Android.OS.Bundle GetSkuDetails (int p0, string p1, string p2, global::Android.OS.Bundle p3);

		[Register ("isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I", "GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler:Com.Android.Vending.Billing.IInAppBillingServiceInvoker, InAppServiceBinding")]
		int IsBillingSupported (int p0, string p1, string p2);

	}

	[global::Android.Runtime.Register ("com/android/vending/billing/IInAppBillingService", DoNotGenerateAcw=true)]
	internal class IInAppBillingServiceInvoker : global::Java.Lang.Object, IInAppBillingService {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/android/vending/billing/IInAppBillingService");
		IntPtr class_ref;

		public static IInAppBillingService GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IInAppBillingService> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.android.vending.billing.IInAppBillingService"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IInAppBillingServiceInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override System.Type ThresholdType {
			get { return typeof (IInAppBillingServiceInvoker); }
		}

		static Delegate cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetConsumePurchase_ILjava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == null)
				cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_);
			return cb_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
		}

		static int n_ConsumePurchase_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			int __ret = __this.ConsumePurchase (p0, p1, p2);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_consumePurchase_ILjava_lang_String_Ljava_lang_String_;
		public int ConsumePurchase (int p0, string p1, string p2)
		{
			if (id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_consumePurchase_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "consumePurchase", "(ILjava/lang/String;Ljava/lang/String;)I");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			int __ret = JNIEnv.CallIntMethod (Handle, id_consumePurchase_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

		static Delegate cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
			return cb_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		static IntPtr n_GetBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString (native_p4, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetBuyIntent (p0, p1, p2, p3, p4));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		public global::Android.OS.Bundle GetBuyIntent (int p0, string p1, string p2, string p3, string p4)
		{
			if (id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getBuyIntent", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod (Handle, id_getBuyIntent_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3), new JValue (native_p4)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			JNIEnv.DeleteLocalRef (native_p3);
			JNIEnv.DeleteLocalRef (native_p4);
			return __ret;
		}

		static Delegate cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_);
			return cb_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		static IntPtr n_GetPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetPurchases (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		public global::Android.OS.Bundle GetPurchases (int p0, string p1, string p2, string p3)
		{
			if (id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getPurchases", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod (Handle, id_getPurchases_ILjava_lang_String_Ljava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (native_p3)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			JNIEnv.DeleteLocalRef (native_p3);
			return __ret;
		}

		static Delegate cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
#pragma warning disable 0169
		static Delegate GetGetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_Handler ()
		{
			if (cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == null)
				cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_);
			return cb_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
		}

		static IntPtr n_GetSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Android.OS.Bundle p3 = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetSkuDetails (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_;
		public global::Android.OS.Bundle GetSkuDetails (int p0, string p1, string p2, global::Android.OS.Bundle p3)
		{
			if (id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ == IntPtr.Zero)
				id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_ = JNIEnv.GetMethodID (class_ref, "getSkuDetails", "(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			global::Android.OS.Bundle __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Bundle> (JNIEnv.CallObjectMethod (Handle, id_getSkuDetails_ILjava_lang_String_Ljava_lang_String_Landroid_os_Bundle_, new JValue (p0), new JValue (native_p1), new JValue (native_p2), new JValue (p3)), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

		static Delegate cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetIsBillingSupported_ILjava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == null)
				cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, int>) n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_);
			return cb_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
		}

		static int n_IsBillingSupported_ILjava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			int __ret = __this.IsBillingSupported (p0, p1, p2);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_;
		public int IsBillingSupported (int p0, string p1, string p2)
		{
			if (id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "isBillingSupported", "(ILjava/lang/String;Ljava/lang/String;)I");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			int __ret = JNIEnv.CallIntMethod (Handle, id_isBillingSupported_ILjava_lang_String_Ljava_lang_String_, new JValue (p0), new JValue (native_p1), new JValue (native_p2));
			JNIEnv.DeleteLocalRef (native_p1);
			JNIEnv.DeleteLocalRef (native_p2);
			return __ret;
		}

		static Delegate cb_asBinder;
#pragma warning disable 0169
		static Delegate GetAsBinderHandler ()
		{
			if (cb_asBinder == null)
				cb_asBinder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_AsBinder);
			return cb_asBinder;
		}

		static IntPtr n_AsBinder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Android.Vending.Billing.IInAppBillingService __this = global::Java.Lang.Object.GetObject<global::Com.Android.Vending.Billing.IInAppBillingService> (native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.AsBinder ());
		}
#pragma warning restore 0169

		IntPtr id_asBinder;
		public global::Android.OS.IBinder AsBinder ()
		{
			if (id_asBinder == IntPtr.Zero)
				id_asBinder = JNIEnv.GetMethodID (class_ref, "asBinder", "()Landroid/os/IBinder;");
			return global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallObjectMethod (Handle, id_asBinder), JniHandleOwnership.TransferLocalRef);
		}

	}

}
