namespace DesignPatterns.Core.Creational.Prototype.Implementation;

public class PrototypeRegistry
{
    private Dictionary<string, IPrototype> _prototypes = new();

    public void Register(string key, IPrototype prototype)
    {
        _prototypes[key] = prototype;
    }

    public IPrototype GetClone(string key)
    {
        if (!_prototypes.ContainsKey(key))
            throw new ArgumentException($"Prototipo '{key}' no encontrado");

        return _prototypes[key].Clone();
    }

    public void ListPrototypes()
    {
        Console.WriteLine("\n=== Prototipos Registrados ===");
        foreach (var proto in _prototypes)
        {
            Console.WriteLine($"- {proto.Key}");
        }
    }
}