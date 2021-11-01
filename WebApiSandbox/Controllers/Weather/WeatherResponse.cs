namespace WebApiSandbox.Controllers.crypto.Sha256
{
    public class WeatherResponse
    {
        public WeatherResponse(string description, int celsiusTemperature)
        {
            this.Description = description;
            this.CelsiusTemperature = celsiusTemperature;
        }

        public string Description { get; set; }
        public int CelsiusTemperature { get; set; }
    }
}