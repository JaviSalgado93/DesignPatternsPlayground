namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Chain of Responsibility - Ejemplo Avanzado: Approval System ===\n");

        // Crear cadena de aprobadores
        IApprover manager = new Manager();
        IApprover director = new Director();
        IApprover vp = new VP();
        IApprover ceo = new CEO();

        manager.SetNext(director);
        director.SetNext(vp);
        vp.SetNext(ceo);

        // Solicitudes de diferentes montos
        Console.WriteLine("--- Procesando solicitudes de gastos ---\n");

        manager.ProcessRequest(new ExpenseRequest("Oficina", 500, "Juan"));
        Console.WriteLine();

        manager.ProcessRequest(new ExpenseRequest("Conferencia", 2500, "María"));
        Console.WriteLine();

        manager.ProcessRequest(new ExpenseRequest("Expansión", 8000, "Carlos"));
        Console.WriteLine();

        manager.ProcessRequest(new ExpenseRequest("Adquisición", 15000, "Luis"));
        Console.WriteLine();

        manager.ProcessRequest(new ExpenseRequest("Imposible", 1000000, "Pedro"));

        Console.WriteLine("\n Chain permite que múltiples niveles procesen según autoridad");
    }
}