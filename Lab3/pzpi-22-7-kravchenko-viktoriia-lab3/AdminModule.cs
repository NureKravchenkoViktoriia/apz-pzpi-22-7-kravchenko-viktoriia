using System;

public class AdminModule
{
    public int GetDeviceId()
    {
        Console.WriteLine("Device Configuration:");

        Console.Write("Enter Device ID (default is 1): ");
        var input = Console.ReadLine();

        return int.TryParse(input, out var deviceId) && deviceId > 0 ? deviceId : 1;
    }
}
