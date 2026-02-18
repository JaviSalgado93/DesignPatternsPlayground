namespace DesignPatterns.Core.Structural.Decorator.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Decoradores de stream de datos con compresión y encriptación
/// </summary>

public interface IDataStream
{
    void Write(string data);
    string Read();
    void Close();
}

/// <summary>
/// Componente - Stream base
/// </summary>
public class FileDataStream : IDataStream
{
    private string _data = "";
    private bool _isOpen = true;

    public void Write(string data)
    {
        if (!_isOpen) throw new InvalidOperationException("Stream cerrado");
        _data += data;
        Console.WriteLine($"[FileStream] Escribiendo: {data}");
    }

    public string Read()
    {
        if (!_isOpen) throw new InvalidOperationException("Stream cerrado");
        Console.WriteLine($"[FileStream] Leyendo datos");
        return _data;
    }

    public void Close()
    {
        _isOpen = false;
        Console.WriteLine("[FileStream] Cerrado");
    }
}

/// <summary>
/// Decorador base
/// </summary>
public abstract class DataStreamDecorator : IDataStream
{
    protected IDataStream _stream;

    public DataStreamDecorator(IDataStream stream)
    {
        _stream = stream;
    }

    public virtual void Write(string data)
    {
        _stream.Write(data);
    }

    public virtual string Read()
    {
        return _stream.Read();
    }

    public virtual void Close()
    {
        _stream.Close();
    }
}

/// <summary>
/// Decorador - Compresión
/// </summary>
public class CompressionDecorator : DataStreamDecorator
{
    public CompressionDecorator(IDataStream stream) : base(stream)
    {
    }

    public override void Write(string data)
    {
        var compressed = CompressData(data);
        Console.WriteLine($"[Compression] Comprimiendo: {data} -> {compressed}");
        base.Write(compressed);
    }

    public override string Read()
    {
        var data = base.Read();
        var decompressed = DecompressData(data);
        Console.WriteLine($"[Compression] Descomprimiendo: {data} -> {decompressed}");
        return decompressed;
    }

    private string CompressData(string data)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
    }

    private string DecompressData(string data)
    {
        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(data));
    }
}

/// <summary>
/// Decorador - Encriptación
/// </summary>
public class EncryptionDecorator : DataStreamDecorator
{
    public EncryptionDecorator(IDataStream stream) : base(stream)
    {
    }

    public override void Write(string data)
    {
        var encrypted = EncryptData(data);
        Console.WriteLine($"[Encryption] Encriptando: {data} -> {encrypted}");
        base.Write(encrypted);
    }

    public override string Read()
    {
        var data = base.Read();
        var decrypted = DecryptData(data);
        Console.WriteLine($"[Encryption] Desencriptando: {data} -> {decrypted}");
        return decrypted;
    }

    private string EncryptData(string data)
    {
        // Simulación simple de encriptación
        return string.Join("", data.Select(c => (char)(c + 1)));
    }

    private string DecryptData(string data)
    {
        // Simulación simple de desencriptación
        return string.Join("", data.Select(c => (char)(c - 1)));
    }
}

/// <summary>
/// Decorador - Logging
/// </summary>
public class LoggingDecorator : DataStreamDecorator
{
    private int _operationCount = 0;

    public LoggingDecorator(IDataStream stream) : base(stream)
    {
    }

    public override void Write(string data)
    {
        _operationCount++;
        Console.WriteLine($"[Logging] Operación #{_operationCount}: Write");
        base.Write(data);
    }

    public override string Read()
    {
        _operationCount++;
        Console.WriteLine($"[Logging] Operación #{_operationCount}: Read");
        return base.Read();
    }

    public override void Close()
    {
        _operationCount++;
        Console.WriteLine($"[Logging] Operación #{_operationCount}: Close");
        base.Close();
    }
}