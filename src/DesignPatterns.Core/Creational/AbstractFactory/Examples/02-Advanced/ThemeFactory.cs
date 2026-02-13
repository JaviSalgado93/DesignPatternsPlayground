namespace DesignPatterns.Core.Creational.AbstractFactory.Examples._02_Advanced;

public interface IThemeColor
{
    string GetBackgroundColor();
    string GetForegroundColor();
}

public interface IThemeFont
{
    string GetFontFamily();
    int GetFontSize();
}

public interface ITheme
{
    IThemeColor CreateColor();
    IThemeFont CreateFont();
}

// ===== LIGHT THEME =====
public class LightColor : IThemeColor
{
    public string GetBackgroundColor() => "#FFFFFF";
    public string GetForegroundColor() => "#000000";
}

public class LightFont : IThemeFont
{
    public string GetFontFamily() => "Segoe UI";
    public int GetFontSize() => 12;
}

public class LightTheme : ITheme
{
    public IThemeColor CreateColor() => new LightColor();
    public IThemeFont CreateFont() => new LightFont();
}

// ===== DARK THEME =====
public class DarkColor : IThemeColor
{
    public string GetBackgroundColor() => "#1E1E1E";
    public string GetForegroundColor() => "#FFFFFF";
}

public class DarkFont : IThemeFont
{
    public string GetFontFamily() => "Consolas";
    public int GetFontSize() => 11;
}

public class DarkTheme : ITheme
{
    public IThemeColor CreateColor() => new DarkColor();
    public IThemeFont CreateFont() => new DarkFont();
}

// ===== HIGH CONTRAST THEME =====
public class HighContrastColor : IThemeColor
{
    public string GetBackgroundColor() => "#000000";
    public string GetForegroundColor() => "#FFFF00";
}

public class HighContrastFont : IThemeFont
{
    public string GetFontFamily() => "Arial";
    public int GetFontSize() => 14;
}

public class HighContrastTheme : ITheme
{
    public IThemeColor CreateColor() => new HighContrastColor();
    public IThemeFont CreateFont() => new HighContrastFont();
}

public class ThemeFactory
{
    public static ITheme CreateTheme(string themeName)
    {
        return themeName.ToLower() switch
        {
            "light" => new LightTheme(),
            "dark" => new DarkTheme(),
            "highcontrast" => new HighContrastTheme(),
            _ => throw new ArgumentException("Tema desconocido")
        };
    }
}