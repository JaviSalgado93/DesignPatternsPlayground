namespace DesignPatterns.Core.Behavioral.Mediator.Implementation;

/// <summary>
/// Mediator - Define interfaz para comunicación
/// </summary>
public interface IMediator
{
    void Register(Colleague colleague);
    void Send(string message, Colleague sender);
    void SendDirected(string message, Colleague sender, Colleague receiver);
}

/// <summary>
/// Colleague - Define interfaz para colegas
/// </summary>
public abstract class Colleague
{
    protected IMediator _mediator;
    public string Name { get; protected set; }

    protected Colleague(string name)
    {
        Name = name;
    }

    public virtual void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}