namespace DesignPatterns.Core.Structural.Flyweight.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Árbol compartido en un bosque
/// </summary>

public class TreeType // Intrínseco - Flyweight
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string Texture { get; set; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
        Console.WriteLine($"[TreeType] Creando tipo: {name} ({color}, {texture})");
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"🌳 {Name} en ({x}, {y}) - {Color} - {Texture}");
    }
}

public class Tree // Extrínseco
{
    public int X { get; set; }
    public int Y { get; set; }
    public TreeType Type { get; set; } // Compartido

    public Tree(int x, int y, TreeType type)
    {
        X = x;
        Y = y;
        Type = type;
    }

    public void Draw()
    {
        Type.Draw(X, Y);
    }
}

public class TreeFactory
{
    private Dictionary<string, TreeType> _treeTypes = new();

    public TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}:{color}:{texture}";

        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }
        else
        {
            Console.WriteLine($"[Factory] Reutilizando tipo: {name}");
        }

        return _treeTypes[key];
    }

    public int GetTreeTypeCount() => _treeTypes.Count;
}

public class Forest
{
    private List<Tree> _trees = new();
    private TreeFactory _factory = new();

    public void PlantTree(int x, int y, string name, string color, string texture)
    {
        var type = _factory.GetTreeType(name, color, texture);
        var tree = new Tree(x, y, type);
        _trees.Add(tree);
    }

    public void Draw()
    {
        Console.WriteLine("\n--- Dibujando bosque ---");
        foreach (var tree in _trees)
        {
            tree.Draw();
        }
    }

    public int GetTreeCount() => _trees.Count;
    public int GetTreeTypeCount() => _factory.GetTreeTypeCount();
}