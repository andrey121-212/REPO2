using System;

namespace zd_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод числителя и знаменателя
            Console.Write("Введите числитель (неотрицательное число): ");
            int chislitel = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите знаменатель (положительное число): ");
            int znamenatel = Convert.ToInt32(Console.ReadLine());

            // Проверка на корректность ввода
            if (znamenatel <= 0)
            {
                Console.WriteLine("Знаменатель должен быть положительным числом.");
                return;
            }

            // Вычисление НОД для числителя и знаменателя
            int nod = NOD(chislitel, znamenatel);

            // Сокращение дроби
            int SokrChislitel = chislitel / nod;
            int SokrZnamenatel = znamenatel / nod;

            // Вывод сокращенной дроби
            Console.WriteLine($"Сокращенная дробь: {SokrChislitel}/{SokrZnamenatel}");
        }

        // Метод для вычисления НОД (алгоритм Евклида)
        static int NOD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
