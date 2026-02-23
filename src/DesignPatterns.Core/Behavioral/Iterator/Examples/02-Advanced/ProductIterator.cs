namespace DesignPatterns.Core.Behavioral.Iterator.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Catálogo de productos con múltiples iteradores
/// </summary>

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public override string ToString() => $"{Name} - ${Price:F2} ({Stock} units)";
}

public interface IProductIterator
{
    bool HasNext();
    Product Next();
    void Reset();
}

public class ProductCatalog
{
    private List<Product> _products = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
        Console.WriteLine($"  + Producto agregado: {product.Name}");
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
        Console.WriteLine($"  - Producto removido: {product.Name}");
    }

    public IProductIterator CreateIterator() => new ProductIterator(this);

    public IProductIterator CreateIteratorByPriceRange(decimal minPrice, decimal maxPrice)
        => new PriceRangeIterator(this, minPrice, maxPrice);

    public IProductIterator CreateIteratorByStock(int minStock)
        => new StockIterator(this, minStock);

    public IProductIterator CreateIteratorSortedByPrice()
        => new SortedPriceIterator(this);

    public int GetProductCount() => _products.Count;

    public Product GetProduct(int index) => _products[index];

    /// <summary>
    /// Iterator básico
    /// </summary>
    private class ProductIterator : IProductIterator
    {
        private ProductCatalog _catalog;
        private int _index = 0;

        public ProductIterator(ProductCatalog catalog) => _catalog = catalog;

        public bool HasNext() => _index < _catalog.GetProductCount();

        public Product Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No hay más productos");
            return _catalog.GetProduct(_index++);
        }

        public void Reset()
        {
            _index = 0;
            Console.WriteLine("[ProductIterator] Reiniciando");
        }
    }

    /// <summary>
    /// Iterator por rango de precio
    /// </summary>
    private class PriceRangeIterator : IProductIterator
    {
        private ProductCatalog _catalog;
        private decimal _minPrice;
        private decimal _maxPrice;
        private int _index = 0;

        public PriceRangeIterator(ProductCatalog catalog, decimal minPrice, decimal maxPrice)
        {
            _catalog = catalog;
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public bool HasNext()
        {
            while (_index < _catalog.GetProductCount())
            {
                var product = _catalog.GetProduct(_index);
                if (product.Price >= _minPrice && product.Price <= _maxPrice)
                    return true;
                _index++;
            }
            return false;
        }

        public Product Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No hay más productos");
            return _catalog.GetProduct(_index++);
        }

        public void Reset()
        {
            _index = 0;
            Console.WriteLine($"[PriceRangeIterator] Reiniciando (${_minPrice} - ${_maxPrice})");
        }
    }

    /// <summary>
    /// Iterator por stock mínimo
    /// </summary>
    private class StockIterator : IProductIterator
    {
        private ProductCatalog _catalog;
        private int _minStock;
        private int _index = 0;

        public StockIterator(ProductCatalog catalog, int minStock)
        {
            _catalog = catalog;
            _minStock = minStock;
        }

        public bool HasNext()
        {
            while (_index < _catalog.GetProductCount())
            {
                if (_catalog.GetProduct(_index).Stock >= _minStock)
                    return true;
                _index++;
            }
            return false;
        }

        public Product Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No hay más productos");
            return _catalog.GetProduct(_index++);
        }

        public void Reset()
        {
            _index = 0;
            Console.WriteLine($"[StockIterator] Reiniciando (mín. stock: {_minStock})");
        }
    }

    /// <summary>
    /// Iterator ordenado por precio
    /// </summary>
    private class SortedPriceIterator : IProductIterator
    {
        private List<Product> _sorted;
        private int _index = 0;

        public SortedPriceIterator(ProductCatalog catalog)
        {
            _sorted = catalog._products.OrderBy(p => p.Price).ToList();
        }

        public bool HasNext() => _index < _sorted.Count;

        public Product Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("No hay más productos");
            return _sorted[_index++];
        }

        public void Reset()
        {
            _index = 0;
            Console.WriteLine("[SortedPriceIterator] Reiniciando (ordenado por precio)");
        }
    }
}