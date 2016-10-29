using System;
using Newtonsoft.Json;
namespace SuperOfertas
{
	public class Catalogo
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("titulo")]
		public string Titulo { get; set; }
		[JsonProperty("descricao")]
		public string Descricao { get; set; }
		[JsonProperty("imagemUrl")]
		public string ImagemUrl { get; set; }
		[JsonProperty("imagemCaminho")]
		public string ImagemCaminho { get; set; }
		[JsonProperty("tipo")]
		public int Tipo { get; set; }

		public Catalogo()
		{

		}
	}
}
