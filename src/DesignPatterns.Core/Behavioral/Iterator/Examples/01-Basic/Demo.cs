using System;
namespace DesignPatterns.Core.Behavioral.Iterator.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Iterator Pattern - Ejemplo Básico: Book Collection ===\n");

        var library = new BookCollection();

        Console.WriteLine("--- Agregando libros ---");
        library.AddBook(new Book("1984", "George Orwell", 1949));
        library.AddBook(new Book("Brave New World", "Aldous Huxley", 1932));
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
        library.AddBook(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));

        Console.WriteLine($"\n--- Iteración normal (Total: {library.GetBookCount()}) ---");
        var iterator = library.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine($"  📚 {iterator.Next()}");
        }

        Console.WriteLine("\n--- Iteración inversa ---");
        var reverseIterator = library.CreateReverseIterator();
        while (reverseIterator.HasNext())
        {
            Console.WriteLine($"  📚 {reverseIterator.Next()}");
        }

        Console.WriteLine("\n--- Libros publicados en 1951 ---");
        var yearIterator = library.CreateIteratorByYear(1951);
        while (yearIterator.HasNext())
        {
            Console.WriteLine($"  📚 {yearIterator.Next()}");
        }

        Console.WriteLine("\n Iterator permite recorrer sin exponer estructura interna");
    }
}