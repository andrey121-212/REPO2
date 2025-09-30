using System;

namespace zd_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int K;
            int A, B;

            // Ввод размера массива K с проверкой
            Console.Write("Введите размер массива K: ");
            if (!int.TryParse(Console.ReadLine(), out K) || K <= 0)
            {
                Console.WriteLine("Ошибка: Размер массива должен быть положительным целым числом.");
                return; // Завершаем программу, если ввод некорректен
            }

            // Ввод значения A с проверкой
            Console.Write("Введите значение A: ");
            if (!int.TryParse(Console.ReadLine(), out A))
            {
                Console.WriteLine("Ошибка: Введено некорректное значение для A.");
                return; // Завершаем программу, если ввод некорректен
            }

            // Ввод значения B с проверкой
            Console.Write("Введите значение B: ");
            if (!int.TryParse(Console.ReadLine(), out B))
            {
                Console.WriteLine("Ошибка: Введено некорректное значение для B.");
                return; // Завершаем программу, если ввод некорректен
            }

            // Проверка, что A <= B для корректной работы rnd.Next
            if (A > B)
            {
                Console.WriteLine("Ошибка: Значение A не может быть больше значения B.");
                return; // Завершаем программу, если диапазон некорректен
            }

            int[] array = new int[K];
            Random rnd = new Random();

            // Заполнение массива случайными значениями
            Console.WriteLine("Сгенерированные элементы массива:");
            for (int i = 0; i < K; i++)
            {
                // rnd.Next(A, B) генерирует число от A (включительно) до B (НЕ включительно)
                // Поэтому, если хотим включить B, нужно использовать rnd.Next(A, B + 1)
                // Если же диапазон строго от A до B (не включая B), тоrnd.Next(A, B) корректно
                // В данном коде предполагается, что B - это верхняя граница, которая может быть включена.
                // Исправим на B+1 для включения B. Если B не должно включаться, оставьте B.
                array[i] = rnd.Next(A, B + 1);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // Поиск индексов минимального и максимального элементов
            int minIndex = 0, maxIndex = 0;
            // Если массив пустой (K=0), этот цикл не выполнится, что корректно.
            for (int i = 1; i < K; i++)
            {
                if (array[i] < array[minIndex]) minIndex = i;
                if (array[i] > array[maxIndex]) maxIndex = i;
            }

            // Вывод элементов между минимальным и максимальным (включительно)
            Console.WriteLine("Элементы между минимальным и максимальным (включительно):");
            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            for (int i = start; i <= end; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(); // Перевод строки для красоты

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}