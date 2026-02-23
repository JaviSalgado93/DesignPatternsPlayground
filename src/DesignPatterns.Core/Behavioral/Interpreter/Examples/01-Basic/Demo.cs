namespace DesignPatterns.Core.Behavioral.Interpreter.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Interpreter Pattern - Ejemplo Básico: Math Expressions ===\n");

        Console.WriteLine("--- Expresión 1: 5 + 3 ---");
        var expr1 = new AddExpr(new NumberExpr(5), new NumberExpr(3));
        Console.WriteLine($"  Expresión: {expr1.GetExpression()}");
        Console.WriteLine($"  Resultado: {expr1.Evaluate()}\n");

        Console.WriteLine("--- Expresión 2: (10 - 4) * 2 ---");
        var expr2 = new MultiplyExpr(
            new SubtractExpr(new NumberExpr(10), new NumberExpr(4)),
            new NumberExpr(2)
        );
        Console.WriteLine($"  Expresión: {expr2.GetExpression()}");
        Console.WriteLine($"  Resultado: {expr2.Evaluate()}\n");

        Console.WriteLine("--- Expresión 3: 2 ^ 3 (potencia) ---");
        var expr3 = new PowerExpr(new NumberExpr(2), new NumberExpr(3));
        Console.WriteLine($"  Expresión: {expr3.GetExpression()}");
        Console.WriteLine($"  Resultado: {expr3.Evaluate()}\n");

        Console.WriteLine("--- Expresión 4: (100 / 5) + 3 * 2 ---");
        var expr4 = new AddExpr(
            new DivideExpr(new NumberExpr(100), new NumberExpr(5)),
            new MultiplyExpr(new NumberExpr(3), new NumberExpr(2))
        );
        Console.WriteLine($"  Expresión: {expr4.GetExpression()}");
        Console.WriteLine($"  Resultado: {expr4.Evaluate()}\n");

        Console.WriteLine(" Interpreter permite evaluar expresiones complejas de forma flexible");
    }
}