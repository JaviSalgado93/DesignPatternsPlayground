namespace DesignPatterns.Core.Behavioral.Observer.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Notificación de cambios de precio
/// </summary>

public interface IStockObserver
{
    void Update(Stock stock);
}

public class Stock
{
    private string _symbol;
    private decimal _price;
    private List<IStockObserver> _observers = new();

    public Stock(string symbol, decimal initialPrice)
    {
        _symbol = symbol;
        _price = initialPrice;
    }

    public string Symbol => _symbol;
    public decimal Price => _price;

    public void Subscribe(IStockObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            Console.WriteLine($"[Stock {_symbol}] Observador suscrito");
        }
    }

    public void Unsubscribe(IStockObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
            Console.WriteLine($"[Stock {_symbol}] Observador desuscrito");
        }
    }

    public void SetPrice(decimal newPrice)
    {
        if (newPrice != _price)
        {
            var oldPrice = _price;
            _price = newPrice;
            Console.WriteLine($"[Stock {_symbol}] Precio cambió: ${oldPrice} → ${_price}");
            NotifyObservers();
        }
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

public class Investor : IStockObserver
{
    private string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(Stock stock)
    {
        Console.WriteLine($"  → [{_name}] Acción: {stock.Symbol} ahora está a ${stock.Price}");
    }
}

public class TradingBot : IStockObserver
{
    public void Update(Stock stock)
    {
        if (stock.Price > 100)
        {
            Console.WriteLine($"  → [Bot] VENDER: {stock.Symbol} está alto (${stock.Price})");
        }
        else if (stock.Price < 50)
        {
            Console.WriteLine($"  → [Bot] COMPRAR: {stock.Symbol} está bajo (${stock.Price})");
        }
    }
}