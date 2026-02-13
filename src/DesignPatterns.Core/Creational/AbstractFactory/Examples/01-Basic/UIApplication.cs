namespace DesignPatterns.Core.Creational.AbstractFactory.Examples._01_Basic;

using DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class UIApplication
{
    private IUIFactory _factory;

    public UIApplication(IUIFactory factory)
    {
        _factory = factory;
    }

    public void Render()
    {
        var button = _factory.CreateButton();
        var checkbox = _factory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }
}