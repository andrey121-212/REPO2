using System;

namespace ЛР_2 // Костыгов А.А.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите a1: ");
            double a1 = Convert.ToDouble(Console.ReadLine());

            double resultA = 2 * Math.Pow(Math.Sin(3 * Math.PI - 2 * a), 2) * Math.Pow(Math.Cos(5 * Math.PI + 2 * a), 2);
            double resultA1 = 0.25 - 0.25 * Math.Sin((5.0 / 2.0) * Math.PI - 8 * a1);

            Console.WriteLine($"z1 = {resultA:E2}");
            Console.WriteLine($"z2 = {resultA1:E2}");

            Console.ReadKey();
        }
    }
}
