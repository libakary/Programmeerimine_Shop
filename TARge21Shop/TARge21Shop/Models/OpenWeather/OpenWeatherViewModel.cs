namespace TARge21Shop.Models.OpenWeather
{
	public class OpenWeatherViewModel
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
