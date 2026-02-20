namespace DesignPatterns.Core.Behavioral.State.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== State Pattern - Ejemplo Básico: Traffic Light ===\n");

        var light = new TrafficLight();

        Console.WriteLine($"Estado actual: {light.GetCurrentColor()}\n");

        light.Change();
        light.Change();
        light.Change();
        light.Change();

        Console.WriteLine("\n State permite comportamiento dependiente de estado");
    }
}