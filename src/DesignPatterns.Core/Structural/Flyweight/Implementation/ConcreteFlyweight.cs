namespace DesignPatterns.Core.Structural.Flyweight.Implementation;

/// <summary>
/// ConcreteFlyweight - Objeto compartido (estado intrínseco)
/// </summary>
public class ConcreteFlyweight : IFlyweight
{
    private string _intrinsicState; // Compartido

    public ConcreteFlyweight(string intrinsicState)
    {
        _intrinsicState = intrinsicState;
    }

    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Intrínseco: {_intrinsicState}, Extrínseco: {extrinsicState}");
    }

    public string GetIntrinsicState() => _intrinsicState;
}