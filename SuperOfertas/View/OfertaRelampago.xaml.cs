using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class OfertaRelampago : ContentPage
	{
		public string Imagem { get; set; }

		public OfertaRelampago()
		{

			BindingContext = ((App)App.Current).relampagoViewModel;
			InitializeComponent();

		}
	}
}
