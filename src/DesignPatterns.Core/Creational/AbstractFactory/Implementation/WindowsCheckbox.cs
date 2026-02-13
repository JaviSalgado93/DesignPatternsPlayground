namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class WindowsCheckbox : IUICheckbox
{
    public void Render()
    {
        Console.WriteLine("[Windows] Renderizando checkbox Windows");
    }

    public string GetStyle()
    {
        return "Windows Classic Style";
    }
}