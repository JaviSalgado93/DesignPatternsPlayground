namespace DesignPatterns.Core.Behavioral.Interpreter.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Interpretador de comandos para consola
/// </summary>

public interface ICommand
{
    void Execute();
    string GetDescription();
}

public class CommandContext
{
    private Dictionary<string, string> _variables = new();
    private List<string> _output = new();

    public void SetVariable(string name, string value)
    {
        _variables[name] = value;
        _output.Add($"Variable '{name}' establecida a '{value}'");
    }

    public string GetVariable(string name)
    {
        if (_variables.ContainsKey(name))
            return _variables[name];
        throw new InvalidOperationException($"Variable '{name}' no existe");
    }

    public void PrintVariable(string name)
    {
        string value = GetVariable(name);
        _output.Add($"{name} = {value}");
    }

    public void Print(string message)
    {
        _output.Add(message);
    }

    public List<string> GetOutput() => _output;

    public void Clear()
    {
        _output.Clear();
        _variables.Clear();
    }
}

/// <summary>
/// Comando: SET variable valor
/// </summary>
public class SetCommand : ICommand
{
    private CommandContext _context;
    private string _varName;
    private string _value;

    public SetCommand(CommandContext context, string varName, string value)
    {
        _context = context;
        _varName = varName;
        _value = value;
    }

    public void Execute()
    {
        _context.SetVariable(_varName, _value);
    }

    public string GetDescription() => $"SET {_varName} = {_value}";
}

/// <summary>
/// Comando: PRINT variable
/// </summary>
public class PrintCommand : ICommand
{
    private CommandContext _context;
    private string _varName;

    public PrintCommand(CommandContext context, string varName)
    {
        _context = context;
        _varName = varName;
    }

    public void Execute()
    {
        _context.PrintVariable(_varName);
    }

    public string GetDescription() => $"PRINT {_varName}";
}

/// <summary>
/// Comando: ECHO mensaje
/// </summary>
public class EchoCommand : ICommand
{
    private CommandContext _context;
    private string _message;

    public EchoCommand(CommandContext context, string message)
    {
        _context = context;
        _message = message;
    }

    public void Execute()
    {
        _context.Print(_message);
    }

    public string GetDescription() => $"ECHO {_message}";
}

/// <summary>
/// Comando: CLEAR
/// </summary>
public class ClearCommand : ICommand
{
    private CommandContext _context;

    public ClearCommand(CommandContext context)
    {
        _context = context;
    }

    public void Execute()
    {
        _context.Clear();
        _context.Print("Variables y salida limpiadas");
    }

    public string GetDescription() => "CLEAR";
}

/// <summary>
/// Parser de comandos
/// </summary>
public class CommandInterpreter
{
    private CommandContext _context;

    public CommandInterpreter()
    {
        _context = new CommandContext();
    }

    public void Execute(string commandLine)
    {
        Console.WriteLine($"[Interpreter] Ejecutando: {commandLine}");

        string[] parts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return;

        string command = parts[0].ToUpper();

        ICommand cmd = command switch
        {
            "SET" when parts.Length >= 3 =>
                new SetCommand(_context, parts[1], string.Join(" ", parts.Skip(2))),

            "PRINT" when parts.Length >= 2 =>
                new PrintCommand(_context, parts[1]),

            "ECHO" when parts.Length >= 2 =>
                new EchoCommand(_context, string.Join(" ", parts.Skip(1))),

            "CLEAR" =>
                new ClearCommand(_context),

            _ => throw new InvalidOperationException($"Comando desconocido: {command}")
        };

        cmd.Execute();
        Console.WriteLine($"  → {cmd.GetDescription()}");
    }

    public void PrintOutput()
    {
        Console.WriteLine("\n--- Salida ---");
        foreach (var line in _context.GetOutput())
        {
            Console.WriteLine($"  {line}");
        }
    }

    public CommandContext GetContext() => _context;
}