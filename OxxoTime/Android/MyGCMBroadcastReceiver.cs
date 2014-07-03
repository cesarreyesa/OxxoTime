using System;
using Android.App;
using Android.Content;


namespace OxxoTime.Android
{

	[BroadcastReceiver(Permission= "com.google.android.c2dm.permission.SEND")]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] {"oxxoTime" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] {"oxxoTime" })]
	[IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "oxxoTime"})]
	public class MyGCMBroadcastReceiver : BroadcastReceiver
	{
		const string TAG = "PushHandlerBroadcastReceiver";
		public override void OnReceive(Context context, Intent intent)
		{
			MyIntentService.RunIntentInService(context, intent);
			SetResult(Result.Ok, null, null);
		}
	}
}

