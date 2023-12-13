using DigiteerTechnical.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiteerTechnical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        [HttpGet("raifall/id/{stationId}/readings")]
        public IActionResult GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            return Ok(new RainfallReadingResponse { Readings = new List<RainfallReading>() });
        }
    }
}
