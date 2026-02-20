namespace DesignPatterns.Core.Behavioral.State.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== State Pattern - Ejemplo Avanzado: Document Editor ===\n");

        var doc = new Document();

        Console.WriteLine("--- Intentando editar en readonly ---");
        doc.Edit("Hola Mundo");

        Console.WriteLine("\n--- Guardando documento ---");
        doc.Save();

        Console.WriteLine("\n--- Editando nuevamente ---");
        doc.Edit("Contenido actualizado");

        Console.WriteLine("\n--- Intentando cerrar con cambios ---");
        doc.Close();

        Console.WriteLine("\n--- Intentando editar documento cerrado ---");
        doc.Edit("Más contenido");

        Console.WriteLine("\n State gestiona transiciones y comportamiento complejo");
    }
}