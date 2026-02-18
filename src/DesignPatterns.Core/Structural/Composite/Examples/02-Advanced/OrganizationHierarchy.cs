namespace DesignPatterns.Core.Structural.Composite.Examples._02_Advanced;

/// <summary>
/// Ejemplo avanzado: Jerarquía organizacional
/// </summary>

public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    decimal Salary { get; }
    void Display(int indent = 0);
    decimal GetTotalSalary();
    int GetEmployeeCount();
}

/// <summary>
/// Hoja - Empleado individual
/// </summary>
public class Employee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, string position, decimal salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"👤 {Name} ({Position}) - ${Salary}");
    }

    public decimal GetTotalSalary()
    {
        return Salary;
    }

    public int GetEmployeeCount()
    {
        return 1;
    }
}

/// <summary>
/// Composite - Departamento
/// </summary>
public class Department : IEmployee
{
    public string Name { get; set; }
    public string Position => "Departamento";
    public decimal Salary => 0;

    private List<IEmployee> _members = new();

    public Department(string name)
    {
        Name = name;
    }

    public void Add(IEmployee employee)
    {
        _members.Add(employee);
    }

    public void Remove(IEmployee employee)
    {
        _members.Remove(employee);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"🏢 {Name}");
        foreach (var member in _members)
        {
            member.Display(indent + 2);
        }
    }

    public decimal GetTotalSalary()
    {
        return _members.Sum(m => m.GetTotalSalary());
    }

    public int GetEmployeeCount()
    {
        return _members.Sum(m => m.GetEmployeeCount());
    }
}