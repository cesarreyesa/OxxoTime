using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Parse;


namespace OxxoTime.Android
{
	[Activity (Label = "OxxoTime.Android.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;
		protected override void OnCreate (Bundle bundle)
		{
			ParseClient.Initialize("q7qlJD20kEtint79e6xe1bsgAj7mYv4MEmA1swTb", "adGks0GRUouK6Nzyt7vatV6NoerZK3F1lu9bbfpX");

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += (sender, args)=>{
				button.Text = string.Format ("{0} clicks!", count++);
				string senders = "367399986029";
				Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");
				intent.SetPackage("com.google.android.gsf");
				intent.PutExtra("app", PendingIntent.GetBroadcast(this.ApplicationContext, 0, new Intent(), 0));
				intent.PutExtra("sender", senders);
				this.ApplicationContext.StartService(intent);
			};
		}
	}
}

