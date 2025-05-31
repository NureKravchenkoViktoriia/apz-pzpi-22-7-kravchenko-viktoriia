using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Ініціалізація модулів
        var loggingModule = new LoggingModule();
        var wifiConfigModule = new WiFiConfigurationModule();
        var adminModule = new AdminModule();
        var config = new ConfigurationModule("http://localhost:5000", 10); // Серверний URL і інтервал
        var sensorDataModule = new SensorDataCollectionModule();
        var dataProcessingModule = new DataProcessingModule();
        var dataTransmissionModule = new DataTransmissionModule(config.ServerUrl);

        loggingModule.Log("IoT client starting...");

        // Крок 1: Налаштування Wi-Fi
        loggingModule.Log("Starting Wi-Fi configuration...");
        wifiConfigModule.ConfigureWiFi();

        // Крок 2: Вибір пристрою
        loggingModule.Log("Starting device configuration...");
        var deviceId = adminModule.GetDeviceId();
        loggingModule.Log($"Device ID set to {deviceId}");

        // Головний цикл роботи клієнта
        while (true)
        {
            try
            {
                // Збір даних
                var waterConsumption = sensorDataModule.CollectData();
                loggingModule.Log($"Collected raw data: {waterConsumption} liters");

                // Обробка даних
                var processedData = dataProcessingModule.AnalyzeData(waterConsumption);
                loggingModule.Log($"Processed data: {processedData} liters (after analysis)");

                // Буферизація даних перед передачею
                dataTransmissionModule.BufferData(deviceId, processedData);

                // Періодичне надсилання даних
                var result = await dataTransmissionModule.SendBufferedDataAsync();
                if (!result)
                {
                    loggingModule.Log("Failed to send data.");
                }
            }
            catch (Exception ex)
            {
                loggingModule.Log($"Error: {ex.Message}");
            }

            // Очікування перед наступним циклом збору даних
            await Task.Delay(config.DataCollectionInterval * 1000);
        }
    }
}
