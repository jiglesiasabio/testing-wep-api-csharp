using System;
using WebApiSandbox.Clients;

namespace WebApiSandbox.Services.Weather
{
    public class WeatherService: WeatherServiceInterface
    {
        private readonly WeatherClientInterface _weatherClient;

        public WeatherService(WeatherClientInterface weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public CityWeather getWeatherForCity(string cityName)
        {
            // We get the celsius value from a 3rd party API (simlulated)
            var celsius = _weatherClient.GetCelsiusTempForCity(cityName);
            
            // We calculate the Farenheit value
            var farenheit = (celsius * 9 / 5) + 32;
            
            // We assign a description to the temp value
            var description = String.Empty;
            
            switch (celsius)
            {
                case <= 10:
                    description = "Cold";
                    break;
                case <= 21:
                    description = "Fresh";
                    break;
                case <= 40:
                    description = "Hot";
                    break;
                default:
                    description = "Hell!";
                    break;
            }
            
            return new CityWeather(description, celsius, farenheit);
        }
    }
}