namespace DesignPatterns.Core.Behavioral.Visitor.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Visitor Pattern - Ejemplo Básico: Shapes ===\n");

        var drawing = new Drawing();
        drawing.Add(new Circle(5));
        drawing.Add(new Rectangle(4, 6));
        drawing.Add(new Triangle(3, 4, 5));

        Console.WriteLine("--- Calculando áreas ---");
        drawing.Accept(new AreaCalculator());

        Console.WriteLine("\n--- Calculando perímetros ---");
        drawing.Accept(new PerimeterCalculator());

        Console.WriteLine("\n Visitor permite agregar operaciones sin modificar figuras");
    }
}