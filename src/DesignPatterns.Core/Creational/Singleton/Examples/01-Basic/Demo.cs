namespace DesignPatterns.Core.Creational.Singleton.Examples._01_Basic;

/// <summary>
/// Demostración del Singleton Pattern con SimpleLogger
/// Muestra el concepto clave: UNA ÚNICA INSTANCIA
/// </summary>
public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Singleton Pattern - Ejemplo Básico: Logger ===\n");

        // ========== PRIMER ACCESO ==========
        // Aquí se CREA la instancia por primera vez
        var logger = SimpleLogger.Instance;
        logger.Log("Aplicación iniciada");
        logger.Log("Operación 1 completada");
        logger.Log("Operación 2 completada");
        logger.LogError("Operación 3 falló");

        // ========== SEGUNDO ACCESO ==========
        // Aquí NO se crea nueva instancia, reutiliza la anterior
        // ¡Pero no lo sabemos! Simplemente obtenemos "otra instancia"
        var logger2 = SimpleLogger.Instance;
        logger2.Log("Operación 4 completada");

        // ========== VERIFICACIÓN ==========
        // Verificamos que REALMENTE son la MISMA instancia
        bool sonIguales = ReferenceEquals(logger, logger2);
        Console.WriteLine($"\n¿logger y logger2 son la misma instancia? {sonIguales}");
        // Output: true

        // ========== PRUEBA FINAL ==========
        // logger y logger2 comparten la MISMA lista de logs
        // Si logger2 agrega algo, logger lo ve también
        Console.WriteLine("\n--- Todos los logs registrados ---");
        var allLogs = logger.GetAllLogs();
        foreach (var log in allLogs)
        {
            Console.WriteLine(log);
        }
        // Nota: Se ven los 5 logs (del logger y logger2) porque es LA MISMA lista
    }
}