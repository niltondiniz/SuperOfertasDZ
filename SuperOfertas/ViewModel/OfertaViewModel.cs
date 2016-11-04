using System;
using System.ComponentModel;

namespace SuperOfertas
{
	public class OfertaViewModel : INotifyPropertyChanged
	{
		private string _imagem;

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

		public OfertaViewModel()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}
	}
}
