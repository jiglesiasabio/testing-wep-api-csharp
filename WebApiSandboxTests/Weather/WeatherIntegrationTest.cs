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
                        // Here we setup the service with a mocked replica we can control from our test
                        services.Add(new ServiceDescriptor(typeof(WeatherServiceInterface), new WeatherService(this._weatherClientInterfaceMock.Object)));
                    });
                })
                .CreateClient();
        }

        /*
         * In this integration test we want to test all the components of the application but mocking the WeatherClient
         * because we do not want to call any third party when running our tests.
         * 
         * Also we want to have full control of what the client is returning so we know what to expect the controller to return.
         *
         * What we are doing:
         * 
         * 1. We mock the client
         * 2. We setup an expectation for the mock so we can control what temperature it will return
         * 3. We assert that the json response has been built correctly for the given input (coming from the service)
         *
         * This way we are testing:
         * 
         * a. The controller interface.
         * b. That the controller and the WeatherService play well together.
         * c. That the WeatherService and the WeatherClient play well together.
         */
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