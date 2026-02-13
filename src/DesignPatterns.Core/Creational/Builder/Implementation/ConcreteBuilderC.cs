namespace DesignPatterns.Core.Creational.Builder.Implementation;

public class ConcreteBuilderC : HouseBuilder
{
    public override void BuildFoundation()
    {
        _house.Foundation = "Cimientos de granito y acero de ingeniería";
    }

    public override void BuildWalls()
    {
        _house.Walls = "Paredes de mármol y cristal inteligente";
    }

    public override void BuildRoof()
    {
        _house.Roof = "Techo automático retráctil";
    }

    public override void BuildDoor()
    {
        _house.Door = "Puerta de seguridad inteligente";
    }

    public override void BuildWindows()
    {
        _house.Windows = "Ventanas inteligentes con control de temperatura";
    }

    public override void BuildGarage()
    {
        _house.Garage = "Garaje subterráneo para 4 autos";
    }

    public override void BuildGarden()
    {
        _house.Garden = "Jardín con sistema de riego automático";
    }
}