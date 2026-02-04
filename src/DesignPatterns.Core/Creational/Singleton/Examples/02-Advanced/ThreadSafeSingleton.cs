namespace DesignPatterns.Core.Creational.Singleton.Examples._02_Advanced;

/// <summary>
/// Singleton Thread-Safe usando Double-Check Locking
/// Este patrón asegura que solo UN hilo cree la instancia
/// </summary>
public sealed class ThreadSafeSingleton
{
    private static ThreadSafeSingleton? _instance;
    private static readonly object _lock = new object();

    private int _threadSafeCounter = 0;

    private ThreadSafeSingleton()
    {
        Console.WriteLine($"[ThreadSafeSingleton] Instancia creada por el hilo:  {Thread.CurrentThread.ManagedThreadId}");
    }

    /// <summary>
    /// Acceso thread-safe a la instancia única
    /// Usa Double-Check Locking para minimizar los bloqueos
    /// </summary>
    public static ThreadSafeSingleton Instance
    {
        get
        {
            // Primera verificación sin bloqueo (optimización)
            if (_instance == null)
            {
                // Bloqueo solo si es necesario
                lock (_lock)
                {
                    // Segunda verificación dentro del bloqueo
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }
            return _instance;
        }
    }

    public void IncrementCounter()
    {
        lock (_lock)
        {
            _threadSafeCounter++;
            Console.WriteLine($"[Hilo {Thread.CurrentThread.ManagedThreadId}] Contador: {_threadSafeCounter}");
        }
    }

    public int GetCounterValue()
    {
        lock (_lock)
        {
            return _threadSafeCounter;
        }
    }
}