using System;
using System.IO;

public class LoggingModule
{
    private string _logFilePath = "iot_log.txt";

    public void Log(string message)
    {
        Console.WriteLine(message); // Вивести в консоль

        // Запис у файл
        File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}\n");
    }
}
