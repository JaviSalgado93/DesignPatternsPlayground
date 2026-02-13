namespace DesignPatterns.Core.Creational.Builder.Implementation;

/// <summary>
/// Builder abstracto que define los pasos de construcción
/// </summary>
public abstract class HouseBuilder
{
    protected House _house;

    public HouseBuilder()
    {
        _house = new House();
    }

    public abstract void BuildFoundation();
    public abstract void BuildWalls();
    public abstract void BuildRoof();
    public abstract void BuildDoor();
    public abstract void BuildWindows();
    public abstract void BuildGarage();
    public abstract void BuildGarden();

    public House GetHouse()
    {
        return _house;
    }
}