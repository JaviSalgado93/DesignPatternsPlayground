namespace DesignPatterns.Core.Creational.FactoryMethod.Examples._01_Basic;

/// <summary>
/// Ejemplo Básico: Factory para crear diferentes formas geométricas
/// </summary>

public interface IShape
{
    void Draw();
    double GetArea();
}

public class Circle : IShape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public void Draw()
    {
        Console.WriteLine($"[Circle] Dibujando círculo con radio: {_radius}");
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public class Rectangle : IShape
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"[Rectangle] Dibujando rectángulo: {_width}x{_height}");
    }

    public double GetArea()
    {
        return _width * _height;
    }
}

public class Triangle : IShape
{
    private double _base;
    private double _height;

    public Triangle(double baseValue, double height)
    {
        _base = baseValue;
        _height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"[Triangle] Dibujando triángulo: base={_base}, altura={_height}");
    }

    public double GetArea()
    {
        return (_base * _height) / 2;
    }
}

/// <summary>
/// Factory para crear formas
/// </summary>
public class ShapeFactory
{
    public static IShape CreateShape(string shapeType, params double[] dimensions)
    {
        return shapeType.ToLower() switch
        {
            "circle" => new Circle(dimensions[0]),
            "rectangle" => new Rectangle(dimensions[0], dimensions[1]),
            "triangle" => new Triangle(dimensions[0], dimensions[1]),
            _ => throw new ArgumentException($"Tipo de forma desconocida: {shapeType}")
        };
    }
}