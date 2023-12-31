﻿using DigiteerTechnical.Data;
using DigiteerTechnical.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiteerTechnical.Controllers
{
    [ApiController]
    public class RainfallController : ControllerBase
    {
        [HttpGet("rainfall/id/{stationId}/readings")]
        public IActionResult GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            try
            {
                RainfallLocalReadings rainfallLocalReadings = new RainfallLocalReadings();

                var readings = rainfallLocalReadings.GenerateRainfallReadings(stationId, count);

                //error 400
                if (count < 1 || count > 100)
                {
                    return BadRequest(new ErrorResponse
                    {
                        Message = "Invalid request",
                        Detail = new List<ErrorDetail> { new ErrorDetail { PropertyName = "Test Details", Message = "Make sure count is within 1 to 100" } }
                    });
                }

                //error 404
                if (readings == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Message = "No readings found for the specified stationId",
                        Detail = new List<ErrorDetail> { new ErrorDetail { PropertyName = "Test Details", Message = "Station ID does not exist or format is invalid" } }
                    });
                }

                return Ok(new RainfallReadingResponse { Readings = readings });
            }
            catch (Exception ex)
            {
                //error 500
                return StatusCode(500, new ErrorResponse
                {
                    Message = "Internal server error: " + ex.Message,
                    Detail = new List<ErrorDetail> { new ErrorDetail { PropertyName = "Test Details", Message = "Contact developer" } }
                });
            }
        }

    }
}
