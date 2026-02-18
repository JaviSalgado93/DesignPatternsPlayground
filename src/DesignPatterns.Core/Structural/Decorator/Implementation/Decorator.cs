namespace DesignPatterns.Core.Structural.Decorator.Implementation;

/// <summary>
/// Decorator - Clase base para decoradores
/// </summary>
public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public virtual void Operation()
    {
        _component.Operation();
    }

    public virtual string GetDescription()
    {
        return _component.GetDescription();
    }
}