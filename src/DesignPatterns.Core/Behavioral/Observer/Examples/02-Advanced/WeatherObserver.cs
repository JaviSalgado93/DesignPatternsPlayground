namespace DesignPatterns.Core.Behavioral.Observer.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Sistema de estación meteorológica
/// </summary>

public class WeatherData
{
    private float _temperature;
    private float _humidity;
    private float _pressure;
    private List<IWeatherObserver> _observers = new();

    public float Temperature => _temperature;
    public float Humidity => _humidity;
    public float Pressure => _pressure;

    public void RegisterObserver(IWeatherObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            Console.WriteLine($"[WeatherStation] Observador registrado. Total: {_observers.Count}");
        }
    }

    public void RemoveObserver(IWeatherObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"[WeatherStation] Observador removido. Total: {_observers.Count}");
    }

    public void SetMeasurements(float temp, float humidity, float pressure)
    {
        _temperature = temp;
        _humidity = humidity;
        _pressure = pressure;
        Console.WriteLine($"[WeatherStation] Nuevas mediciones: {temp}°C, {humidity}% humedad, {pressure}hPa");
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

public interface IWeatherObserver
{
    void Update(WeatherData weatherData);
}

public class CurrentConditionsDisplay : IWeatherObserver
{
    public void Update(WeatherData weatherData)
    {
        Console.WriteLine($"  → [Display] Condiciones actuales: {weatherData.Temperature}°C, {weatherData.Humidity}% humedad");
    }
}

public class StatisticsDisplay : IWeatherObserver
{
    private float _maxTemp = float.MinValue;
    private float _minTemp = float.MaxValue;
    private float _avgTemp = 0;
    private int _count = 0;

    public void Update(WeatherData weatherData)
    {
        _maxTemp = Math.Max(_maxTemp, weatherData.Temperature);
        _minTemp = Math.Min(_minTemp, weatherData.Temperature);
        _avgTemp = (_avgTemp * _count + weatherData.Temperature) / ++_count;

        Console.WriteLine($"  → [Stats] Temp - Máx: {_maxTemp}°C, Mín: {_minTemp}°C, Promedio: {_avgTemp:F1}°C");
    }
}

public class ForecastDisplay : IWeatherObserver
{
    private float _previousPressure = 1013f;

    public void Update(WeatherData weatherData)
    {
        var trend = weatherData.Pressure > _previousPressure ? "mejorando" : "empeorando";
        Console.WriteLine($"  → [Forecast] Pronóstico: Tiempo {trend}");
        _previousPressure = weatherData.Pressure;
    }
}

public class AlarmDisplay : IWeatherObserver
{
    public void Update(WeatherData weatherData)
    {
        if (weatherData.Temperature > 30)
        {
            Console.WriteLine($"  → [Alarm] ⚠️  ALERTA: Temperatura muy alta ({weatherData.Temperature}°C)");
        }
        else if (weatherData.Temperature < 0)
        {
            Console.WriteLine($"  → [Alarm] ❄️  ALERTA: Temperatura bajo cero ({weatherData.Temperature}°C)");
        }
    }
}