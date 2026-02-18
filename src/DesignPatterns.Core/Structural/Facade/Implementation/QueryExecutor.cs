namespace DesignPatterns.Core.Structural.Facade.Implementation;

/// <summary>
/// Subsistema 4 - Ejecución de consultas
/// </summary>
public class QueryExecutor
{
    private DatabaseConnection _database;

    public QueryExecutor(DatabaseConnection database)
    {
        _database = database;
    }

    public void ExecuteQuery(string query)
    {
        if (!_database.IsConnected)
        {
            Console.WriteLine("[QueryExecutor] Error: Base de datos no conectada");
            return;
        }

        Console.WriteLine($"[QueryExecutor] Ejecutando: {query}");
        // Simulación de ejecución
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("[QueryExecutor] Consulta completada");
    }

    public List<string> FetchResults()
    {
        return new List<string> { "Resultado 1", "Resultado 2", "Resultado 3" };
    }
}