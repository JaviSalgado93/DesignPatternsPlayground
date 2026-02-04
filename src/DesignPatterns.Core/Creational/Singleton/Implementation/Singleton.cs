namespace DesignPatterns.Core.Creational.Singleton.Implementation;

/// <summary>
/// Singleton Pattern - Garantiza una única instancia de la clase
/// Esta es la implementación recomendada usando Lazy<T>
/// </summary>
public sealed class Singleton
{
    // Lazy<T> se encarga de la inicialización thread-safe de forma automática
    private static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());

    /// <summary>
    /// Propiedad que proporciona acceso a la única instancia del Singleton
    /// </summary>
    public static Singleton Instance => _lazy.Value;

    /// <summary>
    /// Contador para demostrar que la instancia es única
    /// </summary>
    private int _callCount = 0;

    /// <summary>
    /// Constructor privado - impide la creación de instancias adicionales
    /// </summary>
    private Singleton()
    {
        Console.WriteLine("[Singleton] Nueva instancia creada");
    }

    /// <summary>
    /// Método de ejemplo
    /// </summary>
    public void DoSomething()
    {
        _callCount++;
        Console.WriteLine($"[Singleton] DoSomething llamado.   Total de llamadas: {_callCount}");
    }

    /// <summary>
    /// Retorna información sobre la instancia actual
    /// </summary>
    public string GetInfo()
    {
        return $"Instancia de Singleton.   Hash Code: {GetHashCode()}.  Llamadas: {_callCount}";
    }
}