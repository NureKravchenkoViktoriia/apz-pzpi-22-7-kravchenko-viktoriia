using AquaTrack.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AquaTrack
{
    public partial class AdminForm : Form
    {
        private string currentLanguage = "uk";
        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
            LoadDevices();
            SetLanguage(currentLanguage);
        }

        // Метод для зміни мови
        private void SetLanguage(string language)
        {
            if (language == "uk")
            {
                gbUsers.Text = "Керування користувачами";
                btnDeleteUser.Text = "Видалити користувача";
                btnMakeAdmin.Text = "Змінити роль";
                btnRefreshUsers.Text = "Оновити список";
                gbBackup.Text = "Резервне копіювання";
                btnCreateBackup.Text = "Створити резервну копію";
                labelnumber.Text = "Номер";
                labelrole.Text = "Роль";
                gbDevices.Text = "Керування ІоТ-девайсами";
                btnDeleteDevice.Text = "Видалити пристрій";
                btnAddDevice.Text = "Додати пристрій";
                btnRefreshDevices.Text = "Оновити список";
                labeltype.Text = "Тип пристрою:";
                labelstatus.Text = "Статус пристрою:";
                BtnChangeLanguage.Text = "Укр/Англ";
            }
            else if (language == "en")
            {
                gbUsers.Text = "User Management";
                btnDeleteUser.Text = "Delete User";
                btnMakeAdmin.Text = "Change Role";
                btnRefreshUsers.Text = "Refresh List";
                gbBackup.Text = "Backup";
                btnCreateBackup.Text = "Create Backup";
                labelnumber.Text = "Number";
                labelrole.Text = "Role";
                gbDevices.Text = "IoT Devices Management";
                btnDeleteDevice.Text = "Delete Device";
                btnAddDevice.Text = "Add Device";
                btnRefreshDevices.Text = "Refresh List";
                labeltype.Text = "Device Type:";
                labelstatus.Text = "Device Status:";
                BtnChangeLanguage.Text = "UA/EN";
            }
        }

        private async void LoadUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                var response = await client.GetAsync("api/users/list");

                if (response.IsSuccessStatusCode)
                {
                    var users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
                    dgvUsers.DataSource = users;
                }
                else
                {
                    MessageBox.Show("Помилка завантаження списку користувачів.");
                }
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");
                    var response = await client.DeleteAsync($"api/users/delete/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Користувача успішно видалено.");
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Помилка видалення користувача.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть користувача.");
            }
        }

        private async void btnMakeAdmin_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtUserId.Text, out int userId) && !string.IsNullOrEmpty(txtUserRole.Text))
            {
                string newRole = txtUserRole.Text.Trim();

                // Перевірка, чи роль є допустимою (наприклад, 'Admin' або 'User')
                if (newRole != "Admin" && newRole != "User")
                {
                    MessageBox.Show("Роль повинна бути або 'Admin', або 'User'.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");

                    // Формуємо запит для оновлення ролі, передаючи параметри через URL
                    var response = await client.PutAsync($"api/users/update-role?userId={userId}&newRole={newRole}", null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Роль успішно змінено.");
                        LoadUsers(); // Оновлюємо список користувачів
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Помилка зміни ролі: {errorMessage}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні дані. Перевірте ID користувача та роль.");
            }
        }

        private async void LoadDevices()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                var response = await client.GetAsync("api/iot-devices/list");

                if (response.IsSuccessStatusCode)
                {
                    var devices = JsonConvert.DeserializeObject<List<IoTDevice>>(await response.Content.ReadAsStringAsync());
                    dgvDevices.DataSource = devices;
                }
                else
                {
                    MessageBox.Show("Помилка завантаження списку пристроїв.");
                }
            }
        }

        private async void btnAddDevice_Click(object sender, EventArgs e)
        {
            // Перевірка введених даних
            string deviceType = txtDeviceType.Text.Trim();
            string deviceStatus = txtDeviceStatus.Text.Trim();

            if (string.IsNullOrEmpty(deviceType) || string.IsNullOrEmpty(deviceStatus))
            {
                MessageBox.Show("Будь ласка, введіть тип пристрою та статус.");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");

                // Створення нового пристрою з введеними даними
                var device = new IoTDevice
                {
                    DeviceType = deviceType,
                    Status = deviceStatus
                };

                // Перетворення об'єкта у JSON
                var content = new StringContent(JsonConvert.SerializeObject(device), Encoding.UTF8, "application/json");

                // Надсилання POST-запиту
                var response = await client.PostAsync("api/iot-devices/register", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Пристрій додано успішно.");
                    txtDeviceType.Clear();
                    txtDeviceStatus.Clear();
                    LoadDevices(); // Оновлення списку пристроїв
                }
                else
                {
                    MessageBox.Show("Помилка при додаванні пристрою. Перевірте дані.");
                }
            }
        }

        private async void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://localhost:5000/api/users/list");
                    response.EnsureSuccessStatusCode();

                    var usersJson = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(usersJson);

                    dgvUsers.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при отриманні списку користувачів: {ex.Message}");
            }
        }

        private async void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть пристрій для видалення.");
                return;
            }

            var selectedRow = dgvDevices.SelectedRows[0];
            var deviceId = (int)selectedRow.Cells["DeviceId"].Value;

            var confirmation = MessageBox.Show("Ви впевнені, що хочете видалити цей пристрій?", "Підтвердження", MessageBoxButtons.YesNo);
            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"http://localhost:5000/api/iot-devices/delete/{deviceId}");
                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Пристрій успішно видалено.");
                    btnRefreshDevices_Click(sender, e); // Оновлюємо список пристроїв
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні пристрою: {ex.Message}");
            }
        }

        private async void btnRefreshDevices_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://localhost:5000/api/iot-devices/list");
                    response.EnsureSuccessStatusCode();

                    var devicesJson = await response.Content.ReadAsStringAsync();
                    var devices = JsonConvert.DeserializeObject<List<IoTDevice>>(devicesJson);

                    dgvDevices.DataSource = devices;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при отриманні списку пристроїв: {ex.Message}");
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-7G3I2IS;Database=aquatrack;Integrated Security=True;";  
            string backupFilePath = @"C:\Users\owner\Desktop\хнуре\3 курс\АтаРК\Backup\aquatrack_backup.bak"; 

            string backupQuery = $@"
                BACKUP DATABASE [aquatrack]
                TO DISK = '{backupFilePath}'
                WITH INIT, COMPRESSION;
            ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Резервну копію бази даних створено успішно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні резервної копії: {ex.Message}");
            }
        }

        private void BtnChangeLanguage_Click(object sender, EventArgs e)
        {
            // Зміна мови при натисканні кнопки
            if (currentLanguage == "uk")
            {
                currentLanguage = "en";
            }
            else
            {
                currentLanguage = "uk";
            }
            SetLanguage(currentLanguage); // Оновлюємо текст елементів інтерфейсу
        }
    }
}
