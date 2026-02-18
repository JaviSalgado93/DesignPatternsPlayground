namespace DesignPatterns.Core.Structural.Facade.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Sistema de cine en casa
/// </summary>

public class Amplifier
{
    public void TurnOn() => Console.WriteLine("[Amplifier] Encendido");
    public void TurnOff() => Console.WriteLine("[Amplifier] Apagado");
    public void SetVolume(int level) => Console.WriteLine($"[Amplifier] Volumen: {level}");
}

public class DVDPlayer
{
    public void TurnOn() => Console.WriteLine("[DVD] Encendido");
    public void TurnOff() => Console.WriteLine("[DVD] Apagado");
    public void Play(string movie) => Console.WriteLine($"[DVD] Reproduciendo: {movie}");
    public void Stop() => Console.WriteLine("[DVD] Detenido");
}

public class Projector
{
    public void TurnOn() => Console.WriteLine("[Projector] Encendido");
    public void TurnOff() => Console.WriteLine("[Projector] Apagado");
    public void SetInput(string input) => Console.WriteLine($"[Projector] Entrada: {input}");
}

public class Screen
{
    public void Down() => Console.WriteLine("[Screen] Pantalla bajada");
    public void Up() => Console.WriteLine("[Screen] Pantalla subida");
}

public class Lights
{
    public void Dim(int level) => Console.WriteLine($"[Lights] Brillo: {level}%");
    public void On() => Console.WriteLine("[Lights] Luces encendidas");
}

/// <summary>
/// Facade - Simplifica el sistema complejo
/// </summary>
public class HomeTheaterFacade
{
    private Amplifier _amplifier;
    private DVDPlayer _dvdPlayer;
    private Projector _projector;
    private Screen _screen;
    private Lights _lights;

    public HomeTheaterFacade()
    {
        _amplifier = new Amplifier();
        _dvdPlayer = new DVDPlayer();
        _projector = new Projector();
        _screen = new Screen();
        _lights = new Lights();
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine($"=== Preparando para ver: {movie} ===");
        _lights.Dim(10);
        _screen.Down();
        _projector.TurnOn();
        _projector.SetInput("DVD");
        _amplifier.TurnOn();
        _amplifier.SetVolume(5);
        _dvdPlayer.TurnOn();
        _dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("=== Terminando película ===");
        _dvdPlayer.Stop();
        _dvdPlayer.TurnOff();
        _amplifier.TurnOff();
        _projector.TurnOff();
        _screen.Up();
        _lights.On();
    }

    public void ListenToRadio()
    {
        Console.WriteLine("=== Escuchando radio ===");
        _amplifier.TurnOn();
        _amplifier.SetVolume(3);
        _lights.On();
    }

    public void EndRadio()
    {
        Console.WriteLine("=== Radio apagada ===");
        _amplifier.TurnOff();
    }
}