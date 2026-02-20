namespace DesignPatterns.Core.Behavioral.Visitor.Implementation;

/// <summary>
/// ConcreteVisitor A
/// </summary>
public class ConcreteVisitorA : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine($"  → [VisitorA] Visitando {element.GetName()}");
        Console.WriteLine($"     Operación específica A en A");
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine($"  ��� [VisitorA] Visitando {element.GetName()}");
        Console.WriteLine($"     Operación específica A en B");
    }
}

/// <summary>
/// ConcreteVisitor B
/// </summary>
public class ConcreteVisitorB : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine($"  → [VisitorB] Visitando {element.GetName()}");
        Console.WriteLine($"     Operación específica B en A");
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine($"  → [VisitorB] Visitando {element.GetName()}");
        Console.WriteLine($"     Operación específica B en B");
    }
}

/// <summary>
/// ObjectStructure - Colección de elementos
/// </summary>
public class ObjectStructure
{
    private List<IElement> _elements = new();

    public void Add(IElement element)
    {
        _elements.Add(element);
    }

    public void Remove(IElement element)
    {
        _elements.Remove(element);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var element in _elements)
        {
            element.Accept(visitor);
        }
    }

    public int GetElementCount() => _elements.Count;
}