namespace DesignPatterns.Core.Creational.FactoryMethod.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Factory Method Pattern - Ejemplo Básico: Formas Geométricas ===\n");

        // Crear diferentes formas usando la factory
        var circle = ShapeFactory.CreateShape("circle", 5);
        var rectangle = ShapeFactory.CreateShape("rectangle", 4, 6);
        var triangle = ShapeFactory.CreateShape("triangle", 3, 8);

        // Lista de formas
        var shapes = new List<IShape> { circle, rectangle, triangle };

        Console.WriteLine("\nDibujando formas:\n");
        foreach (var shape in shapes)
        {
            shape.Draw();
        }

        Console.WriteLine("\nCalculando áreas:\n");
        foreach (var shape in shapes)
        {
            var area = shape.GetArea();
            Console.WriteLine($"Área: {area:F2}");
        }

        Console.WriteLine("\n La factory permite crear diferentes tipos sin saber la clase concreta");
    }
}