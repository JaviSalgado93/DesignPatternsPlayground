namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class MacUIFactory : IUIFactory
{
    public IUIButton CreateButton()
    {
        return new MacButton();
    }

    public IUICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}