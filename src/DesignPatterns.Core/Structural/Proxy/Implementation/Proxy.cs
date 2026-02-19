namespace DesignPatterns.Core.Structural.Proxy.Implementation;

/// <summary>
/// Proxy - Controla acceso a RealSubject
/// </summary>
public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        // Lazy loading - solo crear cuando se necesita
        if (_realSubject == null)
        {
            Console.WriteLine("[Proxy] Creando RealSubject...");
            _realSubject = new RealSubject();
        }

        Console.WriteLine("[Proxy] Acceso permitido, delegando a RealSubject");
        _realSubject.Request();
    }
}