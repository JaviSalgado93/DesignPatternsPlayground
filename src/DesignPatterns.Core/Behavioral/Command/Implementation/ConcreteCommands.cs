namespace DesignPatterns.Core.Behavioral.Command.Implementation;

/// <summary>
/// ConcreteCommands - Implementan operaciones específicas
/// </summary>

public class AddCommand : ICommand
{
    private Receiver _receiver;
    private int _amount;
    private int _previousValue;

    public AddCommand(Receiver receiver, int amount)
    {
        _receiver = receiver;
        _amount = amount;
    }

    public void Execute()
    {
        _previousValue = _receiver.GetValue();
        _receiver.Add(_amount);
    }

    public void Undo()
    {
        _receiver.Subtract(_amount);
    }
}

public class SubtractCommand : ICommand
{
    private Receiver _receiver;
    private int _amount;

    public SubtractCommand(Receiver receiver, int amount)
    {
        _receiver = receiver;
        _amount = amount;
    }

    public void Execute()
    {
        _receiver.Subtract(_amount);
    }

    public void Undo()
    {
        _receiver.Add(_amount);
    }
}

public class MultiplyCommand : ICommand
{
    private Receiver _receiver;
    private int _amount;
    private int _previousValue;

    public MultiplyCommand(Receiver receiver, int amount)
    {
        _receiver = receiver;
        _amount = amount;
    }

    public void Execute()
    {
        _previousValue = _receiver.GetValue();
        _receiver.Multiply(_amount);
    }

    public void Undo()
    {
        if (_previousValue == 0)
            _receiver.Reset();
        else
            Console.WriteLine($"[Undo] Restaurando a {_previousValue}");
    }
}

public class ResetCommand : ICommand
{
    private Receiver _receiver;
    private int _previousValue;

    public ResetCommand(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _previousValue = _receiver.GetValue();
        _receiver.Reset();
    }

    public void Undo()
    {
        Console.WriteLine($"[Undo] Restaurando a {_previousValue}");
    }
}