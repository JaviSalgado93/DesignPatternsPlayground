namespace DesignPatterns.Core.Behavioral.Memento.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Memento Pattern - Ejemplo Avanzado: Document Versioning ===\n");

        var doc = new Document("Reporte Trimestral", "Juan");
        var history = new DocumentHistory();

        Console.WriteLine("--- Creando versiones de documento ---");

        doc.Edit("Introducción del reporte Q1");
        history.SaveVersion(doc.CreateVersion());

        doc.Edit("Introducción del reporte Q1\n\nResultados: Crecimiento del 15%");
        history.SaveVersion(doc.CreateVersion());

        doc.Edit("Introducción del reporte Q1\n\nResultados: Crecimiento del 15%\nConclusión: Muy positivo");
        history.SaveVersion(doc.CreateVersion());

        doc.ShowInfo();

        history.ShowVersionHistory();

        Console.WriteLine("\n--- Restaurando a versión anterior ---");
        doc.RestoreVersion(history.GetVersion(1));
        doc.ShowInfo();

        Console.WriteLine("\n--- Restaurando a versión 3 ---");
        doc.RestoreVersion(history.GetVersion(3));
        doc.ShowInfo();

        Console.WriteLine($"\n[History] Total de versiones: {history.GetVersionCount()}");
        Console.WriteLine("\n Memento permite completo control de versiones");
    }
}