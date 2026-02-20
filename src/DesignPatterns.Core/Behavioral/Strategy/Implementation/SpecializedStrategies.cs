namespace DesignPatterns.Core.Behavioral.Strategy.Implementation;

/// <summary>
/// Estrategias de ejemplo para cálculos
/// </summary>

public interface ICalculationStrategy
{
    int Calculate(int a, int b);
    string GetDescription();
}

public class AdditionStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b)
    {
        Console.WriteLine($"  → Calculando suma: {a} + {b}");
        return a + b;
    }

    public string GetDescription() => "Suma";
}

public class SubtractionStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b)
    {
        Console.WriteLine($"  → Calculando resta: {a} - {b}");
        return a - b;
    }

    public string GetDescription() => "Resta";
}

public class MultiplicationStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b)
    {
        Console.WriteLine($"  → Calculando multiplicación: {a} * {b}");
        return a * b;
    }

    public string GetDescription() => "Multiplicación";
}

public class DivisionStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("  ✗ Error: División por cero");
            return 0;
        }
        Console.WriteLine($"  → Calculando división: {a} / {b}");
        return a / b;
    }

    public string GetDescription() => "División";
}

/// <summary>
/// Calculadora que usa estrategias
/// </summary>
public class Calculator
{
    private ICalculationStrategy _strategy;

    public Calculator(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICalculationStrategy strategy)
    {
        Console.WriteLine($"[Calculator] Cambiando a: {strategy.GetDescription()}");
        _strategy = strategy;
    }

    public int Execute(int a, int b)
    {
        var result = _strategy.Calculate(a, b);
        Console.WriteLine($"  ✓ Resultado: {result}");
        return result;
    }
}