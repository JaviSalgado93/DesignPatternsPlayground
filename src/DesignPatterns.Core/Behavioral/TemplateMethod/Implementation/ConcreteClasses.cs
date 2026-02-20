namespace DesignPatterns.Core.Behavioral.TemplateMethod.Implementation;

/// <summary>
/// ConcreteClass A - Implementa pasos específicos
/// </summary>
public class CSVProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("  [CSV] Leyendo datos CSV");
        Console.WriteLine("  [CSV] Parseando columnas");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("  [CSV] Validando datos");
        Console.WriteLine("  [CSV] Aplicando transformaciones CSV");
    }

    protected override void SaveData()
    {
        Console.WriteLine("  [CSV] Guardando en formato CSV");
    }
}

/// <summary>
/// ConcreteClass B - Implementa pasos específicos
/// </summary>
public class JSONProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("  [JSON] Leyendo datos JSON");
        Console.WriteLine("  [JSON] Deserializando JSON");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("  [JSON] Validando schema JSON");
        Console.WriteLine("  [JSON] Transformando estructura");
    }

    protected override void SaveData()
    {
        Console.WriteLine("  [JSON] Serializando a JSON");
        Console.WriteLine("  [JSON] Guardando archivo JSON");
    }
}

/// <summary>
/// ConcreteClass C - Implementa pasos específicos
/// </summary>
public class XMLProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("  [XML] Leyendo documento XML");
        Console.WriteLine("  [XML] Parseando elementos");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("  [XML] Validando DTD/Schema");
        Console.WriteLine("  [XML] Aplicando XSLT");
    }

    protected override void SaveData()
    {
        Console.WriteLine("  [XML] Formateando XML");
        Console.WriteLine("  [XML] Escribiendo archivo XML");
    }
}