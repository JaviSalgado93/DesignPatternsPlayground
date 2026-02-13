namespace DesignPatterns.Core.Creational.Builder.Implementation;

/// <summary>
/// Clase compleja que será construida paso a paso
/// </summary>
public class House
{
    public string Foundation { get; set; }
    public string Walls { get; set; }
    public string Roof { get; set; }
    public string Door { get; set; }
    public string Windows { get; set; }
    public string Garage { get; set; }
    public string Garden { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine("\n=== Detalles de la Casa ===");
        Console.WriteLine($"Fundación: {Foundation ?? "No especificada"}");
        Console.WriteLine($"Paredes: {Walls ?? "No especificadas"}");
        Console.WriteLine($"Techo: {Roof ?? "No especificado"}");
        Console.WriteLine($"Puerta: {Door ?? "No especificada"}");
        Console.WriteLine($"Ventanas: {Windows ?? "No especificadas"}");
        Console.WriteLine($"Garaje: {Garage ?? "No especificado"}");
        Console.WriteLine($"Jardín: {Garden ?? "No especificado"}");
    }
}