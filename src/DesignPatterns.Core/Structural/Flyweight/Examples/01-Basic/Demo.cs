namespace DesignPatterns.Core.Structural.Flyweight.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Flyweight Pattern - Ejemplo Básico: Text Editor ===\n");

        var factory = new CharacterFactory();

        // Crear caracteres (muchos reutilizarán el mismo objeto)
        Console.WriteLine("--- Creando texto: 'Hello' ---");
        var h = factory.GetCharacter('H', "Arial");
        var e1 = factory.GetCharacter('e', "Arial");
        var l1 = factory.GetCharacter('l', "Arial");
        var l2 = factory.GetCharacter('l', "Arial"); // Reutiliza l1
        var o = factory.GetCharacter('o', "Arial");

        Console.WriteLine($"\n--- Mostrando caracteres ---");
        h.Display(1, 1);
        e1.Display(1, 2);
        l1.Display(1, 3);
        l2.Display(1, 4);
        o.Display(1, 5);

        Console.WriteLine($"\n--- Creando más texto con fuentes diferentes ---");
        var h2 = factory.GetCharacter('H', "Times"); // Nueva fuente
        var e2 = factory.GetCharacter('e', "Arial"); // Reutiliza e1

        h2.Display(2, 1);
        e2.Display(2, 2);

        Console.WriteLine($"\n--- Estadísticas ---");
        Console.WriteLine($"Total de objetos Flyweight creados: {factory.GetCharacterCount()}");
        Console.WriteLine("Sin Flyweight: tendríamos 7 objetos");
        Console.WriteLine("Con Flyweight: solo 6 objetos compartidos");

        Console.WriteLine("\n Flyweight reduce memoria compartiendo caracteres comunes");
    }
}