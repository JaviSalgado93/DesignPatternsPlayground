namespace DesignPatterns.Core.Structural.Adapter.Implementation;

/// <summary>
/// Implementación moderna que implementa IModernPlayer
/// </summary>
public class ModernMediaPlayer : IModernPlayer
{
    private string _currentFile;
    private bool _isPlaying;

    public void Play(string fileName)
    {
        _currentFile = fileName;
        _isPlaying = true;
        Console.WriteLine($"[Modern Player] Reproduciendo: {fileName}");
    }

    public void Pause()
    {
        _isPlaying = false;
        Console.WriteLine("[Modern Player] En pausa");
    }

    public void Stop()
    {
        _isPlaying = false;
        _currentFile = null;
        Console.WriteLine("[Modern Player] Detenido");
    }

    public string GetCurrentFile()
    {
        return _currentFile;
    }
}