using Moq;
using NUnit.Framework;
using WebApiSandbox.Clients;
using WebApiSandbox.Services;
using WebApiSandbox.Services.Weather;

namespace WebApiSandboxTests.Weather
{
    public class WeatherServiceTest
    {
        private WeatherService _sut;

        private Mock<WeatherClientInterface> _weatherClientInterfaceMock;
        
        [SetUp]
        public void Setup()
        {
            _weatherClientInterfaceMock = new Mock<WeatherClientInterface>();
            
            _sut = new WeatherService(_weatherClientInterfaceMock.Object);
        }

        [Test]
        public void ItShouldReturnACityWeatherObject()
        {
            // GIVEN
            var city = "madrid";
            var celsiusInMadrid = 42;

            _weatherClientInterfaceMock
                .Setup(m => m.GetCelsiusTempForCity(city))
                .Returns(celsiusInMadrid);
            
            // WHEN
            CityWeather returnedValue = _sut.getWeatherForCity(city);

            // THEN
            Assert.AreEqual(celsiusInMadrid,returnedValue.celsius);
        }
        
        // ItShouldReturnTheRightFarenheitTemperature
        
        // It should say cold if celsius are below 10
        
        // It should say fresh if celsius are between 10 and 21
        
        // It should say hot if celsius are between 21 and 40
        
        // It should say hell! if celsius are above 40
        
        // But Maybe this should be on a separated service??? refactor here???
    }
}