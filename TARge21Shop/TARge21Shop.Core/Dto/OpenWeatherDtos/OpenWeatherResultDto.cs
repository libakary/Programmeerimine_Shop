using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.OpenWeatherDtos
{
	public class OpenWeatherResultDto
	{
		public string city { get; set; }
		public double temp { get; set; }
		public double feels_like { get; set; }
		public int humidity { get; set; }
		public int pressure { get; set; }
		public double wind_speed { get; set; }
		public string main { get; set; }
	}
}
