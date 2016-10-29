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
		public List<ProdutoCompra> Lista { get; }
		public ProdutoCompraViewModel listacompravm;

		public ListaCompra()
		{
			listacompravm = new ProdutoCompraViewModel();
			listacompravm.ListaCompra = new ObservableCollection<ProdutoCompra>(listacompravm.Listar());
			BindingContext = listacompravm;

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

		async void AddItem(object sender, EventArgs e)
		{
			PromptResult resposta;
			resposta = await UserDialogs.Instance.PromptAsync("", "Adicionar a lista", "Inserir", "Cancelar", "Ex: 5Kg Feijão", InputType.Name);
			if (resposta.Text != "")
			{
				ProdutoCompra item = new ProdutoCompra(1, resposta.Text, 0);

				listacompravm.Insert<ProdutoCompra>(item);
				listacompravm.ListaCompra.Add(item);
			}
		}

		public async void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			var listitem = (ProdutoCompra)mi.CommandParameter;
			bool resposta = await DisplayAlert("Confirma exclusão do item?", listitem.Descricao, "Sim", "Não");
			if (resposta)
			{
				listacompravm.Delete<ProdutoCompra>(listitem);
				listacompravm.ListaCompra.Remove(listitem);
			}
		}

		public void StatusChange(object sender, ToggledEventArgs e)
		{
			var mi = ((ListSwitch)sender);
			var listitem = (ProdutoCompra)mi.ProdutoCompra;
			listacompravm.Update<ProdutoCompra>(listitem);
		}
	}
}
