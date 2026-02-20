namespace DesignPatterns.Core.Behavioral.TemplateMethod.Implementation;

/// <summary>
/// AbstractClass - Define template method
/// </summary>
public abstract class DataProcessor
{
    /// <summary>
    /// Template Method - Define el esqueleto del algoritmo
    /// </summary>
    public void Process(string filePath)
    {
        Console.WriteLine($"[DataProcessor] Iniciando procesamiento de: {filePath}\n");

        OpenFile(filePath);
        Console.WriteLine();

        ReadData();
        Console.WriteLine();

        ProcessData();
        Console.WriteLine();

        SaveData();
        Console.WriteLine();

        CloseFile();
        Console.WriteLine($"[DataProcessor] Procesamiento completado\n");
    }

    /// <summary>
    /// Pasos concretos (comunes a todas las subclases)
    /// </summary>
    protected virtual void OpenFile(string filePath)
    {
        Console.WriteLine($"  [Template] Abriendo archivo: {filePath}");
    }

    protected virtual void CloseFile()
    {
        Console.WriteLine($"  [Template] Cerrando archivo");
    }

    /// <summary>
    /// Pasos abstractos (implementados por subclases)
    /// </summary>
    protected abstract void ReadData();
    protected abstract void ProcessData();
    protected abstract void SaveData();
}