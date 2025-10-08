using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private List<Task> tasks;
        private int currentFilter; // 0-все, 1-активные, 2-выполненные

        public Form1()
        {
            InitializeComponent();
            InitializeTaskManager();
        }

        private void InitializeTaskManager()
        {
            tasks = new List<Task>();
            currentFilter = 0;

            // Настройка колонок ListView
            listViewTasks.Columns.Add("Статус", 80);
            listViewTasks.Columns.Add("Задача", 300);
            listViewTasks.Columns.Add("Приоритет", 100);
            listViewTasks.Columns.Add("Дата создания", 120);
            listViewTasks.Columns.Add("Срок выполнения", 120);

            listViewTasks.View = View.Details;
            listViewTasks.FullRowSelect = true;
            listViewTasks.GridLines = true;

            // Загрузка тестовых данных
            LoadSampleTasks();
            UpdateTasksList();
            UpdateStats();
        }

        private void LoadSampleTasks()
        {
            tasks.Add(new Task("Изучить C#", "Выучить основы программирования на C#", DateTime.Now.AddDays(7), Priority.High));
            tasks.Add(new Task("Купить продукты", "Молоко, хлеб, яйца", DateTime.Now.AddDays(1), Priority.Medium));
            tasks.Add(new Task("Сделать домашнее задание", "Математика и физика", DateTime.Now.AddDays(3), Priority.High));
        }

        private void AddTask()
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime dueDate = dtpDueDate.Value;
            Priority priority = GetSelectedPriority();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите название задачи!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task newTask = new Task(title, description, dueDate, priority);
            tasks.Add(newTask);

            ClearInputFields();
            UpdateTasksList();
            UpdateStats();

            MessageBox.Show("Задача добавлена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteTask()
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Удалить выбранную задачу?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = listViewTasks.SelectedItems[0].Index;
                tasks.RemoveAt(GetFilteredTaskIndex(index));
                UpdateTasksList();
                UpdateStats();
            }
        }

        private void ToggleTaskCompletion()
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = listViewTasks.SelectedItems[0].Index;
            Task task = tasks[GetFilteredTaskIndex(index)];
            task.IsCompleted = !task.IsCompleted;

            UpdateTasksList();
            UpdateStats();
        }

        private void EditTask()
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = listViewTasks.SelectedItems[0].Index;
            Task task = tasks[GetFilteredTaskIndex(index)];

            // Заполняем поля формы данными выбранной задачи
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpDueDate.Value = task.DueDate;
            SetPrioritySelection(task.Priority);

            // Удаляем старую задачу (будет заменена отредактированной)
            tasks.RemoveAt(GetFilteredTaskIndex(index));
            UpdateTasksList();
            UpdateStats();
        }

        private void ClearCompletedTasks()
        {
            var result = MessageBox.Show("Удалить все выполненные задачи?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tasks.RemoveAll(task => task.IsCompleted);
                UpdateTasksList();
                UpdateStats();
            }
        }

        private Priority GetSelectedPriority()
        {
            if (rbHigh.Checked) return Priority.High;
            if (rbMedium.Checked) return Priority.Medium;
            return Priority.Low;
        }

        private void SetPrioritySelection(Priority priority)
        {
            switch (priority)
            {
                case Priority.High:
                    rbHigh.Checked = true;
                    break;
                case Priority.Medium:
                    rbMedium.Checked = true;
                    break;
                case Priority.Low:
                    rbLow.Checked = true;
                    break;
            }
        }

        private void ClearInputFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now.AddDays(1);
            rbMedium.Checked = true;
        }

        private void UpdateTasksList()
        {
            listViewTasks.Items.Clear();

            var filteredTasks = GetFilteredTasks();

            foreach (var task in filteredTasks)
            {
                ListViewItem item = new ListViewItem();

                // Статус
                item.Text = task.IsCompleted ? "✅ Выполнена" : "⏳ Активна";
                item.ForeColor = task.IsCompleted ? Color.Green : Color.Black;

                // Задача
                item.SubItems.Add(task.Title);

                // Приоритет
                string priorityText = GetPriorityText(task.Priority);
                Color priorityColor = GetPriorityColor(task.Priority);
                item.SubItems.Add(priorityText);
                item.SubItems[2].ForeColor = priorityColor;

                // Дата создания
                item.SubItems.Add(task.CreatedDate.ToString("dd.MM.yyyy"));

                // Срок выполнения
                string dueDateText = task.DueDate.ToString("dd.MM.yyyy");
                if (task.DueDate < DateTime.Now && !task.IsCompleted)
                {
                    dueDateText += " ⚠️ ПРОСРОЧЕНО";
                    item.SubItems[3].ForeColor = Color.Red;
                }
                item.SubItems.Add(dueDateText);

                // Цвет строки для просроченных задач
                if (task.DueDate < DateTime.Now && !task.IsCompleted)
                {
                    item.BackColor = Color.LightPink;
                }
                else if (task.IsCompleted)
                {
                    item.BackColor = Color.LightGreen;
                }

                listViewTasks.Items.Add(item);
            }
        }

        private List<Task> GetFilteredTasks()
        {
            switch (currentFilter)
            {
                case 1: // Активные
                    return tasks.FindAll(task => !task.IsCompleted);
                case 2: // Выполненные
                    return tasks.FindAll(task => task.IsCompleted);
                default: // Все
                    return tasks;
            }
        }

        private int GetFilteredTaskIndex(int listViewIndex)
        {
            var filteredTasks = GetFilteredTasks();
            if (listViewIndex >= 0 && listViewIndex < filteredTasks.Count)
            {
                Task task = filteredTasks[listViewIndex];
                return tasks.IndexOf(task);
            }
            return -1;
        }

        private void UpdateStats()
        {
            int totalTasks = tasks.Count;
            int completedTasks = tasks.FindAll(task => task.IsCompleted).Count;
            int activeTasks = totalTasks - completedTasks;
            int overdueTasks = tasks.FindAll(task => !task.IsCompleted && task.DueDate < DateTime.Now).Count;

            lblStats.Text = $"Всего: {totalTasks} | Активные: {activeTasks} | Выполненные: {completedTasks} | Просроченные: {overdueTasks}";
        }

        private string GetPriorityText(Priority priority)
        {
            switch (priority)
            {
                case Priority.High: return "🔴 Высокий";
                case Priority.Medium: return "🟡 Средний";
                case Priority.Low: return "🟢 Низкий";
                default: return "Средний";
            }
        }

        private Color GetPriorityColor(Priority priority)
        {
            switch (priority)
            {
                case Priority.High: return Color.Red;
                case Priority.Medium: return Color.Orange;
                case Priority.Low: return Color.Green;
                default: return Color.Black;
            }
        }

        private void ApplyFilter(int filterType)
        {
            currentFilter = filterType;
            UpdateTasksList();

            // Обновляем текст кнопки фильтра
            string filterText = "Все";
            switch (filterType)
            {
                case 1: filterText = "Активные"; break;
                case 2: filterText = "Выполненные"; break;
            }
            btnFilter.Text = $"Фильтр: {filterText}";
        }

        // Обработчики событий
        private void btnAdd_Click(object sender, EventArgs e) => AddTask();
        private void btnDelete_Click(object sender, EventArgs e) => DeleteTask();
        private void btnComplete_Click(object sender, EventArgs e) => ToggleTaskCompletion();
        private void btnEdit_Click(object sender, EventArgs e) => EditTask();
        private void btnClearCompleted_Click(object sender, EventArgs e) => ClearCompletedTasks();

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Циклическое переключение фильтров
            currentFilter = (currentFilter + 1) % 3;
            ApplyFilter(currentFilter);
        }

        private void listViewTasks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                int index = listViewTasks.SelectedItems[0].Index;
                Task task = tasks[GetFilteredTaskIndex(index)];

                string taskInfo = $"Название: {task.Title}\n" +
                                $"Описание: {task.Description}\n" +
                                $"Приоритет: {GetPriorityText(task.Priority)}\n" +
                                $"Статус: {(task.IsCompleted ? "Выполнена" : "Активна")}\n" +
                                $"Дата создания: {task.CreatedDate:dd.MM.yyyy HH:mm}\n" +
                                $"Срок выполнения: {task.DueDate:dd.MM.yyyy}\n" +
                                $"Просрочена: {(task.DueDate < DateTime.Now && !task.IsCompleted ? "Да" : "Нет")}";

                MessageBox.Show(taskInfo, "Информация о задаче",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddTask();
                e.Handled = true;
            }
        }
    }

    // Класс задачи
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title, string description, DateTime dueDate, Priority priority)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            DueDate = dueDate;
            Priority = priority;
            IsCompleted = false;
        }
    }

    // Перечисление приоритетов
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}