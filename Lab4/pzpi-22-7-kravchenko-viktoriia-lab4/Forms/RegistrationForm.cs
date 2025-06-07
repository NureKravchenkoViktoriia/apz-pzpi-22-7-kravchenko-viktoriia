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

namespace AquaTrack
{
    public partial class RegistrationForm : Form
    {
        private const string ApiUrl = "http://localhost:5000/api/users/register";
        
        // Словники для перекладу
        private Dictionary<string, string> ukrainianTexts = new Dictionary<string, string>
        {
            { "labelRegister", "Реєстрація" },
            { "labelName", "Ім'я користувача" },
            { "labelEmail", "Пошта" },
            { "labelPass", "Пароль" },
            { "RegisterButton", "Зареєструватись" },
            { "buttonReturn", "Повернутись" },
            { "MessageFillFields", "Всі поля мають бути заповнені!" },
            { "MessageUserRegistered", "Користувача успішно зареєстровано." },
            { "MessageError", "Помилка: " },
            { "BtnChangeLanguage", "Укр/Англ" },
            
        };

        private Dictionary<string, string> englishTexts = new Dictionary<string, string>
        {
            { "labelRegister", "Register" },
            { "labelName", "Username" },
            { "labelEmail", "Email" },
            { "labelPass", "Password" },
            { "RegisterButton", "Register" },
            { "buttonReturn", "Return" },
            { "MessageFillFields", "All fields must be filled!" },
            { "MessageUserRegistered", "User successfully registered." },
            { "MessageError", "Error: " },
            { "BtnChangeLanguage", "UA/EN" },
        };
        private Dictionary<string, string> currentLanguage;

        public RegistrationForm()
        {
            InitializeComponent();
            currentLanguage = ukrainianTexts; // За замовчуванням українська мова
            UpdateUI();
        }

        // Оновлюємо інтерфейс згідно з вибраною мовою
        private void UpdateUI()
        {
            labelRegister.Text = currentLanguage["labelRegister"];
            labelName.Text = currentLanguage["labelName"];
            labelEmail.Text = currentLanguage["labelEmail"];
            labelPass.Text = currentLanguage["labelPass"];
            RegisterButton.Text = currentLanguage["RegisterButton"];
            buttonReturn.Text = currentLanguage["buttonReturn"];
            BtnChangeLanguage.Text = currentLanguage["BtnChangeLanguage"];
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;

            // Перевірка на заповненість полів
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(currentLanguage["MessageFillFields"]);
                return;
            }

            var newUser = new
            {
                Username = username,
                Email = email,
                PasswordHash = password,
                Role = "User" // За замовчуванням роль "User"
            };

            var json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(ApiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(currentLanguage["MessageUserRegistered"]);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(currentLanguage["MessageError"] + errorMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(currentLanguage["MessageError"] + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            this.Hide();
            authorizationForm.Show();
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
    }
}
    

