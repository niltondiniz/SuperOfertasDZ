using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public string Imagem { get; set; }

		public MasterPage()
		{
			BindingContext = ((App)App.Current).masterPageViewModel;
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Promoções",
				IconSource = "ic_rss.png",
				TargetType = typeof(ListaPromocao)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Lista de Compras",
				IconSource = "ic_thumb_up.png",
				TargetType = typeof(ListaCompra)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Oferta do Dia",
				IconSource = "ic_square_inc_cash.png",
				TargetType = typeof(Oferta)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Oferta do Relâmpago",
				IconSource = "ic_flash.png",
				TargetType = typeof(OfertaRelampago)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Contato",
				IconSource = "ic_voice.png",
				TargetType = typeof(Feedback)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Nossas Lojas",
				IconSource = "ic_map_marker_radius.png",
				TargetType = typeof(Mapa)
			});

			ListView.ItemsSource = masterPageItems;

		}
	}
}
