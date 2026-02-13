namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class LinuxButton : IUIButton
{
    public void Render()
    {
        Console.WriteLine("[Linux] Renderizando botón Linux (GTK)");
    }

    public string GetStyle()
    {
        return "Linux GTK Style";
    }
}