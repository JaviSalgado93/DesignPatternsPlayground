namespace DesignPatterns.Core.Behavioral.TemplateMethod.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Template Method Pattern - Ejemplo Avanzado: Document Generation ===\n");

        var pdf = new PDFDocument();
        pdf.Generate("report");

        Console.WriteLine("─".PadRight(60, '─'));
        Console.WriteLine();

        var word = new WordDocument();
        word.Generate("invoice");

        Console.WriteLine("─".PadRight(60, '─'));
        Console.WriteLine();

        var html = new HTMLDocument();
        html.Generate("webpage");

        Console.WriteLine("─".PadRight(60, '─'));
        Console.WriteLine();

        var markdown = new MarkdownDocument();
        markdown.Generate("readme");

        Console.WriteLine(" Template Method estandariza el proceso sin sacrificar flexibilidad");
    }
}