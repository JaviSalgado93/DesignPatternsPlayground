namespace DesignPatterns.Core.Behavioral.Observer.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Observer Pattern - Ejemplo Básico: Stock Price ===\n");

        var apple = new Stock("AAPL", 150.00m);

        var investor1 = new Investor("Alice");
        var investor2 = new Investor("Bob");
        var bot = new TradingBot();

        Console.WriteLine("--- Suscribiendo observadores ---");
        apple.Subscribe(investor1);
        apple.Subscribe(investor2);
        apple.Subscribe(bot);

        Console.WriteLine("\n--- Cambios de precio ---");
        apple.SetPrice(155.00m);
        apple.SetPrice(145.00m);
        apple.SetPrice(48.00m);

        Console.WriteLine("\n--- Desuscribiendo observador ---");
        apple.Unsubscribe(investor2);

        Console.WriteLine("\n--- Nuevo cambio de precio ---");
        apple.SetPrice(52.00m);

        Console.WriteLine("\n Observer notifica cambios automáticamente");
    }
}