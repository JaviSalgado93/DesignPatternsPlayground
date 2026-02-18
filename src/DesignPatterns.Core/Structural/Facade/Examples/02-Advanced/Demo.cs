namespace DesignPatterns.Core.Structural.Facade.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Facade Pattern - Ejemplo Avanzado: Banking System ===\n");

        // Crear cuenta
        var account = new Account("ACC-12345", 10000);
        var banking = new BankingFacade(account);

        Console.WriteLine($"Saldo inicial: ${banking.GetBalance()}\n");

        // Depósito simple
        Console.WriteLine("--- Depositando dinero ---");
        banking.DepositMoney(500);

        // Retiro
        Console.WriteLine("\n--- Retirando dinero ---");
        banking.WithdrawMoney(200);

        // Retiro sospechoso
        Console.WriteLine("\n--- Intento de retiro sospechoso ---");
        banking.WithdrawMoney(10000);

        // Solicitar préstamo (aprobado)
        Console.WriteLine("\n--- Solicitud de préstamo pequeño ---");
        banking.ApplyForLoan(5000);

        // Solicitar préstamo (rechazado)
        Console.WriteLine("\n--- Solicitud de préstamo grande ---");
        banking.ApplyForLoan(20000);

        Console.WriteLine($"\n--- Saldo final: ${banking.GetBalance()} ---");

        Console.WriteLine("\n Facade oculta la complejidad del sistema bancario");
    }
}