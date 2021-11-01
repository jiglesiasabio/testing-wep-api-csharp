using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiSandbox.Controllers.Sha256;
using WebApiSandbox.Services;
using WebApiSandbox.Services.Weather;

namespace WebApiSandbox.Controllers.crypto.Sha256
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly WeatherServiceInterface _weatherService;

        public WeatherController(ILogger<CryptoController> logger, WeatherServiceInterface weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("madrid")]
        public IActionResult Get()
        {
            return Ok(_weatherService.getWeatherForCity("madrid"));
        }
    }
}