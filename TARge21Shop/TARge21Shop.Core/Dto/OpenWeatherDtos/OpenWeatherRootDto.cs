using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.WeatherDtos;

namespace TARge21Shop.Core.Dto.OpenWeatherDtos
{
	public class OpenWeatherRootDto
	{
		[JsonPropertyName("Temperature")]
		public double temp { get; set; }

		[JsonPropertyName("TempFeelsLike")]
		public double feels_like { get; set; }

		[JsonPropertyName("Humidity")]
		public int humidity { get; set; }

		[JsonPropertyName("Pressure")]
		public int pressure { get; set; }

		[JsonPropertyName("WindSpeed")]
		public double wind_speed { get; set; }

		[JsonPropertyName("WeatherCondition")]
		public string main { get; set; }
	}
}
