namespace DesignPatterns.Core.Structural.Bridge.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Bridge Pattern - Ejemplo Avanzado: Window Renderers ===\n");

        var renderers = new List<(string name, IRenderer renderer)>
        {
            ("Windows", new WindowsRenderer()),
            ("Linux", new LinuxRenderer()),
            ("Mac", new MacRenderer())
        };

        foreach (var (name, renderer) in renderers)
        {
            Console.WriteLine($"\n--- Aplicación en {name} ---");
            var appWindow = new ApplicationWindow(renderer, "Mi Aplicación");
            appWindow.Draw();

            Console.WriteLine($"\n--- Diálogo en {name} ---");
            var dialog = new DialogWindow(renderer, "¿Estás seguro?");
            dialog.Draw();
        }

        // Cambiar renderer en tiempo de ejecución
        Console.WriteLine($"\n--- Cambiar renderer en runtime ---");
        var window = new ApplicationWindow(new WindowsRenderer(), "Aplicación");
        window.Draw();

        Console.WriteLine("\n[Cambiando a Linux...]");
        window.SetRenderer(new LinuxRenderer());
        window.Draw();

        Console.WriteLine("\n✅ Bridge permite cambiar abstracción e implementación independientemente");
    }
}