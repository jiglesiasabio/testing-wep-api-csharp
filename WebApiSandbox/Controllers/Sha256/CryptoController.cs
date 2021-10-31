using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiSandbox.Services;

namespace WebApiSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly Sha256HashingServiceInterface _sha256HashingService;

        public CryptoController(ILogger<CryptoController> logger, Sha256HashingServiceInterface sha256HashingService)
        {
            _logger = logger;
            _sha256HashingService = sha256HashingService;
        }

        [HttpPost]
        public HashResponse Post(HashRequest request)
        {
            var hash = this._sha256HashingService.Hash(request.ClearText);
            return new HashResponse(hash);
        }
    }
}