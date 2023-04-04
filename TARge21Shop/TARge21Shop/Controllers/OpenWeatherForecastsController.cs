using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto.OpenWeatherDtos;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.OpenWeather;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
	public class OpenWeatherForecastsController : Controller
	{
		private readonly IOpenWeatherServices _openWeatherServices;
		public OpenWeatherForecastsController
			(
				IOpenWeatherServices openWeatherServices
			)
		{
			_openWeatherServices = openWeatherServices;
		}

		public IActionResult Index()
		{
			OpenWeatherViewModel vm = new OpenWeatherViewModel();
			return View(vm);
		}

		[HttpPost]
		public IActionResult ShowWeather()
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("City", "OpenWeatherForecasts");
			}
			return View();
		}

		[HttpGet]
		public IActionResult city()
		{
			OpenWeatherResultDto dto = new OpenWeatherResultDto();

			_openWeatherServices.OpenWeatherDetail(dto);

			OpenWeatherViewModel vm = new OpenWeatherViewModel();

			//vm.city = dto.city;
			vm.temp = dto.temp;
			vm.feels_like = dto.feels_like;
			vm.humidity = dto.humidity;
			vm.pressure = dto.pressure;
			vm.wind_speed = dto.wind_speed;
			vm.main = dto.main;

			return View(vm);
		}
	}
}
