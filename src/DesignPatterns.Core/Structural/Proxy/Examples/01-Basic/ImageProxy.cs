namespace DesignPatterns.Core.Structural.Proxy.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Proxy para imágenes grandes
/// </summary>

public interface IImage
{
    void Display();
}

/// <summary>
/// Real Image - Imagen pesada
/// </summary>
public class RealImage : IImage
{
    private string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadImageFromDisk();
    }

    private void LoadImageFromDisk()
    {
        Console.WriteLine($"[RealImage] Cargando imagen desde disco: {_filename}");
        System.Threading.Thread.Sleep(2000); // Simular carga lenta
        Console.WriteLine($"[RealImage] Imagen cargada: {_filename}");
    }

    public void Display()
    {
        Console.WriteLine($"[RealImage] Mostrando imagen: {_filename}");
    }
}

/// <summary>
/// Proxy Image - Controla acceso a imagen pesada
/// </summary>
public class ImageProxy : IImage
{
    private string _filename;
    private RealImage _realImage;

    public ImageProxy(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        // Lazy loading - solo cargar cuando se muestre
        if (_realImage == null)
        {
            Console.WriteLine($"[ImageProxy] Primera vez mostrando {_filename}, cargando...");
            _realImage = new RealImage(_filename);
        }

        _realImage.Display();
    }
}