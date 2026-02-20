namespace DesignPatterns.Core.Behavioral.Observer.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Observer Pattern - Ejemplo Avanzado: Weather Station ===\n");

        var weatherData = new WeatherData();

        var currentDisplay = new CurrentConditionsDisplay();
        var statisticsDisplay = new StatisticsDisplay();
        var forecastDisplay = new ForecastDisplay();
        var alarmDisplay = new AlarmDisplay();

        Console.WriteLine("--- Registrando observadores ---");
        weatherData.RegisterObserver(currentDisplay);
        weatherData.RegisterObserver(statisticsDisplay);
        weatherData.RegisterObserver(forecastDisplay);
        weatherData.RegisterObserver(alarmDisplay);

        Console.WriteLine("\n--- Actualizando mediciones ---");
        weatherData.SetMeasurements(25.0f, 65.0f, 1013.1f);

        Console.WriteLine("\n--- Nuevas mediciones ---");
        weatherData.SetMeasurements(27.5f, 70.0f, 1012.5f);

        Console.WriteLine("\n--- Temperatura extrema ---");
        weatherData.SetMeasurements(35.0f, 45.0f, 1010.0f);

        Console.WriteLine("\n--- Removiendo observador ---");
        weatherData.RemoveObserver(statisticsDisplay);

        Console.WriteLine("\n--- Nuevas mediciones sin estadísticas ---");
        weatherData.SetMeasurements(22.0f, 60.0f, 1014.0f);

        Console.WriteLine("\n Observer permite múltiples reacciones a cambios");
    }
}