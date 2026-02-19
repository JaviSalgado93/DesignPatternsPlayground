namespace DesignPatterns.Core.Behavioral.Command.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Calculadora con undo/redo
/// </summary>

public interface ICalculatorCommand
{
    void Execute();
    void Undo();
}

public class Calculator
{
    private int _value = 0;

    public void Add(int amount) => _value += amount;
    public void Subtract(int amount) => _value -= amount;
    public int GetValue() => _value;
    public void Reset() => _value = 0;
}

public class AddCalculatorCommand : ICalculatorCommand
{
    private Calculator _calculator;
    private int _amount;

    public AddCalculatorCommand(Calculator calculator, int amount)
    {
        _calculator = calculator;
        _amount = amount;
    }

    public void Execute()
    {
        _calculator.Add(_amount);
        Console.WriteLine($"Sumado {_amount}. Resultado: {_calculator.GetValue()}");
    }

    public void Undo()
    {
        _calculator.Subtract(_amount);
        Console.WriteLine($"Deshacer suma. Resultado: {_calculator.GetValue()}");
    }
}

public class SubtractCalculatorCommand : ICalculatorCommand
{
    private Calculator _calculator;
    private int _amount;

    public SubtractCalculatorCommand(Calculator calculator, int amount)
    {
        _calculator = calculator;
        _amount = amount;
    }

    public void Execute()
    {
        _calculator.Subtract(_amount);
        Console.WriteLine($"Restado {_amount}. Resultado: {_calculator.GetValue()}");
    }

    public void Undo()
    {
        _calculator.Add(_amount);
        Console.WriteLine($"Deshacer resta. Resultado: {_calculator.GetValue()}");
    }
}

public class CalculatorInvoker
{
    private Stack<ICalculatorCommand> _commands = new();
    private Stack<ICalculatorCommand> _undoCommands = new();

    public void ExecuteCommand(ICalculatorCommand command)
    {
        command.Execute();
        _commands.Push(command);
        _undoCommands.Clear();
    }

    public void Undo()
    {
        if (_commands.Count > 0)
        {
            var command = _commands.Pop();
            command.Undo();
            _undoCommands.Push(command);
        }
    }

    public void Redo()
    {
        if (_undoCommands.Count > 0)
        {
            var command = _undoCommands.Pop();
            command.Execute();
            _commands.Push(command);
        }
    }
}