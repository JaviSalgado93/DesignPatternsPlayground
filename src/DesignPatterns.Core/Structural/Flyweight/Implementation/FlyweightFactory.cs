namespace DesignPatterns.Core.Structural.Flyweight.Implementation;

/// <summary>
/// FlyweightFactory - Crea y cachea flyweights
/// </summary>
public class FlyweightFactory
{
    private Dictionary<string, IFlyweight> _flyweights = new();

    public IFlyweight GetFlyweight(string key)
    {
        if (!_flyweights.ContainsKey(key))
        {
            Console.WriteLine($"[Factory] Creando nuevo Flyweight: {key}");
            _flyweights[key] = new ConcreteFlyweight(key);
        }
        else
        {
            Console.WriteLine($"[Factory] Reutilizando Flyweight: {key}");
        }

        return _flyweights[key];
    }

    public int GetFlyweightCount() => _flyweights.Count;
}