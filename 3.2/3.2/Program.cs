using System;
using System.Collections.Generic;

// --- Перечисление для типов уведомлений ---
// Определяет возможные типы уведомлений.
public enum NotificationType
{
    Message,    // Системное сообщение/уведомление
    Call,       // Входящий звонок
    Email       // Новое электронное письмо
    // Если бы требовалась отправка сообщений между пользователями,
    // можно было бы добавить, например, UserMessage, но по условию
    // fokus на сообщения, звонки, письма.
}

// --- Класс для передачи данных события ---
// Содержит информацию, передаваемую вместе с событием.
public class NotificationEventArgs : EventArgs
{
    public Notification Notification { get; }

    public NotificationEventArgs(Notification notification)
    {
        Notification = notification;
    }
}

// --- Класс, представляющий само уведомление ---
// Содержит данные уведомления и определяет событие, которое генерируется.
public class Notification
{
    public NotificationType Type { get; }
    public string Message { get; }
    public string Details { get; } // Дополнительные детали (например, номер телефона, тема письма).

    // Событие, которое будет генерироваться при получении уведомления.
    // EventHandler<NotificationEventArgs> - стандартный делегат для событий с аргументами.
    public event EventHandler<NotificationEventArgs> NotificationReceived;

    public Notification(NotificationType type, string message, string details = null)
    {
        Type = type;
        Message = message;
        Details = details;
    }

    // Внутренний метод для вызова события.
    // Он вызывается, когда происходит событие (например, уведомление получено).
    internal void RaiseNotificationReceived()
    {
        // Проверяем, есть ли подписчики на событие. Если есть, вызываем их.
        // ?.Invoke - безопасный вызов.
        NotificationReceived?.Invoke(this, new NotificationEventArgs(this));
    }
}

// --- Класс - менеджер уведомлений ---
// Оркестрирует создание уведомлений, подписку на их события и их вызов.
public class NotificationManager
{
    // В данной реализации, NotificationManager будет создавать экземпляры Notification
    // и подписывать на их события общий обработчик.
    // Это позволяет имитировать получение разных типов уведомлений.

    /// <summary>
    /// Обработчик, который будет вызываться при получении уведомления любого типа.
    /// </summary>
    private void HandleNotificationReceived(object sender, NotificationEventArgs e)
    {
        Notification receivedNotification = e.Notification;

        // В зависимости от типа уведомления, выводим соответствующую информацию.
        switch (receivedNotification.Type)
        {
            case NotificationType.Message: // Системное сообщение/уведомление
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"!!! Получено СИСТЕМНОЕ УВЕДОМЛЕНИЕ: {receivedNotification.Message}");
                Console.WriteLine($"    Детали: {receivedNotification.Details ?? "Нет деталей"}");
                Console.ResetColor();
                break;

            case NotificationType.Call: // Входящий звонок
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($">>> Входящий ЗВОНОК: {receivedNotification.Message}");
                Console.WriteLine($"    От: {receivedNotification.Details ?? "Неизвестный номер"}");
                Console.ResetColor();
                break;

            case NotificationType.Email: // Новое электронное письмо
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"@@@ Получено ПИСЬМО: {receivedNotification.Message}");
                Console.WriteLine($"    Тема: {receivedNotification.Details ?? "Без темы"}");
                Console.ResetColor();
                break;

                // Если бы были другие типы, они бы обрабатывались здесь.
                // Например, для сообщений между пользователями:
                /*
                case NotificationType.UserMessage:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"--- НОВОЕ СООБЩЕНИЕ: {receivedNotification.Message}");
                    Console.WriteLine($"    От: {e.Sender ?? "Неизвестный"}"); // Предполагая, что Sender есть в EventArgs
                    Console.WriteLine($"    Содержимое: {receivedNotification.Details ?? "Пустое сообщение"}");
                    Console.ResetColor();
                    break;
                */
        }
    }

    /// <summary>
    /// Имитирует получение уведомления определенного типа.
    /// </summary>
    /// <param name="type">Тип уведомления.</param>
    /// <param name="message">Основное сообщение уведомления.</param>
    /// <param name="details">Дополнительные детали.</param>
    public void SimulateNotification(NotificationType type, string message, string details = null)
    {
        Console.WriteLine($"\n--- Симуляция получения уведомления: {type} ---");

        // Создаем НОВЫЙ объект Notification для данного события.
        Notification newNotification = new Notification(type, message, details);

        // Подписываем общий обработчик на событие этого нового уведомления.
        // Это гарантирует, что когда событие будет вызвано, наш обработчик его получит.
        newNotification.NotificationReceived += HandleNotificationReceived;

        // Вызываем метод, который генерирует событие NotificationReceived.
        // Это имитирует момент, когда уведомление действительно "приходит" в приложение.
        newNotification.RaiseNotificationReceived();

        // Важно: В реальном приложении, после обработки события,
        // возможно, потребуется отписаться от него, если это уведомление
        // больше не требуется или оно было одноразовым.
        // newNotification.NotificationReceived -= HandleNotificationReceived; // Пример отписки
    }
}

// --- Главная программа для демонстрации ---
// Точка входа в приложение, где мы тестируем функциональность.
class Program
{
    static void Main(string[] args)
    {
        // Установка кодировки консоли для корректного отображения кириллицы.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("--- Инициализация системы уведомлений ---");

        // Создаем экземпляр NotificationManager, который будет управлять всеми уведомлениями.
        NotificationManager manager = new NotificationManager();

        Console.WriteLine("\n--- Тестирование отправки различных типов уведомлений ---");

        // 1. Симуляция получения системного сообщения
        manager.SimulateNotification(NotificationType.Message, "Обновление системы", "Доступна новая версия 1.2.");

        // 2. Симуляция входящего звонка
        manager.SimulateNotification(NotificationType.Call, "Входящий звонок", "123-456-7890");

        // 3. Симуляция получения электронного письма
        manager.SimulateNotification(NotificationType.Email, "Важное письмо", "Тема: Результаты встречи");

        // 4. Симуляция другого системного сообщения
        manager.SimulateNotification(NotificationType.Message, "Напоминание", "Завтра запланирована уборка.");

        // 5. Симуляция еще одного входящего звонка (без указания номера телефона)
        manager.SimulateNotification(NotificationType.Call, "Входящий звонок");

        Console.WriteLine("\n--- Система уведомлений завершила имитацию ---");
        Console.ReadKey(); // Ожидание нажатия клавиши перед выходом
    }
}