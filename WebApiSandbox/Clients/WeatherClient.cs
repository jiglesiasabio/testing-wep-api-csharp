using System;

namespace WebApiSandbox.Clients
{
    public class WeatherClient: WeatherClientInterface
    {
        public int GetCelsiusTempForCity(string city)
        {
            Random rnd = new Random();
            return rnd.Next(52);;
        }
    }
}