using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using Android.Widget;
using Android.Util;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using PushNotification.Plugin;
using Android.Content;

namespace SuperOfertas.Droid
{
	[Activity(Label = "SuperOfertas", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
			  ScreenOrientation = ScreenOrientation.Portrait)]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

		public static Context AppContext;

		protected override async void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			var intent = new Intent(this, typeof(RegistrationIntentService));
			StartService(intent);

			//AppContext = this.ApplicationContext;

			global::Xamarin.Forms.Forms.Init(this, bundle);
			var activity = (Activity)Forms.Context;
			var view = activity.FindViewById(Android.Resource.Id.Content);
			//CrossPushNotification.Initialize<CrossPushNotificationListener>("677084542092");
			var app = new App();
			LoadApplication(app);
			try
			{
				Snackbar.Make(view, "Aguarde carregando...", Snackbar.LengthLong).Show();
				await app.vm.GetProdutos();
				Snackbar.Make(view, "Pronto!", Snackbar.LengthLong).Show();
				//Snackbar.Make(view, CrossPushNotification.SenderId, Snackbar.LengthLong).Show();
			}
			catch (Exception e)
			{
				Log.Debug("X", "Exceção gerada em: {0}", e.Message);
			}


			Xamarin.FormsMaps.Init(this, bundle);

			//FirebaseOptions options = new FirebaseOptions.Builder()
			//.SetApplicationId(Settings.FirebaseAppId)
			//.SetApiKey(Settings.FirebaseApiKey)
			//.SetGcmSenderId(Settings.GcmSenderId)
			//.SetDatabaseUrl(Settings.FirebaseDatabaseUrl)
			//.SetStorageBucket(Settings.FirebaseStorageBucket)
			//.Build();

			//FirebaseApp app = FirebaseApp.InitializeApp(Android.App.Application.Context, options);

			//_auth = FirebaseAuth.Instance;
			//_auth.AuthState += AuthStateChanged;



			//CheckUserAuthentication();

			var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
			var y = typeof(Xamarin.Forms.Themes.LightThemeResources);
			var z = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);

			UserDialogs.Init(this);
			//StartPushService();

		}

		public static void StartPushService()
		{
			AppContext.StartService(new Intent(AppContext, typeof(PushNotificationService)));

			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{

				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}

	}
}
