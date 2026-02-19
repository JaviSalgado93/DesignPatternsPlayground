namespace DesignPatterns.Core.Structural.Flyweight.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Caracteres en un editor de texto
/// </summary>

public interface ICharacter
{
    void Display(int row, int column);
    char GetChar();
}

/// <summary>
/// Flyweight - Carácter compartido
/// </summary>
public class Character : ICharacter
{
    private char _char; // Intrínseco - compartido
    private string _font; // Intrínseco - compartido

    public Character(char c, string font)
    {
        _char = c;
        _font = font;
    }

    public void Display(int row, int column)
    {
        Console.WriteLine($"Mostrando '{_char}' en ({row}, {column}) con fuente {_font}");
    }

    public char GetChar() => _char;
}

/// <summary>
/// Factory - Cachea caracteres
/// </summary>
public class CharacterFactory
{
    private Dictionary<string, Character> _characters = new();

    public Character GetCharacter(char c, string font)
    {
        string key = $"{c}:{font}";

        if (!_characters.ContainsKey(key))
        {
            Console.WriteLine($"[Factory] Creando carácter: {key}");
            _characters[key] = new Character(c, font);
        }
        else
        {
            Console.WriteLine($"[Factory] Reutilizando carácter: {key}");
        }

        return _characters[key];
    }

    public int GetCharacterCount() => _characters.Count;
}