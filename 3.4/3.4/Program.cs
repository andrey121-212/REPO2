using System;
using System.Collections.Generic;
using System.Linq;

// --- 1. Класс, представляющий элемент данных (например, запись в журнале) ---
public class DataItem
{
    public DateTime Date { get; }
    public string Content { get; }

    public DataItem(DateTime date, string content)
    {
        Date = date;
        Content = content;
    }

    public override string ToString()
    {
        return $"[{Date:yyyy-MM-dd}] {Content}";
    }
}

// --- 2. Класс - Менеджер фильтрации ---
public class DataFilterManager
{
    private List<DataItem> _dataSet;

    public DataFilterManager(List<DataItem> initialData)
    {
        _dataSet = initialData ?? new List<DataItem>();
    }

    /// <summary>
    /// Применяет заданный фильтр (делегат Predicate) к списку данных.
    /// </summary>
    /// <param name="filterPredicate">Делегат, определяющий условие фильтрации.</param>
    /// <returns>Список элементов, прошедших фильтрацию.</returns>
    public List<DataItem> ApplyFilter(Predicate<DataItem> filterPredicate)
    {
        if (filterPredicate == null)
        {
            Console.WriteLine("Предупреждение: Фильтр не задан. Возвращен весь список.");
            return _dataSet.ToList();
        }

        // Используем стандартный метод List<T>.FindAll, который принимает Predicate<T>
        List<DataItem> filteredList = _dataSet.FindAll(filterPredicate);
        return filteredList;
    }

    /// <summary>
    /// Отображает весь набор данных.
    /// </summary>
    public void DisplayAllData()
    {
        Console.WriteLine("\n--- Полный набор данных ---");
        if (!_dataSet.Any())
        {
            Console.WriteLine("Набор данных пуст.");
            return;
        }
        foreach (var item in _dataSet)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("--------------------------");
    }
}

// --- Класс Program для демонстрации ---
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Подготовка исходных данных
        List<DataItem> data = new List<DataItem>
        {
            new DataItem(new DateTime(2023, 10, 15), "Системное обновление завершено успешно."),
            new DataItem(new DateTime(2023, 10, 18), "Пользователь: Алиса вошла в систему."),
            new DataItem(new DateTime(2023, 11, 01), "Ошибка базы данных при запросе."),
            new DataItem(new DateTime(2023, 11, 02), "Системное обновление завершено успешно."),
            new DataItem(new DateTime(2023, 11, 05), "Пользователь: Боб не смог авторизоваться.")
        };

        DataFilterManager manager = new DataFilterManager(data);
        manager.DisplayAllData();

        // --- 2. Демонстрация выбора и применения фильтров ---

        bool continueFiltering = true;
        while (continueFiltering)
        {
            Console.WriteLine("\n--- Выберите тип фильтра ---");
            Console.WriteLine("1. Фильтр по ключевому слову (например, 'Системное')");
            Console.WriteLine("2. Фильтр по дате (показать все за Ноябрь 2023)");
            Console.WriteLine("3. Показать весь набор данных");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            List<DataItem> results = new List<DataItem>();
            string filterName = "Все данные";

            switch (choice)
            {
                case "1":
                    Console.Write("Введите ключевое слово для поиска: ");
                    string keyword = Console.ReadLine();
                    filterName = $"Поиск по ключу: '{keyword}'";

                    // Пользовательский фильтр, заданный через ЛЯМБДА-ВЫРАЖЕНИЕ
                    // Применяем делегат Predicate<DataItem>
                    results = manager.ApplyFilter(item =>
                        item.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    );
                    break;

                case "2":
                    int targetMonth = 11; // Ноябрь
                    int targetYear = 2023;
                    filterName = $"Записи за {targetMonth}/{targetYear}";

                    // Фильтр по дате (через ЛЯМБДА-ВЫРАЖЕНИЕ)
                    results = manager.ApplyFilter(item =>
                        item.Date.Month == targetMonth && item.Date.Year == targetYear
                    );
                    break;

                case "3":
                    manager.DisplayAllData();
                    continue; // Пропускаем вывод результатов

                case "0":
                    continueFiltering = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор.");
                    Console.ResetColor();
                    continue;
            }

            // Вывод результатов, если фильтрация произошла
            if (choice != "3" && choice != "0")
            {
                Console.WriteLine($"\n--- Результаты фильтрации: {filterName} ({results.Count} найдено) ---");
                if (results.Any())
                {
                    foreach (var item in results)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("Ничего не найдено по заданным критериям.");
                }
                Console.WriteLine("------------------------------------------------------");
            }
        }

        Console.WriteLine("\nПриложение завершено.");
    }
}