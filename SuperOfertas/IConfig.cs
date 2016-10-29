using System;
using SQLite.Net.Interop;

namespace SuperOfertas
{
	public interface IConfig
	{
		string DiretorioDB { get; }
		ISQLitePlatform Plataforma { get; }

	}
}
