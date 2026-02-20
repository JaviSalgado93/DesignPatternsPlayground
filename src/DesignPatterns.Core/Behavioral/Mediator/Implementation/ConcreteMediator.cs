namespace DesignPatterns.Core.Behavioral.Mediator.Implementation;

/// <summary>
/// ConcreteMediator - Implementa comunicación entre colegas
/// </summary>
public class ConcreteMediator : IMediator
{
    private Dictionary<string, Colleague> _colleagues = new();

    public void Register(Colleague colleague)
    {
        _colleagues[colleague.Name] = colleague;
        colleague.SetMediator(this);
        Console.WriteLine($"[Mediator] {colleague.Name} registrado");
    }

    public void Send(string message, Colleague sender)
    {
        Console.WriteLine($"[Mediator] {sender.Name} envía: '{message}'");

        foreach (var colleague in _colleagues.Values)
        {
            if (colleague != sender)
            {
                colleague.Receive($"De {sender.Name}: {message}");
            }
        }
    }

    public void SendDirected(string message, Colleague sender, Colleague receiver)
    {
        Console.WriteLine($"[Mediator] {sender.Name} -> {receiver.Name}: '{message}'");
        receiver.Receive($"De {sender.Name}: {message}");
    }

    public int GetColleagueCount() => _colleagues.Count;
}