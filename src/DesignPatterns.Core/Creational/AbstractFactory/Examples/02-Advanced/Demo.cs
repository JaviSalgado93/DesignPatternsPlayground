namespace DesignPatterns.Core.Creational.AbstractFactory.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Abstract Factory Pattern - Ejemplo Avanzado: Temas ===\n");

        var themes = new[] { "light", "dark", "highcontrast" };

        foreach (var themeName in themes)
        {
            Console.WriteLine($"\n--- Tema: {themeName.ToUpper()} ---");

            var theme = ThemeFactory.CreateTheme(themeName);

            var color = theme.CreateColor();
            var font = theme.CreateFont();

            Console.WriteLine($"Color de fondo: {color.GetBackgroundColor()}");
            Console.WriteLine($"Color de texto: {color.GetForegroundColor()}");
            Console.WriteLine($"Fuente: {font.GetFontFamily()} ({font.GetFontSize()}px)");
        }

        Console.WriteLine("\n Abstract Factory gestiona familias completas de objetos relacionados");
    }
}