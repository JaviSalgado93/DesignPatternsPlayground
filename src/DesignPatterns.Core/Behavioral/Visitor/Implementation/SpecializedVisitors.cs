using System.Text;

namespace DesignPatterns.Core.Behavioral.Visitor.Implementation;

/// <summary>
/// Visitor para exportar datos
/// </summary>
public class ExportVisitor : IVisitor
{
    private StringBuilder _output = new();

    public void VisitConcreteElementA(ConcreteElementA element)
    {
        _output.AppendLine($"Exportando {element.GetName()} a formato A");
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        _output.AppendLine($"Exportando {element.GetName()} a formato B");
    }

    public string GetExportedData() => _output.ToString();
}

/// <summary>
/// Visitor para validar datos
/// </summary>
public class ValidationVisitor : IVisitor
{
    private List<string> _errors = new();

    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine($"  ✓ Validando {element.GetName()}");
        if (element.GetName().Length > 50)
            _errors.Add($"{element.GetName()} muy largo");
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine($"  ✓ Validando {element.GetName()}");
        if (element.GetName().Contains("Inválido"))
            _errors.Add($"{element.GetName()} contiene palabra prohibida");
    }

    public bool IsValid() => _errors.Count == 0;
    public List<string> GetErrors() => _errors;
}

/// <summary>
/// Visitor para registrar cambios
/// </summary>
public class LoggingVisitor : IVisitor
{
    private string _logFile;

    public LoggingVisitor(string logFile = "visitor.log")
    {
        _logFile = logFile;
    }

    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine($"  📝 [Log] Registrando visita a {element.GetName()}");
        Console.WriteLine($"     Archivo: {_logFile}");
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine($"  📝 [Log] Registrando visita a {element.GetName()}");
        Console.WriteLine($"     Archivo: {_logFile}");
    }
}