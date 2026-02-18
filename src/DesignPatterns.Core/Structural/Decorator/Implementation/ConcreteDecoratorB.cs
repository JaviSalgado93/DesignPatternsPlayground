namespace DesignPatterns.Core.Structural.Decorator.Implementation;

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("[Decorador B] Funcionalidad adicional");
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " + Decorador B";
    }
}