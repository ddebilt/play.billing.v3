play.billing.v3
===============

A C# Google Play client, for use with Xamarin.Android applications.

To use, refer to how the the BillingService implementation is used within the Activity1.cs file. There is an example for "Buy", "GetSkuDetails" (items that can be bought), "GetPurchases" (items that have been bought), and "Consume" (consuming a purchase, allowing re-purchase).


Security
========
When testing with a developer account, and not using the static SKUs (e.g. android.test.purchased, etc.) you can receive signed responses from the google play service. You'll need to set your application key in the Activity1.cs file ("m_sig" member variable). 

Refer to: http://docs.xamarin.com/guides/android/deployment%2C_testing%2C_and_metrics/publishing_an_application

You will also want to read the following link, regarding testing: 
http://developer.android.com/guide/google/play/billing/billing_testing.html