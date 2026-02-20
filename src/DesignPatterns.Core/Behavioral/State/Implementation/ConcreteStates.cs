namespace DesignPatterns.Core.Behavioral.State.Implementation;

/// <summary>
/// ConcreteState A - Primer estado
/// </summary>
public class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → [StateA] Manejando solicitud");
        Console.WriteLine("  → [StateA] Transicionando a StateB");
        context.SetState(new ConcreteStateB());
    }

    public string GetStateName() => "State A";
}

/// <summary>
/// ConcreteState B - Segundo estado
/// </summary>
public class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → [StateB] Manejando solicitud");
        Console.WriteLine("  → [StateB] Transicionando a State C");
        context.SetState(new ConcreteStateC());
    }

    public string GetStateName() => "State B";
}

/// <summary>
/// ConcreteState C - Tercer estado
/// </summary>
public class ConcreteStateC : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → [StateC] Manejando solicitud");
        Console.WriteLine("  → [StateC] Transicionando a State A");
        context.SetState(new ConcreteStateA());
    }

    public string GetStateName() => "State C";
}