using SimpleTaskManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class MainForm : Form
    {
        private List<MyTask> tasks = new List<MyTask>();
        private int nextId = 1;

        public MainForm()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshTaskList();
        }

        private void LoadSampleData()
        {
            tasks.Add(new MyTask
            {
                Id = nextId++,
                TaskTitle = "Завершить отчет",
                TaskDescription = "Подготовить квартальный отчет",
                Priority = "Высокий",
                DueDate = DateTime.Now.AddDays(2),
                IsCompleted = false
            });

            tasks.Add(new MyTask
            {
                Id = nextId++,
                TaskTitle = "Создать презентацию",
                TaskDescription = "Презентация для клиента",
                Priority = "Средний",
                DueDate = DateTime.Now.AddDays(5),
                IsCompleted = false
            });

            tasks.Add(new MyTask
            {
                Id = nextId++,
                TaskTitle = "Купить продукты",
                TaskDescription = "Молоко, хлеб, яйца",
                Priority = "Низкий",
                DueDate = DateTime.Now.AddDays(-1),
                IsCompleted = false
            });
        }

        private void RefreshTaskList()
        {
            listTasks.Items.Clear();

            var searchText = txtSearch.Text.ToLower();
            var filterIndex = cmbFilter.SelectedIndex;

            var filteredTasks = tasks.Where(task =>
            {
                // Поиск
                if (!string.IsNullOrEmpty(searchText))
                {
                    if (!task.TaskTitle.ToLower().Contains(searchText) &&
                        !task.TaskDescription.ToLower().Contains(searchText))
                        return false;
                }

                // Фильтрация
                switch (filterIndex)
                {
                    case 1: // Активные
                        return !task.IsCompleted;
                    case 2: // Завершенные
                        return task.IsCompleted;
                    case 3: // Просроченные
                        return !task.IsCompleted && task.DueDate < DateTime.Now;
                    default: // Все
                        return true;
                }
            });

            foreach (var task in filteredTasks)
            {
                var item = new ListViewItem(task.TaskTitle);
                item.SubItems.Add(task.Priority);
                item.SubItems.Add(task.DueDate.ToString("dd.MM.yyyy"));
                item.SubItems.Add(task.IsCompleted ? "Да" : "Нет");
                item.Tag = task;

                // Цветовое кодирование
                if (task.IsCompleted)
                    item.BackColor = Color.LightGreen;
                else if (task.DueDate < DateTime.Now)
                    item.BackColor = Color.LightPink;
                else if (task.Priority == "Высокий")
                    item.BackColor = Color.LightYellow;
                else if (task.Priority == "Критический")
                    item.BackColor = Color.LightCoral;

                listTasks.Items.Add(item);
            }

            UpdateStats();
        }

        private void UpdateStats()
        {
            var total = tasks.Count;
            var completed = tasks.Count(t => t.IsCompleted);
            var overdue = tasks.Count(t => !t.IsCompleted && t.DueDate < DateTime.Now);

            lblStats.Text = $"Всего: {total}  Выполнено: {completed}  Просрочено: {overdue}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TaskForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var task = form.GetTask();
                task.Id = nextId++;
                tasks.Add(task);
                RefreshTaskList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу для редактирования");
                return;
            }

            var task = (MyTask)listTasks.SelectedItems[0].Tag;
            var form = new TaskForm(task);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshTaskList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу для удаления");
                return;
            }

            var task = (MyTask)listTasks.SelectedItems[0].Tag;
            if (MessageBox.Show($"Удалить задачу '{task.TaskTitle}'?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tasks.Remove(task);
                RefreshTaskList();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите задачу");
                return;
            }

            var task = (MyTask)listTasks.SelectedItems[0].Tag;
            task.IsCompleted = true;
            RefreshTaskList();
            MessageBox.Show($"Задача '{task.TaskTitle}' отмечена как выполненная");
        }

        private void listTasks_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }
    }

    public class MyTask
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}

public class TaskForm : Form
{
    private MyTask task;
    private TextBox txtTitle;
    private TextBox txtDescription;
    private ComboBox cmbPriority;
    private DateTimePicker dtpDueDate;
    private CheckBox chkCompleted;
    private Button btnOk;
    private Button btnCancel;

    public TaskForm()
    {
        task = new MyTask();
        InitializeForm();
    }

    public TaskForm(MyTask existingTask) : this()
    {
        task = existingTask;
        txtTitle.Text = task.TaskTitle;
        txtDescription.Text = task.TaskDescription;
        cmbPriority.Text = task.Priority;
        dtpDueDate.Value = task.DueDate;
        chkCompleted.Checked = task.IsCompleted;
    }

    private void InitializeForm()
    {
        // Настройка формы
        this.Text = "Добавить задачу";
        this.Size = new Size(400, 300);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Создание элементов
        var lblTitle = new Label { Text = "Название:", Location = new Point(20, 20), Size = new Size(80, 20) };
        txtTitle = new TextBox { Location = new Point(100, 20), Size = new Size(250, 20) };

        var lblDescription = new Label { Text = "Описание:", Location = new Point(20, 50), Size = new Size(80, 20) };
        txtDescription = new TextBox { Location = new Point(100, 50), Size = new Size(250, 60), Multiline = true };

        var lblPriority = new Label { Text = "Приоритет:", Location = new Point(20, 120), Size = new Size(80, 20) };
        cmbPriority = new ComboBox { Location = new Point(100, 120), Size = new Size(150, 20) };
        cmbPriority.Items.AddRange(new string[] { "Низкий", "Средний", "Высокий", "Критический" });
        cmbPriority.SelectedIndex = 1;

        var lblDueDate = new Label { Text = "Срок:", Location = new Point(20, 150), Size = new Size(80, 20) };
        dtpDueDate = new DateTimePicker { Location = new Point(100, 150), Size = new Size(150, 20), Value = DateTime.Now.AddDays(7) };

        chkCompleted = new CheckBox { Text = "Выполнена", Location = new Point(100, 180), Size = new Size(100, 20) };

        btnOk = new Button { Text = "Сохранить", Location = new Point(100, 220), Size = new Size(80, 25) };
        btnCancel = new Button { Text = "Отмена", Location = new Point(190, 220), Size = new Size(80, 25) };

        // Добавление на форму
        this.Controls.Add(lblTitle);
        this.Controls.Add(txtTitle);
        this.Controls.Add(lblDescription);
        this.Controls.Add(txtDescription);
        this.Controls.Add(lblPriority);
        this.Controls.Add(cmbPriority);
        this.Controls.Add(lblDueDate);
        this.Controls.Add(dtpDueDate);
        this.Controls.Add(chkCompleted);
        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancel);

        // События
        btnOk.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название задачи");
                return;
            }
            DialogResult = DialogResult.OK;
        };

        btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

        this.AcceptButton = btnOk;
        this.CancelButton = btnCancel;
    }

    public MyTask GetTask()
    {
        task.TaskTitle = txtTitle.Text;
        task.TaskDescription = txtDescription.Text;
        task.Priority = cmbPriority.Text;
        task.DueDate = dtpDueDate.Value;
        task.IsCompleted = chkCompleted.Checked;
        return task;
    }
}