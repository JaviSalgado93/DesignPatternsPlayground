namespace DesignPatterns.Core.Structural.Decorator.Implementation;

public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("[Decorador A] Antes de la operación");
        base.Operation();
        Console.WriteLine("[Decorador A] Después de la operación");
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " + Decorador A";
    }
}