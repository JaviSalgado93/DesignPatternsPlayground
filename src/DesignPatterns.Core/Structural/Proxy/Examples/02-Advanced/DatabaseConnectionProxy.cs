namespace DesignPatterns.Core.Structural.Proxy.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Proxy con control de acceso, caching y auditoría
/// </summary>

public interface IDatabase
{
    void Execute(string query);
    string FetchData(string query);
}

/// <summary>
/// Real Database - Base de datos real
/// </summary>
public class RealDatabase : IDatabase
{
    private string _connectionString;
    private int _queryCount = 0;

    public RealDatabase(string connectionString)
    {
        _connectionString = connectionString;
        Connect();
    }

    private void Connect()
    {
        Console.WriteLine($"[Database] Conectando a: {_connectionString}");
    }

    public void Execute(string query)
    {
        _queryCount++;
        Console.WriteLine($"[Database] Ejecutando query #{_queryCount}: {query}");
        System.Threading.Thread.Sleep(500); // Simular ejecución
        Console.WriteLine("[Database] Query ejecutada");
    }

    public string FetchData(string query)
    {
        _queryCount++;
        Console.WriteLine($"[Database] Obteniendo datos: {query}");
        System.Threading.Thread.Sleep(500); // Simular lectura
        return $"Datos de: {query}";
    }
}

/// <summary>
/// Proxy Database - Control de acceso, caching y auditoría
/// </summary>
public class DatabaseProxy : IDatabase
{
    private RealDatabase _realDatabase;
    private Dictionary<string, string> _cache = new();
    private string _currentUser = "";
    private List<string> _auditLog = new();

    public DatabaseProxy(string connectionString, string user)
    {
        _currentUser = user;
        _realDatabase = new RealDatabase(connectionString);
    }

    public void Execute(string query)
    {
        // Control de acceso
        if (!HasPermission(_currentUser, "execute"))
        {
            Console.WriteLine($"[Proxy] ❌ Acceso denegado: {_currentUser}");
            LogAudit($"Intento no autorizado de Execute: {query}");
            return;
        }

        // Auditoría
        LogAudit($"Execute: {query}");

        // Delegar a base de datos real
        _realDatabase.Execute(query);
    }

    public string FetchData(string query)
    {
        // Control de acceso
        if (!HasPermission(_currentUser, "read"))
        {
            Console.WriteLine($"[Proxy] ❌ Acceso denegado: {_currentUser}");
            LogAudit($"Intento no autorizado de FetchData: {query}");
            return "";
        }

        // Caching
        if (_cache.ContainsKey(query))
        {
            Console.WriteLine($"[Proxy] 💾 Retornando desde caché");
            LogAudit($"Cache hit: {query}");
            return _cache[query];
        }

        // Auditoría
        LogAudit($"FetchData: {query}");

        // Delegar a base de datos real
        var result = _realDatabase.FetchData(query);

        // Guardar en caché
        _cache[query] = result;
        Console.WriteLine($"[Proxy] Resultado guardado en caché");

        return result;
    }

    private bool HasPermission(string user, string action)
    {
        // Simulación simple de permisos
        return user == "admin" || user == "user";
    }

    private void LogAudit(string message)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        var entry = $"[{timestamp}] {_currentUser}: {message}";
        _auditLog.Add(entry);
        Console.WriteLine($"[Proxy] 📋 {entry}");
    }

    public void PrintAuditLog()
    {
        Console.WriteLine("\n=== Audit Log ===");
        foreach (var entry in _auditLog)
        {
            Console.WriteLine(entry);
        }
    }
}