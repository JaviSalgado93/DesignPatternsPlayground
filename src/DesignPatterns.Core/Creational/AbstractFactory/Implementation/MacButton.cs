namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class MacButton : IUIButton
{
    public void Render()
    {
        Console.WriteLine("[macOS] Renderizando botón macOS (redondeado azul)");
    }

    public string GetStyle()
    {
        return "macOS Aqua Style";
    }
}