using SQLite.Net.Attributes;
using System.Collections.ObjectModel;

namespace SuperOfertas
{
	[Table("ProdutoCompra")]
	public class ProdutoCompraViewModel : ViewModelBase
	{
		public ObservableCollection<ProdutoCompra> ListaCompra
		{
			get { return GetValue<ObservableCollection<ProdutoCompra>>(); }
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

		public int Status
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

	}
}
