namespace DesignPatterns.Core.Behavioral.Strategy.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Estrategias de pago
/// </summary>

public interface IPaymentStrategy
{
    bool Pay(decimal amount);
    string GetPaymentMethod();
    decimal GetProcessingFee(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _cvv;

    public CreditCardPayment(string cardNumber, string cvv)
    {
        _cardNumber = cardNumber;
        _cvv = cvv;
    }

    public bool Pay(decimal amount)
    {
        Console.WriteLine($"  💳 Procesando pago con tarjeta de crédito");
        Console.WriteLine($"     Tarjeta: {_cardNumber[^4..]}");
        Console.WriteLine($"     Monto: ${amount:F2}");

        if (ValidateCard())
        {
            Console.WriteLine($"  ✓ Pago aprobado");
            return true;
        }
        Console.WriteLine($"  ✗ Pago rechazado");
        return false;
    }

    public string GetPaymentMethod() => "Tarjeta de Crédito";

    public decimal GetProcessingFee(decimal amount) => amount * 0.03m; // 3%

    private bool ValidateCard() => !string.IsNullOrEmpty(_cvv) && _cvv.Length == 3;
}

public class PayPalPayment : IPaymentStrategy
{
    private string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public bool Pay(decimal amount)
    {
        Console.WriteLine($"  🌐 Procesando pago con PayPal");
        Console.WriteLine($"     Email: {_email}");
        Console.WriteLine($"     Monto: ${amount:F2}");
        Console.WriteLine($"  ✓ Pago completado");
        return true;
    }

    public string GetPaymentMethod() => "PayPal";

    public decimal GetProcessingFee(decimal amount) => amount * 0.025m; // 2.5%
}

public class BitcoinPayment : IPaymentStrategy
{
    private string _walletAddress;

    public BitcoinPayment(string walletAddress)
    {
        _walletAddress = walletAddress;
    }

    public bool Pay(decimal amount)
    {
        Console.WriteLine($"  ₿ Procesando pago con Bitcoin");
        Console.WriteLine($"     Billetera: {_walletAddress[..8]}...");
        Console.WriteLine($"     Monto: {amount * 0.000025m:F8} BTC");
        Console.WriteLine($"  ✓ Transacción iniciada");
        return true;
    }

    public string GetPaymentMethod() => "Bitcoin";

    public decimal GetProcessingFee(decimal amount) => amount * 0.01m; // 1%
}

public class BankTransferPayment : IPaymentStrategy
{
    private string _accountNumber;

    public BankTransferPayment(string accountNumber)
    {
        _accountNumber = accountNumber;
    }

    public bool Pay(decimal amount)
    {
        Console.WriteLine($"  🏦 Procesando transferencia bancaria");
        Console.WriteLine($"     Cuenta: {_accountNumber[^4..]}");
        Console.WriteLine($"     Monto: ${amount:F2}");
        Console.WriteLine($"  ✓ Transferencia procesada");
        return true;
    }

    public string GetPaymentMethod() => "Transferencia Bancaria";

    public decimal GetProcessingFee(decimal amount) => 2.50m; // Tarifa fija
}

public class ShoppingCart
{
    private decimal _totalAmount = 0;
    private IPaymentStrategy _paymentStrategy;

    public void AddItem(decimal price)
    {
        _totalAmount += price;
        Console.WriteLine($"  + Item añadido: ${price:F2}");
    }

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
        Console.WriteLine($"[ShoppingCart] Método de pago: {strategy.GetPaymentMethod()}");
    }

    public void Checkout()
    {
        var fee = _paymentStrategy.GetProcessingFee(_totalAmount);
        var total = _totalAmount + fee;

        Console.WriteLine($"\n[Checkout] Total: ${_totalAmount:F2}");
        Console.WriteLine($"[Checkout] Comisión: ${fee:F2}");
        Console.WriteLine($"[Checkout] Total a pagar: ${total:F2}\n");

        if (_paymentStrategy.Pay(total))
        {
            Console.WriteLine($"  ✓ ¡Gracias por su compra!");
        }
    }

    public decimal GetTotal() => _totalAmount;
}