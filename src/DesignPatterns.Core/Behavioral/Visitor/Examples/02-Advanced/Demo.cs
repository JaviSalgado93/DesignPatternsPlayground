namespace DesignPatterns.Core.Behavioral.Visitor.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Visitor Pattern - Ejemplo Avanzado: Document Processing ===\n");

        var document = new Document();
        document.AddElement(new Paragraph("Este es el primer párrafo del documento."));
        document.AddElement(new Image("foto.jpg", "Foto de ejemplo"));
        document.AddElement(new Link("https://example.com", "Visita nuestro sitio"));
        document.AddElement(new Table(3, 4));
        document.AddElement(new Paragraph("Este es el segundo párrafo."));

        Console.WriteLine("--- Contando palabras ---");
        var wordCounter = new WordCountVisitor();
        document.Accept(wordCounter);
        Console.WriteLine($"  📊 Total de palabras: {wordCounter.GetWordCount()}\n");

        Console.WriteLine("--- Exportando a HTML ---");
        var htmlExporter = new HTMLExportVisitor();
        document.Accept(htmlExporter);
        Console.WriteLine("  ✓ Exportación completada\n");

        Console.WriteLine("--- Validando documento ---");
        var validator = new ValidationVisitor();
        document.Accept(validator);
        if (validator.IsValid())
            Console.WriteLine("  ✓ Documento válido");
        else
        {
            Console.WriteLine("  ✗ Errores encontrados:");
            foreach (var error in validator.GetErrors())
                Console.WriteLine($"    - {error}");
        }

        Console.WriteLine("\n Visitor permite operaciones complejas sin modificar elementos");
    }
}