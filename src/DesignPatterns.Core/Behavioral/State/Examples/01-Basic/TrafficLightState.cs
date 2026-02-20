namespace DesignPatterns.Core.Behavioral.State.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Semáforo de tránsito
/// </summary>

public interface ITrafficLightState
{
    void Change(TrafficLight light);
    string GetColor();
}

public class RedLight : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("🔴 Luz roja - DETENER");
        Console.WriteLine("   → Cambiando a luz verde");
        light.SetState(new GreenLight());
    }

    public string GetColor() => "Rojo";
}

public class GreenLight : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("🟢 Luz verde - AVANZAR");
        Console.WriteLine("   → Cambiando a luz amarilla");
        light.SetState(new YellowLight());
    }

    public string GetColor() => "Verde";
}

public class YellowLight : ITrafficLightState
{
    public void Change(TrafficLight light)
    {
        Console.WriteLine("🟡 Luz amarilla - PRECAUCIÓN");
        Console.WriteLine("   → Cambiando a luz roja");
        light.SetState(new RedLight());
    }

    public string GetColor() => "Amarillo";
}

public class TrafficLight
{
    private ITrafficLightState _state;
    private int _cycleCount = 0;

    public TrafficLight()
    {
        _state = new RedLight();
        Console.WriteLine($"[TrafficLight] Iniciado en: {_state.GetColor()}");
    }

    public void SetState(ITrafficLightState state)
    {
        _state = state;
    }

    public void Change()
    {
        _cycleCount++;
        Console.WriteLine($"\n--- Cambio #{_cycleCount} ---");
        _state.Change(this);
    }

    public string GetCurrentColor() => _state.GetColor();
}