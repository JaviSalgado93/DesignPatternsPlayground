namespace DesignPatterns.Core.Structural.Decorator.Implementation;

/// <summary>
/// Component - Define interfaz común para objetos y decoradores
/// </summary>
public interface IComponent
{
    void Operation();
    string GetDescription();
}