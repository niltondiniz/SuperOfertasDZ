using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class ItemCompra : ContentPage
	{
		public ItemCompra(ProdutoCompra produto = null)
		{
			BindingContext = ((App)App.Current).produtoCompraViewModel;
			((App)App.Current).produtoCompraViewModel.page = this;
			((App)App.Current).produtoCompraViewModel.produto = produto;

			InitializeComponent();

		}

		void SomaClick(object sender, EventArgs e)
		{
			((App)App.Current).produtoCompraViewModel.Quantidade += 1;
		}

		void SubtraiClick(object sender, EventArgs e)
		{
			((App)App.Current).produtoCompraViewModel.Quantidade -= 1;

		}

	}
}
