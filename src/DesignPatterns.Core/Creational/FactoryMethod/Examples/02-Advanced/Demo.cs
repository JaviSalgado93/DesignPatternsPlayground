namespace DesignPatterns.Core.Creational.FactoryMethod.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Factory Method Pattern - Ejemplo Avanzado: Conexiones a BD ===\n");

        var databases = new[] { "mysql", "sqlserver", "postgres" };

        foreach (var dbType in databases)
        {
            Console.WriteLine($"\n--- Trabajando con {dbType.ToUpper()} ---");

            // La factory crea la conexión adecuada
            var connection = DatabaseConnectionFactory.CreateConnection(dbType);

            // El código cliente no sabe qué tipo de conexión es
            connection.Connect();
            connection.ExecuteQuery("SELECT * FROM usuarios");
            connection.ExecuteQuery("INSERT INTO logs VALUES (...)");
            connection.Disconnect();
        }

        Console.WriteLine("\n Factory Method permite cambiar BD sin modificar el código cliente");
    }
}