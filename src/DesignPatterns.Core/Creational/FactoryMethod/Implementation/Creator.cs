namespace DesignPatterns.Core.Creational.FactoryMethod.Implementation;

/// <summary>
/// Clase abstracta que define el Factory Method
/// </summary>
public abstract class Creator
{
    /// <summary>
    /// Factory Method - cada subclase decide qué producto crear
    /// </summary>
    public abstract IProduct FactoryMethod();

    /// <summary>
    /// Lógica que usa el producto creado
    /// </summary>
    public void BusinessLogic()
    {
        var product = FactoryMethod();
        Console.WriteLine($"[Creator] Creado: {product.GetProductType()}");
        product.Operation();
    }
}

/// <summary>
/// Creador concreto A - crea productos de tipo A
/// </summary>
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

/// <summary>
/// Creador concreto B - crea productos de tipo B
/// </summary>
public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

/// <summary>
/// Creador concreto C - crea productos de tipo C
/// </summary>
public class ConcreteCreatorC : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductC();
    }
}