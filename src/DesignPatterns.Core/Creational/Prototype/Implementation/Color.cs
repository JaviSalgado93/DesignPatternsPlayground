namespace DesignPatterns.Core.Creational.Prototype.Implementation;

public class Color : IPrototype
{
    public string Name { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public Color(string name, int red, int green, int blue)
    {
        Name = name;
        Red = red;
        Green = green;
        Blue = blue;
    }

    public IPrototype Clone()
    {
        return new Color(Name, Red, Green, Blue);
    }

    public override string ToString()
    {
        return $"Color: {Name} RGB({Red},{Green},{Blue})";
    }
}