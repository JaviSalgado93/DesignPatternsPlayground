namespace DesignPatterns.Core.Creational.Prototype.Examples._02_Advanced;

public interface IPrototype
{
    IPrototype Clone();
}

public class CharacterAttribute
{
    public string Name { get; set; }
    public int Value { get; set; }

    public CharacterAttribute(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public CharacterAttribute Clone()
    {
        return new CharacterAttribute(Name, Value);
    }
}

public class GameCharacter : IPrototype
{
    public string Name { get; set; }
    public string CharacterClass { get; set; }
    public int Level { get; set; }
    public List<CharacterAttribute> Attributes { get; set; }
    public List<string> Skills { get; set; }

    public GameCharacter(string name, string characterClass, int level)
    {
        Name = name;
        CharacterClass = characterClass;
        Level = level;
        Attributes = new();
        Skills = new();
    }

    public void AddAttribute(CharacterAttribute attr)
    {
        Attributes.Add(attr);
    }

    public void AddSkill(string skill)
    {
        Skills.Add(skill);
    }

    public IPrototype Clone()
    {
        // Clone profundo
        var cloned = new GameCharacter(Name, CharacterClass, Level);

        // Clonar atributos
        foreach (var attr in Attributes)
        {
            cloned.Attributes.Add(attr.Clone());
        }

        // Clonar skills
        foreach (var skill in Skills)
        {
            cloned.Skills.Add(skill);
        }

        return cloned;
    }

    public void Display()
    {
        Console.WriteLine($"\n--- Personaje: {Name} ---");
        Console.WriteLine($"Clase: {CharacterClass}");
        Console.WriteLine($"Nivel: {Level}");

        if (Attributes.Count > 0)
        {
            Console.WriteLine("Atributos:");
            foreach (var attr in Attributes)
            {
                Console.WriteLine($"  - {attr.Name}: {attr.Value}");
            }
        }

        if (Skills.Count > 0)
        {
            Console.WriteLine("Habilidades:");
            foreach (var skill in Skills)
            {
                Console.WriteLine($"  - {skill}");
            }
        }
    }
}