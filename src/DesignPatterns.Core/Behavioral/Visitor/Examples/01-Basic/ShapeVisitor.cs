namespace DesignPatterns.Core.Behavioral.Visitor.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Operaciones en figuras geométricas
/// </summary>

public interface IShape
{
    void Accept(IShapeVisitor visitor);
    string GetName();
}

public interface IShapeVisitor
{
    void VisitCircle(Circle circle);
    void VisitRectangle(Rectangle rectangle);
    void VisitTriangle(Triangle triangle);
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitCircle(this);
    }

    public string GetName() => "Círculo";
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitRectangle(this);
    }

    public string GetName() => "Rectángulo";
}

public class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitTriangle(this);
    }

    public string GetName() => "Triángulo";
}

/// <summary>
/// Visitor para calcular área
/// </summary>
public class AreaCalculator : IShapeVisitor
{
    public void VisitCircle(Circle circle)
    {
        double area = Math.PI * circle.Radius * circle.Radius;
        Console.WriteLine($"  📐 Área del {circle.GetName()}: {area:F2}");
    }

    public void VisitRectangle(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"  📐 Área del {rectangle.GetName()}: {area:F2}");
    }

    public void VisitTriangle(Triangle triangle)
    {
        double s = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
        double area = Math.Sqrt(s * (s - triangle.SideA) * (s - triangle.SideB) * (s - triangle.SideC));
        Console.WriteLine($"  📐 Área del {triangle.GetName()}: {area:F2}");
    }
}

/// <summary>
/// Visitor para calcular perímetro
/// </summary>
public class PerimeterCalculator : IShapeVisitor
{
    public void VisitCircle(Circle circle)
    {
        double perimeter = 2 * Math.PI * circle.Radius;
        Console.WriteLine($"  📏 Perímetro del {circle.GetName()}: {perimeter:F2}");
    }

    public void VisitRectangle(Rectangle rectangle)
    {
        double perimeter = 2 * (rectangle.Width + rectangle.Height);
        Console.WriteLine($"  📏 Perímetro del {rectangle.GetName()}: {perimeter:F2}");
    }

    public void VisitTriangle(Triangle triangle)
    {
        double perimeter = triangle.SideA + triangle.SideB + triangle.SideC;
        Console.WriteLine($"  📏 Perímetro del {triangle.GetName()}: {perimeter:F2}");
    }
}

/// <summary>
/// Colección de figuras
/// </summary>
public class Drawing
{
    private List<IShape> _shapes = new();

    public void Add(IShape shape)
    {
        _shapes.Add(shape);
    }

    public void Accept(IShapeVisitor visitor)
    {
        foreach (var shape in _shapes)
        {
            shape.Accept(visitor);
        }
    }
}