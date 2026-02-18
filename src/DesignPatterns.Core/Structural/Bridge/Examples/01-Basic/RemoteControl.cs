namespace DesignPatterns.Core.Structural.Bridge.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Control remoto para diferentes dispositivos
/// </summary>

public interface IDevice
{
    void PowerOn();
    void PowerOff();
    void SetVolume(int volume);
    void SetChannel(int channel);
}

public class Television : IDevice
{
    private bool _isPowered;
    private int _volume = 50;
    private int _channel = 1;

    public void PowerOn()
    {
        _isPowered = true;
        Console.WriteLine("[TV] Encendido");
    }

    public void PowerOff()
    {
        _isPowered = false;
        Console.WriteLine("[TV] Apagado");
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
        Console.WriteLine($"[TV] Volumen: {volume}");
    }

    public void SetChannel(int channel)
    {
        _channel = channel;
        Console.WriteLine($"[TV] Canal: {channel}");
    }
}

public class Radio : IDevice
{
    private bool _isPowered;
    private double _frequency = 88.5;
    private int _volume = 30;

    public void PowerOn()
    {
        _isPowered = true;
        Console.WriteLine("[Radio] Encendida");
    }

    public void PowerOff()
    {
        _isPowered = false;
        Console.WriteLine("[Radio] Apagada");
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
        Console.WriteLine($"[Radio] Volumen: {volume}");
    }

    public void SetChannel(int channel)
    {
        _frequency = 88.5 + (channel * 0.5);
        Console.WriteLine($"[Radio] Frecuencia: {_frequency} FM");
    }
}

/// <summary>
/// Abstracción - Control remoto base
/// </summary>
public abstract class RemoteControl
{
    protected IDevice _device;

    public RemoteControl(IDevice device)
    {
        _device = device;
    }

    public virtual void PowerOn()
    {
        _device.PowerOn();
    }

    public virtual void PowerOff()
    {
        _device.PowerOff();
    }

    public virtual void VolumeUp()
    {
        _device.SetVolume(50);
    }

    public virtual void VolumeDown()
    {
        _device.SetVolume(30);
    }
}

/// <summary>
/// Abstracción refinada - Control avanzado
/// </summary>
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device)
    {
    }

    public void Mute()
    {
        _device.SetVolume(0);
        Console.WriteLine("Silenciado");
    }

    public void SetChannel(int channel)
    {
        _device.SetChannel(channel);
    }
}