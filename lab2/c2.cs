using System;

class Lab2
{
    static void Main()
    {
        
        //1
        Console.WriteLine("\nНомери елементів > заданого числа");
        Console.Write("Введіть число для порівняння: ");
        double threshold = double.Parse(Console.ReadLine()!);
        
        // Спосіб 1
        int[] arr1D = { 10, 50, 20, 60, 30 };
        Console.Write("В одновимірному масиві індекси: ");
        for (int i = 0; i < arr1D.Length; i++)
            if (arr1D[i] > threshold) Console.Write(i + " ");
            
        // Спосіб 2
        int[,] arr2D = { { 10, 60 }, { 70, 20 } };
        Console.Write("\nВ двовимірному масиві індекси: ");
        for (int i = 0; i < arr2D.GetLength(0); i++)
            for (int j = 0; j < arr2D.GetLength(1); j++)
                if (arr2D[i, j] > threshold) Console.Write($"[{i},{j}] ");

        //2
        Console.WriteLine("\n\nSwap першого min та останнього max");
        double[] task2Arr = { 5, 1, 8, 1, 8, 3 }; // min=1 (індекс 1), max=8 (останній індекс 4)
        int minIdx = 0, maxIdx = 0;
        for (int i = 1; i < task2Arr.Length; i++) {
            if (task2Arr[i] < task2Arr[minIdx]) minIdx = i; 
            if (task2Arr[i] >= task2Arr[maxIdx]) maxIdx = i; 
        }
        (task2Arr[minIdx], task2Arr[maxIdx]) = (task2Arr[maxIdx], task2Arr[minIdx]);
        Console.WriteLine("Масив після заміни: " + string.Join(", ", task2Arr));

        //3
        Console.WriteLine("\nНорма матриці: сума максимумів стовпців");
        int[,] matrix = { { 1, 9, 3 }, { 7, 2, 8 } };
        double norm = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            int maxCol = matrix[0, j];
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, j] > maxCol) maxCol = matrix[i, j];
            norm += maxCol;
        }
        Console.WriteLine($"Норма матриці: {norm}");

        //4
        Console.WriteLine("\nСхідчастий масив: сума поза інтервалоm");
        Console.Write("Інтервал від: "); double start = double.Parse(Console.ReadLine()!);
        Console.Write("Інтервал до: "); double end = double.Parse(Console.ReadLine()!);
        
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 10, 5 };
        jagged[1] = new int[] { 20, 2, 30 };
        jagged[2] = new int[] { 3, 4, 50 };
        
        double[] results = new double[jagged.Length];
        for (int i = 0; i < jagged.Length; i++) {
            double sum = 0;
            foreach (int val in jagged[i])
                if (val < start || val > end) sum += val;
            results[i] = sum;
            Console.WriteLine($"Рядок {i}: Сума поза [{start}, {end}] = {sum}");
        }
    }
}