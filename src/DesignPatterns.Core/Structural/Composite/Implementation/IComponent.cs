namespace DesignPatterns.Core.Structural.Composite.Implementation;

/// <summary>
/// Component - Define interfaz común para componentes y composites
/// </summary>
public interface IComponent
{
    string Name { get; }
    void Display(int indent = 0);
    int GetSize();
}