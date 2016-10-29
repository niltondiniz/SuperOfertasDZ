using System;

using Xamarin.Forms;

namespace SuperOfertas
{
	public class OfertaRelampagoViewModel : ViewModelBase
	{
		public string Imagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public OfertaRelampagoViewModel()
		{

		}
	}
}

