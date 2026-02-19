namespace DesignPatterns.Core.Behavioral.Command.Implementation;

/// <summary>
/// Receiver - Realiza el trabajo actual
/// </summary>
public class Receiver
{
    private int _value = 0;

    public void Add(int amount)
    {
        _value += amount;
        Console.WriteLine($"[Receiver] Sumado {amount}. Valor actual: {_value}");
    }

    public void Subtract(int amount)
    {
        _value -= amount;
        Console.WriteLine($"[Receiver] Restado {amount}. Valor actual: {_value}");
    }

    public void Multiply(int amount)
    {
        _value *= amount;
        Console.WriteLine($"[Receiver] Multiplicado por {amount}. Valor actual: {_value}");
    }

    public int GetValue() => _value;

    public void Reset()
    {
        _value = 0;
        Console.WriteLine("[Receiver] Reiniciado a 0");
    }
}