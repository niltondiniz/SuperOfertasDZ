using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class ListaCompra : ContentPage
	{
		public ListaCompra()
		{
			((App)App.Current).produtoCompraViewModel.page = this;
			BindingContext = ((App)App.Current).produtoCompraViewModel;


			/*
			Lista = new ObservableCollection<Promocao>();
			Lista.Add(new Promocao("Amaciante Mon Bijou", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.", 100, "http://economizamercado.com.br/img/amaciante-mon-bijou-2lt-oferta-descricaofoto-produto-1755048091420685145.jpg"));
			Lista.Add(new Promocao("Amaciante Mon Bijou Concentrado", "sit amet, consectetur adipiscing elit, sed", 100, "http://economizamercado.com.br/img/amaciante-roupas-concentrado-mon-bijou-500ml-oferta-descricaofoto-produto-2660012111592858180.jpg"));
			Lista.Add(new Promocao("Achocolatado Leco 200ml", "Ex ea commodo consequat. Duis aute irure dolor in reprehenderit.", 100, "http://economizamercado.com.br/img/achocolatado-uht-leco-200ml-categoria-oferta-foto-produto-266265610934400071.jpg"));
			Lista.Add(new Promocao("Suco Vigor 200ml", "ex ea commodo consequat. Duis aute irure dolor in reprehenderit ", 100, "http://economizamercado.com.br/img/suco-pronto-vigor-200ml-categoria-oferta-foto-produto-10331532022269.jpg"));
			Lista.Add(new Promocao("Ades 1l", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.", 100, "http://economizamercado.com.br/img/bebida-soja-ades-1l-categoria-oferta-foto-produto-1873016121495783778.jpg"));
			Lista.Add(new Promocao("Coxa de Frango Sadia", "Ex ea commodo consequat. Duis aut.", 100, "http://economizamercado.com.br/img/coxa-frango-sadia-bandeja-kg-categoria-oferta-foto-produto-13930140921713090.jpg"));
			*/
			InitializeComponent();
		}

		public async void AddItem(object sender, EventArgs e)
		{

			((App)App.Current).produtoCompraViewModel.Limpar();
			var modalPage = new ItemCompra();
			await Navigation.PushModalAsync(modalPage);




			//PromptResult resposta;
			//resposta = await UserDialogs.Instance.PromptAsync("", "Adicionar a lista", "Inserir", "Cancelar", "Ex: 5Kg Feijão", InputType.Name);
			//if (resposta.Text != "")
			//{
			//	ProdutoCompra item = new ProdutoCompra(1, resposta.Text, 0);

			//	listacompravm.Insert<ProdutoCompra>(item);
			//	listacompravm.ListaCompra.Add(item);
			//}
		}

		public async void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			var listitem = (ProdutoCompra)mi.CommandParameter;
			bool resposta = await DisplayAlert("Confirma exclusão do item?", listitem.Descricao, "Sim", "Não");
			if (resposta)
			{
				((App)App.Current).produtoCompraViewModel.Delete<ProdutoCompra>(listitem);
				((App)App.Current).produtoCompraViewModel.ListaCompra.Remove(listitem);
				((App)App.Current).produtoCompraViewModel.AtualizaLista();
				((App)App.Current).produtoCompraViewModel.Total = ((App)App.Current).produtoCompraViewModel.TotalCompra();
			}
		}

		public async void OnUpdate(object sender, EventArgs e)
		{

			var mi = ((MenuItem)sender);
			var produto = (ProdutoCompra)mi.CommandParameter;

			((App)App.Current).produtoCompraViewModel.Limpar();
			((App)App.Current).produtoCompraViewModel.Id = produto.Id;
			((App)App.Current).produtoCompraViewModel.Descricao = produto.Descricao;
			((App)App.Current).produtoCompraViewModel.Quantidade = produto.Quantidade;
			((App)App.Current).produtoCompraViewModel.Valor = produto.Valor;

			var modalPage = new ItemCompra();
			await Navigation.PushModalAsync(modalPage);
			((App)App.Current).produtoCompraViewModel.TotalCompra();


		}

		public void StatusChange(object sender, ToggledEventArgs e)
		{
			var mi = ((ListSwitch)sender);
			var listitem = (ProdutoCompra)mi.ProdutoCompra;
			((App)App.Current).produtoCompraViewModel.Update<ProdutoCompra>(listitem);
		}
	}
}
