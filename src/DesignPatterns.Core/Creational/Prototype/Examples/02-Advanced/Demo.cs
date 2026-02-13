namespace DesignPatterns.Core.Creational.Prototype.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Prototype Pattern - Ejemplo Avanzado: Game Character ===\n");

        // Crear personaje prototipo
        var prototypeHero = new GameCharacter("Héroe Base", "Guerrero", 1);
        prototypeHero.AddAttribute(new CharacterAttribute("Fuerza", 10));
        prototypeHero.AddAttribute(new CharacterAttribute("Defensa", 5));
        prototypeHero.AddAttribute(new CharacterAttribute("Vida", 100));
        prototypeHero.AddSkill("Golpe Básico");
        prototypeHero.AddSkill("Grito de Guerra");

        prototypeHero.Display();

        // Clonar y modificar
        var heroLevel50 = prototypeHero.Clone() as GameCharacter;
        heroLevel50.Name = "Héroe Nivel 50";
        heroLevel50.Level = 50;

        // Aumentar atributos
        heroLevel50.Attributes[0].Value = 50;
        heroLevel50.Attributes[1].Value = 35;
        heroLevel50.Attributes[2].Value = 500;

        // Agregar nuevo skill
        heroLevel50.AddSkill("Ataque Devastador");

        heroLevel50.Display();

        // Clonar para crear variante
        var archerVariant = prototypeHero.Clone() as GameCharacter;
        archerVariant.Name = "Arquero";
        archerVariant.CharacterClass = "Arquero";
        archerVariant.Attributes[0].Value = 8;
        archerVariant.Attributes[1].Value = 7;
        archerVariant.Skills.Clear();
        archerVariant.AddSkill("Disparo");
        archerVariant.AddSkill("Lluvia de Flechas");

        archerVariant.Display();

        Console.WriteLine("\n Prototype permite crear variantes complejas de forma eficiente");
    }
}