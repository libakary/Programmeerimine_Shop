using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto.OpenWeatherDtos;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.OpenWeather;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
	public class OpenWeathersController : Controller
	{
		private readonly IOpenWeatherServices _openWeatherServices;
		public OpenWeathersController
			(
				IOpenWeatherServices openWeatherServices
			)
		{
			_openWeatherServices = openWeatherServices;
		}

		public IActionResult Index()
		{
			SearchCityViewModel vm = new SearchCityViewModel();
			return View(vm);
		}

		[HttpPost]
		public IActionResult SearchCity(SearchCityViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("City", "OpenWeathers", new {city = model.CityName});
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult City(string city)
		{
			OpenWeatherResultDto dto = new OpenWeatherResultDto();
			CityResultViewModel vm = new CityResultViewModel();

			dto.City = city;

			_openWeatherServices.WeatherDetail(dto);

			vm.City = city;
			vm.Temp = dto.Temp;
			vm.Feels_like = dto.Feels_like;
			vm.Humidity = dto.Humidity;
			vm.Pressure = dto.Pressure;
			vm.Speed = dto.Speed;
			vm.Description = dto.Description;
			vm.Main = dto.Main;
			

			//CityResultViewModel vm = new();
			// nüüd toimub mappimine

			return View(vm);
		}
	}
}
