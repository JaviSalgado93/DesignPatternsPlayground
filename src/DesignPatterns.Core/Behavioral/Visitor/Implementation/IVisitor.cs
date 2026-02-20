namespace DesignPatterns.Core.Behavioral.Visitor.Implementation;

/// <summary>
/// Element - Define interfaz para aceptar visitors
/// </summary>
public interface IElement
{
    void Accept(IVisitor visitor);
    string GetName();
}

/// <summary>
/// Visitor - Define interfaz para operaciones
/// </summary>
public interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA element);
    void VisitConcreteElementB(ConcreteElementB element);
}

/// <summary>
/// ConcreteElement A
/// </summary>
public class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public string GetName() => "Elemento A";
}

/// <summary>
/// ConcreteElement B
/// </summary>
public class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public string GetName() => "Elemento B";
}