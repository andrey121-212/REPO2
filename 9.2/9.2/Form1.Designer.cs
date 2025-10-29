namespace SimpleTaskManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabProjects;
        private TabPage tabEmployees;
        private TabPage tabTasks;
        private ListBox listProjects;
        private ListBox listEmployees;
        private ListBox listTasks;
        private Button btnAddProject;
        private Button btnEditProject;
        private Button btnDeleteProject;
        private Button btnAddEmployee;
        private Button btnDeleteEmployee;
        private Button btnAddTask;
        private Button btnEditTask;
        private Button btnDeleteTask;
        private Button btnReport;
        private Label lblStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Главная форма
            this.Text = "Управление задачами проекта";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Панель статистики
            lblStats = new Label
            {
                Text = "Проектов: 0 | Сотрудников: 0 | Задач: 0",
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightBlue
            };
            this.Controls.Add(lblStats);

            // Кнопка отчета
            btnReport = new Button
            {
                Text = "Создать отчет",
                Size = new Size(100, 30),
                Location = new Point(580, 10)
            };
            btnReport.Click += btnReport_Click;
            this.Controls.Add(btnReport);

            // TabControl
            tabControl = new TabControl
            {
                Location = new Point(10, 10),
                Size = new Size(660, 400)
            };
            this.Controls.Add(tabControl);

            // Вкладка Проекты
            tabProjects = new TabPage { Text = "Проекты" };
            InitializeProjectsTab();
            tabControl.Controls.Add(tabProjects);

            // Вкладка Сотрудники
            tabEmployees = new TabPage { Text = "Сотрудники" };
            InitializeEmployeesTab();
            tabControl.Controls.Add(tabEmployees);

            // Вкладка Задачи
            tabTasks = new TabPage { Text = "Задачи" };
            InitializeTasksTab();
            tabControl.Controls.Add(tabTasks);
        }

        private void InitializeProjectsTab()
        {
            // Список проектов
            listProjects = new ListBox
            {
                Location = new Point(10, 10),
                Size = new Size(500, 300),
                Font = new Font("Arial", 10)
            };
            tabProjects.Controls.Add(listProjects);

            // Кнопки для проектов
            btnAddProject = new Button
            {
                Text = "Добавить проект",
                Location = new Point(520, 10),
                Size = new Size(120, 30)
            };
            btnAddProject.Click += btnAddProject_Click;

            btnEditProject = new Button
            {
                Text = "Изменить проект",
                Location = new Point(520, 50),
                Size = new Size(120, 30)
            };
            btnEditProject.Click += btnEditProject_Click;

            btnDeleteProject = new Button
            {
                Text = "Удалить проект",
                Location = new Point(520, 90),
                Size = new Size(120, 30)
            };
            btnDeleteProject.Click += btnDeleteProject_Click;

            tabProjects.Controls.AddRange(new Control[] { btnAddProject, btnEditProject, btnDeleteProject });
        }

        private void InitializeEmployeesTab()
        {
            // Список сотрудников
            listEmployees = new ListBox
            {
                Location = new Point(10, 10),
                Size = new Size(500, 300),
                Font = new Font("Arial", 10)
            };
            tabEmployees.Controls.Add(listEmployees);

            // Кнопки для сотрудников
            btnAddEmployee = new Button
            {
                Text = "Добавить сотрудника",
                Location = new Point(520, 10),
                Size = new Size(120, 30)
            };
            btnAddEmployee.Click += btnAddEmployee_Click;

            btnDeleteEmployee = new Button
            {
                Text = "Удалить сотрудника",
                Location = new Point(520, 50),
                Size = new Size(120, 30)
            };
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;

            tabEmployees.Controls.AddRange(new Control[] { btnAddEmployee, btnDeleteEmployee });
        }

        private void InitializeTasksTab()
        {
            // Список задач
            listTasks = new ListBox
            {
                Location = new Point(10, 10),
                Size = new Size(500, 300),
                Font = new Font("Arial", 9)
            };
            tabTasks.Controls.Add(listTasks);

            // Кнопки для задач
            btnAddTask = new Button
            {
                Text = "Добавить задачу",
                Location = new Point(520, 10),
                Size = new Size(120, 30)
            };
            btnAddTask.Click += btnAddTask_Click;

            btnEditTask = new Button
            {
                Text = "Изменить задачу",
                Location = new Point(520, 50),
                Size = new Size(120, 30)
            };
            btnEditTask.Click += btnEditTask_Click;

            btnDeleteTask = new Button
            {
                Text = "Удалить задачу",
                Location = new Point(520, 90),
                Size = new Size(120, 30)
            };
            btnDeleteTask.Click += btnDeleteTask_Click;

            tabTasks.Controls.AddRange(new Control[] { btnAddTask, btnEditTask, btnDeleteTask });
        }
    }
}