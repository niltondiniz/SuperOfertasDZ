using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SuperOfertas
{
	public partial class Mapa : ContentPage
	{
		public Mapa()
		{
			Title = "Nossas Lojas";

			try
			{
				var map = new Map(
					MapSpan.FromCenterAndRadius(
							new Position(37, -122), Distance.FromMiles(0.3)))
				{
					IsShowingUser = true,
					HeightRequest = 100,
					WidthRequest = 960,
					VerticalOptions = LayoutOptions.FillAndExpand
				};

				var position = new Position(37, -122); // Latitude, Longitude

				var pin = new Pin
				{
					Type = PinType.Place,
					Position = position,
					Label = ((App)App.Current).masterPageViewModel.Titulo,
					Address = ((App)App.Current).masterPageViewModel.Descricao
				};

				map.Pins.Add(pin);

				var stack = new StackLayout { Spacing = 0 };
				stack.Children.Add(map);
				Content = stack;

			}
			catch (Exception e)
			{
				//Debug.WriteLine("Exceção gerada em:{0} ", e.Message);
			}

		}

	}

}

