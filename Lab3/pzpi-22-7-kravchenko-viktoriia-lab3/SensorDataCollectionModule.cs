using System;

public class SensorDataCollectionModule
{
    private Random _random;

    public SensorDataCollectionModule()
    {
        _random = new Random();
    }

    public double CollectData()
    {
        // Симуляція збору даних (вимірювання витрати води)
        return Math.Round(_random.NextDouble() * 100, 2); // Витрати води від 0 до 100 літрів
    }
}
