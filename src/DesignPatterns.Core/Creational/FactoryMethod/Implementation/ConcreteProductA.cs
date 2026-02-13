namespace DesignPatterns.Core.Creational.FactoryMethod.Implementation;

public class ConcreteProductA : IProduct
{
    public string GetProductType()
    {
        return "Producto A";
    }

    public void Operation()
    {
        Console.WriteLine("[ProductA] Realizando operación específica de A");
    }
}