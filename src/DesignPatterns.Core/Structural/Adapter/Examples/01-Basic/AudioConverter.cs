namespace DesignPatterns.Core.Structural.Adapter.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Adaptador de formatos de audio
/// </summary>

public interface IAudioPlayer
{
    void PlayAudio(string fileName);
    void StopAudio();
}

public class MP3Player : IAudioPlayer
{
    public void PlayAudio(string fileName)
    {
        if (fileName.EndsWith(".mp3"))
            Console.WriteLine($"[MP3 Player] Reproduciendo: {fileName}");
        else
            Console.WriteLine($"[MP3 Player] Error: formato no soportado");
    }

    public void StopAudio()
    {
        Console.WriteLine("[MP3 Player] Detenido");
    }
}

public class VLCPlayer
{
    public void PlayVLCFile(string fileName)
    {
        Console.WriteLine($"[VLC] Reproduciendo: {fileName}");
    }

    public void StopVLC()
    {
        Console.WriteLine("[VLC] Detenido");
    }
}

/// <summary>
/// Adapter para permitir que VLC funcione como IAudioPlayer
/// </summary>
public class VLCAdapter : IAudioPlayer
{
    private VLCPlayer _vlcPlayer;

    public VLCAdapter(VLCPlayer vlcPlayer)
    {
        _vlcPlayer = vlcPlayer;
    }

    public void PlayAudio(string fileName)
    {
        _vlcPlayer.PlayVLCFile(fileName);
    }

    public void StopAudio()
    {
        _vlcPlayer.StopVLC();
    }
}

/// <summary>
/// Adapter para permitir que MP3Player funcione con múltiples formatos
/// </summary>
public class UniversalAudioAdapter : IAudioPlayer
{
    private MP3Player _mp3Player;

    public UniversalAudioAdapter(MP3Player mp3Player)
    {
        _mp3Player = mp3Player;
    }

    public void PlayAudio(string fileName)
    {
        // Convertir cualquier formato a MP3 internamente
        if (fileName.EndsWith(".wav") || fileName.EndsWith(".flac"))
        {
            var mp3FileName = Path.ChangeExtension(fileName, ".mp3");
            Console.WriteLine($"[Converter] Convirtiendo {fileName} a {mp3FileName}");
            _mp3Player.PlayAudio(mp3FileName);
        }
        else
        {
            _mp3Player.PlayAudio(fileName);
        }
    }

    public void StopAudio()
    {
        _mp3Player.StopAudio();
    }
}