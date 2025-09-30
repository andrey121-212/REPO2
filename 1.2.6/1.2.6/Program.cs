using System;
using System.Linq;

namespace zd_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Определяем массив из 10 элементов
            double[] array = new double[10];
            Random rnd = new Random();

            // Заполнение массива случайными значениями из диапазона [-10, 10)
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.NextDouble() * 20 - 10;
                Console.WriteLine($"{i}: {array[i]:F2}");
            }

            // Формируем массив индексов по возрастанию значений элементов
            var indices = array
                .Select((value, index) => new { value, index })
                .OrderBy(x => x.value)
                .Select(x => x.index)
                .ToArray();

            // Выводим массив индексов
            Console.WriteLine("Массив индексов в порядке возрастания значений:");
            foreach (var index in indices)
            {
                Console.Write(index + " ");
            }
        }
    }
}
