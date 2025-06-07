using System;
using System.Linq;
using System.Web.Http;
using AquaTrack.Data.Models;
using AquaTrack.Services;

namespace AquaTrack.Controllers
{
    [RoutePrefix("api/limits")]
    public class LimitsController : ApiController
    {
        private readonly LimitService _service;

        public LimitsController(LimitService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateLimit(CreateLimitRequest request)
        {
            // Валідація
            if (request.LimitValue <= 0)
            {
                return BadRequest("Значення ліміту повинно бути більшим за 0.");
            }

            if (request.StartDate >= request.EndDate)
            {
                return BadRequest("Дата початку повинна бути меншою за дату закінчення.");
            }

            var limit = new Limit
            {
                LimitValue = request.LimitValue,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                UserId = request.UserId,
                DeviceId = request.DeviceId
            };

            try
            {
                _service.CreateLimit(limit);
                return Ok(limit);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("update/{limitId}")]
        public IHttpActionResult UpdateLimit(int limitId, Limit updatedLimit)
        {
            var limit = _service.GetLimitById(limitId);
            if (limit == null) return NotFound();

            // Перевірка на коректність дат
            if (updatedLimit.StartDate > updatedLimit.EndDate)
            {
                return BadRequest("Дата завершення повинна бути після дати початку.");
            }

            updatedLimit.LimitId = limitId; // Встановлюємо ідентифікатор ліміту
            _service.UpdateLimit(updatedLimit); // Оновлення ліміту
            return Ok(updatedLimit); // Повертаємо оновлений ліміт
        }

        [HttpDelete]
        [Route("delete/{limitId}")]
        public IHttpActionResult DeleteLimit(int limitId)
        {
            try
            {
                var limit = _service.GetLimitById(limitId);
                if (limit == null) return NotFound();

                _service.DeleteLimit(limitId);  // Викликається метод видалення ліміту
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);  // Обробка помилки, якщо ліміт не можна видалити
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);  // Інші помилки
            }
        }


        [HttpGet]
        [Route("check-exceeded/{limitId}")]
        public IHttpActionResult CheckLimitExceeded(int limitId)
        {
            try
            {
                var isExceeded = _service.IsLimitExceeded(limitId);
                return Ok(new { LimitExceeded = isExceeded });
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
        [Route("progress/{limitId}")]
        public IHttpActionResult GetLimitProgress(int limitId)
        {
            try
            {
                var progress = _service.GetLimitProgress(limitId);
                return Ok(new { Progress = progress });
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
        [Route("list")]
        public IHttpActionResult GetLimits()
        {
            var limits = _service.GetAllLimits();
            return Ok(limits);
        }


    }
}

