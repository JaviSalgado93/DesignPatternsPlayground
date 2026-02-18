namespace DesignPatterns.Core.Structural.Adapter.Implementation;

/// <summary>
/// Clase antigua incompatible con la interfaz esperada
/// </summary>
public class OldMediaPlayer
{
    private string _currentFile;
    private bool _isPlaying;

    public void StartMedia(string file)
    {
        _currentFile = file;
        _isPlaying = true;
        Console.WriteLine($"[Old Player] Reproduciendo: {file}");
    }

    public void StopMedia()
    {
        _isPlaying = false;
        Console.WriteLine("[Old Player] Parado");
    }

    public void PauseMedia()
    {
        _isPlaying = false;
        Console.WriteLine("[Old Player] En pausa");
    }

    public string GetMediaFile()
    {
        return _currentFile;
    }

    public bool IsMediaPlaying()
    {
        return _isPlaying;
    }
}