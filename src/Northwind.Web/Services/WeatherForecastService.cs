using System;
using Northwind.Web.Models;

namespace Northwind.Web.Services
{
	public interface IWeatherForecastService 
	{
		WeatherForecast ForecastFor(DateTime dateTime);

		WeatherForecast ForecastForTemperature(DateTime dateTime, double temperature);

		string SummaryFor(double temperature);
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
				var temperatureC = rng.Next(-20, 55) * 1.0;
				return new WeatherForecast
				{

					Date = dateTime,
					TemperatureC = temperatureC,
					Summary = SummaryFor(temperatureC)

				};
			}
			
		}

		public WeatherForecast ForecastForTemperature(DateTime dateTime, double temperature)
        {
			if (dateChecker(dateTime))
            {
				throw new ArgumentException("Cannot get a forecast for the past");
            } else {

				double temperatureC = ((temperature - 32.0) * (5.0 / 9.0)) * 1.0;
				return new WeatherForecast
				{
					Date = dateTime,
					TemperatureC = temperatureC,
					Summary = SummaryFor(temperatureC)
				};
            }
        }
		public string SummaryFor(double temperature)
		{
			int tempIndex = 0;
			while (temperature < 54.8)
            {
				temperature = temperature + 8.3333;
				tempIndex = tempIndex + 1;
			}

			return Summaries[9-tempIndex];

		}

		private bool dateChecker(DateTime dateTime)
        {
			return (DateTime.Today - dateTime.Date == TimeSpan.FromDays(1));

		}
	}

}