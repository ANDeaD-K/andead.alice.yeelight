using andead.alice.yeelight.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace andead.alice.yeelight.Controllers
{
[   Route("api/[controller]")]
    public class YeelightController : Controller
    {

        [HttpPost("alice-webhook")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult AliceWebhook(AliceRequest request)
        {
            return Ok("This is test");
        }
    }
}