using System;
using Newtonsoft.Json.Linq;
using PushNotification.Plugin;
using PushNotification.Plugin.Abstractions;

namespace SuperOfertas
{
	public class CrossPushNotificationListener : IPushNotificationListener
	{
		public CrossPushNotificationListener()
		{
		}

		public void OnError(string message, DeviceType deviceType)
		{
			//Debug.WriteLine(string.Format("Push notification error - {0}", message));
			var mensagem = message;
		}

		public void OnMessage(JObject values, DeviceType deviceType)
		{
			//Debug.WriteLine("Message Arrived");

		}

		public async void OnRegistered(string token, DeviceType deviceType)
		{
			//Debug.WriteLine(string.Format("Push Notification - Device Registered - Token : {0}", token));

			var client = new System.Net.Http.HttpClient();
			client.BaseAddress = new Uri("http://virtual.niltondiniz.com/");
			client.GetAsync("registragcm.php?token=" + token);

		}

		public void OnUnregistered(DeviceType deviceType)
		{
			//Debug.WriteLine("Push Notification - Device Unnregistered");
		}

		public bool ShouldShowNotification()
		{
			return true;
		}
	}
}