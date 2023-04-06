namespace TARge21Shop.Models.OpenWeather
{
	public class CityResultViewModel
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
