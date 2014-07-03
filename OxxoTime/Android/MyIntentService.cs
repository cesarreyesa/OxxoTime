using System;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Widget;
using Android.Support.V4.App;

namespace OxxoTime.Android
{
	[Service]
	public class MyIntentService : IntentService
	{
		static PowerManager.WakeLock sWakeLock;
		static object LOCK = new object();

		public static void RunIntentInService(Context context, Intent intent)
		{
			lock (LOCK)
			{
				if (sWakeLock == null)
				{
					// This is called from BroadcastReceiver, there is no init.
					var pm = PowerManager.FromContext(context);
					sWakeLock = pm.NewWakeLock(
						WakeLockFlags.Partial, "My WakeLock Tag");
				}
			}

			sWakeLock.Acquire();
			intent.SetClass(context, typeof(MyIntentService));
			context.StartService(intent);
		}

		protected override void OnHandleIntent(Intent intent)
		{
			try
			{
				Context context = this.ApplicationContext;
				string action = intent.Action;

				if (action.Equals("com.google.android.c2dm.intent.REGISTRATION"))
				{
					String registrationKey = intent.GetStringExtra("registration_id");
					Console.WriteLine("registrando" + registrationKey);
					//HandleRegistration(context, intent);
				}
				else if (action.Equals("com.google.android.c2dm.intent.RECEIVE"))
				{
					String data = intent.GetStringExtra("alert");
					Toast.MakeText (this, data, ToastLength.Long).Show();
					//HandleMessage(context, intent);
				}
			}
			finally
			{
				lock (LOCK)
				{
					//Sanity check for null as this is a public method
					if (sWakeLock != null)
						sWakeLock.Release();
				}
			}
		}
	}
}

