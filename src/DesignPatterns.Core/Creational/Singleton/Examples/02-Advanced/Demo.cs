namespace DesignPatterns.Core.Creational.Singleton.Examples._02_Advanced;

/// <summary>
/// Demostración del Singleton Pattern - Ejemplos Avanzados
/// </summary>
public class Demo
{
    public static void RunLazyDemo()
    {
        Console.WriteLine("=== Singleton Pattern - Ejemplo Avanzado: Lazy Initialization ===\n");

        Console.WriteLine("Antes de acceder a la instancia:");
        Console.WriteLine($"¿Instancia creada? {LazyInitialization.Instance.IsValueCreated}");

        Console.WriteLine("\nAccediendo a la instancia por primera vez.. .");
        var instance1 = LazyInitialization.Instance;
        Console.WriteLine($"¿Instancia creada? {instance1.IsValueCreated}");

        Console.WriteLine("\nInformación de la instancia:");
        Console.WriteLine(instance1.GetInstanceInfo());

        Console.WriteLine("\nAccediendo nuevamente:");
        var instance2 = LazyInitialization.Instance;
        instance2.Access();

        Console.WriteLine($"\n¿Misma instancia? {ReferenceEquals(instance1, instance2)}");
        Console.WriteLine(instance2.GetInstanceInfo());
    }

    public static void RunThreadSafeDemo()
    {
        Console.WriteLine("\n\n=== Singleton Pattern - Ejemplo Avanzado: Thread-Safe ===\n");

        // Creamos múltiples hilos que acceden a la instancia
        var threads = new List<Thread>();

        for (int i = 0; i < 5; i++)
        {
            var thread = new Thread(() =>
            {
                var singleton = ThreadSafeSingleton.Instance;
                singleton.IncrementCounter();
                System.Threading.Thread.Sleep(100);
                singleton.IncrementCounter();
            })
            {
                Name = $"Worker-{i}"
            };
            threads.Add(thread);
        }

        Console.WriteLine("Iniciando 5 hilos simultáneos...\n");
        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        var finalSingleton = ThreadSafeSingleton.Instance;
        Console.WriteLine($"\nValor final del contador: {finalSingleton.GetCounterValue()}");
        Console.WriteLine($"Se esperaba: 10 (5 hilos × 2 incrementos cada uno)");
    }
}