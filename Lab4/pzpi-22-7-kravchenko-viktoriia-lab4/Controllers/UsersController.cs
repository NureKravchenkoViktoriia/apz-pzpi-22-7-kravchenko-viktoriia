using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AquaTrack.Data.Models;
using AquaTrack.Services;

namespace AquaTrack.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(User user)
        {
            try
            {
                _service.RegisterUser(user);
                return Ok("Користувач успішно зареєстрований.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromUri] string email, [FromUri] string password)
        {
            try
            {
                var user = _service.Authenticate(email, password);
                return Ok(new
                {
                    Message = "Успішна авторизація",
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.Role
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(); // Неправильний логін або пароль
            }
        }


        [HttpPut]
        [Route("update-profile")]
        public IHttpActionResult UpdateProfile(User updatedUser)
        {
            var user = _service.GetUserById(updatedUser.UserId);
            if (user == null) return NotFound();

            updatedUser.UserId = user.UserId;
            _service.UpdateUser(updatedUser);
            return Ok(updatedUser);
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetUsers(string role = null)
        {
            var currentUserRole = "Admin"; // Перевірка ролі
            if (currentUserRole != "Admin")
            {
                return Content(HttpStatusCode.Forbidden, "Доступ дозволений тільки адміністраторам.");
            }

            var users = _service.GetAllUsers();
            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(users);
        }

        [HttpPut]
        [Route("update-role")]
        public IHttpActionResult UpdateRole([FromUri] int userId, [FromUri] string newRole)
        {
            try
            {
                var user = _service.GetUserById(userId);
                if (user == null)
                {
                    return NotFound(); // Користувача не знайдено
                }

                // Перевірка нової ролі
                var validRoles = new List<string> { "User", "Admin" };
                if (!validRoles.Contains(newRole))
                {
                    return BadRequest("Невірна роль.");
                }

                // Оновлення ролі
                user.Role = newRole;
                _service.UpdateUser(user);

                return Ok($"Роль користувача з ID {userId} успішно змінено на {newRole}.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Помилка при оновленні ролі: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            var currentUserRole = "Admin"; 

            if (currentUserRole != "Admin")
            {
                return Content(HttpStatusCode.Forbidden, "Доступ дозволений тільки адміністраторам.");
            }

            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                _service.DeleteUser(id);
                return Ok($"Користувача з ID {id} успішно видалено.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Помилка видалення: {ex.Message}");
            }
        }


    }
}

