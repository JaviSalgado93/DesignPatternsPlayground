namespace DesignPatterns.Core.Behavioral.Iterator.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Librería de libros con iterador
/// </summary>

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString() => $"{Title} by {Author} ({Year})";
}

public interface IBookIterator
{
    bool HasNext();
    Book Next();
    void Reset();
}

public class BookCollection
{
    private List<Book> _books = new();

    public void AddBook(Book book) => _books.Add(book);

    public void RemoveBook(Book book) => _books.Remove(book);

    public IBookIterator CreateIterator() => new BookIterator(this);

    public IBookIterator CreateReverseIterator() => new ReverseBookIterator(this);

    public IBookIterator CreateIteratorByYear(int year) => new BookIteratorByYear(this, year);

    public int GetBookCount() => _books.Count;

    public Book GetBook(int index) => _books[index];

    private class BookIterator : IBookIterator
    {
        private BookCollection _collection;
        private int _index = 0;

        public BookIterator(BookCollection collection) => _collection = collection;

        public bool HasNext() => _index < _collection.GetBookCount();

        public Book Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();
            return _collection.GetBook(_index++);
        }

        public void Reset() => _index = 0;
    }

    private class ReverseBookIterator : IBookIterator
    {
        private BookCollection _collection;
        private int _index;

        public ReverseBookIterator(BookCollection collection)
        {
            _collection = collection;
            _index = collection.GetBookCount() - 1;
        }

        public bool HasNext() => _index >= 0;

        public Book Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();
            return _collection.GetBook(_index--);
        }

        public void Reset() => _index = _collection.GetBookCount() - 1;
    }

    private class BookIteratorByYear : IBookIterator
    {
        private BookCollection _collection;
        private int _year;
        private int _index = 0;

        public BookIteratorByYear(BookCollection collection, int year)
        {
            _collection = collection;
            _year = year;
        }

        public bool HasNext()
        {
            while (_index < _collection.GetBookCount())
            {
                if (_collection.GetBook(_index).Year == _year)
                    return true;
                _index++;
            }
            return false;
        }

        public Book Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();
            return _collection.GetBook(_index++);
        }

        public void Reset() => _index = 0;
    }
}