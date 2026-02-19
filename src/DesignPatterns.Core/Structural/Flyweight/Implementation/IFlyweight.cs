namespace DesignPatterns.Core.Structural.Flyweight.Implementation;

/// <summary>
/// Flyweight - Define interfaz para flyweights
/// </summary>
public interface IFlyweight
{
    void Operation(string extrinsicState);
    string GetIntrinsicState();
}