using andead.alice.yeelight.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace andead.alice.yeelight.Controllers
{
[   Route("api/[controller]")]
    public class YeelightController : Controller
    {
        private readonly ILogger _logger;

        public YeelightController(ILogger<YeelightController> logger)
        {
            _logger = logger;
        }

        [HttpGet("alice-webhook")]
        [HttpPost("alice-webhook")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult AliceWebhook(AliceRequest request)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(request));

            return Ok("This is test");
        }
    }
}