using System;
using System.Collections.Generic;
using System.Linq; // Для использования ToList() и Any()

public class FixedLengthStringArray
{
    private readonly string[] _data; // Внутреннее хранилище строк
    private readonly int _length;    // Фиксированная длина массива

    /// <summary>
    /// Возвращает фиксированную длину массива.
    /// </summary>
    public int Length => _length;

    /// <summary>
    /// Конструктор для создания массива заданной фиксированной длины.
    /// </summary>
    /// <param name="length">Желаемая фиксированная длина массива.</param>
    /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если длина меньше или равна нулю.</exception>
    public FixedLengthStringArray(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Длина массива должна быть положительным числом.");
        }
        _length = length;
        _data = new string[_length]; // Инициализируем внутренний массив
    }

    /// <summary>
    /// Конструктор для создания массива из существующего массива строк.
    /// </summary>
    /// <param name="initialData">Исходный массив строк.</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если initialData равно null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если длина initialData не соответствует конструктору.</exception>
    public FixedLengthStringArray(string[] initialData)
    {
        if (initialData == null)
        {
            throw new ArgumentNullException(nameof(initialData), "Исходный массив строк не может быть null.");
        }
        _length = initialData.Length;
        _data = new string[_length];
        // Копируем данные, выполняя проверку индекса для каждого элемента
        for (int i = 0; i < _length; i++)
        {
            this[i] = initialData[i]; // Используем сеттер индексатора для проверки
        }
    }

    // --- Контроль выхода за пределы массива и доступ к элементам ---

    /// <summary>
    /// Позволяет обращаться к отдельным строкам массива по индексам.
    /// </summary>
    /// <param name="index">Индекс элемента.</param>
    /// <exception cref="IndexOutOfRangeException">Выбрасывается, если индекс находится за пределами допустимых границ массива.</exception>
    public string this[int index]
    {
        get
        {
            // Проверка выхода за пределы массива при чтении
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException($"Индекс {index} находится вне допустимых границ массива (0-{_length - 1}).");
            }
            return _data[index];
        }
        set
        {
            // Проверка выхода за пределы массива при записи
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException($"Индекс {index} находится вне допустимых границ массива (0-{_length - 1}).");
            }
            _data[index] = value;
        }
    }

    // --- Операции сцепления ---

    /// <summary>
    /// Выполняет поэлементное сцепление двух массивов с образованием нового массива.
    /// Результат будет иметь длину, равную сумме длин обоих массивов.
    /// </summary>
    /// <param name="otherArray">Второй массив для сцепления.</param>
    /// <returns>Новый объект FixedLengthStringArray, содержащий объединенные элементы.</returns>
    /// <exception cref="ArgumentNullException">Выбрасывается, если otherArray равен null.</exception>
    public FixedLengthStringArray Concatenate(FixedLengthStringArray otherArray)
    {
        if (otherArray == null)
        {
            throw new ArgumentNullException(nameof(otherArray), "Массив для сцепления не может быть null.");
        }

        // Длина нового массива равна сумме длин двух исходных
        int newLength = this._length + otherArray.Length;
        // Если бы мы хотели ограничить максимальную длину, здесь была бы проверка:
        // if (newLength > MAX_ARRAY_LENGTH) throw new InvalidOperationException(...);

        FixedLengthStringArray newArray = new FixedLengthStringArray(newLength);

        // Копируем элементы из текущего массива
        for (int i = 0; i < this._length; i++)
        {
            newArray[i] = this[i]; // Используем индексатор для безопасной записи
        }

        // Копируем элементы из другого массива
        for (int i = 0; i < otherArray.Length; i++)
        {
            newArray[this._length + i] = otherArray[i]; // Используем индексатор
        }

        return newArray;
    }

    // --- Операции слияния с исключением повторяющихся элементов ---

    /// <summary>
    /// Выполняет слияние двух массивов с исключением повторяющихся элементов.
    /// Новый массив будет иметь фиксированную длину, равную сумме длин исходных массивов,
    /// и будет содержать уникальные элементы. Пустые ячейки могут остаться (null).
    /// </summary>
    /// <param name="otherArray">Второй массив для слияния.</param>
    /// <returns>Новый объект FixedLengthStringArray, содержащий уникальные элементы.</returns>
    /// <exception cref="ArgumentNullException">Выбрасывается, если otherArray равен null.</exception>
    public FixedLengthStringArray MergeUnique(FixedLengthStringArray otherArray)
    {
        if (otherArray == null)
        {
            throw new ArgumentNullException(nameof(otherArray), "Массив для слияния не может быть null.");
        }

        int newLength = this._length + otherArray.Length;
        FixedLengthStringArray mergedArray = new FixedLengthStringArray(newLength);
        HashSet<string> uniqueElements = new HashSet<string>(); // Используем HashSet для быстрого определения уникальности

        int currentIndex = 0;

        // Добавляем элементы из текущего массива, если они уникальны
        for (int i = 0; i < this._length; i++)
        {
            string element = this[i];
            if (!string.IsNullOrEmpty(element) && uniqueElements.Add(element)) // Проверяем, что не null/пусто и добавляем
            {
                mergedArray[currentIndex++] = element;
            }
        }

        // Добавляем элементы из другого массива, если они уникальны
        for (int i = 0; i < otherArray.Length; i++)
        {
            string element = otherArray[i];
            if (!string.IsNullOrEmpty(element) && uniqueElements.Add(element))
            {
                mergedArray[currentIndex++] = element;
            }
        }

        // Важно: Если количество уникальных элементов меньше newLength,
        // оставшиеся элементы в mergedArray будут null, что соответствует
        // фиксированной длине и условию "остаются пустые ячейки".

        return mergedArray;
    }

    // --- Вывод на экран ---

    /// <summary>
    /// Выводит на экран элемент массива по заданному индексу.
    /// </summary>
    /// <param name="index">Индекс элемента для вывода.</param>
    public void DisplayElement(int index)
    {
        try
        {
            // Используем индексатор, который уже содержит проверку границ
            Console.WriteLine($"Элемент по индексу {index}: \"{this[index]}\"");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка при выводе элемента: {ex.Message}");
        }
    }

    /// <summary>
    /// Выводит на экран весь массив.
    /// </summary>
    public void DisplayAll()
    {
        if (_length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        Console.WriteLine($"\n--- Содержимое массива (Длина: {_length}) ---");
        for (int i = 0; i < _length; i++)
        {
            Console.WriteLine($"[{i}]: \"{this[i] ?? "null"}\""); // Выводим "null", если элемент null
        }
        Console.WriteLine("-------------------------------------");
    }
}

// --- Пример использования класса ---
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("--- Создание массивов ---");
        // Создаем массив длиной 5
        FixedLengthStringArray arr1 = new FixedLengthStringArray(5);
        arr1[0] = "Apple";
        arr1[1] = "Banana";
        arr1[2] = "Cherry";
        // arr1[5] = "Date"; // Попытка выхода за пределы (приведет к ошибке, если раскомментировать)

        // Создаем массив из существующего
        string[] initialData = { "Red", "Green", "Blue" };
        FixedLengthStringArray arr2 = new FixedLengthStringArray(initialData);

        // Создаем другой массив
        FixedLengthStringArray arr3 = new FixedLengthStringArray(4);
        arr3[0] = "Orange";
        arr3[1] = "Banana"; // Дубликат
        arr3[2] = "Grape";
        arr3[3] = "Apple";  // Дубликат

        Console.WriteLine("Массив 1:");
        arr1.DisplayAll();
        Console.WriteLine("Массив 2:");
        arr2.DisplayAll();
        Console.WriteLine("Массив 3:");
        arr3.DisplayAll();

        Console.WriteLine("\n--- Доступ к элементам ---");
        arr1.DisplayElement(1); // Apple
        arr1.DisplayElement(3); // null (по умолчанию)
        arr1.DisplayElement(5); // Ошибка: индекс вне границ

        Console.WriteLine("\n--- Поэлементное сцепление (Concatenate) ---");
        FixedLengthStringArray concatenatedArray = arr1.Concatenate(arr2);
        Console.WriteLine($"Результат сцепления (Длина: {concatenatedArray.Length}):");
        concatenatedArray.DisplayAll();

        // Попробуем сцепить arr1 и arr3
        Console.WriteLine("\n--- Сцепление arr1 и arr3 ---");
        FixedLengthStringArray concatenatedArray2 = arr1.Concatenate(arr3);
        Console.WriteLine($"Результат сцепления (Длина: {concatenatedArray2.Length}):");
        concatenatedArray2.DisplayAll();


        Console.WriteLine("\n--- Слияние с исключением дубликатов (MergeUnique) ---");
        // arr1: {"Apple", "Banana", "Cherry", null, null}
        // arr3: {"Orange", "Banana", "Grape", "Apple"}
        // Ожидаемый результат (уникальные): {"Apple", "Banana", "Cherry", "Orange", "Grape"}
        FixedLengthStringArray mergedArray = arr1.MergeUnique(arr3);
        Console.WriteLine($"Результат слияния (Длина: {mergedArray.Length}):");
        mergedArray.DisplayAll();

        // Пример с пустыми строками и null
        FixedLengthStringArray arr4 = new FixedLengthStringArray(3);
        arr4[0] = "One";
        arr4[1] = ""; // Пустая строка

        FixedLengthStringArray arr5 = new FixedLengthStringArray(3);
        arr5[0] = "Two";
        arr5[1] = null; // null
        arr5[2] = "One"; // Дубликат

        Console.WriteLine("\n--- Слияние с пустыми строками и null ---");
        FixedLengthStringArray mergedWithNulls = arr4.MergeUnique(arr5);
        Console.WriteLine($"Результат слияния (Длина: {mergedWithNulls.Length}):");
        mergedWithNulls.DisplayAll();


        Console.WriteLine("\n--- Тестирование некорректных операций ---");
        try
        {
            new FixedLengthStringArray(0); // Некорректная длина
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            arr1.DisplayElement(10); // Выход за пределы
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            arr1.Concatenate(null); // Сцепление с null
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}