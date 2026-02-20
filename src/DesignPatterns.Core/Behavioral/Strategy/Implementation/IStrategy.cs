namespace DesignPatterns.Core.Behavioral.Strategy.Implementation;

/// <summary>
/// Strategy - Define interfaz para algoritmos
/// </summary>
public interface IStrategy
{
    void Execute();
    string GetName();
}

/// <summary>
/// Context - Usa strategy para ejecutar algoritmo
/// </summary>
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
        Console.WriteLine($"[Context] Estrategia configurada: {_strategy.GetName()}");
    }

    public void SetStrategy(IStrategy strategy)
    {
        Console.WriteLine($"[Context] Cambiando estrategia a: {strategy.GetName()}");
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        Console.WriteLine($"[Context] Ejecutando: {_strategy.GetName()}");
        _strategy.Execute();
    }

    public string GetCurrentStrategy() => _strategy.GetName();
}