namespace DesignPatterns.Core.Structural.Decorator.Implementation;

/// <summary>
/// ConcreteComponent - Objeto original sin decoración
/// </summary>
public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Operación base ejecutada");
    }

    public string GetDescription()
    {
        return "Componente base";
    }
}