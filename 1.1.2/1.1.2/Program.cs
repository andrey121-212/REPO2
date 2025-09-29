using System;

public class AverageOfThree
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите три числа:");

        // 1. Ввод чисел с проверкой на корректность
        double num1 = GetValidNumber("Первое число: ");
        double num2 = GetValidNumber("Второе число: ");
        double num3 = GetValidNumber("Третье число: ");

        // 2. Вычисление среднего арифметического
        double average = (num1 + num2 + num3) / 3;

        // 3. Вывод результата
        Console.WriteLine($"Среднее арифметическое: {average}");
    }

    // Функция для получения корректного числа от пользователя
    static double GetValidNumber(string prompt)
    {
        double number;
        bool isValid;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            isValid = double.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Ошибка: Введите корректное число.");
            }
        } while (!isValid);

        return number;
    }
}