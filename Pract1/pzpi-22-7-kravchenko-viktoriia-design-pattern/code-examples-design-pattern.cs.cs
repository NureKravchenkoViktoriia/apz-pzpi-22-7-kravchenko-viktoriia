  using System;
  using System.Collections.Generic;
 
   // Інтерфейс Спостерігача
   interface IObserver
   {
        void Update(float temperature, float humidity, float pressure);
      }

  // Інтерфейс Видавця (Subject)
  interface ISubject
  {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
      }

  // Конкретний Видавець - Станція погоди
  class WeatherStation : ISubject
  {
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;
  
    public WeatherStation()
    {
      observers = new List<IObserver>();
    }

    public void SetMeasurements(float temp, float hum, float pres)
    {
          temperature = temp;
          humidity = hum;
          pressure = pres;
          NotifyObservers();
        }

    public void RegisterObserver(IObserver observer)
    {
          observers.Add(observer);
        }

    public void RemoveObserver(IObserver observer)
    {
          observers.Remove(observer);
        }

    public void NotifyObservers()
    {
          foreach (var observer in observers)
              {
                observer.Update(temperature, humidity, pressure);
              }
        }
  }

  // Конкретний Спостерігач - Поточний дисплей
  class CurrentConditionsDisplay : IObserver
  {
    private float temperature;
    private float humidity;
  
    public void Update(float temperature, float humidity, float pressure)
    {
      this.temperature = temperature;
      this.humidity = humidity;
      Display();
    }

    public void Display()
    {
          Console.WriteLine($"Поточні умови: {temperature}°C, {humidity}% вологості");
        }
  }

  // Інший Спостерігач - Прогноз погоди
  class ForecastDisplay : IObserver
  {
    private float currentPressure = 1013.25f;
    private float lastPressure;
  
    public void Update(float temperature, float humidity, float pressure)
    {
      lastPressure = currentPressure;
      currentPressure = pressure;
      Display();
    }

    public void Display()
    {
          Console.Write("Прогноз: ");
          if (currentPressure > lastPressure)
              {
                Console.WriteLine("Очікується покращення погоди.");
              }
          else if (currentPressure == lastPressure)
              {
                Console.WriteLine("Без змін.");
              }
         else
             {
               Console.WriteLine("Можливе погіршення погоди.");
             }
       }
 }

 // Головна програма
 class Program
 {
       static void Main()
  {
             WeatherStation station = new WeatherStation();
        
     CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();
             ForecastDisplay forecastDisplay = new ForecastDisplay();
        
     station.RegisterObserver(currentDisplay);
             station.RegisterObserver(forecastDisplay);
        
     Console.WriteLine("Оновлення 1:");
             station.SetMeasurements(25.0f, 65.0f, 1012.5f);
        
     Console.WriteLine("\nОновлення 2:");
             station.SetMeasurements(27.0f, 70.0f, 1015.0f);
        
     Console.WriteLine("\nОновлення 3:");
             station.SetMeasurements(22.5f, 90.0f, 1009.0f);
           }
     }
