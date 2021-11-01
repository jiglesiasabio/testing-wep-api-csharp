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
            var celsius = _weatherClient.GetCelsiusTempForCity(cityName);
            
            return new CityWeather("Fresh", celsius, 32);
        }
        
        // TODO male the 'description' field dynamic
        // TODO make the 'farenheit' calculated based on the celsius value (X°C × 9/5) + 32 = 32°F

    }
}