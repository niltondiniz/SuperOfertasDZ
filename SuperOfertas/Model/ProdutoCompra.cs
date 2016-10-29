using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace SuperOfertas
{
	public class ProdutoCompra
	{
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get;
			private set;

		}

		[NotNull]
		public string Descricao
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public ProdutoCompra(int id, string descricao, int status)
		{
			this.Id = id;
			this.Descricao = descricao;
			this.Status = status;
		}

		public ProdutoCompra()
		{

		}
	}
}
