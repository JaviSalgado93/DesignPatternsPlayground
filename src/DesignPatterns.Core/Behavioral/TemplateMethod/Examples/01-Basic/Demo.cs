namespace DesignPatterns.Core.Behavioral.TemplateMethod.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Template Method Pattern - Ejemplo Básico: Cooking ===\n");

        var pasta = new Pasta();
        pasta.Cook();

        Console.WriteLine("─".PadRight(60, '─'));
        Console.WriteLine();

        var omelette = new Omelette();
        omelette.Cook();

        Console.WriteLine("─".PadRight(60, '─'));
        Console.WriteLine();

        var soup = new Soup();
        soup.Cook();

        Console.WriteLine(" Template Method define estructura, subclases definen detalles");
    }
}