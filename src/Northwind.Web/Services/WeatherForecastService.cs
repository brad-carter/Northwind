using System;
using Northwind.Web.Models;

namespace Northwind.Web.Services
{
	public interface IWeatherForecastService 
	{
		WeatherForecast ForecastFor(DateTime dateTime);

		WeatherForecast ForecastForTemperature(DateTime dateTime, int temperature);

		string SummaryFor(int temperature);
	}


	public class WeatherForecastService : IWeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherForecast ForecastFor(DateTime dateTime)
		{
			if (dateChecker(dateTime))
            {
				throw new ArgumentException("Cannot get a forecast for the past");
            } else {
				var rng = new Random();
				var temperatureC = rng.Next(-20, 55);
				int temperatureF = (int) (temperatureC * (9 / 5) + 32);
				return new WeatherForecast
				{

					Date = dateTime,
					TemperatureC = temperatureF,
					Summary = SummaryFor(temperatureF)

				};
			}
			
		}

		public WeatherForecast ForecastForTemperature(DateTime dateTime, int temperature)
        {
			if (dateChecker(dateTime))
            {
				throw new ArgumentException("Cannot get a forecast for the past");
            } else {
				return new WeatherForecast
				{
					Date = dateTime,
					TemperatureC = temperature,
					Summary = SummaryFor(temperature)
				};
            }
        }
		public string SummaryFor(int temperature)
		{
			int tempIndex = 0;
			while (temperature < 140)
            {
				tempIndex++;
				temperature = temperature + 14;
            }

			return Summaries[9-tempIndex];

		}

		private bool dateChecker(DateTime dateTime)
        {
			return (DateTime.Today - dateTime.Date == TimeSpan.FromDays(1));

		}
	}

}