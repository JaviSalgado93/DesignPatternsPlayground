namespace DesignPatterns.Core.Behavioral.Strategy.Implementation;

/// <summary>
/// ConcreteStrategy A
/// </summary>
public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("  → Ejecutando Strategy A");
        Console.WriteLine("  → Procesando de forma rápida");
        Console.WriteLine("  → Resultado: Procesamiento A completado");
    }

    public string GetName() => "Strategy A (Rápido)";
}

/// <summary>
/// ConcreteStrategy B
/// </summary>
public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("  → Ejecutando Strategy B");
        Console.WriteLine("  → Procesando de forma confiable");
        Console.WriteLine("  → Resultado: Procesamiento B completado");
    }

    public string GetName() => "Strategy B (Confiable)";
}

/// <summary>
/// ConcreteStrategy C
/// </summary>
public class ConcreteStrategyC : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("  → Ejecutando Strategy C");
        Console.WriteLine("  → Procesando de forma eficiente");
        Console.WriteLine("  → Resultado: Procesamiento C completado");
    }

    public string GetName() => "Strategy C (Eficiente)";
}