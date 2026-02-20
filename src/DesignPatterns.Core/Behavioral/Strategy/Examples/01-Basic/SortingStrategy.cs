namespace DesignPatterns.Core.Behavioral.Strategy.Examples._01_Basic;

/// <summary>
/// Ejemplo básico: Algoritmos de ordenamiento
/// </summary>

public interface ISortingStrategy
{
    void Sort(int[] array);
    string GetName();
    int GetComplexity();
}

public class BubbleSortStrategy : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("  → Ordenando con Bubble Sort...");
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public string GetName() => "Bubble Sort";
    public int GetComplexity() => 2; // O(n²)
}

public class QuickSortStrategy : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("  → Ordenando con Quick Sort...");
        QuickSort(array, 0, array.Length - 1);
    }

    private void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);
            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    private int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        int temp2 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp2;
        return i + 1;
    }

    public string GetName() => "Quick Sort";
    public int GetComplexity() => 1; // O(n log n)
}

public class MergeSortStrategy : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("  → Ordenando con Merge Sort...");
        MergeSort(array, 0, array.Length - 1);
    }

    private void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }

    private void Merge(int[] array, int left, int mid, int right)
    {
        int[] leftArr = new int[mid - left + 1];
        int[] rightArr = new int[right - mid];

        Array.Copy(array, left, leftArr, 0, leftArr.Length);
        Array.Copy(array, mid + 1, rightArr, 0, rightArr.Length);

        int i = 0, j = 0, k = left;
        while (i < leftArr.Length && j < rightArr.Length)
        {
            if (leftArr[i] <= rightArr[j])
                array[k++] = leftArr[i++];
            else
                array[k++] = rightArr[j++];
        }

        while (i < leftArr.Length)
            array[k++] = leftArr[i++];
        while (j < rightArr.Length)
            array[k++] = rightArr[j++];
    }

    public string GetName() => "Merge Sort";
    public int GetComplexity() => 1; // O(n log n)
}

public class Sorter
{
    private ISortingStrategy _strategy;

    public Sorter(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ISortingStrategy strategy)
    {
        Console.WriteLine($"[Sorter] Cambiando a: {strategy.GetName()}");
        _strategy = strategy;
    }

    public void Sort(int[] array)
    {
        var complexity = _strategy.GetComplexity() == 2 ? "n²" : "n log n";
        Console.WriteLine($"[Sorter] Usando: {_strategy.GetName()} - Complejidad O({complexity})");
        _strategy.Sort(array);
    }

    public void PrintArray(int[] array)
    {
        Console.WriteLine($"  → Array: [{string.Join(", ", array)}]");
    }
}