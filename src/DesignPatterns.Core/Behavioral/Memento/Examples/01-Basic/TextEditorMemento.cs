namespace DesignPatterns.Core.Behavioral.Memento.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Editor de texto con snapshots
/// </summary>

public class EditorMemento
{
    public string Content { get; }
    public DateTime SavedAt { get; }

    public EditorMemento(string content)
    {
        Content = content;
        SavedAt = DateTime.Now;
    }
}

public class TextEditor
{
    private string _content = "";

    public string Content
    {
        get => _content;
        set => _content = value;
    }

    public void Write(string text)
    {
        _content += text;
        Console.WriteLine($"[Editor] Escrito: '{text}'");
    }

    public void Clear()
    {
        _content = "";
        Console.WriteLine("[Editor] Contenido limpiado");
    }

    public EditorMemento CreateSnapshot()
    {
        Console.WriteLine($"[Editor] Snapshot guardado: '{_content}'");
        return new EditorMemento(_content);
    }

    public void RestoreFromSnapshot(EditorMemento memento)
    {
        _content = memento.Content;
        Console.WriteLine($"[Editor] Restaurado desde snapshot: '{_content}'");
    }

    public void ShowContent()
    {
        Console.WriteLine($"Contenido actual: '{_content}'");
    }
}

public class EditorHistory
{
    private List<EditorMemento> _snapshots = new();

    public void Save(EditorMemento memento)
    {
        _snapshots.Add(memento);
        Console.WriteLine($"[History] Snapshot guardado. Total: {_snapshots.Count}");
    }

    public EditorMemento Get(int index)
    {
        if (index >= 0 && index < _snapshots.Count)
            return _snapshots[index];
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public int GetCount() => _snapshots.Count;

    public void ShowSnapshots()
    {
        Console.WriteLine("\n[History] Snapshots disponibles:");
        for (int i = 0; i < _snapshots.Count; i++)
        {
            Console.WriteLine($"  {i}: '{_snapshots[i].Content}' - {_snapshots[i].SavedAt:HH:mm:ss}");
        }
    }
}