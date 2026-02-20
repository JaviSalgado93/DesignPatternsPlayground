namespace DesignPatterns.Core.Behavioral.Observer.Implementation;

/// <summary>
/// Observer - Define interfaz para observadores
/// </summary>
public interface IObserver
{
    void Update(Subject subject);
}

/// <summary>
/// Subject - Define interfaz para sujetos observables
/// </summary>
public abstract class Subject
{
    private List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            Console.WriteLine($"[Subject] Observador agregado. Total: {_observers.Count}");
        }
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
            Console.WriteLine($"[Subject] Observador eliminado. Total: {_observers.Count}");
        }
    }

    public void Notify()
    {
        Console.WriteLine($"[Subject] Notificando {_observers.Count} observadores...");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public int GetObserverCount() => _observers.Count;
}