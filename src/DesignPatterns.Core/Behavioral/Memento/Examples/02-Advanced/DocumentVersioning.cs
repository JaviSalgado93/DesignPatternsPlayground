namespace DesignPatterns.Core.Behavioral.Memento.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Sistema de versionado de documentos
/// </summary>

public class DocumentMemento
{
    public string Title { get; }
    public string Content { get; }
    public string Author { get; }
    public int Version { get; }
    public DateTime CreatedAt { get; }

    public DocumentMemento(string title, string content, string author, int version)
    {
        Title = title;
        Content = content;
        Author = author;
        Version = version;
        CreatedAt = DateTime.Now;
    }

    public override string ToString()
    {
        return $"v{Version}: '{Title}' por {Author} ({CreatedAt:yyyy-MM-dd HH:mm:ss})";
    }
}

public class Document
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public int Version { get; set; }

    public Document(string title, string author)
    {
        Title = title;
        Author = author;
        Content = "";
        Version = 1;
    }

    public void Edit(string newContent)
    {
        Content = newContent;
        Version++;
        Console.WriteLine($"[Document] Editado v{Version}: {Title}");
    }

    public DocumentMemento CreateVersion(string description = "")
    {
        Console.WriteLine($"[Document] Versión v{Version} guardada");
        return new DocumentMemento(Title, Content, Author, Version);
    }

    public void RestoreVersion(DocumentMemento memento)
    {
        Title = memento.Title;
        Content = memento.Content;
        Author = memento.Author;
        Version = memento.Version;
        Console.WriteLine($"[Document] Restaurado a v{Version}");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"\nTítulo: {Title}");
        Console.WriteLine($"Autor: {Author}");
        Console.WriteLine($"Versión: {Version}");
        Console.WriteLine($"Contenido: {Content}");
    }
}

public class DocumentHistory
{
    private Dictionary<int, DocumentMemento> _versions = new();
    private int _versionCount = 0;

    public void SaveVersion(DocumentMemento memento)
    {
        _versionCount++;
        _versions[_versionCount] = memento;
        Console.WriteLine($"[History] Versión {_versionCount} guardada");
    }

    public DocumentMemento GetVersion(int versionNumber)
    {
        if (_versions.ContainsKey(versionNumber))
            return _versions[versionNumber];
        throw new ArgumentException($"Versión {versionNumber} no existe");
    }

    public void ShowVersionHistory()
    {
        Console.WriteLine("\n[History] Historial de versiones:");
        foreach (var kvp in _versions.OrderByDescending(x => x.Key))
        {
            Console.WriteLine($"  v{kvp.Key}: {kvp.Value}");
        }
    }

    public int GetVersionCount() => _versionCount;
}