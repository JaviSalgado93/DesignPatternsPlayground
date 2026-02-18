namespace DesignPatterns.Core.Structural.Facade.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Facade Pattern - Ejemplo Básico: Home Theater ===\n");

        var homeTheater = new HomeTheaterFacade();

        // Sin Facade: Sería necesario controlar todos los dispositivos manualmente
        // Con Facade: Una única llamada simplifica todo

        Console.WriteLine("--- Ver película ---");
        homeTheater.WatchMovie("Interstellar");

        Console.WriteLine("\n--- Pausa (30 segundos) ---");
        System.Threading.Thread.Sleep(1000);

        Console.WriteLine("\n--- Terminando película ---");
        homeTheater.EndMovie();

        Console.WriteLine("\n\n--- Escuchando radio ---");
        homeTheater.ListenToRadio();

        System.Threading.Thread.Sleep(1000);

        Console.WriteLine("\n--- Apagando radio ---");
        homeTheater.EndRadio();

        Console.WriteLine("\n Facade simplifica sistemas complejos");
    }
}