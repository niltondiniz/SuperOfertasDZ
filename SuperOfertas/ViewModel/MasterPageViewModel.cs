using System;
namespace SuperOfertas
{
	public class MasterPageViewModel : ViewModelBase
	{

		public string Titulo
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Descricao
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Imagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public MasterPageViewModel()
		{

		}
	}
}
