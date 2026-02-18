namespace DesignPatterns.Core.Structural.Bridge.Implementation;

public class Triangle : Shape
{
    public Triangle(IColor color) : base(color)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Dibujando triángulo de color {_color.Fill()}");
    }
}