using System;
using Newtonsoft.Json;
namespace SuperOfertas
{
	public class JsonResponse
	{
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("status")]
		public string Status { get; set; }
		[JsonProperty("data")]
		public string Data { get; set; }
		public JsonResponse()
		{

		}
	}
}
