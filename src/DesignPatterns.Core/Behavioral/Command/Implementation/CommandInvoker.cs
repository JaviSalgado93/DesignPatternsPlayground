namespace DesignPatterns.Core.Behavioral.Command.Implementation;

/// <summary>
/// Invoker - Ejecuta y maneja historial de comandos
/// </summary>
public class CommandInvoker
{
    private Stack<ICommand> _history = new();
    private Stack<ICommand> _undoHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
        _undoHistory.Clear(); // Limpiar redo cuando se ejecuta nuevo comando
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            var command = _history.Pop();
            command.Undo();
            _undoHistory.Push(command);
            Console.WriteLine("[Invoker] Deshacer realizado");
        }
        else
        {
            Console.WriteLine("[Invoker] No hay comandos para deshacer");
        }
    }

    public void Redo()
    {
        if (_undoHistory.Count > 0)
        {
            var command = _undoHistory.Pop();
            command.Execute();
            _history.Push(command);
            Console.WriteLine("[Invoker] Rehacer realizado");
        }
        else
        {
            Console.WriteLine("[Invoker] No hay comandos para rehacer");
        }
    }

    public int GetHistoryCount() => _history.Count;
}