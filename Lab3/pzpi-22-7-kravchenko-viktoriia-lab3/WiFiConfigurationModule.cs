using System;

public class WiFiConfigurationModule
{
    public string SSID { get; private set; }
    public string Password { get; private set; }

    public void ConfigureWiFi()
    {
        Console.WriteLine("Wi-Fi Configuration:");

        Console.Write("Enter Wi-Fi SSID: ");
        SSID = Console.ReadLine();

        Console.Write("Enter Wi-Fi Password: ");
        Password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(SSID) || string.IsNullOrWhiteSpace(Password))
        {
            Console.WriteLine("Wi-Fi configuration failed: SSID or Password is empty. Please retry.");
            ConfigureWiFi();
        }
        else
        {
            Console.WriteLine($"Wi-Fi configured. SSID: {SSID}");
        }
    }
}
