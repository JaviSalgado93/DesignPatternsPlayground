namespace DesignPatterns.Core.Behavioral.State.Implementation;

/// <summary>
/// State - Define interfaz para estados
/// </summary>
public interface IState
{
    void Handle(Context context);
    string GetStateName();
}

/// <summary>
/// Context - Mantiene referencia a estado actual
/// </summary>
public class Context
{
    private IState _currentState;

    public Context(IState initialState)
    {
        _currentState = initialState;
        Console.WriteLine($"[Context] Estado inicial: {_currentState.GetStateName()}");
    }

    public void SetState(IState state)
    {
        Console.WriteLine($"[Context] Transición: {_currentState.GetStateName()} → {state.GetStateName()}");
        _currentState = state;
    }

    public IState GetState() => _currentState;

    public void Request()
    {
        Console.WriteLine($"[Context] Procesando solicitud en estado: {_currentState.GetStateName()}");
        _currentState.Handle(this);
    }

    public string GetCurrentStateName() => _currentState.GetStateName();
}