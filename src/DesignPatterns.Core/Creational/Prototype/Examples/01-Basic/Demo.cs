namespace DesignPatterns.Core.Creational.Prototype.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Prototype Pattern - Ejemplo Básico: Document Cloning ===\n");

        // Crear documento original
        var originalDoc = new Document(
            "Mi Propuesta",
            "Esta es una propuesta importante...",
            "Juan Pérez"
        );

        originalDoc.Display();

        // Clonar el documento
        var clonedDoc = originalDoc.Clone() as Document;
        clonedDoc.Title = "Propuesta - Revisión 2";
        clonedDoc.Content = "Contenido actualizado...";

        Console.WriteLine("\n--- Después de clonar y modificar ---");
        clonedDoc.Display();

        // Verificar que son objetos diferentes
        Console.WriteLine($"\n¿Son el mismo objeto? {ReferenceEquals(originalDoc, clonedDoc)}");
        Console.WriteLine($"Original sigue intacto: {originalDoc.Title}");

        Console.WriteLine("\n Prototype permite clonar objetos de forma eficiente");
    }
}