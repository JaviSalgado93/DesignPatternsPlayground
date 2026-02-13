namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class MacCheckbox : IUICheckbox
{
    public void Render()
    {
        Console.WriteLine("[macOS] Renderizando checkbox macOS");
    }

    public string GetStyle()
    {
        return "macOS Aqua Style";
    }
}