namespace DesignPatterns.Core.Behavioral.ChainOfResponsibility.Implementation;

/// <summary>
/// ConcreteHandlers - Implementaciones específicas
/// </summary>

public class DebugHandler : AbstractHandler
{
    protected override bool CanHandle(Request request)
    {
        return request.Type == "Debug";
    }

    protected override void ProcessRequest(Request request)
    {
        Console.WriteLine($"[DebugHandler] ✓ Manejando Debug: {request.Description}");
    }
}

public class InfoHandler : AbstractHandler
{
    protected override bool CanHandle(Request request)
    {
        return request.Type == "Info";
    }

    protected override void ProcessRequest(Request request)
    {
        Console.WriteLine($"[InfoHandler] ℹ️ Manejando Info: {request.Description}");
    }
}

public class WarningHandler : AbstractHandler
{
    protected override bool CanHandle(Request request)
    {
        return request.Type == "Warning";
    }

    protected override void ProcessRequest(Request request)
    {
        Console.WriteLine($"[WarningHandler] ⚠️ Manejando Warning: {request.Description}");
    }
}

public class ErrorHandler : AbstractHandler
{
    protected override bool CanHandle(Request request)
    {
        return request.Type == "Error";
    }

    protected override void ProcessRequest(Request request)
    {
        Console.WriteLine($"[ErrorHandler] ❌ Manejando Error: {request.Description}");
    }
}

public class CriticalHandler : AbstractHandler
{
    protected override bool CanHandle(Request request)
    {
        return request.Type == "Critical";
    }

    protected override void ProcessRequest(Request request)
    {
        Console.WriteLine($"[CriticalHandler] 🔴 CRÍTICO: {request.Description}");
    }
}