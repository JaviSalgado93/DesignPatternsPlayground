namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Implementation;

/// <summary>
/// AbstractHandler - Clase base para manejadores
/// </summary>
public abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;

    public virtual void SetNext(IHandler next)
    {
        _nextHandler = next;
    }

    public virtual void Handle(Request request)
    {
        if (CanHandle(request))
        {
            ProcessRequest(request);
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine($"[{GetType().Name}] No puede manejar, pasando a siguiente...");
            _nextHandler.Handle(request);
        }
        else
        {
            Console.WriteLine($"[Fin de cadena] Nadie pudo manejar la solicitud: {request.Type}");
        }
    }

    protected abstract bool CanHandle(Request request);
    protected abstract void ProcessRequest(Request request);
}