namespace DesignPatterns.Core.Behavioral.TemplateMethod.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Recetas de cocina
/// </summary>

public abstract class Recipe
{
    /// <summary>
    /// Template Method - Pasos para cocinar
    /// </summary>
    public void Cook()
    {
        Console.WriteLine($"🍳 Cocinando {GetDishName()}...\n");

        GatherIngredients();
        Console.WriteLine();

        PrepareIngredients();
        Console.WriteLine();

        Cook_Internal();
        Console.WriteLine();

        Season();
        Console.WriteLine();

        Serve();
        Console.WriteLine();
    }

    // Pasos comunes
    protected virtual void GatherIngredients()
    {
        Console.WriteLine("  1. Reuniendo ingredientes");
    }

    protected virtual void Serve()
    {
        Console.WriteLine("  5. Sirviendo en platos");
    }

    // Pasos abstractos
    protected abstract void PrepareIngredients();
    protected abstract void Cook_Internal();
    protected abstract void Season();
    protected abstract string GetDishName();
}

public class Pasta : Recipe
{
    protected override void PrepareIngredients()
    {
        Console.WriteLine("  2. Picando tomates y ajo");
    }

    protected override void Cook_Internal()
    {
        Console.WriteLine("  3. Hirviendo agua y pasta");
        Console.WriteLine("  3. Cocinando la salsa");
    }

    protected override void Season()
    {
        Console.WriteLine("  4. Agregando sal, pimienta y orégano");
    }

    protected override string GetDishName() => "Pasta a la Italiana";
}

public class Omelette : Recipe
{
    protected override void PrepareIngredients()
    {
        Console.WriteLine("  2. Batiendo huevos");
        Console.WriteLine("  2. Picando cebolla y queso");
    }

    protected override void Cook_Internal()
    {
        Console.WriteLine("  3. Calentando mantequilla");
        Console.WriteLine("  3. Cocinando en sartén");
    }

    protected override void Season()
    {
        Console.WriteLine("  4. Agregando sal y pimienta");
    }

    protected override string GetDishName() => "Omelette de Queso";
}

public class Soup : Recipe
{
    protected override void PrepareIngredients()
    {
        Console.WriteLine("  2. Picando verduras");
        Console.WriteLine("  2. Cortando pollo");
    }

    protected override void Cook_Internal()
    {
        Console.WriteLine("  3. Hirviendo en caldo");
        Console.WriteLine("  3. Cocinando 20 minutos");
    }

    protected override void Season()
    {
        Console.WriteLine("  4. Agregando caldo de pollo y especias");
    }

    protected override string GetDishName() => "Sopa de Pollo";
}