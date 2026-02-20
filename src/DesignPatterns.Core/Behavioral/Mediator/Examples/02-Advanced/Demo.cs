namespace DesignPatterns.Core.Behavioral.Mediator.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Mediator Pattern - Ejemplo Avanzado: Airport Control ===\n");

        var airportControl = new AirportControl();

        var flight1 = new Airplane("AA100");
        var flight2 = new Airplane("UA200");
        var flight3 = new Helicopter("HC50");

        airportControl.RegisterAircraft(flight1);
        airportControl.RegisterAircraft(flight2);
        airportControl.RegisterAircraft(flight3);

        Console.WriteLine("\n--- Solicitudes de aterrizaje ---");
        flight1.RequestLanding();
        flight2.RequestLanding();
        flight3.RequestLanding();

        Console.WriteLine("\n--- Transmisión de emergencia ---");
        airportControl.Broadcast("Se reporta clima severo en el área");

        Console.WriteLine("\n--- Solicitudes de despegue ---");
        flight1.RequestTakeoff();
        flight2.RequestTakeoff();

        Console.WriteLine($"\n[Control] Aeronaves en cola de aterrizaje: {airportControl.GetQueueLength()}");
        Console.WriteLine("\n Mediator coordina complejo sistema de tráfico aéreo");
    }
}