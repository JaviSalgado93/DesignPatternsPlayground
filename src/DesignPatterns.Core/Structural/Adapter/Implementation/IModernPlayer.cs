namespace DesignPatterns.Core.Structural.Adapter.Implementation;

/// <summary>
/// Interfaz que el cliente espera
/// </summary>
public interface IModernPlayer
{
    void Play(string fileName);
    void Pause();
    void Stop();
    string GetCurrentFile();
}