namespace DesignPatterns.Core.Behavioral.Command.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Command Pattern - Ejemplo Básico: Calculator ===\n");

        var calculator = new Calculator();
        var invoker = new CalculatorInvoker();

        Console.WriteLine("--- Ejecutando comandos ---");
        invoker.ExecuteCommand(new AddCalculatorCommand(calculator, 10));
        invoker.ExecuteCommand(new AddCalculatorCommand(calculator, 5));
        invoker.ExecuteCommand(new SubtractCalculatorCommand(calculator, 3));

        Console.WriteLine($"\nValor actual: {calculator.GetValue()}");

        Console.WriteLine("\n--- Deshaciendo operaciones ---");
        invoker.Undo();
        invoker.Undo();

        Console.WriteLine($"Valor después de 2 undos: {calculator.GetValue()}");

        Console.WriteLine("\n--- Rehaciendo operaciones ---");
        invoker.Redo();

        Console.WriteLine($"Valor después de redo: {calculator.GetValue()}");

        Console.WriteLine("\n Command encapsula operaciones con undo/redo");
    }
}