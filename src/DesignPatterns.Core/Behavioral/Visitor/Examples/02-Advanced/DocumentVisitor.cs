using System.Text;

namespace DesignPatterns.Core.Behavioral.Visitor.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Procesamiento de elementos de documento
/// </summary>

public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
    string GetContent();
}

public interface IDocumentVisitor
{
    void VisitParagraph(Paragraph paragraph);
    void VisitImage(Image image);
    void VisitLink(Link link);
    void VisitTable(Table table);
}

public class Paragraph : IDocumentElement
{
    public string Content { get; set; }

    public Paragraph(string content)
    {
        Content = content;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.VisitParagraph(this);
    }

    public string GetContent() => Content;
}

public class Image : IDocumentElement
{
    public string FilePath { get; set; }
    public string AltText { get; set; }

    public Image(string filePath, string altText)
    {
        FilePath = filePath;
        AltText = altText;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.VisitImage(this);
    }

    public string GetContent() => $"[Imagen: {FilePath}]";
}

public class Link : IDocumentElement
{
    public string Url { get; set; }
    public string Text { get; set; }

    public Link(string url, string text)
    {
        Url = url;
        Text = text;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.VisitLink(this);
    }

    public string GetContent() => $"[{Text}]({Url})";
}

public class Table : IDocumentElement
{
    public int Rows { get; set; }
    public int Columns { get; set; }

    public Table(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.VisitTable(this);
    }

    public string GetContent() => $"[Tabla {Rows}x{Columns}]";
}

/// <summary>
/// Visitor para contar palabras
/// </summary>
public class WordCountVisitor : IDocumentVisitor
{
    private int _wordCount = 0;

    public void VisitParagraph(Paragraph paragraph)
    {
        var words = paragraph.Content.Split(' ').Length;
        _wordCount += words;
        Console.WriteLine($"  📝 Párrafo: {words} palabras");
    }

    public void VisitImage(Image image)
    {
        Console.WriteLine($"  🖼️  Imagen: {image.AltText}");
    }

    public void VisitLink(Link link)
    {
        var words = link.Text.Split(' ').Length;
        _wordCount += words;
        Console.WriteLine($"  🔗 Link: {words} palabras");
    }

    public void VisitTable(Table table)
    {
        Console.WriteLine($"  📊 Tabla: {table.Rows}x{table.Columns}");
    }

    public int GetWordCount() => _wordCount;
}

/// <summary>
/// Visitor para exportar a HTML
/// </summary>
public class HTMLExportVisitor : IDocumentVisitor
{
    private StringBuilder _html = new();

    public void VisitParagraph(Paragraph paragraph)
    {
        _html.AppendLine($"<p>{paragraph.Content}</p>");
    }

    public void VisitImage(Image image)
    {
        _html.AppendLine($"<img src=\"{image.FilePath}\" alt=\"{image.AltText}\" />");
    }

    public void VisitLink(Link link)
    {
        _html.AppendLine($"<a href=\"{link.Url}\">{link.Text}</a>");
    }

    public void VisitTable(Table table)
    {
        _html.AppendLine($"<table rows=\"{table.Rows}\" cols=\"{table.Columns}\"></table>");
    }

    public string GetHTML() => _html.ToString();
}

/// <summary>
/// Visitor para validar documento
/// </summary>
public class ValidationVisitor : IDocumentVisitor
{
    private List<string> _errors = new();

    public void VisitParagraph(Paragraph paragraph)
    {
        if (string.IsNullOrEmpty(paragraph.Content))
            _errors.Add("Párrafo vacío");
        if (paragraph.Content.Length > 1000)
            _errors.Add("Párrafo muy largo");
    }

    public void VisitImage(Image image)
    {
        if (!File.Exists(image.FilePath))
            _errors.Add($"Imagen no encontrada: {image.FilePath}");
    }

    public void VisitLink(Link link)
    {
        if (string.IsNullOrEmpty(link.Url))
            _errors.Add("URL vacía");
    }

    public void VisitTable(Table table)
    {
        if (table.Rows == 0 || table.Columns == 0)
            _errors.Add("Tabla vacía");
    }

    public bool IsValid() => _errors.Count == 0;
    public List<string> GetErrors() => _errors;
}

/// <summary>
/// Documento con elementos
/// </summary>
public class Document
{
    private List<IDocumentElement> _elements = new();

    public void AddElement(IDocumentElement element)
    {
        _elements.Add(element);
    }

    public void Accept(IDocumentVisitor visitor)
    {
        foreach (var element in _elements)
        {
            element.Accept(visitor);
        }
    }

    public int GetElementCount() => _elements.Count;
}