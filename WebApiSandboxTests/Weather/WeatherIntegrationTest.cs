using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using WebApiSandbox.Clients;
using WebApiSandbox.Services.Weather;

namespace WebApiSandboxTests.Weather
{
    public class ApiWebApplicationFactory : WebApplicationFactory<WebApiSandbox.Startup>
    {
    }

    public class WeatherIntegrationTest
    {
        private HttpClient _client;
        private ApiWebApplicationFactory _factory;
        private Mock<WeatherClient> _weatherClientInterfaceMock;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _weatherClientInterfaceMock = new Mock<WeatherClient>(MockBehavior.Strict);
            
            _factory = new ApiWebApplicationFactory();
            _client = _factory.WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        services.Add(new ServiceDescriptor(typeof(WeatherServiceInterface), new WeatherService(this._weatherClientInterfaceMock.Object)));
                    });
                })
                .CreateClient();
        }

        [Test]
        public async Task ItShouldTellTheWeatherForACity()
        {
            // GIVEN
            var celsius = 10;
            _weatherClientInterfaceMock.Setup(m => m.GetCelsiusTempForCity("madrid")).Returns(celsius);
            
            // WHEN
            var response = await _client.GetAsync("/weather/madrid");

            // THEN
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
            var actualResponseBody = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("{\"description\":\"Cold\",\"celsius\":10,\"farenheit\":50}", actualResponseBody);
        }
    }
}