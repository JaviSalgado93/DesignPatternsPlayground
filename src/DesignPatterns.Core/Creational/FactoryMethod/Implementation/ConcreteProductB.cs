namespace DesignPatterns.Core.Creational.FactoryMethod.Implementation;

public class ConcreteProductB : IProduct
{
    public string GetProductType()
    {
        return "Producto B";
    }

    public void Operation()
    {
        Console.WriteLine("[ProductB] Realizando operación específica de B");
    }
}