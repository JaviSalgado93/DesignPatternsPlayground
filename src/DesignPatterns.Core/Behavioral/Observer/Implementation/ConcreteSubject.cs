namespace DesignPatterns.Core.Behavioral.Observer.Implementation;

/// <summary>
/// ConcreteSubject - Implementa Subject observable
/// </summary>
public class ConcreteSubject : Subject
{
    private string _state;

    public string State
    {
        get => _state;
        set
        {
            _state = value;
            Console.WriteLine($"[ConcreteSubject] Estado cambió a: {_state}");
            Notify();
        }
    }
}

/// <summary>
/// ConcreteObserver - Observa cambios de Subject
/// </summary>
public class ConcreteObserver : IObserver
{
    private string _name;
    private string _observedState;

    public ConcreteObserver(string name)
    {
        _name = name;
        _observedState = "";
    }

    public void Update(Subject subject)
    {
        if (subject is ConcreteSubject concreteSubject)
        {
            _observedState = concreteSubject.State;
            Console.WriteLine($"  → [{_name}] Recibió notificación. Estado observado: {_observedState}");
        }
    }

    public string GetObservedState() => _observedState;
}