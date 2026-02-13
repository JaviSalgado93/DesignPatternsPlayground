namespace DesignPatterns.Core.Creational.Builder.Implementation;

public class ConcreteBuilderB : HouseBuilder
{
    public override void BuildFoundation()
    {
        _house.Foundation = "Cimientos de hormigón reforzado";
    }

    public override void BuildWalls()
    {
        _house.Walls = "Paredes de hormigón y acero";
    }

    public override void BuildRoof()
    {
        _house.Roof = "Techo moderno de losas de concreto";
    }

    public override void BuildDoor()
    {
        _house.Door = "Puerta de aluminio y vidrio";
    }

    public override void BuildWindows()
    {
        _house.Windows = "Ventanas panorámicas de doble vidrio";
    }

    public override void BuildGarage()
    {
        _house.Garage = "Garaje para 2 autos";
    }

    public override void BuildGarden()
    {
        _house.Garden = "Jardín con paisajismo profesional";
    }
}