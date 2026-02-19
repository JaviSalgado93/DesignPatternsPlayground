namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Implementation;

/// <summary>
/// Handler - Define interfaz para manejar solicitudes
/// </summary>
public interface IHandler
{
    void SetNext(IHandler next);
    void Handle(Request request);
}

/// <summary>
/// Request - Solicitud a procesar
/// </summary>
public class Request
{
    public string Type { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }

    public Request(string type, int amount, string description)
    {
        Type = type;
        Amount = amount;
        Description = description;
    }
}