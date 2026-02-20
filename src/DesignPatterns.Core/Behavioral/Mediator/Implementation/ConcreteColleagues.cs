namespace DesignPatterns.Core.Behavioral.Mediator.Implementation;

/// <summary>
/// ConcreteColleagues - Implementan comunicación
/// </summary>

public class ChatUser : Colleague
{
    public ChatUser(string name) : base(name) { }

    public override void Send(string message)
    {
        _mediator.Send(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"[{Name}] Recibe: {message}");
    }
}

public class ChatModerator : Colleague
{
    public ChatModerator(string name) : base(name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"[{Name}] (Moderador) dice: {message}");
        _mediator.Send($"[MODERADO] {message}", this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"[{Name}] (Moderador) Recibe: {message}");
    }
}

public class ChatBot : Colleague
{
    public ChatBot(string name) : base(name) { }

    public override void Send(string message)
    {
        _mediator.Send($"[BOT] {message}", this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"[{Name}] (Bot) Procesa: {message}");

        // El bot responde automáticamente
        if (message.Contains("hola"))
        {
            Send("¡Hola! Soy un bot");
        }
        else if (message.Contains("ayuda"))
        {
            Send("¿En qué puedo ayudarte?");
        }
    }
}