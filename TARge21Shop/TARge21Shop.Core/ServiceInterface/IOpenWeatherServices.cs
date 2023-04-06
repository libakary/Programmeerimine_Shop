using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.OpenWeatherDtos;

namespace TARge21Shop.Core.ServiceInterface
{
	public interface IOpenWeatherServices
	{
		Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto);

	}
}
