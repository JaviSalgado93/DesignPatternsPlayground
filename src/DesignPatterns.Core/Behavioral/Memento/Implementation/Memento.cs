namespace DesignPatterns.Core.Behavioral.Memento.Implementation;

/// <summary>
/// Memento - Almacena estado del Originator
/// </summary>
public class Memento
{
    private readonly string _state;
    private readonly DateTime _timestamp;

    public string State => _state;
    public DateTime Timestamp => _timestamp;

    public Memento(string state)
    {
        _state = state;
        _timestamp = DateTime.Now;
    }

    public override string ToString() => $"Estado: {_state} (Guardado: {_timestamp:yyyy-MM-dd HH:mm:ss})";
}

/// <summary>
/// Originator - Crea mementos y restaura estados
/// </summary>
public class Originator
{
    private string _state;

    public string State
    {
        get => _state;
        set
        {
            _state = value;
            Console.WriteLine($"[Originator] Estado establecido a: {_state}");
        }
    }

    public Memento CreateMemento()
    {
        Console.WriteLine($"[Originator] Creando memento con estado: {_state}");
        return new Memento(_state);
    }

    public void RestoreFromMemento(Memento memento)
    {
        _state = memento.State;
        Console.WriteLine($"[Originator] Restaurado estado desde memento: {_state}");
    }
}

/// <summary>
/// Caretaker - Gestiona historial de mementos
/// </summary>
public class Caretaker
{
    private List<Memento> _mementos = new();

    public void SaveMemento(Memento memento)
    {
        _mementos.Add(memento);
        Console.WriteLine($"[Caretaker] Memento guardado. Total: {_mementos.Count}");
    }

    public Memento GetMemento(int index)
    {
        if (index >= 0 && index < _mementos.Count)
        {
            return _mementos[index];
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public Memento GetLatestMemento()
    {
        if (_mementos.Count > 0)
        {
            return _mementos[_mementos.Count - 1];
        }
        throw new InvalidOperationException("No hay mementos guardados");
    }

    public int GetMementoCount() => _mementos.Count;

    public void ShowHistory()
    {
        Console.WriteLine("\n[Caretaker] Historial de mementos:");
        for (int i = 0; i < _mementos.Count; i++)
        {
            Console.WriteLine($"  {i}: {_mementos[i]}");
        }
    }
}