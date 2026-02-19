namespace DesignPatterns.Core.Behavioral.Command.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Editor de texto con undo/redo
/// </summary>

public interface IEditorCommand
{
    void Execute();
    void Undo();
}

public class TextDocument
{
    private string _content = "";

    public void Insert(int position, string text)
    {
        if (position >= 0 && position <= _content.Length)
        {
            _content = _content.Insert(position, text);
            Console.WriteLine($"[Document] Insertado: '{text}' en posición {position}");
        }
    }

    public void Delete(int position, int length)
    {
        if (position >= 0 && position + length <= _content.Length)
        {
            _content = _content.Remove(position, length);
            Console.WriteLine($"[Document] Eliminado {length} caracteres desde {position}");
        }
    }

    public void Replace(int position, int length, string text)
    {
        Delete(position, length);
        Insert(position, text);
    }

    public string GetContent() => _content;
    public void Clear() => _content = "";
}

public class InsertTextCommand : IEditorCommand
{
    private TextDocument _document;
    private int _position;
    private string _text;

    public InsertTextCommand(TextDocument document, int position, string text)
    {
        _document = document;
        _position = position;
        _text = text;
    }

    public void Execute() => _document.Insert(_position, _text);

    public void Undo() => _document.Delete(_position, _text.Length);
}

public class DeleteTextCommand : IEditorCommand
{
    private TextDocument _document;
    private int _position;
    private int _length;
    private string _deletedText;

    public DeleteTextCommand(TextDocument document, int position, int length)
    {
        _document = document;
        _position = position;
        _length = length;
    }

    public void Execute()
    {
        _deletedText = _document.GetContent().Substring(_position, _length);
        _document.Delete(_position, _length);
    }

    public void Undo() => _document.Insert(_position, _deletedText);
}

public class ReplaceTextCommand : IEditorCommand
{
    private TextDocument _document;
    private int _position;
    private int _length;
    private string _newText;
    private string _oldText;

    public ReplaceTextCommand(TextDocument document, int position, int length, string newText)
    {
        _document = document;
        _position = position;
        _length = length;
        _newText = newText;
    }

    public void Execute()
    {
        _oldText = _document.GetContent().Substring(_position, _length);
        _document.Replace(_position, _length, _newText);
    }

    public void Undo()
    {
        _document.Replace(_position, _newText.Length, _oldText);
    }
}

public class TextEditorInvoker
{
    private Stack<IEditorCommand> _commands = new();
    private Stack<IEditorCommand> _undoStack = new();

    public void Execute(IEditorCommand command)
    {
        command.Execute();
        _commands.Push(command);
        _undoStack.Clear();
    }

    public void Undo()
    {
        if (_commands.Count > 0)
        {
            var command = _commands.Pop();
            command.Undo();
            _undoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Execute();
            _commands.Push(command);
        }
    }

    public int GetHistorySize() => _commands.Count;
}