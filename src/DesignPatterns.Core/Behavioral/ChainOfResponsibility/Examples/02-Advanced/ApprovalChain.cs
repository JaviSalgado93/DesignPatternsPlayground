namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Sistema de aprobación de gastos
/// </summary>

public class ExpenseRequest
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string RequestedBy { get; set; }

    public ExpenseRequest(string description, decimal amount, string requestedBy)
    {
        Description = description;
        Amount = amount;
        RequestedBy = requestedBy;
    }
}

public interface IApprover
{
    void SetNext(IApprover next);
    void ProcessRequest(ExpenseRequest request);
}

public abstract class Approver : IApprover
{
    protected string _name;
    protected decimal _limit;
    protected IApprover _nextApprover;

    public Approver(string name, decimal limit)
    {
        _name = name;
        _limit = limit;
    }

    public virtual void SetNext(IApprover next)
    {
        _nextApprover = next;
    }

    public virtual void ProcessRequest(ExpenseRequest request)
    {
        if (request.Amount <= _limit)
        {
            Approve(request);
        }
        else if (_nextApprover != null)
        {
            Console.WriteLine($"[{_name}] Monto ${request.Amount} excede límite ${_limit}, escalando...");
            _nextApprover.ProcessRequest(request);
        }
        else
        {
            Console.WriteLine($"[Fin de cadena] ❌ Solicitud de ${request.Amount} no aprobada - Excede todos los límites");
        }
    }

    protected virtual void Approve(ExpenseRequest request)
    {
        Console.WriteLine($"[{_name}] ✅ Aprobado: ${request.Amount} para {request.Description}");
    }
}

public class Manager : Approver
{
    public Manager() : base("Manager", 1000) { }
}

public class Director : Approver
{
    public Director() : base("Director", 5000) { }
}

public class VP : Approver
{
    public VP() : base("VP", 10000) { }
}

public class CEO : Approver
{
    public CEO() : base("CEO", decimal.MaxValue) { }
}