using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.OpenWeatherDtos;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
	public class OpenWeatherServices : IOpenWeatherServices
	{
		public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
		{
			//127964 Tallinna kood
			string IDOWeather = "f996dc4eed7b726919dc548b1abc4ee8";
			var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&APPID={IDOWeather}";
			
			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);
				OpenWeatherRootDto weatherResult = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

				dto.City = weatherResult.City;
				dto.Temp = Math.Round(weatherResult.Main.Temp);
				dto.Feels_like = Math.Round(weatherResult.Main.Feels_like);
				dto.Humidity = weatherResult.Main.Humidity;
				dto.Pressure = weatherResult.Main.Pressure;
				dto.Speed = weatherResult.Wind.Speed;
				dto.Description = weatherResult.Weather[0].Description;
			}

			return dto;
		}
	}
}
