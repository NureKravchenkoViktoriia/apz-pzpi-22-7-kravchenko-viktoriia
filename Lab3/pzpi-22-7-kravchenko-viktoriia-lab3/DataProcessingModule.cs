using System;

public class DataProcessingModule
{
    public double AnalyzeData(double sensorData)
    {
        if (sensorData < 0)
            throw new ArgumentException("Invalid sensor data");

        // Обробка: видалення шумів 
        var filteredData = Math.Max(sensorData - (sensorData * 0.05), 0);

        // Аналіз: оцінка аномалій 
        if (filteredData > 90)
        {
            Console.WriteLine("Warning: High water consumption detected!");
        }

        return Math.Round(filteredData, 2);
    }
}
