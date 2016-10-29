using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class Oferta : ContentPage
	{
		public string Imagem { get; set; }

		public Oferta()
		{

			BindingContext = ((App)App.Current).ofertaViewmModel;
			InitializeComponent();

		}
	}
}
