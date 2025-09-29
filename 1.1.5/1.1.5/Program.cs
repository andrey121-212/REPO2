using System;

public class FizzBuzz
{
    public static void Main(string[] args)
    {
        Console.WriteLine("FizzBuzz программа:");

        // Проходим циклом от 1 до 100
        for (int i = 1; i <= 100; i++)
        {
            bool divisibleBy3 = (i % 3 == 0); // Проверяем делится ли число на 3
            bool divisibleBy5 = (i % 5 == 0); // Проверяем делится ли число на 5

            if (divisibleBy3 && divisibleBy5) // Если делится и на 3, и на 5
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (divisibleBy3) // Если делится только на 3
            {
                Console.WriteLine("Fizz");
            }
            else if (divisibleBy5) // Если делится только на 5
            {
                Console.WriteLine("Buzz");
            }
            else // Если не делится ни на 3, ни на 5
            {
                Console.WriteLine(i); // Выводим само число
            }
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey(); // Ждем нажатия клавиши перед завершением
    }
}