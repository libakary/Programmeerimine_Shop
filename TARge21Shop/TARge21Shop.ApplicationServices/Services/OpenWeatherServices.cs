﻿using Nancy.Json;
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
		public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
		{
			//127964 Tallinna kood
			string apikey = "9307c0f72b2102ac959f2ebc3e8823e1";
			var url = $"https://api.openweathermap.org/data/3.0/onecall?lat=59.43&lon=24.75&exclude=hourly,daily&appid=9307c0f72b2102ac959f2ebc3e8823e1";

			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);

				OpenWeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

				dto.city = weatherInfo.OpenWeatherMain.city;
				dto.temp = weatherInfo.OpenWeatherMain.temp;
				dto.feels_like = weatherInfo.OpenWeatherMain.feels_like;
				dto.humidity = weatherInfo.OpenWeatherMain.humidity;
				dto.pressure = weatherInfo.OpenWeatherMain.pressure;
				dto.wind_speed = weatherInfo.OpenWeatherMain.wind_speed;
				dto.main = weatherInfo.OpenWeatherMain.main;

			}

			return dto;
		}
	}
}
