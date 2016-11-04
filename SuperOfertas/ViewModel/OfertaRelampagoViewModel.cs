using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SuperOfertas
{
	public class OfertaRelampagoViewModel : INotifyPropertyChanged
	{
		private string _imagem;

		public OfertaRelampagoViewModel()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
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


	}
}

