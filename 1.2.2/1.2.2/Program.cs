using System;

namespace zd_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 5, 8, 1, 9, 6, 2, 7, 4, 0 };

            // Ввод нового значения
            Console.Write("Введите число для замены максимального элемента: ");
            int newValue = Convert.ToInt32(Console.ReadLine());

            // Поиск максимального элемента и его индекса
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            // Замена максимального элемента
            array[maxIndex] = newValue;

            // Вывод измененного массива
            Console.WriteLine("Измененный массив:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
