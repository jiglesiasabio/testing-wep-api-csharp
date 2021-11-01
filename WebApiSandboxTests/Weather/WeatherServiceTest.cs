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
        
        // Let's verify "description" field values...
        
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
        
        // Let's try to do it in a better and more exhaustive way
        // Using TestCases we can test many similar cases without repeating our testing code!!
        // So now you can go up in this test file and delete some tests!! 🔥
        
        [TestCase(0, "Cold", TestName = "0 Celsius is Cold")]
        [TestCase(9, "Cold", TestName = "9 Celsius is Cold")]
        [TestCase(10, "Cold", TestName = "10 Celsius is Cold")]
        
        [TestCase(11, "Fresh", TestName = "11 Celsius is Fresh")]
        [TestCase(15, "Fresh", TestName = "15 Celsius is Fresh")]
        [TestCase(21, "Fresh", TestName = "11 Celsius is Fresh")]
        
        [TestCase(22, "Hot", TestName = "21 Celsius is Hot")]
        [TestCase(30, "Hot", TestName = "30 Celsius is Hot")]
        [TestCase(40, "Hot", TestName = "40 Celsius is Hot")]
        
        [TestCase(41, "Hell!", TestName = "41 Celsius is Hell!")]
        public void ItShouldReturnTheExpectedDescriptionForGivenCelsiusTemperature(int givenCelsius, string expectedDescription)
        {
            // GIVEN
            var city = "madrid";

            _weatherClientInterfaceMock
                .Setup(m => m.GetCelsiusTempForCity(city))
                .Returns(givenCelsius);
            
            // WHEN
            CityWeather returnedValue = _sut.getWeatherForCity(city);

            // THEN
            Assert.AreEqual(expectedDescription,returnedValue.Description);
        }
    }
}