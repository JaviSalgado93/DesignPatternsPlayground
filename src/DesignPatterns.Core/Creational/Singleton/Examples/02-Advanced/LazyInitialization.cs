namespace DesignPatterns.Core.Creational.Singleton.Examples._02_Advanced;

/// <summary>
/// Singleton con Lazy Initialization
/// La instancia se crea solo cuando se accede por primera vez
/// </summary>
public sealed class LazyInitialization
{
    // Lazy<T> maneja automáticamente la sincronización thread-safe
    private static readonly Lazy<LazyInitialization> _instance =
        new Lazy<LazyInitialization>(
            valueFactory: () => new LazyInitialization(),
            isThreadSafe: true  // Explícitamente thread-safe
        );

    public static LazyInitialization Instance => _instance.Value;

    private readonly string _instanceId = Guid.NewGuid().ToString();
    private readonly DateTime _createdAt = DateTime.Now;
    private int _accessCount = 0;

    private LazyInitialization()
    {
        Console.WriteLine($"[LazyInitialization] Instancia creada con ID: {_instanceId}");
        System.Threading.Thread.Sleep(1000); // Simula trabajo pesado en la inicialización
    }

    public void Access()
    {
        _accessCount++;
        Console.WriteLine($"[LazyInitialization] Acceso #{_accessCount} en hilo {Thread.CurrentThread.ManagedThreadId}");
    }

    public string GetInstanceInfo()
    {
        return $"ID: {_instanceId}, Creado: {_createdAt: G}, Accesos: {_accessCount}";
    }

    public bool IsValueCreated => _instance.IsValueCreated;
}