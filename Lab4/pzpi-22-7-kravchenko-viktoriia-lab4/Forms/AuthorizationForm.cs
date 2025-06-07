using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AquaTrack
{
    public partial class AuthorizationForm : Form
    {
        private Dictionary<string, string> ukrainianTexts = new Dictionary<string, string>
    {
        { "LoginButtonText", "Увійти" },
        { "EmailLabelText", "Електронна пошта:" },
        { "PasswordLabelText", "Пароль:" },
        { "MessageFillFields", "Заповніть усі поля!" },
        { "MessageError", "Невірний логін або пароль." },
        { "MessageWelcome", "Ласкаво просимо, " },
        { "lblTitle", "Авторизація" }, 
        { "labelRegister", "Реєстрація" },
        { "BtnChangeLanguage", "Укр/Англ" },
    };

        private Dictionary<string, string> englishTexts = new Dictionary<string, string>
    {
        { "LoginButtonText", "Login" },
        { "EmailLabelText", "Email:" },
        { "PasswordLabelText", "Password:" },
        { "MessageFillFields", "Fill in all fields!" },
        { "MessageError", "Incorrect email or password." },
        { "MessageWelcome", "Welcome, " },
        { "lblTitle", "Authorization" }, 
        { "labelRegister", "Register" },
        { "BtnChangeLanguage", "UA/EN" },
    };

        private Dictionary<string, string> currentLanguage;

        public AuthorizationForm()
        {
            InitializeComponent();
            passwordtxt.PasswordChar = '*';
            currentLanguage = ukrainianTexts; // За замовчуванням українська мова
            UpdateUI();
        }

        private void UpdateUI()
        {
            BtnLogin.Text = currentLanguage["LoginButtonText"];
            lblEmail2.Text = currentLanguage["EmailLabelText"];
            labelPassword.Text = currentLanguage["PasswordLabelText"];
            lblTitle.Text = currentLanguage["lblTitle"]; 
            labelRegister.Text = currentLanguage["labelRegister"];
            BtnChangeLanguage.Text = currentLanguage["BtnChangeLanguage"];
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public class UserResponse
        {
            public string Username { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = emailtxt.Text;
            string password = passwordtxt.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(currentLanguage["MessageFillFields"], "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var response = await AuthenticateUser(email, password);
                if (response != null)
                {
                    MessageBox.Show(currentLanguage["MessageWelcome"] + response.Username, "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Перевірка ролі користувача
                    if (response.Role == "Admin")
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else if (response.Role == "User")
                    {
                        UserForm userForm = new UserForm();
                        userForm.Show();
                    }
                    else
                    {
                        MessageBox.Show(currentLanguage["MessageError"], "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(currentLanguage["MessageError"], "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<UserResponse> AuthenticateUser(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/"); 

                // Створення URL з параметрами
                var url = $"api/users/login?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";

                // Виконання POST запиту
                var response = await client.PostAsync(url, null); // Тіло запиту не потрібне, бо параметри передаються через query

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(responseBody);

                    return userResponse;
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Помилка: {errorResponse}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private void BtnChangeLanguage_Click(object sender, EventArgs e)
        {
            // Перемикаємо мову
            if (currentLanguage == ukrainianTexts)
                currentLanguage = englishTexts;
            else
                currentLanguage = ukrainianTexts;

            UpdateUI();
        }

        private void labelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.Show();
        }
    }
}

