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
        
        // ItShouldReturnTheRightFarenheitTemperature
        [Test]
        public void ItShouldReturnTheRightCelsiusFarenheitTemperaturePair()
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
            Assert.AreEqual(celsiusInMadrid,returnedValue.Celsius);
            
            var expectedFarenheit = 107;
            Assert.AreEqual(expectedFarenheit,returnedValue.Farenheit);
        }
        
        // It should say cold if celsius are below 10
        [Test]
        public void ItShouldReturnDescriptionColdIfCelsiusAreBelow10()
        {
            // GIVEN
            var city = "madrid";
            var celsiusInMadrid = 9;

            _weatherClientInterfaceMock
                .Setup(m => m.GetCelsiusTempForCity(city))
                .Returns(celsiusInMadrid);
            
            // WHEN
            CityWeather returnedValue = _sut.getWeatherForCity(city);

            // THEN
            Assert.AreEqual("Cold",returnedValue.Description);
        }
        
        [Test]
        public void ItShouldReturnDescriptionFreshIfCelsiusAreBetween10And21()
        {
            // GIVEN
            var city = "madrid";
            var celsiusInMadrid = 12;

            _weatherClientInterfaceMock
                .Setup(m => m.GetCelsiusTempForCity(city))
                .Returns(celsiusInMadrid);
            
            // WHEN
            CityWeather returnedValue = _sut.getWeatherForCity(city);

            // THEN
            Assert.AreEqual("Fresh",returnedValue.Description);
        }
        
        [Test]
        public void ItShouldReturnDescriptionHotIfCelsiusAreBetween21And40()
        {
            // GIVEN
            var city = "madrid";
            var celsiusInMadrid = 30;

            _weatherClientInterfaceMock
                .Setup(m => m.GetCelsiusTempForCity(city))
                .Returns(celsiusInMadrid);
            
            // WHEN
            CityWeather returnedValue = _sut.getWeatherForCity(city);

            // THEN
            Assert.AreEqual("Hot",returnedValue.Description);
        }
        
        [Test]
        public void ItShouldReturnDescriptionHellIfCelsiusAreAbove40()
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
            Assert.AreEqual("Hell!",returnedValue.Description);
        }
    }
}