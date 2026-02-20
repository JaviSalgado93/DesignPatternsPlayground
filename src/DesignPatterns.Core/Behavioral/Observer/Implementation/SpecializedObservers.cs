namespace DesignPatterns.Core.Behavioral.Observer.Implementation;

/// <summary>
/// LoggerObserver - Registra cambios en log
/// </summary>
public class LoggerObserver : IObserver
{
    private string _logFile;

    public LoggerObserver(string logFile = "changes.log")
    {
        _logFile = logFile;
    }

    public void Update(Subject subject)
    {
        Console.WriteLine($"  → [Logger] Registrando cambio en {_logFile}");
        Console.WriteLine($"      Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }
}

/// <summary>
/// EmailObserver - Envía notificaciones por email
/// </summary>
public class EmailObserver : IObserver
{
    private string _email;

    public EmailObserver(string email)
    {
        _email = email;
    }

    public void Update(Subject subject)
    {
        Console.WriteLine($"  → [Email] Enviando notificación a {_email}");
        Console.WriteLine($"      Asunto: Cambio de estado detectado");
    }
}

/// <summary>
/// AlertObserver - Genera alertas
/// </summary>
public class AlertObserver : IObserver
{
    private string _alertLevel;

    public AlertObserver(string level = "INFO")
    {
        _alertLevel = level;
    }

    public void Update(Subject subject)
    {
        Console.WriteLine($"  → [Alert] [{_alertLevel}] Estado cambió");
        Console.WriteLine($"      Acción requerida: Revisar cambios");
    }
}

/// <summary>
/// CacheObserver - Actualiza caché
/// </summary>
public class CacheObserver : IObserver
{
    private Dictionary<string, string> _cache = new();

    public void Update(Subject subject)
    {
        if (subject is ConcreteSubject concreteSubject)
        {
            _cache["lastState"] = concreteSubject.State;
            _cache["lastUpdate"] = DateTime.Now.ToString();
            Console.WriteLine($"  → [Cache] Caché actualizado");
        }
    }

    public string GetCachedState() => _cache.ContainsKey("lastState") ? _cache["lastState"] : "N/A";
}