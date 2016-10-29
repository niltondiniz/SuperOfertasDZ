using System;
namespace SuperOfertas
{
	public class OfertaViewModel : ViewModelBase
	{
		public string Imagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public OfertaViewModel()
		{

		}
	}
}
