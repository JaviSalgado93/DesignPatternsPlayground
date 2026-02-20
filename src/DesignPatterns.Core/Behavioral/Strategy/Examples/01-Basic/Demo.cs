namespace DesignPatterns.Core.Behavioral.Strategy.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Strategy Pattern - Ejemplo Básico: Sorting ===\n");

        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        var sorter = new Sorter(new BubbleSortStrategy());

        Console.WriteLine("--- Ordenando con Bubble Sort ---");
        sorter.Sort((int[])numbers.Clone());
        sorter.PrintArray((int[])numbers.Clone());

        Console.WriteLine("\n--- Cambiando a Quick Sort ---");
        sorter.SetStrategy(new QuickSortStrategy());
        sorter.Sort((int[])numbers.Clone());
        sorter.PrintArray((int[])numbers.Clone());

        Console.WriteLine("\n--- Cambiando a Merge Sort ---");
        sorter.SetStrategy(new MergeSortStrategy());
        sorter.Sort((int[])numbers.Clone());
        sorter.PrintArray((int[])numbers.Clone());

        Console.WriteLine("\n Strategy permite intercambiar algoritmos dinámicamente");
    }
}