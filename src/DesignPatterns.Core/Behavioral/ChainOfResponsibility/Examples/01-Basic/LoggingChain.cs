namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Sistema de logging con niveles
/// </summary>

public class LogRequest
{
    public string Level { get; set; }
    public string Message { get; set; }

    public LogRequest(string level, string message)
    {
        Level = level;
        Message = message;
    }
}

public interface ILogger
{
    void SetNext(ILogger next);
    void Log(LogRequest request);
}

public abstract class Logger : ILogger
{
    protected ILogger _nextLogger;

    public virtual void SetNext(ILogger next)
    {
        _nextLogger = next;
    }

    public virtual void Log(LogRequest request)
    {
        if (Handle(request))
        {
            Process(request);
        }
        else if (_nextLogger != null)
        {
            _nextLogger.Log(request);
        }
    }

    protected abstract bool Handle(LogRequest request);
    protected abstract void Process(LogRequest request);
}

public class ConsoleLogger : Logger
{
    protected override bool Handle(LogRequest request)
    {
        return request.Level == "Info" || request.Level == "Debug";
    }

    protected override void Process(LogRequest request)
    {
        Console.WriteLine($"[Console] {request.Level}: {request.Message}");
    }
}

public class FileLogger : Logger
{
    protected override bool Handle(LogRequest request)
    {
        return request.Level == "Warning" || request.Level == "Error";
    }

    protected override void Process(LogRequest request)
    {
        Console.WriteLine($"[File] Guardando a archivo: {request.Level}: {request.Message}");
    }
}

public class DatabaseLogger : Logger
{
    protected override bool Handle(LogRequest request)
    {
        return request.Level == "Critical";
    }

    protected override void Process(LogRequest request)
    {
        Console.WriteLine($"[Database] Guardando crítico: {request.Message}");
    }
}