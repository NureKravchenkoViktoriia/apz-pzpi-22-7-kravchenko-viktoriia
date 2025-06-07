using AquaTrack.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AquaTrack
{
    public partial class UserForm : Form
    {
        private string currentLanguage = "uk";
        public UserForm()
        {
            InitializeComponent();
            UpdateRealTimeUsage();
            LoadLimits();
            tabControlPages.TabPages[0].Text = "Моніторинг";
            tabControlPages.TabPages[1].Text = "Ліміти";
        }

        // Метод для зміни мови
        private void SetLanguage(string language)
        {
            if (language == "uk")
            {
                tabControlPages.TabPages[0].Text = "Моніторинг";
                tabControlPages.TabPages[1].Text = "Ліміти";
                grpPeriodSelection.Text = "Історія використання води:";
                lblStartDate.Text = "Початкова дата:";
                lblEndDate.Text = "Кінцева дата:";
                btnShowData.Text = "Показати дані";
                lblRealTimeUsage.Text = "Використання в реальному часі: ";
                groupBoxLim.Text = "Ліміти";
                labelstartdate.Text = "Початкова дата:";
                labelenddate.Text = "Кінцева дата:";
                labelwater.Text = "Введіть кількість води:";
                labelnumber.Text = "Введіть номер пристрою:";
                btnAddLimit.Text = "Створити ліміт";
                btnCheckAllLimits.Text = "Перевірити всі ліміти";
                btnRemoveLimit.Text = "Видалити ліміт";
                BtnChangeLanguage.Text = "Укр/Англ";
            }
            else if (language == "en")
            {
                tabControlPages.TabPages[0].Text = "Monitoring";
                tabControlPages.TabPages[1].Text = "Limits";
                grpPeriodSelection.Text = "Water Usage History:";
                lblStartDate.Text = "Start Date:";
                lblEndDate.Text = "End Date:";
                btnShowData.Text = "Show Data";
                lblRealTimeUsage.Text = "Real-time Usage: ";
                groupBoxLim.Text = "Limits";
                labelstartdate.Text = "Start Date:";
                labelenddate.Text = "End Date:";
                labelwater.Text = "Enter Water Amount:";
                labelnumber.Text = "Enter Device Number:";
                btnAddLimit.Text = "Create Limit";
                btnCheckAllLimits.Text = "Check All Limits";
                btnRemoveLimit.Text = "Remove Limit";
                BtnChangeLanguage.Text = "UA/EN";
            }
        }

        private void grpPeriodSelection_Enter(object sender, EventArgs e)
        {

        }
        public class WaterUsageDisplayModel
        {
            public decimal UsageValue { get; set; }
            public int DeviceId { get; set; }
            public DateTime Timestamp { get; set; }
        }
        private async void btnShowData_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Початкова дата не може бути пізніше кінцевої.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var history = await FetchUsageHistory(null, startDate, endDate);

                // Створення нової колекції без полів UsageId та IoTDevice
                var displayHistory = history.Select(h => new WaterUsageDisplayModel
                {
                    Timestamp = h.Timestamp,
                    UsageValue = h.UsageValue,
                    DeviceId = h.DeviceId,
                }).ToList();

                dgvWaterUsageHistory.DataSource = displayHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<WaterUsage>> FetchUsageHistory(int? deviceId, DateTime? startDate, DateTime? endDate)
        {
            string url = $"http://localhost:5000/api/water-usage/history?deviceId={deviceId}&startDate={startDate?.ToUniversalTime():yyyy-MM-dd}&endDate={endDate?.ToUniversalTime():yyyy-MM-dd}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<WaterUsage>>(json);
            }
        }

        private async void UpdateRealTimeUsage()
        {
            while (true)
            {
                try
                {
                    var usage = await FetchCurrentUsage(deviceId: 1); 
                    lblRealTimeUsage.Text = $"Використання в реальному часі: {usage.UsageValue} л";
                }
                catch
                {
                    lblRealTimeUsage.Text = "Помилка завантаження даних.";
                }
                await Task.Delay(5000); // Оновлення кожні 5 секунд
            }
        }

        private async Task<WaterUsage> FetchCurrentUsage(int deviceId)
        {
            string url = $"http://localhost:5000/api/water-usage/current/{deviceId}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WaterUsage>(json);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Функція для завантаження лімітів в DataGridView
        private async void LoadLimits()
        {
            try
            {
                var limits = await FetchLimits();
                dgvLimitRecords.DataSource = limits;
                // Приховуємо непотрібні стовпчики
                dgvLimitRecords.Columns["User"].Visible = false;
                dgvLimitRecords.Columns["IoTDevice"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження лімітів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Функція для отримання лімітів через API
        private async Task<List<Limit>> FetchLimits()
        {
            string url = "http://localhost:5000/api/limits/list";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Limit>>(json);
            }
        }

        // Функція для виклику API для створення ліміту
        private async Task CreateLimit(CreateLimitRequest limit)
        {
            string url = "http://localhost:5000/api/limits/create";
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(limit);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
            }
        }

        // Функція для перевірки перевищення ліміту
        private async Task CheckLimitExceeded(int limitId)
        {
            try
            {
                var response = await FetchLimitExceeded(limitId); // Отримуємо дані перевищення ліміту
                if (response.LimitExceeded)
                {
                   // lblLimitNotification.Visible = true; // Показуємо повідомлення про перевищення ліміту
                }
                else
                {
                    //lblLimitNotification.Visible = false; // Приховуємо повідомлення, якщо ліміт не перевищено
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка перевірки ліміту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<dynamic> FetchLimitExceeded(int limitId)
        {
            string url = $"http://localhost:5000/api/limits/check-exceeded/{limitId}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<JObject>(json);

                // Переводимо значення з JValue в bool
                bool limitExceeded = jsonResponse["LimitExceeded"]?.Value<bool>() ?? false;

                return new { LimitExceeded = limitExceeded }; // Повертаємо перевірку ліміту як об'єкт
            }
        }



        private async Task<dynamic> FetchLimitProgress(int limitId)
        {
            string url = $"http://localhost:5000/api/limits/progress/{limitId}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
        }

        // Функція для виклику API для видалення ліміту
        private async Task DeleteLimit(int limitId)
        {
            string url = $"http://localhost:5000/api/limits/delete/{limitId}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
        }

        private async void btnAddLimit_Click(object sender, EventArgs e)
        {
            dtpLimitStartDate.Update();
            dtpLimitEndDate.Update();
            DateTime startDate = dtpLimitStartDate.Value;
            DateTime endDate = dtpLimitEndDate.Value;
            decimal limitValue;

            // Перевірка значення DeviceId
            if (!int.TryParse(txtDeviceId.Text, out int deviceId) || deviceId <= 0)
            {
                MessageBox.Show("Введіть коректний DeviceId.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка значення ліміту
            if (!decimal.TryParse(txtLimitAmount.Text, out limitValue) || limitValue <= 0)
            {
                MessageBox.Show("Введіть коректний обсяг ліміту.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка дат
            if (startDate > endDate)
            {
                MessageBox.Show("Дата початку повинна бути меншою за дату закінчення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var limit = new CreateLimitRequest
                {
                    StartDate = startDate.ToUniversalTime(),
                    EndDate = endDate.ToUniversalTime(),
                    LimitValue = limitValue,
                    DeviceId = deviceId,
                    UserId = 1 
                };

                await CreateLimit(limit);
                LoadLimits(); // Оновлюємо список лімітів
                MessageBox.Show("Ліміт успішно створено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення ліміту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnRemoveLimit_Click(object sender, EventArgs e)
        {
            if (dgvLimitRecords.SelectedRows.Count > 0)
            {
                int limitId = (int)dgvLimitRecords.SelectedRows[0].Cells[0].Value; // ID ліміту
                try
                {
                    await DeleteLimit(limitId);
                    LoadLimits(); // Оновлюємо список лімітів
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення ліміту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnCheckAllLimits_Click(object sender, EventArgs e)
        {
            try
            {
                var limits = await FetchLimits();
                List<int> exceededLimits = new List<int>(); // Список лімітів, які перевищені

                foreach (var limit in limits)
                {
                    var response = await FetchLimitExceeded(limit.LimitId);
                    if (response.LimitExceeded)
                    {
                        exceededLimits.Add(limit.LimitId);
                    }
                }

                if (exceededLimits.Count > 0)
                {
                    string limitsText = string.Join(", ", exceededLimits);
                    MessageBox.Show($"Ліміти перевищено для лімітів: {limitsText}", "Перевищення ліміту", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Жоден з лімітів не перевищено.", "Перевищення ліміту", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка перевірки лімітів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangeLanguage_Click(object sender, EventArgs e)
        {
            if (currentLanguage == "uk")
            {
                currentLanguage = "en"; // Змінюємо на англійську
            }
            else
            {
                currentLanguage = "uk"; // Змінюємо на українську
            }
            SetLanguage(currentLanguage); // Оновлюємо текст елементів
        }
    }
}