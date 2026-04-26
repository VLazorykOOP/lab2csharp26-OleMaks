using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Завдання 1");
            Task1();
            Console.WriteLine("\n" + new string('-', 40) + "\n");

            Console.WriteLine("Завдання 2");
            Task2();
            Console.WriteLine("\n" + new string('-', 40) + "\n");

            Console.WriteLine("Завдання 3");
            Task3();
            Console.WriteLine("\n" + new string('-', 40) + "\n");

            Console.WriteLine("Завдання 4");
            Task4();
            Console.WriteLine("\nВиконання завершено.");
            Console.ReadKey();
        }

        #region Завдання 1
        static void Task1()
        {
            Console.Write("Розмірність масиву: ");
            int n = int.Parse(Console.ReadLine()!);
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine()!);
            }

            Console.Write("Задане число: ");
            int k = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Номери елементів, більших за {k}:");
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > k)
                {
                    Console.Write(i + " ");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Таких елементів немає.");
            else Console.WriteLine();
        }
        #endregion

        #region Завдання 2
        static void Task2()
        {
            Console.Write("Кількість рядків (n): ");
            int n = int.Parse(Console.ReadLine()!);
            Console.Write("Кількість стовпців (m): ");
            int m = int.Parse(Console.ReadLine()!);

            double[,] arr = new double[n, m];
            Console.WriteLine("Введіть елементи масиву (дійсні числа):");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    arr[i, j] = double.Parse(Console.ReadLine()!);
                }

            PrintMatrix2D(arr, "Початковий масив:");

            int minI = 0, minJ = 0, maxI = 0, maxJ = 0;
            double minVal = arr[0, 0], maxVal = arr[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Перший мінімальний (строге менше)
                    if (arr[i, j] < minVal)
                    {
                        minVal = arr[i, j];
                        minI = i; minJ = j;
                    }
                    // Останній максимальний (>= оновлює індекс до останнього входження)
                    if (arr[i, j] >= maxVal)
                    {
                        maxVal = arr[i, j];
                        maxI = i; maxJ = j;
                    }
                }
            }

            double temp = arr[minI, minJ];
            arr[minI, minJ] = arr[maxI, maxJ];
            arr[maxI, maxJ] = temp;

            PrintMatrix2D(arr, "Масив після обміну:");
        }

        static void PrintMatrix2D(double[,] arr, string title)
        {
            Console.WriteLine(title);
            int n = arr.GetLength(0), m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{arr[i, j],8:F2} ");
                Console.WriteLine();
            }
        }
        #endregion

        #region Завдання 3
        static void Task3()
        {
            Console.Write("Розмірність квадратної матриці (n): ");
            int n = int.Parse(Console.ReadLine()!);
            int[,] arr = new int[n, n];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    arr[i, j] = int.Parse(Console.ReadLine()!);
                }

            PrintMatrix2DInt(arr, "Матриця:");

            double norm = 0;
            for (int j = 0; j < n; j++)
            {
                int maxInColumn = arr[0, j];
                for (int i = 1; i < n; i++)
                {
                    if (arr[i, j] > maxInColumn)
                        maxInColumn = arr[i, j];
                }
                norm += maxInColumn;
                Console.WriteLine($"Максимум у стовпці {j}: {maxInColumn}");
            }

            Console.WriteLine($"\nНорма матриці ||A|| = {norm:F4}");
        }

        static void PrintMatrix2DInt(int[,] arr, string title)
        {
            Console.WriteLine(title);
            int n = arr.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{arr[i, j],6} ");
                Console.WriteLine();
            }
        }
        #endregion

        #region Завдання 4
        static void Task4()
        {
            Console.Write("Кількість рядків (n): ");
            int n = int.Parse(Console.ReadLine()!);
            int[][] jagged = new int[n][];

            Console.WriteLine("Введіть східчастий масив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Довжина рядка {i}: ");
                int len = int.Parse(Console.ReadLine()!);
                jagged[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    Console.Write($"a[{i}][{j}] = ");
                    jagged[i][j] = int.Parse(Console.ReadLine()!);
                }
            }

            Console.Write("Лівий кінець інтервалу (a): ");
            int a = int.Parse(Console.ReadLine()!);
            Console.Write("Правий кінець інтервалу (b): ");
            int b = int.Parse(Console.ReadLine()!);

            int[] resultSums = new int[n];
            for (int i = 0; i < n; i++)
            {
                resultSums[i] = 0;
                foreach (int val in jagged[i])
                {
                    // Елементи, що НЕ потрапляють в [a, b]
                    if (val < a || val > b)
                        resultSums[i] += val;
                }
            }

            Console.WriteLine($"Суми за рядками (елементи поза [{a}, {b}]):");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Рядок {i}: {resultSums[i]}");
        }
        #endregion
    }
}