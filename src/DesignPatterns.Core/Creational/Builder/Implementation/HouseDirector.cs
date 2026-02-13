namespace DesignPatterns.Core.Creational.Builder.Implementation;

/// <summary>
/// Director que orquesta el proceso de construcción
/// </summary>
public class HouseDirector
{
    private HouseBuilder _builder;

    public HouseDirector(HouseBuilder builder)
    {
        _builder = builder;
    }

    public House BuildHouse()
    {
        _builder.BuildFoundation();
        _builder.BuildWalls();
        _builder.BuildRoof();
        _builder.BuildDoor();
        _builder.BuildWindows();
        _builder.BuildGarage();
        _builder.BuildGarden();

        return _builder.GetHouse();
    }
}