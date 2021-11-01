namespace WebApiSandbox.Services.Weather
{
    public class CityWeather
    {
        public CityWeather(string description, int celsius, int farenheit)
        {
            Description = description;
            this.Celsius = celsius;
            this.Farenheit = farenheit;
        }

        public string Description { get; set; }
        public int Celsius { get; set; }
        public int Farenheit { get; set; }
    }
}