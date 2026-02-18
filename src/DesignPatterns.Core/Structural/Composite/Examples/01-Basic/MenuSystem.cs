namespace DesignPatterns.Core.Structural.Composite.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Sistema de menús jerárquicos
/// </summary>

public interface IMenuItem
{
    string Name { get; }
    void Display(int indent = 0);
    void Execute();
}

/// <summary>
/// Hoja - Acción de menú
/// </summary>
public class MenuAction : IMenuItem
{
    public string Name { get; set; }
    private Action _action;

    public MenuAction(string name, Action action)
    {
        Name = name;
        _action = action;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"→ {Name}");
    }

    public void Execute()
    {
        _action?.Invoke();
    }
}

/// <summary>
/// Composite - Menú
/// </summary>
public class Menu : IMenuItem
{
    public string Name { get; set; }
    private List<IMenuItem> _items = new();

    public Menu(string name)
    {
        Name = name;
    }

    public void Add(IMenuItem item)
    {
        _items.Add(item);
    }

    public void Remove(IMenuItem item)
    {
        _items.Remove(item);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"📋 {Name}");
        foreach (var item in _items)
        {
            item.Display(indent + 2);
        }
    }

    public void Execute()
    {
        Display();
    }

    public void ExecuteItem(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            _items[index].Execute();
        }
    }
}