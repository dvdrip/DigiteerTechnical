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
            try
            {
                var readings = GenerateRainfallReadings(stationId, count);

                return Ok(new RainfallReadingResponse { Readings = readings });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ErrorResponse
                {
                    Message = "Internal server error",
                    Detail = null
                });
            }
        }

        //Sample readings
        private List<RainfallReading> GenerateRainfallReadings(string stationId, int count)
        {
            var readings = new List<RainfallReading>();

            for (int i = 0; i < count; i++)
            {
                var reading = new RainfallReading
                {
                    DateMeasured = DateTime.UtcNow.AddDays(-i),
                    AmountMeasured = (decimal)new Random().NextDouble() * 100
                };

                readings.Add(reading);
            }

            return readings;
        }
    }
}
