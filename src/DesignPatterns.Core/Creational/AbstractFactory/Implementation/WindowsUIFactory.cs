namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class WindowsUIFactory : IUIFactory
{
    public IUIButton CreateButton()
    {
        return new WindowsButton();
    }

    public IUICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}