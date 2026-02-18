namespace DesignPatterns.Core.Structural.Composite.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Composite Pattern - Ejemplo Avanzado: Organization Hierarchy ===\n");

        // Crear CEO
        var ceo = new Department("CEO");

        // Crear departamentos
        var itDept = new Department("IT");
        var hrDept = new Department("HR");
        var salesDept = new Department("Ventas");

        // Agregar empleados a IT
        itDept.Add(new Employee("Juan", "Desarrollador", 3000));
        itDept.Add(new Employee("María", "Arquitecto", 4000));
        itDept.Add(new Employee("Pedro", "DevOps", 3500));

        // Agregar empleados a HR
        hrDept.Add(new Employee("Ana", "Manager", 2800));
        hrDept.Add(new Employee("Carlos", "Recruiter", 2200));

        // Agregar empleados a Ventas
        salesDept.Add(new Employee("Luis", "Gerente", 3200));
        salesDept.Add(new Employee("Sofia", "Vendedor", 2000));
        salesDept.Add(new Employee("Diego", "Vendedor", 2000));

        // Agregar departamentos a CEO
        ceo.Add(itDept);
        ceo.Add(hrDept);
        ceo.Add(salesDept);

        // Mostrar estructura
        Console.WriteLine("--- Estructura Organizacional ---");
        ceo.Display();

        // Análisis
        Console.WriteLine($"\n--- Análisis ---");
        Console.WriteLine($"Total de empleados: {ceo.GetEmployeeCount()}");
        Console.WriteLine($"Nómina total: ${ceo.GetTotalSalary()}");

        Console.WriteLine($"\nIT - Empleados: {itDept.GetEmployeeCount()}, Nómina: ${itDept.GetTotalSalary()}");
        Console.WriteLine($"HR - Empleados: {hrDept.GetEmployeeCount()}, Nómina: ${hrDept.GetTotalSalary()}");
        Console.WriteLine($"Ventas - Empleados: {salesDept.GetEmployeeCount()}, Nómina: ${salesDept.GetTotalSalary()}");

        Console.WriteLine("\n Composite permite operar en toda la jerarquía de forma uniforme");
    }
}