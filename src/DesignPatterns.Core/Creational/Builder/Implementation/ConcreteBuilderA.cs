namespace DesignPatterns.Core.Creational.Builder.Implementation;

public class ConcreteBuilderA : HouseBuilder
{
    public override void BuildFoundation()
    {
        _house.Foundation = "Cimientos simples de hormigón";
    }

    public override void BuildWalls()
    {
        _house.Walls = "Paredes de ladrillo básico";
    }

    public override void BuildRoof()
    {
        _house.Roof = "Techo de tejas económicas";
    }

    public override void BuildDoor()
    {
        _house.Door = "Puerta de madera estándar";
    }

    public override void BuildWindows()
    {
        _house.Windows = "Ventanas de vidrio simple";
    }

    public override void BuildGarage()
    {
        _house.Garage = "Sin garaje";
    }

    public override void BuildGarden()
    {
        _house.Garden = "Sin jardín";
    }
}