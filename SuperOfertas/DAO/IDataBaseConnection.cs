using System;
namespace SuperOfertas
{
	public interface IDataBaseConnection
	{
		SQLite.Net.SQLiteConnection DBConnection();
	}
}
