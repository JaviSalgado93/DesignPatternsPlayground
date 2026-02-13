namespace DesignPatterns.Core.Creational.Builder.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Builder Pattern - Ejemplo Básico: Fluent Builder ===\n");

        // Usando el builder fluent
        var person1 = new PersonBuilder()
            .WithFirstName("Juan")
            .WithLastName("Pérez")
            .WithAge(30)
            .WithEmail("juan@example.com")
            .WithPhone("123456789")
            .WithAddress("Calle 1, 123")
            .Build();

        Console.WriteLine("Persona 1:");
        Console.WriteLine(person1);

        // Construcción parcial
        var person2 = new PersonBuilder()
            .WithFirstName("María")
            .WithLastName("García")
            .WithEmail("maria@example.com")
            .Build();

        Console.WriteLine("\nPersona 2 (sin edad ni teléfono):");
        Console.WriteLine(person2);

        Console.WriteLine("\n✅ Builder permite crear objetos complejos de forma legible y flexible");
    }
}