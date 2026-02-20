namespace DesignPatterns.Core.Behavioral.State.Implementation;

/// <summary>
/// Estados con comportamiento específico
/// </summary>

public class IdleState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → Sistema en reposo");
    }

    public string GetStateName() => "Idle";
}

public class ProcessingState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → Procesando datos...");
        context.SetState(new CompletedState());
    }

    public string GetStateName() => "Processing";
}

public class CompletedState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("  → Procesamiento completado");
        context.SetState(new IdleState());
    }

    public string GetStateName() => "Completed";
}

public class ErrorState : IState
{
    private string _errorMessage;

    public ErrorState(string errorMessage = "Error desconocido")
    {
        _errorMessage = errorMessage;
    }

    public void Handle(Context context)
    {
        Console.WriteLine($"  → ERROR: {_errorMessage}");
        Console.WriteLine("  → Reintentando...");
        context.SetState(new IdleState());
    }

    public string GetStateName() => "Error";
}