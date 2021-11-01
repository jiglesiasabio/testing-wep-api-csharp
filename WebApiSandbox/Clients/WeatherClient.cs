using System;

namespace WebApiSandbox.Clients
{
    public class WeatherClient: WeatherClientInterface
    {
        public int GetCelsiusTempForCity(string city)
        {
            /*
             * A note about this client, for the purpose of this demo this client
             * just generates a random celsius value for any given city name
             * but please imagine this was a client calling a 3rd party API...
             *
             * You can imagine we do not want to call a real API every time we run our tests
             *
             * So this client will be mocked in our tests...
             *
             * This will also allow us to control an otherwise unpredictable response by setting mock expectations.
             */
            Random rnd = new Random();
            return rnd.Next(52);;
        }
    }
}