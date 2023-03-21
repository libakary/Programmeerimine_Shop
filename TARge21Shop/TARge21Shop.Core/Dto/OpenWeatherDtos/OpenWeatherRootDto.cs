using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.WeatherDtos;

namespace TARge21Shop.Core.Dto.OpenWeatherDtos
{
	public class OpenWeatherRootDto
	{
		public OpenWeatherMainDto OpenWeatherMain { get; set; }
		public HeadlineDto Headline { get; set; }
		public List<DailyForecastsDto> DailyForecasts { get; set; }
	}
}
