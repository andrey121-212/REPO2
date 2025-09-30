using System;

class Program
{
    static Random random = new Random();

    // Метод для создания квадратной матрицы
    public static int[,] CreateMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(-50, 51); // Случайные значения от -50 до 50
            }
        }
        return matrix;
    }

    // Метод для сортировки строк матрицы по возрастанию сумм их элементов
    public static void SortMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (RowSum(matrix, i) > RowSum(matrix, j))
                {
                    SwapRows(matrix, i, j);
                }
            }
        }
    }

    // Метод для вычисления суммы элементов строки
    public static int RowSum(int[,] matrix, int row)
    {
        int sum = 0;
        int size = matrix.GetLength(1);
        for (int j = 0; j < size; j++)
        {
            sum += matrix[row, j];
        }
        return sum;
    }

    // Метод для обмена двух строк матрицы
    public static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int size = matrix.GetLength(1);
        for (int j = 0; j < size; j++)
        {
            int temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }
    }

    // Метод для вывода матрицы
    public static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Введите размер квадратной матрицы: ");
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = CreateMatrix(size);
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        SortMatrix(matrix);
        Console.WriteLine("Матрица после сортировки строк по возрастанию сумм их элементов:");
        PrintMatrix(matrix);
    }
}
