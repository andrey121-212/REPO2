using System;

namespace zd_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод размера массива
            Console.Write("Введите размер массива N: ");
            // Используем int.TryParse для более безопасного ввода размера,
            // чтобы избежать ошибок при вводе нечисловых значений.
            if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
            {
                Console.WriteLine("Ошибка: Размер массива должен быть положительным целым числом.");
                return; // Выход из программы, если ввод некорректен
            }

            double[] array = new double[N]; // Создаем массив типа double

            // Ввод элементов массива
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                // Используем double.TryParse для безопасного ввода элементов
                if (!double.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Ошибка: Введено некорректное число. Повторите ввод.");
                    i--; // Повторяем ввод текущего элемента
                }
            }

            // Поиск максимального по модулю элемента
            // Важно: обрабатываем случай, когда все элементы равны нулю.
            double maxAbs = 0; // Инициализируем нулем
            if (N > 0) // Проверяем, что массив не пустой
            {
                maxAbs = Math.Abs(array[0]); // Начинаем с первого элемента
                for (int i = 1; i < N; i++)
                {
                    // **ИСПОРАВЛЕННАЯ СТРОКА 25:**
                    // Здесь была опечатка: ar2ray[i] -> array[i]
                    if (Math.Abs(array[i]) > maxAbs)
                    {
                        maxAbs = Math.Abs(array[i]);
                    }
                }
            }

            // Проверка на деление на ноль
            if (maxAbs == 0)
            {
                Console.WriteLine("Ошибка: Максимальный элемент по модулю равен нулю. Нормализация невозможна.");
                return; // Выход, если нормализация невозможна
            }

            // Нормировка элементов массива
            for (int i = 0; i < N; i++)
            {
                array[i] /= maxAbs; // Делим каждый элемент на максимальное значение по модулю
            }

            // Вывод измененного массива
            Console.WriteLine("\nНормированные элементы массива:");
            foreach (double item in array)
            {
                Console.WriteLine($"{item:F4}"); // Выводим с 4 знаками после запятой для лучшей наглядности
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}