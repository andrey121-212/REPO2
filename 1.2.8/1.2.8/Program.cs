using System;

class Program
{
    static Random random = new Random();

    // Статический метод для создания массива
    public static int[] CreateArray(int maxSum)
    {
        int sum = 0;
        int count = 0;
        int[] tempArray = new int[100]; // Максимально возможное количество элементов
        while (sum <= maxSum)
        {
            int value = random.Next(1, 10); // Случайное число от 1 до 9
            sum += value;
            if (sum > maxSum) break;
            tempArray[count++] = value;
        }
        int[] resultArray = new int[count];
        Array.Copy(tempArray, resultArray, count);
        return resultArray;
    }

    static void Main()
    {
        Console.Write("Введите максимальную сумму: ");
        int maxSum = int.Parse(Console.ReadLine());

        int[] array = CreateArray(maxSum);
        Console.WriteLine("Сгенерированный массив:");
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
    }
}
