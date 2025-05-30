using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;

namespace AquaTrack
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string baseAddress = "http://localhost:5000/"; // Адреса для API

            // Окремий потік для запуску сервера
            Thread serverThread = new Thread(() =>
            {
                try
                {
                    using (WebApp.Start<Startup>(baseAddress))
                    {
                        // Повідомлення про успішний запуск
                        MessageBox.Show("Web API запущено на " + baseAddress, "Успішно");

                        // Відкриття браузера
                        Process.Start("explorer", "http://localhost:5000/swagger" );

                        // Потік очікує завершення роботи сервера
                        Thread.Sleep(Timeout.Infinite);
                    }
                }
                catch (Exception ex)
                {
                    // Логування помилок запуску сервера
                    MessageBox.Show("Помилка запуску API: " + ex.Message, "Помилка");
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();

            try
            {
                // Запускаємо WinForms-додаток у головному потоці
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AuthorizationForm());
            }
            catch (Exception ex)
            {
                // Логування помилок запуску WinForms
                MessageBox.Show("Помилка запуску WinForms: " + ex.Message, "Помилка");
            }
        }
    }
}
