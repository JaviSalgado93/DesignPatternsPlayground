namespace DesignPatterns.Core.Behavioral.Interpreter.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Interpretador de expresiones matemáticas simples
/// </summary>

public interface IMathExpression
{
    double Evaluate();
    string GetExpression();
}

/// <summary>
/// Número literal
/// </summary>
public class NumberExpr : IMathExpression
{
    private double _value;

    public NumberExpr(double value)
    {
        _value = value;
    }

    public double Evaluate() => _value;

    public string GetExpression() => _value.ToString();
}

/// <summary>
/// Operación binaria abstracta
/// </summary>
public abstract class BinaryOpExpr : IMathExpression
{
    protected IMathExpression _left;
    protected IMathExpression _right;

    protected BinaryOpExpr(IMathExpression left, IMathExpression right)
    {
        _left = left;
        _right = right;
    }

    public abstract double Evaluate();

    public string GetExpression() => $"({_left.GetExpression()} {GetOperator()} {_right.GetExpression()})";

    protected abstract string GetOperator();
}

/// <summary>
/// Suma
/// </summary>
public class AddExpr : BinaryOpExpr
{
    public AddExpr(IMathExpression left, IMathExpression right) : base(left, right) { }

    public override double Evaluate() => _left.Evaluate() + _right.Evaluate();

    protected override string GetOperator() => "+";
}

/// <summary>
/// Resta
/// </summary>
public class SubtractExpr : BinaryOpExpr
{
    public SubtractExpr(IMathExpression left, IMathExpression right) : base(left, right) { }

    public override double Evaluate() => _left.Evaluate() - _right.Evaluate();

    protected override string GetOperator() => "-";
}

/// <summary>
/// Multiplicación
/// </summary>
public class MultiplyExpr : BinaryOpExpr
{
    public MultiplyExpr(IMathExpression left, IMathExpression right) : base(left, right) { }

    public override double Evaluate() => _left.Evaluate() * _right.Evaluate();

    protected override string GetOperator() => "*";
}

/// <summary>
/// División
/// </summary>
public class DivideExpr : BinaryOpExpr
{
    public DivideExpr(IMathExpression left, IMathExpression right) : base(left, right) { }

    public override double Evaluate()
    {
        double divisor = _right.Evaluate();
        if (divisor == 0)
            throw new InvalidOperationException("División entre cero");
        return _left.Evaluate() / divisor;
    }

    protected override string GetOperator() => "/";
}

/// <summary>
/// Potencia
/// </summary>
public class PowerExpr : BinaryOpExpr
{
    public PowerExpr(IMathExpression left, IMathExpression right) : base(left, right) { }

    public override double Evaluate() => Math.Pow(_left.Evaluate(), _right.Evaluate());

    protected override string GetOperator() => "^";
}