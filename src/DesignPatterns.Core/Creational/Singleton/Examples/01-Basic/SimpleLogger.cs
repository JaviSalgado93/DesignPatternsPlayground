namespace DesignPatterns.Core.Creational.Singleton.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: SimpleLogger
/// Un logger centralizado que implementa el patrón Singleton
/// 
/// ¿Por qué Singleton aquí?
/// - Un logger debe ser accesible desde cualquier parte de la aplicación
/// - Queremos una única instancia que guarde todos los logs
/// - Si tuviéramos múltiples loggers, tendríamos múltiples archivos de logs
/// </summary>
public sealed class SimpleLogger
{
    // ========== ESTRUCTURA SINGLETON ==========
    
    /// <summary>
    /// Lazy<T> = inicialización perezosa + thread-safe automática
    /// Se crea solo cuando se accede por primera vez a Instance
    /// </summary>
    private static readonly Lazy<SimpleLogger> _instance = new Lazy<SimpleLogger>(() => new SimpleLogger());

    /// <summary>
    /// Propiedad que da acceso global a la única instancia
    /// Ejemplo: SimpleLogger.Instance.Log("mensaje")
    /// </summary>
    public static SimpleLogger Instance => _instance.Value;

    // ========== DATOS DEL LOGGER ==========
    
    /// <summary>
    /// Lista que almacena TODOS los logs
    /// Como es una instancia única, TODOS los logs van aquí
    /// </summary>
    private List<string> _logs = new();

    // ========== CONSTRUCTOR PRIVADO ==========
    
    /// <summary>
    /// Constructor PRIVADO = no se puede hacer "new SimpleLogger()"
    /// Solo se puede acceder vía SimpleLogger.Instance
    /// 
    /// Esto GARANTIZA que hay una única instancia
    /// Si el constructor fuera público, cualquiera podría hacer:
    ///     var logger1 = new SimpleLogger();
    ///     var logger2 = new SimpleLogger();  // ¡Dos instancias!
    /// </summary>
    private SimpleLogger()
    {
        _logs.Add("[Inicialización] Logger iniciado");
    }

    // ========== MÉTODOS PÚBLICOS ==========
    
    /// <summary>
    /// Registra un mensaje de log normal
    /// </summary>
    public void Log(string message)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
        _logs.Add(logEntry);           // Guarda en la lista
        Console.WriteLine(logEntry);   // Muestra en pantalla
    }

    /// <summary>
    /// Registra un mensaje de ERROR en rojo
    /// </summary>
    public void LogError(string error)
    {
        string errorEntry = $"[ERROR] [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {error}";
        _logs.Add(errorEntry);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorEntry);
        Console.ResetColor();
    }

    /// <summary>
    /// Retorna TODOS los logs registrados
    /// new() = crea una copia para que no modifiquen la lista original
    /// </summary>
    public List<string> GetAllLogs() => new(_logs);

    /// <summary>
    /// Limpia todos los logs
    /// </summary>
    public void ClearLogs()
    {
        _logs.Clear();
        Console.WriteLine("[Logger] Logs limpiados");
    }
}