namespace DesignPatterns.Core.Structural.Composite.Implementation;

/// <summary>
/// Composite - Objeto que puede contener hijos
/// </summary>
public class DirectoryComponent : IComponent
{
    public string Name { get; set; }
    private List<IComponent> _children = new();

    public DirectoryComponent(string name)
    {
        Name = name;
    }

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"📁 {Name}/");
        foreach (var child in _children)
        {
            child.Display(indent + 2);
        }
    }

    public int GetSize()
    {
        return _children.Sum(c => c.GetSize());
    }
}