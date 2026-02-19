namespace DesignPatterns.Core.Structural.Bridge.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Ventanas con diferentes renderers
/// </summary>

public interface IRenderer
{
    void DrawCircle(int x, int y, int radius);
    void DrawRectangle(int x, int y, int width, int height);
    void DrawText(string text, int x, int y);
    void Clear();
}

public class WindowsRenderer : IRenderer
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"[Windows] Dibujando círculo en ({x},{y}) radio {radius}");
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Console.WriteLine($"[Windows] Dibujando rectángulo en ({x},{y}) {width}x{height}");
    }

    public void DrawText(string text, int x, int y)
    {
        Console.WriteLine($"[Windows] Dibujando texto '{text}' en ({x},{y})");
    }

    public void Clear()
    {
        Console.WriteLine("[Windows] Limpiando pantalla");
    }
}

public class LinuxRenderer : IRenderer
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"[Linux] Renderizando círculo en ({x},{y}) radio {radius}");
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Console.WriteLine($"[Linux] Renderizando rectángulo en ({x},{y}) {width}x{height}");
    }

    public void DrawText(string text, int x, int y)
    {
        Console.WriteLine($"[Linux] Renderizando texto '{text}' en ({x},{y})");
    }

    public void Clear()
    {
        Console.WriteLine("[Linux] Limpiando pantalla");
    }
}

public class MacRenderer : IRenderer
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"[Mac] Dibujando círculo en ({x},{y}) radio {radius}");
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Console.WriteLine($"[Mac] Dibujando rectángulo en ({x},{y}) {width}x{height}");
    }

    public void DrawText(string text, int x, int y)
    {
        Console.WriteLine($"[Mac] Dibujando texto '{text}' en ({x},{y})");
    }

    public void Clear()
    {
        Console.WriteLine("[Mac] Limpiando pantalla");
    }
}

/// <summary>
/// Abstracción - Ventana
/// </summary>
public abstract class Window
{
    protected IRenderer _renderer;

    public Window(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public abstract void Draw();

    public void SetRenderer(IRenderer renderer)
    {
        _renderer = renderer;
    }
}

/// <summary>
/// Ventana de aplicación
/// </summary>
public class ApplicationWindow : Window
{
    private string _title;

    public ApplicationWindow(IRenderer renderer, string title) : base(renderer)
    {
        _title = title;
    }

    public override void Draw()
    {
        _renderer.Clear();
        _renderer.DrawRectangle(0, 0, 800, 600);
        _renderer.DrawText(_title, 10, 10);
        _renderer.DrawRectangle(10, 30, 780, 560);
    }
}

/// <summary>
/// Ventana de diálogo
/// </summary>
public class DialogWindow : Window
{
    private string _message;

    public DialogWindow(IRenderer renderer, string message) : base(renderer)
    {
        _message = message;
    }

    public override void Draw()
    {
        _renderer.Clear();
        _renderer.DrawRectangle(100, 100, 600, 400);
        _renderer.DrawText(_message, 150, 150);
        _renderer.DrawRectangle(150, 350, 100, 30);
        _renderer.DrawText("OK", 185, 360);
    }
}