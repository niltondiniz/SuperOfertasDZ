using System;
using SQLite.Net.Attributes;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using Plugin.Connectivity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Acr.UserDialogs;

namespace SuperOfertas
{
	[Table("ItemOferta")]
	public class ItemOfertaViewModel : ViewModelBase
	{

		public ObservableCollection<Catalogo> ListaItens
		{
			get { return GetValue<ObservableCollection<Catalogo>>(); }
			set { SetValue(value); }
		}

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		[NotNull]
		public string Descricao
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Titulo
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public double Valor
		{
			get { return GetValue<double>(); }
			set { SetValue(value); }
		}

		public int tipo
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		public async Task GetProdutos()
		{

			try
			{

				if (CrossConnectivity.Current.IsConnected)
				{

					var client = new System.Net.Http.HttpClient();
					client.BaseAddress = new Uri("http://virtual.niltondiniz.com/");
					var response = await client.GetAsync("painel_web/index.php/api/v1/app/dadosjson");
					string dadosJson = response.Content.ReadAsStringAsync().Result;

					dynamic jsonObj = JObject.Parse(dadosJson);
					dynamic catalogoLista = jsonObj["data"]["catalogo"];
					dynamic empresa = jsonObj["data"]["empresa"];
					ListaItens = new ObservableCollection<Catalogo>((List<Catalogo>)JsonConvert.DeserializeObject(catalogoLista.ToString(), typeof(List<Catalogo>)));

					GetInfoCliente((string)empresa[0]["razaoSocial"], (string)empresa[0]["nomeFantasia"], (string)empresa[0]["imagemUrl"]);
					GetOfertaDia();
					GetOfertaRelampago();

					var listaPromocao = from item in ListaItens
										where item.Tipo == 2
										select item;

					ListaItens = new ObservableCollection<Catalogo>(listaPromocao);

				}
				else
				{
					ListaItens = new ObservableCollection<Catalogo>();
					ListaItens.Add(new Catalogo
					{
						Titulo = "Sem Conexão com a Internet",
						Descricao = "Verifique sua conexão",
						Tipo = 2,
						ImagemUrl = "no_internet"
					});
				}

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public void GetInfoCliente(string titulo, string descricao, string imagem)
		{
			((App)App.Current).masterPageViewModel.Titulo = titulo;
			((App)App.Current).masterPageViewModel.Descricao = descricao;
			((App)App.Current).masterPageViewModel.Imagem = imagem;

		}
		public void GetOfertaDia()
		{
			var ofertaDia = from item in ListaItens
							where item.Tipo == 3
							select item;

			if (ofertaDia.Count() > 0)
			{
				var itemOferta = ofertaDia.First();

				((App)App.Current).ofertaViewmModel.Imagem = itemOferta.ImagemUrl;
			}
		}
		public void GetOfertaRelampago()
		{
			var ofertaRelampago = from item in ListaItens
								  where item.Tipo == 4
								  select item;

			if (ofertaRelampago.Count() > 0)
			{
				var itemOferta = ofertaRelampago.First();

				((App)App.Current).relampagoViewModel.Imagem = itemOferta.ImagemUrl;
			}
		}
	}
}