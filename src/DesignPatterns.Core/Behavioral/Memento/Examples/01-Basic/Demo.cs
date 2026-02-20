namespace DesignPatterns.Core.Behavioral.Memento.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Memento Pattern - Ejemplo Básico: Text Editor ===\n");

        var editor = new TextEditor();
        var history = new EditorHistory();

        Console.WriteLine("--- Escribiendo y guardando snapshots ---");
        editor.Write("Hola");
        history.Save(editor.CreateSnapshot());

        editor.Write(" ");
        editor.Write("Mundo");
        history.Save(editor.CreateSnapshot());

        editor.Write("!");
        history.Save(editor.CreateSnapshot());

        editor.ShowContent();

        history.ShowSnapshots();

        Console.WriteLine("\n--- Restaurando a snapshot anterior ---");
        editor.RestoreFromSnapshot(history.Get(1));
        editor.ShowContent();

        Console.WriteLine("\n--- Restaurando a primer snapshot ---");
        editor.RestoreFromSnapshot(history.Get(0));
        editor.ShowContent();

        Console.WriteLine("\n Memento permite guardar y restaurar estados");
    }
}