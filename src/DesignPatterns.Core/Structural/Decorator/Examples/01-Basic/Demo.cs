namespace DesignPatterns.Core.Structural.Decorator.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Decorator Pattern - Ejemplo Básico: Coffee Shop ===\n");

        // Café simple
        Console.WriteLine("--- Café simple ---");
        ICoffee coffee1 = new SimpleCoffee();
        Console.WriteLine($"{coffee1.GetDescription()} = ${coffee1.GetCost():F2}");

        // Café con leche
        Console.WriteLine("\n--- Café con leche ---");
        ICoffee coffee2 = new MilkDecorator(new SimpleCoffee());
        Console.WriteLine($"{coffee2.GetDescription()} = ${coffee2.GetCost():F2}");

        // Café con leche y vainilla
        Console.WriteLine("\n--- Café con leche y vainilla ---");
        ICoffee coffee3 = new VanillaDecorator(new MilkDecorator(new SimpleCoffee()));
        Console.WriteLine($"{coffee3.GetDescription()} = ${coffee3.GetCost():F2}");

        // Café con todo (leche, vainilla, caramelo, crema batida)
        Console.WriteLine("\n--- Café deluxe (leche, vainilla, caramelo, crema) ---");
        ICoffee coffee4 = new WhippedCreamDecorator(
            new CaramelDecorator(
                new VanillaDecorator(
                    new MilkDecorator(
                        new SimpleCoffee()
                    )
                )
            )
        );
        Console.WriteLine($"{coffee4.GetDescription()} = ${coffee4.GetCost():F2}");

        // Combinación diferente
        Console.WriteLine("\n--- Combinación personalizada ---");
        ICoffee coffee5 = new CaramelDecorator(new CaramelDecorator(new SimpleCoffee()));
        Console.WriteLine($"{coffee5.GetDescription()} = ${coffee5.GetCost():F2}");

        Console.WriteLine("\n✅ Decorator permite combinar comportamientos dinámicamente");
    }
}