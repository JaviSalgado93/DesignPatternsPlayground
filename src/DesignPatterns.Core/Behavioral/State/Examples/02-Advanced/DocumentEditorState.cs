namespace DesignPatterns.Core.Behavioral.State.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Editor de documentos con estados
/// </summary>

public interface IDocumentState
{
    void Save(Document document);
    void Close(Document document);
    void Edit(Document document, string content);
    string GetStateName();
}

public class Document
{
    private IDocumentState _state;
    private string _content = "";
    private bool _isModified = false;

    public string Content => _content;
    public bool IsModified => _isModified;

    public Document()
    {
        _state = new ReadOnlyState();
        Console.WriteLine("[Document] Inicializado en estado ReadOnly");
    }

    public void SetState(IDocumentState state)
    {
        var oldState = _state.GetStateName();
        _state = state;
        Console.WriteLine($"[Document] Transición: {oldState} → {_state.GetStateName()}");
    }

    public void Edit(string content)
    {
        _state.Edit(this, content);
    }

    public void Save()
    {
        _state.Save(this);
    }

    public void Close()
    {
        _state.Close(this);
    }

    public void SetContent(string content)
    {
        _content = content;
        _isModified = true;
    }

    public void SaveContent()
    {
        _isModified = false;
        Console.WriteLine($"  ✓ Documento guardado: '{_content}'");
    }

    public string GetCurrentState() => _state.GetStateName();
}

public class ReadOnlyState : IDocumentState
{
    public void Edit(Document document, string content)
    {
        Console.WriteLine("  ✓ Desbloqueando documento");
        document.SetState(new EditingState());
        document.Edit(content);
    }

    public void Save(Document document)
    {
        Console.WriteLine("  ✗ No se puede guardar en modo readonly");
    }

    public void Close(Document document)
    {
        Console.WriteLine("  ✓ Cerrando documento readonly");
    }

    public string GetStateName() => "ReadOnly";
}

public class EditingState : IDocumentState
{
    public void Edit(Document document, string content)
    {
        Console.WriteLine($"  ✓ Editando: '{content}'");
        document.SetContent(content);
    }

    public void Save(Document document)
    {
        Console.WriteLine("  ✓ Guardando documento");
        document.SaveContent();
        document.SetState(new ReadOnlyState());
    }

    public void Close(Document document)
    {
        if (document.IsModified)
        {
            Console.WriteLine("  ✗ Hay cambios sin guardar");
            Console.WriteLine("  → Guardando automáticamente");
            document.SaveContent();
        }
        document.SetState(new ClosedState());
    }

    public string GetStateName() => "Editing";
}

public class ClosedState : IDocumentState
{
    public void Edit(Document document, string content)
    {
        Console.WriteLine("  ✗ No se puede editar documento cerrado");
    }

    public void Save(Document document)
    {
        Console.WriteLine("  ✗ No se puede guardar documento cerrado");
    }

    public void Close(Document document)
    {
        Console.WriteLine("  ✓ Documento ya está cerrado");
    }

    public string GetStateName() => "Closed";
}

public class VersioningState : IDocumentState
{
    private int _version = 1;

    public void Edit(Document document, string content)
    {
        _version++;
        Console.WriteLine($"  ✓ Editando (v{_version}): '{content}'");
        document.SetContent(content);
    }

    public void Save(Document document)
    {
        Console.WriteLine($"  ✓ Guardando versión {_version}");
        document.SaveContent();
    }

    public void Close(Document document)
    {
        Console.WriteLine($"  ✓ Cerrando documento (v{_version})");
    }

    public string GetStateName() => $"Versioning (v{_version})";
}