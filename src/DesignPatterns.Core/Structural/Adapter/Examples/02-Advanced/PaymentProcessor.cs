namespace DesignPatterns.Core.Structural.Adapter.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Adaptador para diferentes procesadores de pago
/// </summary>

public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount, string currency);
    string GetTransactionStatus(string transactionId);
}

public class StripePayment
{
    public string ChargeCard(decimal amount, string currency, string cardToken)
    {
        Console.WriteLine($"[Stripe] Cobrando ${amount} {currency}");
        return $"stripe_txn_{Guid.NewGuid().ToString().Substring(0, 8)}";
    }

    public string CheckStatus(string transactionId)
    {
        Console.WriteLine($"[Stripe] Verificando transacción: {transactionId}");
        return "completed";
    }
}

public class PayPalPayment
{
    public void SendPayment(decimal amount, string targetEmail)
    {
        Console.WriteLine($"[PayPal] Enviando ${amount} a {targetEmail}");
    }

    public string GetPaymentStatus(string paymentId)
    {
        Console.WriteLine($"[PayPal] Estado del pago: {paymentId}");
        return "approved";
    }
}

public class SquarePayment
{
    public bool ExecuteTransaction(decimal amount, string customerId)
    {
        Console.WriteLine($"[Square] Procesando ${amount} para cliente {customerId}");
        return true;
    }

    public string FetchStatus(string squareId)
    {
        Console.WriteLine($"[Square] Obteniendo estado: {squareId}");
        return "success";
    }
}

/// <summary>
/// Adapter para Stripe
/// </summary>
public class StripeAdapter : IPaymentProcessor
{
    private StripePayment _stripe;
    private string _lastTransactionId;
    private string _cardToken = "tok_visa";

    public StripeAdapter(StripePayment stripe)
    {
        _stripe = stripe;
    }

    public bool ProcessPayment(decimal amount, string currency)
    {
        _lastTransactionId = _stripe.ChargeCard(amount, currency, _cardToken);
        return !string.IsNullOrEmpty(_lastTransactionId);
    }

    public string GetTransactionStatus(string transactionId)
    {
        return _stripe.CheckStatus(transactionId);
    }
}

/// <summary>
/// Adapter para PayPal
/// </summary>
public class PayPalAdapter : IPaymentProcessor
{
    private PayPalPayment _paypal;
    private string _lastPaymentId;
    private string _targetEmail = "merchant@example.com";

    public PayPalAdapter(PayPalPayment paypal)
    {
        _paypal = paypal;
    }

    public bool ProcessPayment(decimal amount, string currency)
    {
        try
        {
            _paypal.SendPayment(amount, _targetEmail);
            _lastPaymentId = $"paypal_{Guid.NewGuid().ToString().Substring(0, 8)}";
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetTransactionStatus(string transactionId)
    {
        return _paypal.GetPaymentStatus(transactionId);
    }
}

/// <summary>
/// Adapter para Square
/// </summary>
public class SquareAdapter : IPaymentProcessor
{
    private SquarePayment _square;
    private string _lastTransactionId;
    private string _customerId = "cust_123456";

    public SquareAdapter(SquarePayment square)
    {
        _square = square;
    }

    public bool ProcessPayment(decimal amount, string currency)
    {
        var result = _square.ExecuteTransaction(amount, _customerId);
        if (result)
        {
            _lastTransactionId = $"sq_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
        return result;
    }

    public string GetTransactionStatus(string transactionId)
    {
        return _square.FetchStatus(transactionId);
    }
}