using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    // 1. Класс, представляющий книгу
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; } // Уникальный идентификатор

        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            PublicationYear = year;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Год: {PublicationYear}, ISBN: {ISBN}";
        }
    }

    // 2. Класс, представляющий библиотеку
    public class HomeLibrary
    {
        // Коллекция для работы с произвольным числом книг
        private List<Book> _books;

        public IReadOnlyList<Book> Books => _books.AsReadOnly(); // Предоставляем только для чтения

        public HomeLibrary()
        {
            _books = new List<Book>();
        }

        // --- Управление коллекцией ---

        /// <summary>
        /// Добавление книги в библиотеку.
        /// </summary>
        public void AddBook(Book book)
        {
            if (_books.Any(b => b.ISBN == book.ISBN))
            {
                Console.WriteLine($"Ошибка: Книга с ISBN {book.ISBN} уже существует.");
                return;
            }
            _books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена.");
        }

        /// <summary>
        /// Удаление книги из библиотеки по ISBN.
        /// </summary>
        public bool RemoveBook(string isbn)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                Console.WriteLine($"Книга с ISBN {isbn} удалена.");
                return true;
            }
            Console.WriteLine($"Ошибка: Книга с ISBN {isbn} не найдена.");
            return false;
        }

        // --- Поиск ---

        /// <summary>
        /// Поиск книг по произвольному признаку (предикату).
        /// </summary>
        /// <param name="predicate">Условие поиска (например, книга.Author == "Толкин").</param>
        public List<Book> SearchBooks(Func<Book, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Условие поиска (предикат) не может быть null.");
            }
            return _books.Where(predicate).ToList();
        }

        // Удобный метод для поиска по частичному совпадению (пример использования)
        public List<Book> SearchByAuthor(string authorName)
        {
            return SearchBooks(b => b.Author.Contains(authorName, StringComparison.OrdinalIgnoreCase));
        }

        // --- Сортировка ---

        /// <summary>
        /// Сортировка книг по заданному правилу.
        /// </summary>
        /// <param name="comparison">Функция сравнения (например, (a, b) => a.PublicationYear.CompareTo(b.PublicationYear)).</param>
        public void SortBooks(Comparison<Book> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison), "Правило сортировки не может быть null.");
            }
            _books.Sort(comparison);
            Console.WriteLine("Библиотека отсортирована.");
        }

        // --- Отображение ---

        public void DisplayAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }
            Console.WriteLine($"\n--- Содержимое библиотеки ({_books.Count} книг) ---");
            foreach (var book in _books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("-----------------------------------------");
        }
    }

    // --- Тестирование ---
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HomeLibrary myLibrary = new HomeLibrary();

            // 1. Добавление книг
            Console.WriteLine("--- Добавление книг ---");
            myLibrary.AddBook(new Book("Властелин колец", "Дж. Р. Р. Толкин", 1954, "9780618260270"));
            myLibrary.AddBook(new Book("Хоббит", "Дж. Р. Р. Толкин", 1937, "9780007458310"));
            myLibrary.AddBook(new Book("1984", "Джордж Оруэлл", 1949, "9780451524935"));
            myLibrary.AddBook(new Book("Скотный двор", "Джордж Оруэлл", 1945, "9780451526342"));
            myLibrary.AddBook(new Book("Дюна", "Фрэнк Герберт", 1965, "9780441172719"));
            myLibrary.AddBook(new Book("Кольца власти", "Дж. Р. Р. Толкин", 2022, "9781234567890")); // Добавим для теста

            myLibrary.DisplayAllBooks();

            // 2. Поиск книг по автору
            Console.WriteLine("\n--- Поиск книг автора 'Толкин' ---");
            var tolkienBooks = myLibrary.SearchByAuthor("Толкин");
            foreach (var book in tolkienBooks)
            {
                Console.WriteLine($"Найдено: {book.Title}");
            }

            // 3. Поиск книг по году издания (используем прямой предикат)
            Console.WriteLine("\n--- Поиск книг, изданных до 1950 года ---");
            var oldBooks = myLibrary.SearchBooks(b => b.PublicationYear < 1950);
            foreach (var book in oldBooks)
            {
                Console.WriteLine($"Найдено старое издание: {book.Title} ({book.PublicationYear})");
            }

            // 4. Сортировка
            Console.WriteLine("\n--- Сортировка по году издания (по возрастанию) ---");
            myLibrary.SortBooks((b1, b2) => b1.PublicationYear.CompareTo(b2.PublicationYear));
            myLibrary.DisplayAllBooks();

            Console.WriteLine("\n--- Сортировка по названию (в обратном алфавитном порядке) ---");
            myLibrary.SortBooks((b1, b2) => b2.Title.CompareTo(b1.Title));
            myLibrary.DisplayAllBooks();


            // 5. Удаление книги
            Console.WriteLine("\n--- Удаление книги ---");
            myLibrary.RemoveBook("9780451524935"); // Удаляем "1984"
            myLibrary.RemoveBook("9999999999999"); // Попытка удалить несуществующую

            myLibrary.DisplayAllBooks();
        }
    }
}