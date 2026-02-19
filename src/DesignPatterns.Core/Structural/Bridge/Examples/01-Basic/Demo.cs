namespace DesignPatterns.Core.Structural.Bridge.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Bridge Pattern - Ejemplo Básico: Remote Controls ===\n");

        // Control básico para TV
        Console.WriteLine("--- Control Básico para TV ---");
        RemoteControl tvRemote = new BasicRemoteControl(new Television());
        tvRemote.PowerOn();
        tvRemote.VolumeUp();
        tvRemote.PowerOff();

        // Control avanzado para TV
        Console.WriteLine("\n--- Control Avanzado para TV ---");
        var advancedTvRemote = new AdvancedRemoteControl(new Television());
        advancedTvRemote.PowerOn();
        advancedTvRemote.SetChannel(5);
        advancedTvRemote.Mute();
        advancedTvRemote.PowerOff();

        // Control básico para Radio
        Console.WriteLine("\n--- Control Básico para Radio ---");
        RemoteControl radioRemote = new BasicRemoteControl(new Radio());
        radioRemote.PowerOn();
        radioRemote.VolumeDown();
        radioRemote.PowerOff();

        // Control avanzado para Radio
        Console.WriteLine("\n--- Control Avanzado para Radio ---");
        var advancedRadioRemote = new AdvancedRemoteControl(new Radio());
        advancedRadioRemote.PowerOn();
        advancedRadioRemote.SetChannel(10);
        advancedRadioRemote.VolumeUp();
        advancedRadioRemote.PowerOff();

        Console.WriteLine("\n Bridge permite variar abstracción e implementación independientemente");
    }
}

/// <summary>
/// Implementación concreta del control básico
/// </summary>
public class BasicRemoteControl : RemoteControl
{
    public BasicRemoteControl(IDevice device) : base(device)
    {
    }
}