using System;
using Xamarin.Forms;
namespace SuperOfertas
{
	public class ListSwitch : Switch
	{
		public static readonly BindableProperty ProdutoCompraProperty = BindableProperty.Create(
			propertyName: "ProdutoCompra",
			returnType: typeof(ProdutoCompra),
			declaringType: typeof(ListSwitch),
			defaultValue: null);

		public ProdutoCompra ProdutoCompra
		{
			get { return (ProdutoCompra)GetValue(ProdutoCompraProperty); }
			set { SetValue(ProdutoCompraProperty, value); }
		}
	}
}
