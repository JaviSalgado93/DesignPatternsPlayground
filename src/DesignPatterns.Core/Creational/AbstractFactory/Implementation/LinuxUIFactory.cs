namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public class LinuxUIFactory : IUIFactory
{
    public IUIButton CreateButton()
    {
        return new LinuxButton();
    }

    public IUICheckbox CreateCheckbox()
    {
        return new LinuxCheckbox();
    }
}