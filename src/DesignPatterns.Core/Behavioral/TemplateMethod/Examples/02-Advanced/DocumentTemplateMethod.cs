namespace DesignPatterns.Core.Behavioral.TemplateMethod.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Generación de documentos
/// </summary>

public abstract class Document
{
    /// <summary>
    /// Template Method para generar documento
    /// </summary>
    public void Generate(string fileName)
    {
        Console.WriteLine($"📄 Generando {GetDocumentType()}: {fileName}\n");

        CreateHeader();
        Console.WriteLine();

        CreateBody();
        Console.WriteLine();

        CreateFooter();
        Console.WriteLine();

        Format();
        Console.WriteLine();

        Save(fileName);
        Console.WriteLine();

        Console.WriteLine($"✓ {GetDocumentType()} generado exitosamente\n");
    }

    // Pasos comunes
    protected virtual void CreateHeader()
    {
        Console.WriteLine("  [Header] Creando encabezado");
    }

    protected virtual void CreateFooter()
    {
        Console.WriteLine("  [Footer] Creando pie de página");
    }

    // Pasos abstractos
    protected abstract void CreateBody();
    protected abstract void Format();
    protected abstract void Save(string fileName);
    protected abstract string GetDocumentType();
}

public class PDFDocument : Document
{
    protected override void CreateBody()
    {
        Console.WriteLine("  [PDF] Agregando contenido");
        Console.WriteLine("  [PDF] Insertando tablas");
        Console.WriteLine("  [PDF] Añadiendo imágenes");
    }

    protected override void Format()
    {
        Console.WriteLine("  [PDF] Estableciendo márgenes");
        Console.WriteLine("  [PDF] Ajustando fuentes");
        Console.WriteLine("  [PDF] Renderizando a PDF");
    }

    protected override void Save(string fileName)
    {
        Console.WriteLine($"  [PDF] Guardando como: {fileName}.pdf");
        Console.WriteLine($"  [PDF] Comprimiendo PDF");
    }

    protected override string GetDocumentType() => "Documento PDF";
}

public class WordDocument : Document
{
    protected override void CreateBody()
    {
        Console.WriteLine("  [WORD] Agregando párrafos");
        Console.WriteLine("  [WORD] Creando tablas");
        Console.WriteLine("  [WORD] Insertando imágenes");
    }

    protected override void Format()
    {
        Console.WriteLine("  [WORD] Aplicando estilos");
        Console.WriteLine("  [WORD] Configurando numeración");
        Console.WriteLine("  [WORD] Generando tabla de contenidos");
    }

    protected override void Save(string fileName)
    {
        Console.WriteLine($"  [WORD] Guardando como: {fileName}.docx");
        Console.WriteLine($"  [WORD] Comprimiendo DOCX");
    }

    protected override string GetDocumentType() => "Documento Word";
}

public class HTMLDocument : Document
{
    protected override void CreateBody()
    {
        Console.WriteLine("  [HTML] Creando estructura HTML");
        Console.WriteLine("  [HTML] Agregando contenido");
    }

    protected override void Format()
    {
        Console.WriteLine("  [HTML] Agregando CSS");
        Console.WriteLine("  [HTML] Optimizando para navegadores");
    }

    protected override void Save(string fileName)
    {
        Console.WriteLine($"  [HTML] Guardando como: {fileName}.html");
    }

    protected override string GetDocumentType() => "Documento HTML";
}

public class MarkdownDocument : Document
{
    protected override void CreateBody()
    {
        Console.WriteLine("  [MD] Escribiendo contenido en Markdown");
        Console.WriteLine("  [MD] Formateando listas");
    }

    protected override void Format()
    {
        Console.WriteLine("  [MD] Validando sintaxis Markdown");
    }

    protected override void Save(string fileName)
    {
        Console.WriteLine($"  [MD] Guardando como: {fileName}.md");
    }

    protected override string GetDocumentType() => "Documento Markdown";
}