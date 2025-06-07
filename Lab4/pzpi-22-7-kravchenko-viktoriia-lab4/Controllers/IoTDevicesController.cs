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

        public IoTDevicesController(IoTDeviceService service, WaterUsageService waterUsageService)
        {
            _service = service;
            _waterUsageService = waterUsageService;
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetDevices()
        {
            var devices = _service.GetAllDevices()
                                      .Select(d => new IoTDeviceDto
                                      {
                                          DeviceId = d.DeviceId,
                                          DeviceType = d.DeviceType,
                                          Status = d.Status
                                      })
                                      .ToList();

            return Ok(devices);
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult RegisterDevice(IoTDeviceDto deviceDto)
        {
            if (_service.GetAllDevices().Any(d => d.DeviceType == deviceDto.DeviceType))
                return BadRequest("Device type already exists.");

            var device = new IoTDevice
            {
                DeviceType = deviceDto.DeviceType,
                Status = deviceDto.Status
            };

            _service.AddDevice(device);
            return Ok(deviceDto);
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
        public IHttpActionResult CollectData(WaterUsageRequest data)
        {
            try
            {
                // Створюємо об'єкт WaterUsage на основі отриманих даних
                var waterUsage = new WaterUsage
                {
                    UsageValue = data.UsageValue,
                    DeviceId = data.DeviceId,
                    Timestamp = data.Timestamp
                };

                // Викликаємо сервіс для додавання запису
                _waterUsageService.AddUsageRecord(waterUsage, _service);
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

