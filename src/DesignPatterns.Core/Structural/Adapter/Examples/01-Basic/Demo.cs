namespace DesignPatterns.Core.Structural.Adapter.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Adapter Pattern - Ejemplo Básico: Audio Players ===\n");

        // Usar MP3Player directamente
        Console.WriteLine("--- MP3 Player (sin adapter) ---");
        IAudioPlayer mp3 = new MP3Player();
        mp3.PlayAudio("cancion.mp3");
        mp3.StopAudio();

        // Usar VLC mediante adapter
        Console.WriteLine("\n--- VLC Player (con adapter) ---");
        var vlc = new VLCPlayer();
        IAudioPlayer vlcAdapter = new VLCAdapter(vlc);
        vlcAdapter.PlayAudio("video.mkv");
        vlcAdapter.StopAudio();

        // Usar adapter universal
        Console.WriteLine("\n--- Universal Audio Adapter ---");
        IAudioPlayer universal = new UniversalAudioAdapter(new MP3Player());
        universal.PlayAudio("musica.wav");
        universal.PlayAudio("audio.flac");
        universal.StopAudio();

        Console.WriteLine("\nAdapter permite integrar componentes incompatibles");
    }
}