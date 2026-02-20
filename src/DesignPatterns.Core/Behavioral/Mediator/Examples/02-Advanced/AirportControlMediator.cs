namespace DesignPatterns.Core.Behavioral.Mediator.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Control de tráfico aéreo
/// </summary>

public interface IAirportControl
{
    void RegisterAircraft(Aircraft aircraft);
    void RequestLanding(Aircraft aircraft);
    void RequestTakeoff(Aircraft aircraft);
    void Broadcast(string message);
}

public abstract class Aircraft
{
    protected IAirportControl _control;
    public string FlightNumber { get; protected set; }
    public string Status { get; set; }

    protected Aircraft(string flightNumber)
    {
        FlightNumber = flightNumber;
        Status = "En vuelo";
    }

    public virtual void SetControl(IAirportControl control)
    {
        _control = control;
    }

    public abstract void RequestLanding();
    public abstract void RequestTakeoff();
    public abstract void ReceiveInstruction(string instruction);
}

public class AirportControl : IAirportControl
{
    private List<Aircraft> _aircrafts = new();
    private Queue<Aircraft> _landingQueue = new();
    private bool _runwayFree = true;

    public void RegisterAircraft(Aircraft aircraft)
    {
        _aircrafts.Add(aircraft);
        aircraft.SetControl(this);
        Console.WriteLine($"[Control] {aircraft.FlightNumber} registrado");
    }

    public void RequestLanding(Aircraft aircraft)
    {
        Console.WriteLine($"\n[{aircraft.FlightNumber}] Solicita aterrizaje");

        if (_runwayFree)
        {
            _runwayFree = false;
            aircraft.ReceiveInstruction("AUTORIZADO para aterrizaje");
            aircraft.Status = "Aterrizando";

            _runwayFree = true;
        }
        else
        {
            aircraft.ReceiveInstruction("ESPERE en órbita");
            _landingQueue.Enqueue(aircraft);
        }
    }

    public void RequestTakeoff(Aircraft aircraft)
    {
        Console.WriteLine($"\n[{aircraft.FlightNumber}] Solicita despegue");

        if (_runwayFree)
        {
            _runwayFree = false;
            aircraft.ReceiveInstruction("AUTORIZADO para despegue");
            aircraft.Status = "Despegando";

            _runwayFree = true;
        }
        else
        {
            aircraft.ReceiveInstruction("ESPERE permiso de despegue");
        }
    }

    public void Broadcast(string message)
    {
        Console.WriteLine($"\n[Control] Transmisión general: {message}");
        foreach (var aircraft in _aircrafts)
        {
            aircraft.ReceiveInstruction(message);
        }
    }

    public int GetQueueLength() => _landingQueue.Count;
}

public class Airplane : Aircraft
{
    public Airplane(string flightNumber) : base(flightNumber) { }

    public override void RequestLanding()
    {
        _control.RequestLanding(this);
    }

    public override void RequestTakeoff()
    {
        _control.RequestTakeoff(this);
    }

    public override void ReceiveInstruction(string instruction)
    {
        Console.WriteLine($"  ✈️  [{FlightNumber}] Recibe: {instruction}");
    }
}

public class Helicopter : Aircraft
{
    public Helicopter(string flightNumber) : base(flightNumber) { }

    public override void RequestLanding()
    {
        _control.RequestLanding(this);
    }

    public override void RequestTakeoff()
    {
        _control.RequestTakeoff(this);
    }

    public override void ReceiveInstruction(string instruction)
    {
        Console.WriteLine($"  🚁 [{FlightNumber}] Recibe: {instruction}");
    }
}