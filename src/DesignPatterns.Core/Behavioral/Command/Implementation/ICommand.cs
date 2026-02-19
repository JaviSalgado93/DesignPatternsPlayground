namespace DesignPatterns.Core.Behavioral.Command.Implementation;

/// <summary>
/// Command - Define interfaz para comandos
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}