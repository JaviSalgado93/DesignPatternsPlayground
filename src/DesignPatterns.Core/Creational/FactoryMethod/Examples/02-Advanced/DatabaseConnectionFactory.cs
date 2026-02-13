namespace DesignPatterns.Core.Creational.FactoryMethod.Examples._02_Advanced;

/// <summary>
/// Ejemplo Avanzado: Factory para diferentes tipos de conexiones a base de datos
/// </summary>

public interface IDatabaseConnection
{
    void Connect();
    void ExecuteQuery(string query);
    void Disconnect();
    string GetDatabaseType();
}

public class MySqlConnection : IDatabaseConnection
{
    private bool _isConnected = false;

    public void Connect()
    {
        _isConnected = true;
        Console.WriteLine("[MySql] Conectado a base de datos MySQL");
    }

    public void ExecuteQuery(string query)
    {
        if (!_isConnected)
            throw new InvalidOperationException("No hay conexión");
        Console.WriteLine($"[MySql] Ejecutando query: {query}");
    }

    public void Disconnect()
    {
        _isConnected = false;
        Console.WriteLine("[MySql] Desconectado de MySQL");
    }

    public string GetDatabaseType() => "MySQL";
}

public class SqlServerConnection : IDatabaseConnection
{
    private bool _isConnected = false;

    public void Connect()
    {
        _isConnected = true;
        Console.WriteLine("[SqlServer] Conectado a SQL Server");
    }

    public void ExecuteQuery(string query)
    {
        if (!_isConnected)
            throw new InvalidOperationException("No hay conexión");
        Console.WriteLine($"[SqlServer] Ejecutando query: {query}");
    }

    public void Disconnect()
    {
        _isConnected = false;
        Console.WriteLine("[SqlServer] Desconectado de SQL Server");
    }

    public string GetDatabaseType() => "SQL Server";
}

public class PostgresConnection : IDatabaseConnection
{
    private bool _isConnected = false;

    public void Connect()
    {
        _isConnected = true;
        Console.WriteLine("[Postgres] Conectado a PostgreSQL");
    }

    public void ExecuteQuery(string query)
    {
        if (!_isConnected)
            throw new InvalidOperationException("No hay conexión");
        Console.WriteLine($"[Postgres] Ejecutando query: {query}");
    }

    public void Disconnect()
    {
        _isConnected = false;
        Console.WriteLine("[Postgres] Desconectado de PostgreSQL");
    }

    public string GetDatabaseType() => "PostgreSQL";
}

/// <summary>
/// Factory avanzada para conexiones de base de datos
/// </summary>
public class DatabaseConnectionFactory
{
    public static IDatabaseConnection CreateConnection(string databaseType)
    {
        return databaseType.ToLower() switch
        {
            "mysql" => new MySqlConnection(),
            "sqlserver" => new SqlServerConnection(),
            "postgres" => new PostgresConnection(),
            _ => throw new ArgumentException($"Tipo de base de datos desconocida: {databaseType}")
        };
    }
}