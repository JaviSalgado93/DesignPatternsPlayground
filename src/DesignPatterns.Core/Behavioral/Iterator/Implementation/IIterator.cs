namespace DesignPatterns.Core.Behavioral.Iterator.Implementation;

/// <summary>
/// Iterator - Define interfaz para iterar elementos
/// </summary>
public interface IIterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}

/// <summary>
/// Aggregate - Define interfaz para crear iteradores
/// </summary>
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}