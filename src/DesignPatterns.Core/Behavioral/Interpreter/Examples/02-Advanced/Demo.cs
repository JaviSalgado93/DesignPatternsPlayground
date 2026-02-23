namespace DesignPatterns.Core.Behavioral.Interpreter.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Interpreter Pattern - Ejemplo Avanzado: Command Interpreter ===\n");

        var interpreter = new CommandInterpreter();

        Console.WriteLine("--- Ejecutando comandos ---\n");

        interpreter.Execute("SET nombre Juan");
        interpreter.Execute("SET edad 30");
        interpreter.Execute("SET ciudad Madrid");

        interpreter.Execute("ECHO Bienvenido al sistema");

        interpreter.Execute("PRINT nombre");
        interpreter.Execute("PRINT edad");
        interpreter.Execute("PRINT ciudad");

        interpreter.Execute("ECHO Operación completada exitosamente");

        interpreter.PrintOutput();

        Console.WriteLine("\n--- Intentando acceder a variable no existente ---");
        try
        {
            interpreter.Execute("PRINT inexistente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  ❌ Error: {ex.Message}");
        }

        Console.WriteLine("\n--- Limpiando ---");
        interpreter.Execute("CLEAR");
        interpreter.PrintOutput();

        Console.WriteLine("\n Interpreter permite procesar lenguajes específicos de dominio");
    }
}