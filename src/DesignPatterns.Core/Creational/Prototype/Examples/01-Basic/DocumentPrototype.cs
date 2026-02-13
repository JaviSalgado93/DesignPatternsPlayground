namespace DesignPatterns.Core.Creational.Prototype.Examples._01_Basic;

public class Document : IPrototype
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDate { get; set; }

    public Document(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
        CreatedDate = DateTime.Now;
    }

    public IPrototype Clone()
    {
        return new Document(Title, Content, Author)
        {
            CreatedDate = this.CreatedDate
        };
    }

    public void Display()
    {
        Console.WriteLine($"\n--- Documento ---");
        Console.WriteLine($"Título: {Title}");
        Console.WriteLine($"Autor: {Author}");
        Console.WriteLine($"Contenido: {Content}");
        Console.WriteLine($"Creado: {CreatedDate:yyyy-MM-dd HH:mm:ss}");
    }
}

public interface IPrototype
{
    IPrototype Clone();
}