namespace WebApiSandbox.Services.Weather
{
    public class CityWeather
    {
        public CityWeather(string description, int celsius, int farenheit)
        {
            Description = description;
            this.celsius = celsius;
            this.farenheit = farenheit;
        }

        public string Description { get; set; }
        public int celsius { get; set; }
        public int farenheit { get; set; }
    }
}