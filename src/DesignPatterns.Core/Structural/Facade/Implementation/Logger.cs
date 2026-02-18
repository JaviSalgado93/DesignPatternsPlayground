namespace DesignPatterns.Core.Structural.Facade.Implementation;

/// <summary>
/// Subsistema 2 - Logging
/// </summary>
public class Logger
{
    private List<string> _logs = new();

    public void Log(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var logEntry = $"[{timestamp}] {message}";
        _logs.Add(logEntry);
        Console.WriteLine(logEntry);
    }

    public void SaveToFile(string filename)
    {
        Console.WriteLine($"[Logger] Guardando logs en: {filename}");
        // Simulación de guardado
        foreach (var log in _logs)
        {
            Console.WriteLine($"  - {log}");
        }
    }

    public List<string> GetLogs() => _logs;
}