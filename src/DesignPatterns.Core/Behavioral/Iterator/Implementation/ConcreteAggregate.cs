namespace DesignPatterns.Core.Behavioral.Iterator.Implementation;

/// <summary>
/// ConcreteAggregate - Colección que crea iteradores
/// </summary>
public class ConcreteAggregate<T> : IAggregate<T>
{
    private List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
        Console.WriteLine($"[Aggregate] Elemento agregado: {item}");
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        Console.WriteLine($"[Aggregate] Elemento removido: {item}");
    }

    public T GetItem(int index) => _items[index];

    public int GetCount() => _items.Count;

    public IIterator<T> CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    /// <summary>
    /// ConcreteIterator - Implementa iteración forward
    /// </summary>
    private class ConcreteIterator : IIterator<T>
    {
        private ConcreteAggregate<T> _aggregate;
        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public bool HasNext()
        {
            return _current < _aggregate.GetCount();
        }

        public T Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No hay más elementos");

            return _aggregate.GetItem(_current++);
        }

        public void Reset()
        {
            _current = 0;
            Console.WriteLine("[ConcreteIterator] Reiniciando iteración");
        }
    }
}