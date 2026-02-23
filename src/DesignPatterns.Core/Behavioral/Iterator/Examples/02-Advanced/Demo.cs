namespace DesignPatterns.Core.Behavioral.Iterator.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Iterator Pattern - Ejemplo Avanzado: Product Catalog ===\n");

        var catalog = new ProductCatalog();

        Console.WriteLine("--- Agregando productos ---");
        catalog.AddProduct(new Product(1, "Laptop", 999.99m, 5));
        catalog.AddProduct(new Product(2, "Mouse", 29.99m, 50));
        catalog.AddProduct(new Product(3, "Keyboard", 79.99m, 20));
        catalog.AddProduct(new Product(4, "Monitor", 299.99m, 10));
        catalog.AddProduct(new Product(5, "USB Cable", 9.99m, 100));

        Console.WriteLine($"\n--- Todos los productos (Total: {catalog.GetProductCount()}) ---");
        var iterator = catalog.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine($"  🛍️  {iterator.Next()}");
        }

        Console.WriteLine("\n--- Productos entre $50 y $300 ---");
        var priceIterator = catalog.CreateIteratorByPriceRange(50, 300);
        while (priceIterator.HasNext())
        {
            Console.WriteLine($"  💰 {priceIterator.Next()}");
        }

        Console.WriteLine("\n--- Productos con stock >= 15 unidades ---");
        var stockIterator = catalog.CreateIteratorByStock(15);
        while (stockIterator.HasNext())
        {
            Console.WriteLine($"  📦 {stockIterator.Next()}");
        }

        Console.WriteLine("\n--- Productos ordenados por precio ---");
        var sortedIterator = catalog.CreateIteratorSortedByPrice();
        while (sortedIterator.HasNext())
        {
            Console.WriteLine($"  💵 {sortedIterator.Next()}");
        }

        Console.WriteLine("\n Iterator permite múltiples formas de recorrido sin cambiar colección");
    }
}