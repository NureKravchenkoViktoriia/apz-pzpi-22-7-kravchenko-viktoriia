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
        public IHttpActionResult CreateLimit(Limit limit)
        {
            // Валідація
            if (limit.LimitValue <= 0)
            {
                return BadRequest("Значення ліміту повинно бути більшим за 0.");
            }

            if (limit.StartDate >= limit.EndDate)
            {
                return BadRequest("Дата початку повинна бути менша за дату закінчення.");
            }

            var existingLimit = _service.GetAllLimits().FirstOrDefault(l =>
                (l.UserId == limit.UserId || l.DeviceId == limit.DeviceId) &&
                (l.StartDate < limit.EndDate && l.EndDate > limit.StartDate));  // Перевірка на перекриття ліміту
            if (existingLimit != null)
            {
                return BadRequest("Існує ліміт, який перекривається з цим.");
            }

            // Збереження ліміту в базу даних
            _service.CreateLimit(limit);
            return Ok(limit);
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

