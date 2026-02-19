namespace DesignPatterns.Core.Behavioral.Iterator.Implementation;

/// <summary>
/// Iterator - Define interfaz para iteradores
/// </summary>
public interface IIterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}

/// <summary>
/// Aggregate - Define interfaz para colecciones
/// </summary>
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}