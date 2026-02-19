namespace DesignPatterns.Core.Behavioral.Command.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Command Pattern - Ejemplo Avanzado: Text Editor ===\n");

        var document = new TextDocument();
        var editor = new TextEditorInvoker();

        Console.WriteLine("--- Editando documento ---");
        editor.Execute(new InsertTextCommand(document, 0, "Hello "));
        editor.Execute(new InsertTextCommand(document, 6, "World"));
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        editor.Execute(new InsertTextCommand(document, 11, "!"));
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        editor.Execute(new ReplaceTextCommand(document, 0, 5, "Hi"));
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        Console.WriteLine("--- Deshaciendo ediciones ---");
        editor.Undo();
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        editor.Undo();
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        editor.Undo();
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        Console.WriteLine("--- Rehaciendo ediciones ---");
        editor.Redo();
        Console.WriteLine($"Contenido: '{document.GetContent()}'\n");

        Console.WriteLine($"Historial de comandos: {editor.GetHistorySize()}");
        Console.WriteLine("\n Command permite undo/redo con encapsulación");
    }
}