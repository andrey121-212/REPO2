using System;

namespace zd_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества простых чисел
            Console.Write("Введите количество простых чисел K: ");
            int K = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            int number = 2;

            while (count < K)
            {
                if (IsPrime(number))
                {
                    Console.Write(number + " ");
                    count++;

                    // Переход на новую строку после 10 чисел
                    if (count % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                number++;
            }
        }

        // Метод для проверки, является ли число простым
        static bool IsPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
