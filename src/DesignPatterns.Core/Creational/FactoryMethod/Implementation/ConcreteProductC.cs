namespace DesignPatterns.Core.Creational.FactoryMethod.Implementation;

public class ConcreteProductC : IProduct
{
    public string GetProductType()
    {
        return "Producto C";
    }

    public void Operation()
    {
        Console.WriteLine("[ProductC] Realizando operación específica de C");
    }
}