using System;
using Newtonsoft.Json;
namespace SuperOfertas
{
	public class Empresa
	{

		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("razaoSocial")]
		public string RazaoSocial { get; set; }
		[JsonProperty("imagemCaminho")]
		public string ImagemCaminho { get; set; }
		[JsonProperty("imagemUrl")]
		public string ImagemUrl { get; set; }
		[JsonProperty("status")]
		public string status { get; set; }

		public Empresa()
		{

		}
	}
}
