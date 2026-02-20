namespace DesignPatterns.Core.Behavioral.Memento.Implementation;

/// <summary>
/// AdvancedMemento - Almacena múltiples propiedades
/// </summary>
public class AdvancedMemento
{
    public string State { get; }
    public Dictionary<string, object> Properties { get; }
    public DateTime Timestamp { get; }
    public string Description { get; }

    public AdvancedMemento(string state, Dictionary<string, object> properties, string description = "")
    {
        State = state;
        Properties = new Dictionary<string, object>(properties);
        Timestamp = DateTime.Now;
        Description = description;
    }

    public override string ToString()
    {
        var propStr = string.Join(", ", Properties.Select(p => $"{p.Key}={p.Value}"));
        return $"Estado: {State} ({propStr}) - {Description}";
    }
}

/// <summary>
/// AdvancedOriginator - Objeto complejo con múltiples propiedades
/// </summary>
public class AdvancedOriginator
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Version { get; set; }
    public string Author { get; set; }

    public AdvancedOriginator()
    {
        Title = "Documento sin título";
        Content = "";
        Version = 1;
        Author = "Anónimo";
    }

    public AdvancedMemento CreateMemento(string description = "")
    {
        var properties = new Dictionary<string, object>
        {
            { "Title", Title },
            { "Content", Content },
            { "Version", Version },
            { "Author", Author }
        };

        Console.WriteLine($"[AdvancedOriginator] Creando memento: {description}");
        return new AdvancedMemento($"v{Version}", properties, description);
    }

    public void RestoreFromMemento(AdvancedMemento memento)
    {
        if (memento.Properties.ContainsKey("Title"))
            Title = (string)memento.Properties["Title"];
        if (memento.Properties.ContainsKey("Content"))
            Content = (string)memento.Properties["Content"];
        if (memento.Properties.ContainsKey("Version"))
            Version = (int)memento.Properties["Version"];
        if (memento.Properties.ContainsKey("Author"))
            Author = (string)memento.Properties["Author"];

        Console.WriteLine($"[AdvancedOriginator] Restaurado: {memento.Description}");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Título: {Title}");
        Console.WriteLine($"Contenido: {Content}");
        Console.WriteLine($"Versión: {Version}");
        Console.WriteLine($"Autor: {Author}");
    }
}

/// <summary>
/// AdvancedCaretaker - Gestiona historial avanzado
/// </summary>
public class AdvancedCaretaker
{
    private Stack<AdvancedMemento> _undoStack = new();
    private Stack<AdvancedMemento> _redoStack = new();

    public void SaveMemento(AdvancedMemento memento)
    {
        _undoStack.Push(memento);
        _redoStack.Clear(); // Limpiar redo cuando se crea nuevo memento
        Console.WriteLine($"[AdvancedCaretaker] Memento guardado");
    }

    public AdvancedMemento Undo()
    {
        if (_undoStack.Count > 0)
        {
            var memento = _undoStack.Pop();
            _redoStack.Push(memento);
            Console.WriteLine("[AdvancedCaretaker] Deshacer realizado");
            return memento;
        }
        throw new InvalidOperationException("No hay acciones para deshacer");
    }

    public AdvancedMemento Redo()
    {
        if (_redoStack.Count > 0)
        {
            var memento = _redoStack.Pop();
            _undoStack.Push(memento);
            Console.WriteLine("[AdvancedCaretaker] Rehacer realizado");
            return memento;
        }
        throw new InvalidOperationException("No hay acciones para rehacer");
    }

    public bool CanUndo() => _undoStack.Count > 0;
    public bool CanRedo() => _redoStack.Count > 0;
}