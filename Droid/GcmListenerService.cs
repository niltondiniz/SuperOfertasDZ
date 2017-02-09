using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Gcm;
using Android.Util;
using Newtonsoft.Json.Linq;
using Android.Graphics;
using System.Net;

namespace SuperOfertas.Droid
{
	[Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
	public class MyGcmListenerService : GcmListenerService
	{
		public override void OnMessageReceived(string from, Bundle data)
		{
			var title = data.GetString("title");

			dynamic msgObj = JObject.Parse(data.GetString("message"));
			string message = msgObj["msg"];
			string image = msgObj["img"];
			string tipo = msgObj["tp"];
			string summary = msgObj["sm"];

			Log.Debug("MyGcmListenerService", "From:    " + from);
			Log.Debug("MyGcmListenerService", "Message: " + message);
			SendNotification(message, title, image.Replace("%2f", "/"), tipo, summary);
		}

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}


		void SendNotification(string message, string title, string imagem = null, string tipo = null, string summary = null)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

			Notification.Builder notificationBuilder = new Notification.Builder(this)
				.SetSmallIcon(Resource.Drawable.icon)
				.SetContentTitle(title)
				.SetContentText(message)
				.SetAutoCancel(true)
				.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
				.SetContentIntent(pendingIntent)
				.SetVisibility(NotificationVisibility.Public)
				.SetCategory(Notification.CategoryPromo);

			if (tipo.Equals("1"))
			{
				var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
				notificationManager.Notify(0, notificationBuilder.Build());
			}
			else if (tipo.Equals("2"))
			{
				var bigText = new Notification.BigTextStyle();
				bigText.BigText(message);
				bigText.SetSummaryText(summary);
				notificationBuilder.SetStyle(bigText);

				var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
				notificationManager.Notify(0, notificationBuilder.Build());

			}
			else if (tipo.Equals("3"))
			{
				var bigImage = new Notification.BigPictureStyle();
				bigImage.BigPicture(GetImageBitmapFromUrl(imagem));
				bigImage.SetSummaryText(summary);
				notificationBuilder.SetStyle(bigImage);

				var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
				notificationManager.Notify(0, notificationBuilder.Build());

			}
		}
	}
}
