using System;
using System.Web.Http;
using AquaTrack.Services;

namespace AquaTrack.Controllers
{
    [RoutePrefix("api/water-usage")]
    public class WaterUsageController : ApiController
    {
        private readonly WaterUsageService _service;

        public WaterUsageController(WaterUsageService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("current/{deviceId}")]
        public IHttpActionResult GetCurrentUsage(int deviceId)
        {
            var currentUsage = _service.GetCurrentUsage(deviceId);
            if (currentUsage == null)
                return NotFound();

            return Ok(currentUsage);
        }

        [HttpGet]
        [Route("history")]
        public IHttpActionResult GetHistory(int? deviceId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var history = _service.GetUsageHistory(deviceId, startDate, endDate);
                return Ok(history);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("average-usage")]
        public IHttpActionResult GetAverageUsage(int deviceId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var averageUsage = _service.GetAverageUsage(deviceId, startDate, endDate);
                return Ok(averageUsage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

