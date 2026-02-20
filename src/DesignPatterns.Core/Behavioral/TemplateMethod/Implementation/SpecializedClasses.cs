namespace DesignPatterns.Core.Behavioral.TemplateMethod.Implementation;

/// <summary>
/// Template para importación de datos
/// </summary>
public abstract class DataImporter
{
    public void Import(string source)
    {
        Console.WriteLine($"[Importer] Iniciando importación desde: {source}\n");

        Connect(source);
        Console.WriteLine();

        Authenticate();
        Console.WriteLine();

        FetchData();
        Console.WriteLine();

        Transform();
        Console.WriteLine();

        Save();
        Console.WriteLine();

        Disconnect();
        Console.WriteLine($"[Importer] Importación completada\n");
    }

    protected abstract void Connect(string source);
    protected abstract void Authenticate();
    protected abstract void FetchData();
    protected abstract void Transform();
    protected abstract void Save();
    protected abstract void Disconnect();
}

public class DatabaseImporter : DataImporter
{
    protected override void Connect(string source)
    {
        Console.WriteLine($"  [DB] Conectando a: {source}");
    }

    protected override void Authenticate()
    {
        Console.WriteLine($"  [DB] Autenticándose con credenciales");
    }

    protected override void FetchData()
    {
        Console.WriteLine($"  [DB] Ejecutando query");
        Console.WriteLine($"  [DB] Obteniendo resultados");
    }

    protected override void Transform()
    {
        Console.WriteLine($"  [DB] Mapeando a objetos");
    }

    protected override void Save()
    {
        Console.WriteLine($"  [DB] Guardando en base de datos local");
    }

    protected override void Disconnect()
    {
        Console.WriteLine($"  [DB] Desconectando");
    }
}

public class APIImporter : DataImporter
{
    protected override void Connect(string source)
    {
        Console.WriteLine($"  [API] Conectando a endpoint: {source}");
    }

    protected override void Authenticate()
    {
        Console.WriteLine($"  [API] Usando API key");
    }

    protected override void FetchData()
    {
        Console.WriteLine($"  [API] Realizando llamada GET");
        Console.WriteLine($"  [API] Recibiendo JSON response");
    }

    protected override void Transform()
    {
        Console.WriteLine($"  [API] Deserializando JSON");
    }

    protected override void Save()
    {
        Console.WriteLine($"  [API] Almacenando en caché");
    }

    protected override void Disconnect()
    {
        Console.WriteLine($"  [API] Cerrando conexión");
    }
}