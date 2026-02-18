namespace DesignPatterns.Core.Structural.Facade.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Sistema bancario complejo
/// </summary>

public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public bool Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"[Account] Retiro: ${amount}. Saldo actual: ${Balance}");
            return true;
        }
        Console.WriteLine($"[Account] Saldo insuficiente");
        return false;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"[Account] Depósito: ${amount}. Saldo actual: ${Balance}");
    }
}

public class LoanProcessor
{
    public bool ApproveLoan(string accountNumber, decimal amount)
    {
        Console.WriteLine($"[LoanProcessor] Evaluando préstamo de ${amount} para {accountNumber}");
        // Lógica de evaluación
        return amount <= 10000;
    }

    public decimal CalculateInterest(decimal principal, decimal rate, int years)
    {
        Console.WriteLine($"[LoanProcessor] Calculando interés compuesto");
        return principal * (decimal)Math.Pow((double)(1 + rate), years);
    }
}

public class FraudDetection
{
    public bool IsTransactionSuspicious(string accountNumber, decimal amount)
    {
        Console.WriteLine($"[FraudDetection] Verificando transacción de ${amount}");
        return amount > 5000; // Más de 5000 es sospechoso para demostración
    }

    public void LogTransaction(string accountNumber, string type, decimal amount)
    {
        Console.WriteLine($"[FraudDetection] Registrado: {type} de ${amount} en {accountNumber}");
    }
}

public class NotificationService
{
    public void SendSMS(string phone, string message)
    {
        Console.WriteLine($"[SMS] Enviando a {phone}: {message}");
    }

    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"[Email] Enviando a {email}: {message}");
    }
}

/// <summary>
/// Facade - Simplifica operaciones bancarias
/// </summary>
public class BankingFacade
{
    private Account _account;
    private LoanProcessor _loanProcessor;
    private FraudDetection _fraudDetection;
    private NotificationService _notification;

    public BankingFacade(Account account)
    {
        _account = account;
        _loanProcessor = new LoanProcessor();
        _fraudDetection = new FraudDetection();
        _notification = new NotificationService();
    }

    public bool WithdrawMoney(decimal amount)
    {
        Console.WriteLine("=== Procesando retiro ===");

        // Verificar fraude
        if (_fraudDetection.IsTransactionSuspicious(_account.AccountNumber, amount))
        {
            Console.WriteLine("Transacción sospechosa detectada");
            return false;
        }

        // Realizar retiro
        if (_account.Withdraw(amount))
        {
            _fraudDetection.LogTransaction(_account.AccountNumber, "Retiro", amount);
            _notification.SendSMS("+1234567890", $"Retiro de ${amount}");
            return true;
        }

        return false;
    }

    public bool DepositMoney(decimal amount)
    {
        Console.WriteLine("=== Procesando depósito ===");
        _account.Deposit(amount);
        _fraudDetection.LogTransaction(_account.AccountNumber, "Depósito", amount);
        _notification.SendEmail("user@example.com", $"Depósito recibido: ${amount}");
        return true;
    }

    public bool ApplyForLoan(decimal amount)
    {
        Console.WriteLine("=== Solicitud de préstamo ===");

        if (_loanProcessor.ApproveLoan(_account.AccountNumber, amount))
        {
            var totalWithInterest = _loanProcessor.CalculateInterest(amount, 0.05m, 1);
            Console.WriteLine($"Préstamo aprobado. Total a pagar: ${totalWithInterest}");
            _notification.SendEmail("user@example.com", $"Préstamo aprobado: ${amount}");
            return true;
        }

        Console.WriteLine("Préstamo rechazado");
        return false;
    }

    public decimal GetBalance()
    {
        return _account.Balance;
    }
}