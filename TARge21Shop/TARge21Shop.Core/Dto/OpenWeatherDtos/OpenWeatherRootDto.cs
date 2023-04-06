using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.OpenWeatherDtos
{
	public class OpenWeatherRootDto
	{
		[JsonPropertyName("weather")]
		public List<Weathers> Weather { get; set; }
		[JsonPropertyName("main")]
		public Mains Main { get; set; }
		[JsonPropertyName("wind")]
		public Winds Wind { get; set; }
		[JsonPropertyName("id")]
		public int Id { get; set; }
		[JsonPropertyName("name")]
		public string City { get; set; }
	}

	public class Weathers
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
		[JsonPropertyName("main")]
		public string Main { get; set; }
		[JsonPropertyName("description")]
		public string Description { get; set; }
		[JsonPropertyName("icon")]
		public string Icon { get; set; }
	}

	public class Mains
	{
		[JsonPropertyName("temp")]
		public double Temp { get; set; }
		[JsonPropertyName("feels_like")]
		public double Feels_like { get; set; }
		[JsonPropertyName("temp_min")]
		public double Temp_min { get; set; }
		[JsonPropertyName("temp_max")]
		public double Temp_max { get; set; }
		[JsonPropertyName("pressure")]
		public int Pressure { get; set; }
		[JsonPropertyName("humidity")]
		public int Humidity { get; set; }
	}

	public class Winds
	{
		[JsonPropertyName("speed")]
		public double Speed { get; set; }
		[JsonPropertyName("deg")]
		public int Deg { get; set; }
	}
}
