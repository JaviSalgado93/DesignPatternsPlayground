namespace DesignPatterns.Core.Behavioral.Iterator.Implementation;

/// <summary>
/// ReverseIterator - Itera en orden inverso
/// </summary>
public class ReverseIterator<T> : IIterator<T>
{
    private List<T> _items;
    private int _current;

    public ReverseIterator(List<T> items)
    {
        _items = items;
        _current = items.Count - 1;
    }

    public bool HasNext() => _current >= 0;

    public T Next()
    {
        if (!HasNext())
            throw new InvalidOperationException("No hay más elementos");

        return _items[_current--];
    }

    public void Reset() => _current = _items.Count - 1;
}

/// <summary>
/// FilterIterator - Itera filtrando elementos
/// </summary>
public class FilterIterator<T> : IIterator<T>
{
    private List<T> _items;
    private Func<T, bool> _predicate;
    private int _current = 0;

    public FilterIterator(List<T> items, Func<T, bool> predicate)
    {
        _items = items;
        _predicate = predicate;
    }

    public bool HasNext()
    {
        while (_current < _items.Count)
        {
            if (_predicate(_items[_current]))
                return true;
            _current++;
        }
        return false;
    }

    public T Next()
    {
        if (!HasNext())
            throw new InvalidOperationException("No hay más elementos");

        return _items[_current++];
    }

    public void Reset() => _current = 0;
}

/// <summary>
/// StepIterator - Itera saltando elementos
/// </summary>
public class StepIterator<T> : IIterator<T>
{
    private List<T> _items;
    private int _step;
    private int _current = 0;

    public StepIterator(List<T> items, int step)
    {
        _items = items;
        _step = step;
    }

    public bool HasNext() => _current < _items.Count;

    public T Next()
    {
        if (!HasNext())
            throw new InvalidOperationException("No hay más elementos");

        var item = _items[_current];
        _current += _step;
        return item;
    }

    public void Reset() => _current = 0;
}