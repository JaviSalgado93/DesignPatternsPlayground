namespace DesignPatterns.Core.Structural.Bridge.Implementation;

public class Square : Shape
{
    public Square(IColor color) : base(color)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Dibujando cuadrado de color {_color.Fill()}");
    }
}