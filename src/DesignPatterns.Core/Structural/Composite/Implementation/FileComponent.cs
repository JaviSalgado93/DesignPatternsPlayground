namespace DesignPatterns.Core.Structural.Composite.Implementation;

/// <summary>
/// Leaf - Objeto sin hijos
/// </summary>
public class FileComponent : IComponent
{
    public string Name { get; set; }
    public int Size { get; set; }

    public FileComponent(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"📄 {Name} ({Size} KB)");
    }

    public int GetSize()
    {
        return Size;
    }
}