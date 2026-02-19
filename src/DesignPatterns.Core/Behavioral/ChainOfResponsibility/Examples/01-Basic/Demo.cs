namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Chain of Responsibility - Ejemplo Básico: Logging ===\n");

        // Crear cadena de loggers
        ILogger consoleLogger = new ConsoleLogger();
        ILogger fileLogger = new FileLogger();
        ILogger dbLogger = new DatabaseLogger();

        consoleLogger.SetNext(fileLogger);
        fileLogger.SetNext(dbLogger);

        // Procesar diferentes niveles
        Console.WriteLine("--- Enviando logs ---");
        consoleLogger.Log(new LogRequest("Debug", "Debug information"));
        consoleLogger.Log(new LogRequest("Info", "Application started"));
        consoleLogger.Log(new LogRequest("Warning", "Low memory warning"));
        consoleLogger.Log(new LogRequest("Error", "Database connection failed"));
        consoleLogger.Log(new LogRequest("Critical", "System failure - immediate action needed"));

        Console.WriteLine("\n Chain of Responsibility permite procesar en cadena");
    }
}