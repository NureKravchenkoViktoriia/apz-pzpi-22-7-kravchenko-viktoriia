using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class DataTransmissionModule
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private string _serverUrl;
    private Queue<object> _buffer; // Буфер для тимчасового зберігання даних

    public DataTransmissionModule(string serverUrl)
    {
        _serverUrl = serverUrl;
        _buffer = new Queue<object>();
    }

    public void BufferData(int deviceId, double waterConsumption)
    {
        var jsonData = new
        {
            DeviceId = deviceId,
            UsageValue = waterConsumption,
            Timestamp = DateTime.UtcNow
        };

        _buffer.Enqueue(jsonData);
    }

    public async Task<bool> SendBufferedDataAsync()
    {
        while (_buffer.Count > 0)
        {
            var data = _buffer.Dequeue();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{_serverUrl}/api/iot-devices/collect-data", content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to send buffered data. Status code: {response.StatusCode}");
                    _buffer.Enqueue(data); // Повертаємо дані у буфер
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending buffered data: {ex.Message}");
                _buffer.Enqueue(data); // Повертаємо дані у буфер
                return false;
            }
        }

        return true;
    }
}
