namespace DesignPatterns.Core.Behavioral.Interpreter.Implementation;

/// <summary>
/// TerminalExpression - Variable
/// </summary>
public class VariableExpression : IExpression
{
    private string _name;

    public VariableExpression(string name)
    {
        _name = name;
    }

    public int Interpret(Context context)
    {
        return context.GetVariable(_name);
    }

    public string GetExpression() => _name;
}

/// <summary>
/// TerminalExpression - Número
/// </summary>
public class NumberExpression : IExpression
{
    private int _value;

    public NumberExpression(int value)
    {
        _value = value;
    }

    public int Interpret(Context context)
    {
        return _value;
    }

    public string GetExpression() => _value.ToString();
}

/// <summary>
/// NonterminalExpression - Suma
/// </summary>
public class AddExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        int leftValue = _left.Interpret(context);
        int rightValue = _right.Interpret(context);
        return leftValue + rightValue;
    }

    public string GetExpression() => $"({_left.GetExpression()} + {_right.GetExpression()})";
}

/// <summary>
/// NonterminalExpression - Resta
/// </summary>
public class SubtractExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        int leftValue = _left.Interpret(context);
        int rightValue = _right.Interpret(context);
        return leftValue - rightValue;
    }

    public string GetExpression() => $"({_left.GetExpression()} - {_right.GetExpression()})";
}

/// <summary>
/// NonterminalExpression - Multiplicación
/// </summary>
public class MultiplyExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public MultiplyExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        int leftValue = _left.Interpret(context);
        int rightValue = _right.Interpret(context);
        return leftValue * rightValue;
    }

    public string GetExpression() => $"({_left.GetExpression()} * {_right.GetExpression()})";
}

/// <summary>
/// NonterminalExpression - División
/// </summary>
public class DivideExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public DivideExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        int leftValue = _left.Interpret(context);
        int rightValue = _right.Interpret(context);

        if (rightValue == 0)
            throw new InvalidOperationException("División entre cero");

        return leftValue / rightValue;
    }

    public string GetExpression() => $"({_left.GetExpression()} / {_right.GetExpression()})";
}