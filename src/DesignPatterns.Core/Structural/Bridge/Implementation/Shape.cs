namespace DesignPatterns.Core.Structural.Bridge.Implementation;

/// <summary>
/// Abstraction - Define la interfaz de la abstracción
/// </summary>
public abstract class Shape
{
    protected IColor _color;

    public Shape(IColor color)
    {
        _color = color;
    }

    public abstract void Draw();

    public virtual void SetColor(IColor color)
    {
        _color = color;
    }
}