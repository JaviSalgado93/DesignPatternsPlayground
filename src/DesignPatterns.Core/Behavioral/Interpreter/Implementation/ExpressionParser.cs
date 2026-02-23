namespace DesignPatterns.Core.Behavioral.Interpreter.Implementation;

/// <summary>
/// Parser - Construye árbol de expresiones
/// </summary>
public class ExpressionParser
{
    private string[] _tokens;
    private int _current = 0;

    public IExpression Parse(string expression)
    {
        Console.WriteLine($"[Parser] Analizando: {expression}");
        _tokens = Tokenize(expression);
        _current = 0;
        return ParseAddition();
    }

    private IExpression ParseAddition()
    {
        var left = ParseMultiplication();

        while (_current < _tokens.Length && (_tokens[_current] == "+" || _tokens[_current] == "-"))
        {
            string op = _tokens[_current++];
            var right = ParseMultiplication();

            if (op == "+")
                left = new AddExpression(left, right);
            else
                left = new SubtractExpression(left, right);
        }

        return left;
    }

    private IExpression ParseMultiplication()
    {
        var left = ParsePrimary();

        while (_current < _tokens.Length && (_tokens[_current] == "*" || _tokens[_current] == "/"))
        {
            string op = _tokens[_current++];
            var right = ParsePrimary();

            if (op == "*")
                left = new MultiplyExpression(left, right);
            else
                left = new DivideExpression(left, right);
        }

        return left;
    }

    private IExpression ParsePrimary()
    {
        string token = _tokens[_current++];

        if (int.TryParse(token, out int number))
            return new NumberExpression(number);

        return new VariableExpression(token);
    }

    private string[] Tokenize(string expression)
    {
        return expression.Replace("(", " ( ")
                        .Replace(")", " ) ")
                        .Replace("+", " + ")
                        .Replace("-", " - ")
                        .Replace("*", " * ")
                        .Replace("/", " / ")
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
}