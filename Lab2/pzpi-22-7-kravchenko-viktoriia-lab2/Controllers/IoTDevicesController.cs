using System;
using System.Linq;
using System.Web.Http;
using AquaTrack.Data.Models;
using AquaTrack.Services;

namespace AquaTrack.Controllers
{
    [RoutePrefix("api/iot-devices")]
    public class IoTDevicesController : ApiController
    {
        private readonly IoTDeviceService _service;
        private readonly WaterUsageService _waterUsageService;

        public IoTDevicesController(IoTDeviceService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetDevices()
        {
            var devices = _service.GetAllDevices();
            return Ok(devices);
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult RegisterDevice(IoTDevice device)
        {
            if (_service.GetAllDevices().Any(d => d.DeviceType == device.DeviceType))
                return BadRequest("Device type already exists.");

            _service.AddDevice(device);
            return Ok(device);
        }

        [HttpDelete]
        [Route("delete/{deviceId}")]
        public IHttpActionResult DeleteDevice(int deviceId)
        {
            var device = _service.GetDeviceById(deviceId);
            if (device == null) return NotFound();

            _service.DeleteDevice(deviceId);
            return Ok();
        }

        [HttpPost]
        [Route("collect-data")]
        public IHttpActionResult CollectData(WaterUsage data)
        {
            try
            {
                _waterUsageService.AddUsageRecord(data, _service);
                return Ok("Data collected successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("list-by-status")]
        public IHttpActionResult GetDevicesByStatus(string status)
        {
            var devices = _service.GetAllDevices()
                                  .Where(d => d.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                                  .ToList();

            if (!devices.Any())
                return NotFound();

            return Ok(devices);
        }

    }
}

