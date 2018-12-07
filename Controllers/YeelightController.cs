using andead.alice.yeelight.Models.Request;
using andead.alice.yeelight.Models.Response;
using andead.alice.yeelight.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace andead.alice.yeelight.Controllers
{
    [Route("api/[controller]")]
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
        // public IActionResult AliceWebhook([FromBody] AliceRequest request)
        public IActionResult AliceWebhook([FromBody] AliceRequest request)
        // public IActionResult AliceWebhook()
        {
            _logger.LogWarning(JsonConvert.SerializeObject(request));

            // string resp = "{\"response\": {\"text\": \"Здравствуйте\", \"end_session\": true}, \"session\": {\"session_id\": \"2eac4854\", \"message_id\": 4, \"user_id\": \"AC9WC3DF6FCE\"}, \"version\": \"1.0\"}";

            // AliceRequest aliceRequest = JsonConvert.DeserializeObject<AliceRequest>(request);

            AliceResponse response = new AliceResponse()
            {
                response = new Response()
                {
                    text = "This is test message",
                    end_session = true
                },
                session = new andead.alice.yeelight.Models.Response.Session()
                {
                    session_id = request.session.session_id,
                    message_id = request.session.message_id,
                    user_id = request.session.user_id
                },
                version = "1.0"
            };

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet("turn-on")]
        [ProducesResponseType(200)]
        public IActionResult TurnOn()
        {
            new YeelightManager().TurnOn();
            return Ok("Turn on");
        }

        [HttpGet("turn-off")]
        [ProducesResponseType(200)]
        public IActionResult TurnOff()
        {
            new YeelightManager().TurnOff();
            return Ok("Turn off");
        }
    }
}