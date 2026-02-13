namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class LinuxCheckbox : IUICheckbox
{
    public void Render()
    {
        Console.WriteLine("[Linux] Renderizando checkbox Linux");
    }

    public string GetStyle()
    {
        return "Linux GTK Style";
    }
}