using System;

public class ArraySum
{
    public static void Main(string[] args)
    {
        // 1. Создание массива
        int[] numbers = new int[10]; // Создаем массив из 10 целых чисел (int)

        // 2. Заполнение массива случайными числами
        Random random = new Random(); // Создаем объект Random для генерации случайных чисел
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 101); // Генерируем случайное число от 1 до 100 и присваиваем элементу массива
        }

        // 3. Вывод массива (для отладки, можно закомментировать)
        Console.WriteLine("Сгенерированный массив:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine(); // Перевод строки после вывода массива

        // 4. Вычисление суммы элементов массива
        int sum = 0; // Инициализируем переменную для хранения суммы
        foreach (int number in numbers) // Проходим по каждому элементу массива
        {
            sum += number; // Прибавляем текущий элемент к сумме
        }

        // 5. Вывод суммы
        Console.WriteLine("Сумма всех элементов массива: " + sum);

        Console.ReadKey(); // Ожидаем нажатия клавиши для завершения
    }
}