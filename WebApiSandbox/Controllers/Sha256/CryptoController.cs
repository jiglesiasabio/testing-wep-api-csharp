using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiSandbox.Controllers.Sha256;
using WebApiSandbox.Services;

namespace WebApiSandbox.Controllers.crypto.Sha256
{
    [ApiController]
    [Route("crypto")]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly Sha256HashingServiceInterface _sha256HashingService;

        public CryptoController(ILogger<CryptoController> logger, Sha256HashingServiceInterface sha256HashingService)
        {
            _logger = logger;
            _sha256HashingService = sha256HashingService;
        }

        [HttpPost("sha256")]
        public IActionResult Post(HashRequest request)
        {
            try
            {
                var hash = _sha256HashingService.Hash(request.ClearText);
                return Ok(new HashResponse(hash));
            }
            catch (ArgumentException exception)
            {
                var apiError = new ApiError("400", exception.Message);
                return BadRequest(apiError);
            }
        }
    }
}