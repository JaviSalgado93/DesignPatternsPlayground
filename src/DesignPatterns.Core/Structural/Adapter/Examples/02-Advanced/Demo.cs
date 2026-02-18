namespace DesignPatterns.Core.Structural.Adapter.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Adapter Pattern - Ejemplo Avanzado: Payment Processors ===\n");

        var processors = new List<(string name, IPaymentProcessor processor)>
        {
            ("Stripe", new StripeAdapter(new StripePayment())),
            ("PayPal", new PayPalAdapter(new PayPalPayment())),
            ("Square", new SquareAdapter(new SquarePayment()))
        };

        decimal amount = 99.99m;
        string currency = "USD";

        foreach (var (name, processor) in processors)
        {
            Console.WriteLine($"\n--- Procesando con {name} ---");

            bool success = processor.ProcessPayment(amount, currency);

            if (success)
            {
                Console.WriteLine($"Pago procesado exitosamente");
                var status = processor.GetTransactionStatus($"txn_{Guid.NewGuid().ToString().Substring(0, 8)}");
                Console.WriteLine($"Estado: {status}");
            }
            else
            {
                Console.WriteLine($"❌ Error al procesar pago");
            }
        }

        Console.WriteLine("\nAdapter permite cambiar procesadores sin modificar código cliente");
    }
}