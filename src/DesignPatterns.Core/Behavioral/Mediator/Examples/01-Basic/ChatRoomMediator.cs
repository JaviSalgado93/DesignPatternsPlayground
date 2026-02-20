namespace DesignPatterns.Core.Behavioral.Mediator.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Sala de chat con mediador
/// </summary>

public interface IChatMediator
{
    void RegisterUser(User user);
    void SendMessage(string message, User sender);
}

public abstract class User
{
    protected IChatMediator _chatMediator;
    public string Name { get; protected set; }

    protected User(string name)
    {
        Name = name;
    }

    public void SetChatMediator(IChatMediator mediator)
    {
        _chatMediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ChatRoom : IChatMediator
{
    private List<User> _users = new();

    public void RegisterUser(User user)
    {
        _users.Add(user);
        user.SetChatMediator(this);
        Console.WriteLine($"[ChatRoom] {user.Name} se unió");
    }

    public void SendMessage(string message, User sender)
    {
        Console.WriteLine($"\n[ChatRoom] {sender.Name} envía: '{message}'");

        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive($"{sender.Name}: {message}");
            }
        }
    }
}

public class ChatUser : User
{
    public ChatUser(string name) : base(name) { }

    public override void Send(string message)
    {
        _chatMediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"  → {Name} recibe: {message}");
    }
}