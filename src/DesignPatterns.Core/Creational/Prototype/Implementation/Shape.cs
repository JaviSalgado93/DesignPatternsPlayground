namespace DesignPatterns.Core.Creational.Prototype.Implementation;

public class Shape : IPrototype
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Shape(string name, Color color, int width, int height)
    {
        Name = name;
        Color = color;
        Width = width;
        Height = height;
    }

    public IPrototype Clone()
    {
        // Clone profundo: clonar también el color
        var clonedColor = Color.Clone() as Color;
        return new Shape(Name, clonedColor, Width, Height);
    }

    public override string ToString()
    {
        return $"Shape: {Name} {Width}x{Height} - {Color}";
    }
}