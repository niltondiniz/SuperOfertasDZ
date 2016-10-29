using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Xamarin.Forms;

namespace SuperOfertas
{
	public class ViewModelBase : INotifyPropertyChanged, IDisposable
	{
		private SQLite.Net.SQLiteConnection _conexao;

		public event PropertyChangedEventHandler PropertyChanged;

		private Dictionary<string, object> properties = new Dictionary<string, object>();

		protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				properties.Add(propertyName, default(T));
			}

			var oldValue = GetValue<T>(propertyName);
			if (!EqualityComparer<T>.Default.Equals(oldValue, value))
			{
				properties[propertyName] = value;
				OnPropertyChanged(propertyName);
			}
		}

		protected T GetValue<T>([CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				return default(T);
			}
			else {
				return (T)properties[propertyName];
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void Dispose()
		{
			_conexao.Dispose();
		}

		public ViewModelBase()
		{
			var config = DependencyService.Get<IConfig>();
			_conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados.db3"));
			_conexao.CreateTable<ProdutoCompra>();
		}

		public void Insert<T>(object objeto)
		{
			_conexao.Insert((T)objeto);
		}

		public List<ProdutoCompra> Listar()
		{
			return _conexao.Table<ProdutoCompra>().ToList();
		}

		public void Delete<T>(object objeto)
		{
			_conexao.Delete(objeto);
		}

		public void Update<T>(object objeto)
		{
			_conexao.Update((T)objeto);
		}
	}
}
