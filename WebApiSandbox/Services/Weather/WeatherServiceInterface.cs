namespace WebApiSandbox.Services.Weather
{
    public interface WeatherServiceInterface
    {
        public CityWeather getWeatherForCity(string cityName);
    }
}