namespace DesignPatterns.Core.Behavioral.Strategy.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Strategy Pattern - Ejemplo Avanzado: Payment Methods ===\n");

        var cart = new ShoppingCart();

        Console.WriteLine("--- Agregando items ---");
        cart.AddItem(50.00m);
        cart.AddItem(30.00m);
        cart.AddItem(20.00m);

        Console.WriteLine("\n--- Pagando con Tarjeta de Crédito ---");
        cart.SetPaymentStrategy(new CreditCardPayment("4532-XXXX-XXXX-1234", "123"));
        cart.Checkout();

        Console.WriteLine("\n--- Pagando con PayPal ---");
        cart.SetPaymentStrategy(new PayPalPayment("usuario@example.com"));
        cart.Checkout();

        Console.WriteLine("\n--- Pagando con Bitcoin ---");
        cart.SetPaymentStrategy(new BitcoinPayment("1A1z7agoat4wrMSEYGecLaKV2x94Y"));
        cart.Checkout();

        Console.WriteLine("\n--- Pagando con Transferencia Bancaria ---");
        cart.SetPaymentStrategy(new BankTransferPayment("1234-5678-9012-3456"));
        cart.Checkout();

        Console.WriteLine("\n Strategy permite múltiples formas de pago sin código condicional");
    }
}