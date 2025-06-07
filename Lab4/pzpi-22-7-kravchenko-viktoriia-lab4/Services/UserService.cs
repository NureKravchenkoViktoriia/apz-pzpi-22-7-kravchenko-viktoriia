using System;
using System.Collections.Generic;
using System.Linq;
using AquaTrack.Data.Models;
using AquaTrack.Repositories;
using BCrypt.Net;

namespace AquaTrack.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers(string role = null)
        {
            var users = _repository.GetAll();
            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
            }
            return users;
        }


        public User GetUserById(int id)
        {
            return _repository.GetById(id);
        }

        public void RegisterUser(User user)
        {
            // Перевірка, чи існує користувач із таким email
            if (_repository.GetAll().Any(u => u.Email == user.Email))
            {
                throw new Exception("Користувач із таким email вже існує.");
            }

            // Хешування пароля
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            // Призначення ролі за замовчуванням
            user.Role = "User";

            // Додавання користувача до бази
            _repository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }

        public void UpdateUserRole(int userId, string newRole)
        {
            var user = GetUserById(userId);
            if (user == null)
            {
                throw new Exception("Користувача не знайдено.");
            }

            user.Role = newRole;
            UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("Користувача з таким ID не знайдено.");
            }

            _repository.Delete(id);
        }


        public User Authenticate(string email, string password)
        {
            // Пошук користувача за email
            var user = _repository.GetAll().FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("Користувача з таким email не знайдено.");
            }

            // Перевірка хешованого пароля
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Невірний пароль.");
            }

            return user;
        }
    }
}
