using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SuperOfertas
{
	public partial class ListaPromocao : ContentPage
	{

		public ListaPromocao()
		{
			BindingContext = ((App)App.Current).vm;
			InitializeComponent();

			if (((App)App.Current).vm != null)
			{

				PromoList.RefreshCommand = new Command(async () =>
				{
					await ((App)App.Current).vm.GetProdutos();
					PromoList.IsRefreshing = false;

				});

			}
		}
	}
}
