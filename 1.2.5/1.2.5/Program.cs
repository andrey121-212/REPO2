using System;

namespace zd_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод размера массива
            Console.Write("Введите размер массива K: ");
            int K = Convert.ToInt32(Console.ReadLine());
            char[] array = new char[K];
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            Random rnd = new Random();

            // Заполнение массива случайными буквами
            for (int i = 0; i < K; i++)
            {
                array[i] = (char)rnd.Next('а', 'я' + 1);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // Создание нового массива из согласных букв
            Console.WriteLine("Массив согласных букв:");
            foreach (var letter in array)
            {
                if (Array.IndexOf(vowels, letter) == -1)
                {
                    Console.Write(letter + " ");
                }
            }
        }
    }
}

