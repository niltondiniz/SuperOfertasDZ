using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using Android.Widget;
using Android.Util;
using Android.Support.Design.Widget;
using Xamarin.Forms;

namespace SuperOfertas.Droid
{
	[Activity(Label = "SuperOfertas", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
			  ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			var activity = (Activity)Forms.Context;
			var view = activity.FindViewById(Android.Resource.Id.Content);

			var app = new App();
			LoadApplication(app);
			try
			{
				Snackbar.Make(view, "Aguarde carregando...", Snackbar.LengthLong).Show();
				await app.vm.GetProdutos();
				Snackbar.Make(view, "Pronto!", Snackbar.LengthLong).Show();
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

		}
	}
}
