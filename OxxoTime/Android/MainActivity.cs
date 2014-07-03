using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Parse;
using OxxoTime.Service;
using OxxoTime.Model;
using OxxoTime.Droid;

namespace OxxoTime.Android
{
	// Get our button from the layout resource,
	// and attach an event to it
	//	Button button = FindViewById<Button> (Resource.Id.myButton);

	//	button.Click += (sender, args)=>{
	//	button.Text = string.Format ("{0} clicks!", count++);
	//	string senders = "367399986029";
	//	Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");
	//	intent.SetPackage("com.google.android.gsf");
	//	intent.PutExtra("app", PendingIntent.GetBroadcast(this.ApplicationContext, 0, new Intent(), 0));
	//	intent.PutExtra("sender", senders);
	//	this.ApplicationContext.StartService(intent);
	//};
	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Activity
	{
		Button btnLogin = null; 
		TextView txtviewLoginResult = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			ParseClient.Initialize (Options.ParseApplicationId, Options.ParseDotNetKey);
			var user = new User() { Name = "Ricardo Blanco", Email ="ricardo.blanco@pricetravel.com" };
			var obj = user.AsParseObject();
			obj.SaveAsync ();

			InitializeControls();
			Authenticate ();
			SetControlsAfterAuthentication ();

		}

		protected void InitializeControls()
		{
			SetContentView (Resource.Layout.Main);
			btnLogin = FindViewById<Button> (Resource.Id.main_button_login);
			txtviewLoginResult = FindViewById<TextView> (Resource.Id.main_textview_login_result);
			btnLogin.Visibility = ViewStates.Invisible;
			txtviewLoginResult.Visibility = ViewStates.Invisible;
			btnLogin.Click += (delegate(object sender, EventArgs e) {
				onBtnLogin_Click();
			});
		}

		protected void Authenticate ()
		{

		}

		protected void SetControlsAfterAuthentication()
		{
			if (!AuthenticationService.IsLoggedIn ()) {
				btnLogin.Visibility = ViewStates.Visible;
				txtviewLoginResult.Visibility = ViewStates.Visible;
			} 
			else 
			{
				InitializeLoggedInControls ();
			}
		}

		protected void InitializeLoggedInControls()
		{
			var user = AuthenticationService.CurrentUser;
			SetContentView (Resource.Layout.LoggedInMain);
			TextView txtViewHi = FindViewById<TextView> (Resource.Id.loggedin_main_textview_hi);
			txtViewHi.Text = this.GetString(Resource.String.logged_in_hi).Replace ("{user}", user.Name);
		}

		protected void onBtnLogin_Click()
		{
			setFakeUser ();
			Authenticate ();
			SetControlsAfterAuthentication ();
		}

		protected void setFakeUser()
		{
			AuthenticationService.SetCurrentUser (new User{ 
				UserId = "1", Email = "hugo.cueva@gmail.com", Name = "Hugo Cueva"
			});
		}
	}
}

