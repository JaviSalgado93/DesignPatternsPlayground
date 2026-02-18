namespace DesignPatterns.Core.Structural.Adapter.Implementation;

/// <summary>
/// Adapter que convierte OldMediaPlayer a IModernPlayer
/// </summary>
public class MediaPlayerAdapter : IModernPlayer
{
    private OldMediaPlayer _oldPlayer;

    public MediaPlayerAdapter(OldMediaPlayer oldPlayer)
    {
        _oldPlayer = oldPlayer;
    }

    public void Play(string fileName)
    {
        _oldPlayer.StartMedia(fileName);
    }

    public void Pause()
    {
        _oldPlayer.PauseMedia();
    }

    public void Stop()
    {
        _oldPlayer.StopMedia();
    }

    public string GetCurrentFile()
    {
        return _oldPlayer.GetMediaFile();
    }
}