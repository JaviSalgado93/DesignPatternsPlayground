namespace DesignPatterns.Core.Structural.Flyweight.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Flyweight Pattern - Ejemplo Avanzado: Forest ===\n");

        var forest = new Forest();

        // Plantar muchos árboles (pero solo 3 tipos diferentes)
        Console.WriteLine("--- Plantando bosque ---");
        forest.PlantTree(10, 20, "Roble", "Marrón", "Rugosa");
        forest.PlantTree(15, 25, "Roble", "Marrón", "Rugosa"); // Mismo tipo
        forest.PlantTree(20, 30, "Roble", "Marrón", "Rugosa"); // Mismo tipo

        forest.PlantTree(50, 60, "Pino", "Verde", "Lisa");
        forest.PlantTree(55, 65, "Pino", "Verde", "Lisa"); // Mismo tipo

        forest.PlantTree(100, 110, "Abedul", "Blanco", "Manchada");
        forest.PlantTree(105, 115, "Abedul", "Blanco", "Manchada"); // Mismo tipo

        forest.Draw();

        // Estadísticas
        Console.WriteLine($"\n--- Estadísticas ---");
        Console.WriteLine($"Árboles plantados: {forest.GetTreeCount()}");
        Console.WriteLine($"Tipos de árboles únicos: {forest.GetTreeTypeCount()}");

        // Cálculo de memoria
        const int bytesPerTreeType = 100; // Aprox. por atributos intrínseco
        const int bytesPerTree = 16; // Aprox. para referencias extrínseco

        var memoriaConFlyweight = (forest.GetTreeTypeCount() * bytesPerTreeType) +
                                 (forest.GetTreeCount() * bytesPerTree);
        var memoriasinFlyweight = forest.GetTreeCount() * (bytesPerTreeType + bytesPerTree);

        Console.WriteLine($"\nMemoria sin Flyweight: ~{memoriasinFlyweight} bytes");
        Console.WriteLine($"Memoria con Flyweight: ~{memoriaConFlyweight} bytes");
        Console.WriteLine($"Ahorro: ~{memoriasinFlyweight - memoriaConFlyweight} bytes ({((float)(memoriasinFlyweight - memoriaConFlyweight) / memoriasinFlyweight * 100):F1}%)");

        Console.WriteLine("\n Flyweight permite manejar miles de objetos eficientemente");
    }
}