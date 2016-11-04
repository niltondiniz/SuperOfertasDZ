using System;
using System.ComponentModel;

namespace SuperOfertas
{
	public class MasterPageViewModel : INotifyPropertyChanged
	{

		private string _titulo;
		private string _descricao;
		private string _imagem;

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
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

		public string Imagem
		{
			get { return _imagem; }
			set
			{
				if (value != _imagem)
				{
					_imagem = value;
					OnPropertyChanged("Imagem");
				}
			}
		}

		public MasterPageViewModel()
		{

		}
	}
}
