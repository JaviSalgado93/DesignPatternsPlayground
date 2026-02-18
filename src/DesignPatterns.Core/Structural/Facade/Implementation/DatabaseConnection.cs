namespace DesignPatterns.Core.Structural.Facade.Implementation;

/// <summary>
/// Subsistema 1 - Conexión a base de datos
/// </summary>
public class DatabaseConnection
{
    private bool _isConnected = false;

    public void Connect(string connectionString)
    {
        Console.WriteLine($"[Database] Conectando a: {connectionString}");
        _isConnected = true;
    }

    public void Disconnect()
    {
        Console.WriteLine("[Database] Desconectado");
        _isConnected = false;
    }

    public bool IsConnected => _isConnected;
}