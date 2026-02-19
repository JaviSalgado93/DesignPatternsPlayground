namespace DesignPatterns.Core.Structural.Proxy.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Proxy Pattern - Ejemplo Básico: Image Proxy ===\n");

        // Crear proxies (sin cargar realmente las imágenes)
        Console.WriteLine("--- Creando referencias a imágenes ---");
        IImage image1 = new ImageProxy("photo1.jpg");
        IImage image2 = new ImageProxy("photo2.jpg");
        IImage image3 = new ImageProxy("photo3.jpg");
        Console.WriteLine(" Referencias creadas (sin cargar imágenes)\n");

        // Primera vez mostrar - carga la imagen
        Console.WriteLine("--- Primera vez mostrando image1 ---");
        image1.Display();

        // Segunda vez - ya está cargada
        Console.WriteLine("\n--- Segunda vez mostrando image1 ---");
        image1.Display();

        // Mostrar image2 - carga nueva imagen
        Console.WriteLine("\n--- Mostrando image2 ---");
        image2.Display();

        // Mostrar image3 - carga nueva imagen
        Console.WriteLine("\n--- Mostrando image3 ---");
        image3.Display();

        Console.WriteLine("\n Proxy permite lazy loading de recursos costosos");
    }
}