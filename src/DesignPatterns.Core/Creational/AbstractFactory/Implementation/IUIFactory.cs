namespace DesignPatterns.Core.Creational.AbstractFactory.Implementation;

public interface IUIFactory
{
    IUIButton CreateButton();
    IUICheckbox CreateCheckbox();
}