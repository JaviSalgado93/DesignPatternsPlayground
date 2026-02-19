namespace DesignPatterns.Core.Structural.Proxy.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Proxy Pattern - Ejemplo Avanzado: Database Proxy ===\n");

        // Usuario autorizado
        Console.WriteLine("--- Usuario: admin ---");
        IDatabase db1 = new DatabaseProxy("Server=localhost;DB=mydb", "admin");

        Console.WriteLine("\n--- Primer FetchData ---");
        var result1 = db1.FetchData("SELECT * FROM users");

        Console.WriteLine("\n--- Segundo FetchData (desde caché) ---");
        var result2 = db1.FetchData("SELECT * FROM users");

        Console.WriteLine("\n--- FetchData diferente ---");
        var result3 = db1.FetchData("SELECT * FROM products");

        Console.WriteLine("\n--- Execute query ---");
        db1.Execute("UPDATE users SET active=1");

        // Usuario sin permisos
        Console.WriteLine("\n\n--- Usuario: guest (sin permisos) ---");
        IDatabase db2 = new DatabaseProxy("Server=localhost;DB=mydb", "guest");

        Console.WriteLine("\n--- Intentando FetchData ---");
        db2.FetchData("SELECT * FROM users");

        Console.WriteLine("\n--- Intentando Execute ---");
        db2.Execute("DELETE FROM users");

        // Mostrar auditoría
        if (db1 is DatabaseProxy proxy)
        {
            proxy.PrintAuditLog();
        }

        Console.WriteLine("\n Proxy controla acceso, cachea y audita");
    }
}