using System;

class TemperatureSensor
{
    public event Action<int> TemperatureChanged;

    private int temperature;

    public int Temperature
    {
        get { return temperature; }
        set
        {
            if (temperature != value)
            {
                temperature = value;
                OnTemperatureChanged(value);
            }
        }
    }

    protected virtual void OnTemperatureChanged(int newTemperature)
    {
        TemperatureChanged?.Invoke(newTemperature);
    }
}

class Thermostat
{
    public void OnTemperatureChanged(int newTemperature)
    {
        if (newTemperature > 25)
        {
            Console.WriteLine("Температура в норме.");
        }
        else if (newTemperature < 18)
        {
            Console.WriteLine("Температура слишком низкая, включаю отопление.");
        }
        else
        {
            Console.WriteLine("Температура слишком высокая, включаю кондиционер.");
        }
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat();

        // Подписываем термостат на событие изменения температуры
        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;

        // Изменяем температуру
        sensor.Temperature = 30;  // Температура слишком высокая
        sensor.Temperature = 15;  // Температура слишком низкая
        sensor.Temperature = 22;  // Температура в норме
    }
}
