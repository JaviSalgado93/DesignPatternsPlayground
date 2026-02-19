namespace DesignPatterns.Core.Structural.Proxy.Implementation;

/// <summary>
/// RealSubject - Objeto original que queremos proteger/controlar
/// </summary>
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("[RealSubject] Procesando solicitud costosa...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("[RealSubject] Solicitud completada");
    }
}