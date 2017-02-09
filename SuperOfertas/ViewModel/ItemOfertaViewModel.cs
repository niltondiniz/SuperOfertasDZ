using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using Plugin.Connectivity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
//using System.Diagnostics;
using System.ComponentModel;

namespace SuperOfertas
{
	public class ItemOfertaViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Catalogo> _listaItens;
		private int _id;
		private string _descricao;
		private string _titulo;
		private double _valor;
		private int _tipo;

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}

		public ObservableCollection<Catalogo> ListaItens
		{
			get { return _listaItens; }
			set
			{
				_listaItens = value;
				OnPropertyChanged("ListaItens");
			}
		}

		public int Id
		{
			get { return _id; }
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("Id");
				}
			}
		}

		public string Descricao
		{
			get { return _descricao; }
			set
			{
				if (value != _descricao)
				{
					_descricao = value;
					OnPropertyChanged("Descricao");
				}
			}
		}

		public string Titulo
		{
			get { return _titulo; }
			set
			{
				if (value != _titulo)
				{
					_titulo = value;
					OnPropertyChanged("Titulo");
				}
			}
		}

		public double Valor
		{
			get { return _valor; }
			set
			{
				if (value != _valor)
				{
					_valor = value;
					OnPropertyChanged("Valor");
				}
			}
		}

		public int Tipo
		{
			get { return _tipo; }
			set
			{
				if (value != _tipo)
				{
					_tipo = value;
					OnPropertyChanged("Tipo");
				}
			}
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
				//Debug.WriteLine(e.Message);
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
			try
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
			catch (Exception e)
			{
				//Debug.WriteLine(e.Message);
			}
		}
		public void GetOfertaRelampago()
		{
			try
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
			catch (Exception e)
			{
				//Debug.WriteLine(e.Message);
			}
		}
	}
}