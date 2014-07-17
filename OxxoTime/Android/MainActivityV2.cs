using System;
using Android.App;
using Xamarin.Forms.Platform.Android;
using Android.OS;
using Parse;
using OxxoTime.Service;
using Xamarin.Forms;
using OxxoTime.Model;

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
	public class MainActivityV2 : AndroidActivity
	{
		IUserManager userManager = new Service.UserManager();

		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			ParseClient.Initialize (Options.ParseApplicationId, Options.ParseDotNetKey);


			Xamarin.Forms.Forms.Init (this, bundle);
			var activityIndicator = new ActivityIndicator (){
				IsRunning = true
			};

			var userEmail = new AndroidServices().GetCurrentGoogleUserEmail();
			Console.WriteLine(userEmail);
			var exists = await userManager.ExistUser(userEmail);
			if (!exists) {
				Console.WriteLine ("el sssusuario no existe en parse");
				Console.WriteLine ("creando cuenta");
				userManager.CreateUser (new User{ Name = userEmail, Email = userEmail });
				Console.WriteLine ("cuenta creada");
			} else {
				Console.WriteLine ("el usuario existe en parse");
			}
			activityIndicator.IsRunning = false;
			//			Task taskA = Task.Run( () => {
			//			});

			SetPage (new ContentPage { 
				Content = new StackLayout{
					Children = {
						new Label {
							Text = "Cargando usuario"
						},
						activityIndicator
					}
				}
			});

		}

	}
}

