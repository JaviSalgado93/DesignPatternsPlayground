namespace DesignPatterns.Core.Structural.Bridge.Implementation;

public class Circle : Shape
{
    public Circle(IColor color) : base(color)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Dibujando círculo de color {_color.Fill()}");
    }
}