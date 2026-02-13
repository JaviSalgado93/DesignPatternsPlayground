namespace DesignPatterns.Core.Creational.AbstractFactory.Examples._01_Basic;

using DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Abstract Factory Pattern - Ejemplo Básico: UI Multiplataforma ===\n");

        var platforms = new[] { "windows", "macos", "linux" };

        foreach (var platform in platforms)
        {
            Console.WriteLine($"\n--- Renderizando en {platform.ToUpper()} ---");

            IUIFactory factory = platform.ToLower() switch
            {
                "windows" => new WindowsUIFactory(),
                "macos" => new MacUIFactory(),
                "linux" => new LinuxUIFactory(),
                _ => throw new ArgumentException("Plataforma desconocida")
            };

            var app = new UIApplication(factory);
            app.Render();
        }

        Console.WriteLine("\n Abstract Factory permite cambiar la familia completa de componentes");
    }
}