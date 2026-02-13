namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class WindowsButton : IUIButton
{
    public void Render()
    {
        Console.WriteLine("[Windows] Renderizando botón Windows (gris metálico)");
    }

    public string GetStyle()
    {
        return "Windows Classic Style";
    }
}