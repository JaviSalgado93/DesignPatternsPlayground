namespace DesignPatterns.Core.Behavioral.Interpreter.Implementation;

/// <summary>
/// AbstractExpression - Define interfaz para interpretar
/// </summary>
public interface IExpression
{
    int Interpret(Context context);
    string GetExpression();
}

/// <summary>
/// Context - Información para interpretar
/// </summary>
public class Context
{
    private Dictionary<string, int> _variables = new();

    public void SetVariable(string name, int value)
    {
        _variables[name] = value;
        Console.WriteLine($"[Context] Variable '{name}' = {value}");
    }

    public int GetVariable(string name)
    {
        if (_variables.ContainsKey(name))
            return _variables[name];
        throw new InvalidOperationException($"Variable '{name}' no existe");
    }

    public bool HasVariable(string name) => _variables.ContainsKey(name);
}