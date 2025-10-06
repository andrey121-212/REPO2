using System;
using System.Collections.Generic;
using System.Linq;

// --- 1. Определение делегата ---
public delegate void TaskActionDelegate(string taskDescription);

// --- 2. Класс, представляющий отдельную задачу ---
public class Task
{
    public string Description { get; }
    public TaskActionDelegate Action { get; }

    public Task(string description, TaskActionDelegate action)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Описание задачи не может быть пустым.", nameof(description));
        }
        if (action == null)
        {
            // Явное выбрасывание ArgumentNullException, если делегат null
            throw new ArgumentNullException(nameof(action), "Действие для задачи не может быть null.");
        }

        Description = description;
        Action = action;
    }

    public void Execute()
    {
        Console.WriteLine($"\n--- Выполнение задачи: '{Description}' ---");
        try
        {
            Action?.Invoke(Description);
            Console.WriteLine($"Задача '{Description}' успешно выполнена.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка при выполнении задачи '{Description}': {ex.Message}");
            Console.ResetColor();
        }
    }
}

// --- 3. Класс для управления задачами ---
public class TaskManager
{
    private List<Task> _tasks;
    private readonly Dictionary<int, (string Name, TaskActionDelegate Delegate)> _availableActions;

    public TaskManager()
    {
        _tasks = new List<Task>();
        _availableActions = new Dictionary<int, (string, TaskActionDelegate)>();

        // По умолчанию регистрируем доступные действия
        RegisterAction("Отправить уведомление", TaskActions.SendNotification);
        RegisterAction("Записать в журнал", TaskActions.LogToFile);
        RegisterAction("Обновить статус", TaskActions.UpdateStatus);
    }

    private void RegisterAction(string name, TaskActionDelegate actionDelegate)
    {
        int id = _availableActions.Count + 1;
        _availableActions.Add(id, (name, actionDelegate));
    }

    public IReadOnlyDictionary<int, (string Name, TaskActionDelegate Delegate)> AvailableActions => _availableActions;

    /// <summary>
    /// Интерактивный метод для добавления задачи с выбором делегата.
    /// </summary>
    public void AddTaskInteractive()
    {
        Console.WriteLine("\n--- Добавление новой задачи ---");

        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        // Отображаем пользователю список доступных действий
        Console.WriteLine("Выберите действие для задачи:");
        foreach (var kvp in _availableActions)
        {
            Console.WriteLine($"{kvp.Key}. {kvp.Value.Name}");
        }
        Console.Write("Введите номер действия: ");

        if (!int.TryParse(Console.ReadLine(), out int choice) || !_availableActions.ContainsKey(choice))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Неверный ввод. Действие не выбрано.");
            Console.ResetColor();
            return;
        }

        TaskActionDelegate selectedAction = _availableActions[choice].Delegate;

        // Создаем и добавляем задачу, перехватывая исключения, которые могут прийти из конструктора Task
        try
        {
            Task newTask = new Task(description, selectedAction);
            _tasks.Add(newTask);
            Console.WriteLine($"Задача \"{description}\" с действием \"{_availableActions[choice].Name}\" успешно добавлена.");
        }
        // Ловим ArgumentException (который включает ArgumentNullException)
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка добавления задачи: {ex.Message}");
            Console.ResetColor();
        }
    }

    // ... (Остальные методы ExecuteAllTasks, ExecuteTask, DisplayAllTasks остаются без изменений)

    public void ExecuteAllTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("\nВ менеджере задач нет задач для выполнения.");
            return;
        }

        Console.WriteLine($"\n--- Начинаем выполнение всех {_tasks.Count} задач ---");
        foreach (var task in _tasks)
        {
            task.Execute();
        }
        Console.WriteLine("--- Все задачи выполнены ---");
    }

    public void ExecuteTask(int index)
    {
        if (index < 0 || index >= _tasks.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: Неверный индекс задачи ({index}). В списке {(_tasks.Count == 0 ? "нет" : $"от 0 до {_tasks.Count - 1}")} задач.");
            Console.ResetColor();
            return;
        }
        _tasks[index].Execute();
    }

    public void DisplayAllTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("\nСписок задач пуст.");
            return;
        }
        Console.WriteLine($"\n--- Список текущих задач ({_tasks.Count} шт.) ---");
        for (int i = 0; i < _tasks.Count; i++)
        {
            string actionName = "Неизвестное действие";
            if (_tasks[i].Action != null)
            {
                var matchingAction = _availableActions.FirstOrDefault(kvp => kvp.Value.Delegate == _tasks[i].Action);
                if (matchingAction.Value.Delegate != null)
                {
                    actionName = matchingAction.Value.Name;
                }
            }
            Console.WriteLine($"{i}. [{actionName}] {_tasks[i].Description}");
        }
        Console.WriteLine("-----------------------------------");
    }
}

// --- 4. Примеры действий (Обработчики делегатов) ---
public static class TaskActions
{
    public static void SendNotification(string taskDescription)
    {
        Console.WriteLine($"    [Отправка уведомления] Уведомление: '{taskDescription}' отправлено.");
    }

    public static void LogToFile(string taskDescription)
    {
        Console.WriteLine($"    [Запись в журнал] Задача '{taskDescription}' записана в лог.");
    }

    public static void UpdateStatus(string taskDescription)
    {
        Console.WriteLine($"    [Обновление статуса] Статус задачи '{taskDescription}' изменен на 'Завершено'.");
    }
}

// --- Главная программа для демонстрации ---
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        TaskManager taskManager = new TaskManager();

        // --- Интерактивное добавление задач ---
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("--- Меню управления задачами (Интерактив) ---");
            Console.WriteLine("1. Добавить задачу (выбрать действие)");
            Console.WriteLine("2. Выполнить все задачи");
            Console.WriteLine("3. Выполнить конкретную задачу");
            Console.WriteLine("4. Показать список всех задач");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    taskManager.AddTaskInteractive(); // Вызываем интерактивный метод
                    break;
                case "2":
                    taskManager.ExecuteAllTasks();
                    break;
                case "3":
                    Console.Write("Введите номер задачи для выполнения: ");
                    if (int.TryParse(Console.ReadLine(), out int taskIndex))
                    {
                        taskManager.ExecuteTask(taskIndex);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                        Console.ResetColor();
                    }
                    break;
                case "4":
                    taskManager.DisplayAllTasks();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите из меню.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
