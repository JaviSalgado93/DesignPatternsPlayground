namespace DesignPatterns.Core.Structural.Decorator.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Sistema de café con ingredientes
/// </summary>

public interface ICoffee
{
    double GetCost();
    string GetDescription();
}

/// <summary>
/// Componente - Café base
/// </summary>
public class SimpleCoffee : ICoffee
{
    public double GetCost()
    {
        return 5.0;
    }

    public string GetDescription()
    {
        return "Café simple";
    }
}

/// <summary>
/// Decorador base
/// </summary>
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }
}

/// <summary>
/// Decoradores concretos
/// </summary>
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", leche";
    }
}

public class VanillaDecorator : CoffeeDecorator
{
    public VanillaDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.75;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", vainilla";
    }
}

public class CaramelDecorator : CoffeeDecorator
{
    public CaramelDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.75;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", caramelo";
    }
}

public class WhippedCreamDecorator : CoffeeDecorator
{
    public WhippedCreamDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double GetCost()
    {
        return base.GetCost() + 1.0;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", crema batida";
    }
}