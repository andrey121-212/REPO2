using System;

public class SubstringChecker
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Проверка на подстроку");
        Console.WriteLine("----------------------");

        // 1. Запрашиваем у пользователя первую строку
        Console.Write("Введите первую строку: ");
        string mainString = Console.ReadLine();

        // 2. Запрашиваем у пользователя вторую строку (потенциальную подстроку)
        Console.Write("Введите вторую строку (потенциальную подстроку): ");
        string subString = Console.ReadLine();

        // 3. Проверка на пустые строки
        if (string.IsNullOrEmpty(mainString) || string.IsNullOrEmpty(subString))
        {
            Console.WriteLine("\nОшибка: Обе строки должны быть не пустыми.");
            return; // Завершаем программу, если одна из строк пуста
        }

        // 4. Определение, является ли вторая строка подстрокой первой
        // Метод Contains() строк в C# идеально подходит для этой задачи.
        // Он возвращает true, если subString содержится в mainString, иначе false.
        bool isSubstring = mainString.Contains(subString);

        // 5. Вывод результата
        Console.WriteLine("\n--- Результат ---");
        if (isSubstring)
        {
            Console.WriteLine($"'{subString}' ЯВЛЯЕТСЯ подстрокой строки '{mainString}'.");
        }
        else
        {
            Console.WriteLine($"'{subString}' НЕ ЯВЛЯЕТСЯ подстрокой строки '{mainString}'.");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}