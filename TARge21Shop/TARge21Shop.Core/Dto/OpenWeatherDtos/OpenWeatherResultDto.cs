﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto.OpenWeatherDtos
{
	public class OpenWeatherResultDto
	{
		public string City { get; set; }
		public double Temp { get; set; }
		public double Feels_like { get; set; }
		public int Humidity { get; set; }
		public int Pressure { get; set; }
		public double Speed { get; set; }
		public string Description { get; set; }
		public string Main { get; set; }
	}
}
