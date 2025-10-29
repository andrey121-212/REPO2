using SimpleTaskManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class MainForm : Form
    {
        private BindingList<Project> projects = new BindingList<Project>();
        private BindingList<Employee> employees = new BindingList<Employee>();
        private BindingList<ProjectTask> tasks = new BindingList<ProjectTask>();

        public MainForm()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshData();
        }

        private void LoadSampleData()
        {
            // Добавляем тестовые данные
            projects.Add(new Project { Id = 1, Name = "Веб-сайт компании", Status = "В работе" });
            projects.Add(new Project { Id = 2, Name = "Мобильное приложение", Status = "Планирование" });

            employees.Add(new Employee { Id = 1, Name = "Иванов Иван", Position = "Разработчик" });
            employees.Add(new Employee { Id = 2, Name = "Петрова Мария", Position = "Дизайнер" });

            tasks.Add(new ProjectTask
            {
                Id = 1,
                Title = "Создать главную страницу",
                ProjectId = 1,
                EmployeeId = 1,
                Priority = "Высокий",
                Status = "В работе",
                DueDate = DateTime.Now.AddDays(5)
            });
        }

        private void RefreshData()
        {
            // Обновляем списки
            listProjects.Items.Clear();
            foreach (var project in projects)
            {
                listProjects.Items.Add($"{project.Id}. {project.Name} ({project.Status})");
            }

            listEmployees.Items.Clear();
            foreach (var employee in employees)
            {
                listEmployees.Items.Add($"{employee.Id}. {employee.Name} - {employee.Position}");
            }

            listTasks.Items.Clear();
            foreach (var task in tasks)
            {
                var project = projects.FirstOrDefault(p => p.Id == task.ProjectId);
                var employee = employees.FirstOrDefault(e => e.Id == task.EmployeeId);
                listTasks.Items.Add($"{task.Id}. {task.Title} | {project?.Name} | {employee?.Name} | {task.Status}");
            }

            // Обновляем статистику
            lblStats.Text = $"Проектов: {projects.Count} | Сотрудников: {employees.Count} | Задач: {tasks.Count}";
        }

        // Проекты
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            var form = new ProjectForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var project = form.GetProject();
                project.Id = projects.Count > 0 ? projects.Max(p => p.Id) + 1 : 1;
                projects.Add(project);
                RefreshData();
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (listProjects.SelectedIndex >= 0)
            {
                var project = projects[listProjects.SelectedIndex];
                var form = new ProjectForm(project);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (listProjects.SelectedIndex >= 0 && MessageBox.Show("Удалить проект?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                projects.RemoveAt(listProjects.SelectedIndex);
                RefreshData();
            }
        }

        // Сотрудники
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var employee = form.GetEmployee();
                employee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
                employees.Add(employee);
                RefreshData();
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (listEmployees.SelectedIndex >= 0 && MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                employees.RemoveAt(listEmployees.SelectedIndex);
                RefreshData();
            }
        }

        // Задачи
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var form = new TaskForm(projects.ToList(), employees.ToList());
            if (form.ShowDialog() == DialogResult.OK)
            {
                var task = form.GetTask();
                task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
                tasks.Add(task);
                RefreshData();
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedIndex >= 0)
            {
                var task = tasks[listTasks.SelectedIndex];
                var form = new TaskForm(task, projects.ToList(), employees.ToList());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedIndex >= 0 && MessageBox.Show("Удалить задачу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tasks.RemoveAt(listTasks.SelectedIndex);
                RefreshData();
            }
        }

        // Отчеты
        private void btnReport_Click(object sender, EventArgs e)
        {
            var report = "ОТЧЕТ ПО ПРОЕКТАМ\n\n";

            foreach (var project in projects)
            {
                var projectTasks = tasks.Where(t => t.ProjectId == project.Id).ToList();
                report += $"Проект: {project.Name}\n";
                report += $"Статус: {project.Status}\n";
                report += $"Задач: {projectTasks.Count}\n";

                if (projectTasks.Any())
                {
                    foreach (var task in projectTasks)
                    {
                        var employee = employees.FirstOrDefault(e => e.Id == task.EmployeeId);
                        report += $"  - {task.Title} ({task.Status}) - {employee?.Name}\n";
                    }
                }
                report += "\n";
            }

            MessageBox.Show(report, "Отчет");
        }
    }

    // Простые классы для хранения данных
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    // ИЗМЕНЕНО: Переименовано с Task на ProjectTask
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}

// Форма для проектов
public class ProjectForm : Form
{
    private TextBox txtName;
    private TextBox txtDescription;
    private ComboBox cmbStatus;
    private Button btnOk;
    private Button btnCancel;
    private Project project;

    public ProjectForm()
    {
        project = new Project();
        InitializeForm();
    }

    public ProjectForm(Project existingProject) : this()
    {
        project = existingProject;
        txtName.Text = project.Name;
        txtDescription.Text = project.Description;
        cmbStatus.Text = project.Status;
    }

    private void InitializeForm()
    {
        this.Text = "Проект";
        this.Size = new Size(400, 250);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;

        // Название
        var lblName = new Label { Text = "Название:", Location = new Point(20, 20), Size = new Size(100, 20) };
        txtName = new TextBox { Location = new Point(120, 20), Size = new Size(250, 20) };
        this.Controls.Add(lblName);
        this.Controls.Add(txtName);

        // Описание
        var lblDesc = new Label { Text = "Описание:", Location = new Point(20, 50), Size = new Size(100, 20) };
        txtDescription = new TextBox { Location = new Point(120, 50), Size = new Size(250, 60), Multiline = true };
        this.Controls.Add(lblDesc);
        this.Controls.Add(txtDescription);

        // Статус
        var lblStatus = new Label { Text = "Статус:", Location = new Point(20, 120), Size = new Size(100, 20) };
        cmbStatus = new ComboBox { Location = new Point(120, 120), Size = new Size(150, 20) };
        cmbStatus.Items.AddRange(new string[] { "Планирование", "В работе", "Завершен", "Отменен" });
        cmbStatus.SelectedIndex = 0;
        this.Controls.Add(lblStatus);
        this.Controls.Add(cmbStatus);

        // Кнопки
        btnOk = new Button { Text = "OK", Location = new Point(120, 160), Size = new Size(75, 25) };
        btnCancel = new Button { Text = "Отмена", Location = new Point(205, 160), Size = new Size(75, 25) };

        btnOk.Click += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введите название проекта");
            }
        };

        btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; };

        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancel);

        this.AcceptButton = btnOk;
        this.CancelButton = btnCancel;
    }

    public Project GetProject()
    {
        project.Name = txtName.Text;
        project.Description = txtDescription.Text;
        project.Status = cmbStatus.Text;
        return project;
    }
}

// Форма для сотрудников
public class EmployeeForm : Form
{
    private TextBox txtName;
    private TextBox txtPosition;
    private TextBox txtEmail;
    private TextBox txtPhone;
    private Button btnOk;
    private Button btnCancel;
    private Employee employee;

    public EmployeeForm()
    {
        employee = new Employee();
        InitializeForm();
    }

    private void InitializeForm()
    {
        this.Text = "Сотрудник";
        this.Size = new Size(400, 200);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;

        int y = 20;

        // ФИО
        var lblName = new Label { Text = "ФИО:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtName = new TextBox { Location = new Point(120, y), Size = new Size(250, 20) };
        this.Controls.Add(lblName);
        this.Controls.Add(txtName);
        y += 30;

        // Должность
        var lblPosition = new Label { Text = "Должность:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtPosition = new TextBox { Location = new Point(120, y), Size = new Size(250, 20) };
        this.Controls.Add(lblPosition);
        this.Controls.Add(txtPosition);
        y += 30;

        // Email
        var lblEmail = new Label { Text = "Email:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtEmail = new TextBox { Location = new Point(120, y), Size = new Size(250, 20) };
        this.Controls.Add(lblEmail);
        this.Controls.Add(txtEmail);
        y += 30;

        // Телефон
        var lblPhone = new Label { Text = "Телефон:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtPhone = new TextBox { Location = new Point(120, y), Size = new Size(250, 20) };
        this.Controls.Add(lblPhone);
        this.Controls.Add(txtPhone);
        y += 40;

        // Кнопки
        btnOk = new Button { Text = "OK", Location = new Point(120, y), Size = new Size(75, 25) };
        btnCancel = new Button { Text = "Отмена", Location = new Point(205, y), Size = new Size(75, 25) };

        btnOk.Click += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введите ФИО сотрудника");
            }
        };

        btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; };

        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancel);

        this.AcceptButton = btnOk;
        this.CancelButton = btnCancel;
    }

    public Employee GetEmployee()
    {
        employee.Name = txtName.Text;
        employee.Position = txtPosition.Text;
        employee.Email = txtEmail.Text;
        employee.Phone = txtPhone.Text;
        return employee;
    }
}

// Форма для задач
public class TaskForm : Form
{
    private TextBox txtTitle;
    private TextBox txtDescription;
    private ComboBox cmbProject;
    private ComboBox cmbEmployee;
    private ComboBox cmbPriority;
    private ComboBox cmbStatus;
    private DateTimePicker dtDueDate;
    private Button btnOk;
    private Button btnCancel;
    private ProjectTask task; // ИЗМЕНЕНО: ProjectTask вместо Task
    private List<Project> projects;
    private List<Employee> employees;

    public TaskForm(List<Project> projectList, List<Employee> employeeList)
    {
        task = new ProjectTask(); // ИЗМЕНЕНО: ProjectTask вместо Task
        projects = projectList;
        employees = employeeList;
        InitializeForm();
    }

    // ИЗМЕНЕНО: Параметр типа ProjectTask вместо Task
    public TaskForm(ProjectTask existingTask, List<Project> projectList, List<Employee> employeeList) : this(projectList, employeeList)
    {
        task = existingTask;
        txtTitle.Text = task.Title;
        txtDescription.Text = task.Description;
        if (cmbProject.Items.Count > 0) cmbProject.SelectedValue = task.ProjectId;
        if (cmbEmployee.Items.Count > 0) cmbEmployee.SelectedValue = task.EmployeeId;
        cmbPriority.Text = task.Priority;
        cmbStatus.Text = task.Status;
        dtDueDate.Value = task.DueDate;
    }

    private void InitializeForm()
    {
        this.Text = "Задача";
        this.Size = new Size(450, 350);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;

        int y = 20;

        // Название
        var lblTitle = new Label { Text = "Название:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtTitle = new TextBox { Location = new Point(120, y), Size = new Size(300, 20) };
        this.Controls.Add(lblTitle);
        this.Controls.Add(txtTitle);
        y += 30;

        // Описание
        var lblDesc = new Label { Text = "Описание:", Location = new Point(20, y), Size = new Size(100, 20) };
        txtDescription = new TextBox { Location = new Point(120, y), Size = new Size(300, 60), Multiline = true };
        this.Controls.Add(lblDesc);
        this.Controls.Add(txtDescription);
        y += 70;

        // Проект
        var lblProject = new Label { Text = "Проект:", Location = new Point(20, y), Size = new Size(100, 20) };
        cmbProject = new ComboBox { Location = new Point(120, y), Size = new Size(200, 20), DropDownStyle = ComboBoxStyle.DropDownList };
        cmbProject.DisplayMember = "Name";
        cmbProject.ValueMember = "Id";
        cmbProject.DataSource = projects;
        this.Controls.Add(lblProject);
        this.Controls.Add(cmbProject);
        y += 30;

        // Исполнитель
        var lblEmployee = new Label { Text = "Исполнитель:", Location = new Point(20, y), Size = new Size(100, 20) };
        cmbEmployee = new ComboBox { Location = new Point(120, y), Size = new Size(200, 20), DropDownStyle = ComboBoxStyle.DropDownList };
        cmbEmployee.DisplayMember = "Name";
        cmbEmployee.ValueMember = "Id";
        cmbEmployee.DataSource = employees;
        this.Controls.Add(lblEmployee);
        this.Controls.Add(cmbEmployee);
        y += 30;

        // Приоритет
        var lblPriority = new Label { Text = "Приоритет:", Location = new Point(20, y), Size = new Size(100, 20) };
        cmbPriority = new ComboBox { Location = new Point(120, y), Size = new Size(150, 20) };
        cmbPriority.Items.AddRange(new string[] { "Низкий", "Средний", "Высокий", "Критический" });
        cmbPriority.SelectedIndex = 1;
        this.Controls.Add(lblPriority);
        this.Controls.Add(cmbPriority);
        y += 30;

        // Статус
        var lblStatus = new Label { Text = "Статус:", Location = new Point(20, y), Size = new Size(100, 20) };
        cmbStatus = new ComboBox { Location = new Point(120, y), Size = new Size(150, 20) };
        cmbStatus.Items.AddRange(new string[] { "Новая", "В работе", "Завершена", "Отменена" });
        cmbStatus.SelectedIndex = 0;
        this.Controls.Add(lblStatus);
        this.Controls.Add(cmbStatus);
        y += 30;

        // Срок
        var lblDueDate = new Label { Text = "Срок:", Location = new Point(20, y), Size = new Size(100, 20) };
        dtDueDate = new DateTimePicker { Location = new Point(120, y), Size = new Size(150, 20), Value = DateTime.Now.AddDays(7) };
        this.Controls.Add(lblDueDate);
        this.Controls.Add(dtDueDate);
        y += 40;

        // Кнопки
        btnOk = new Button { Text = "OK", Location = new Point(120, y), Size = new Size(75, 25) };
        btnCancel = new Button { Text = "Отмена", Location = new Point(205, y), Size = new Size(75, 25) };

        btnOk.Click += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введите название задачи");
            }
        };

        btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; };

        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancel);

        this.AcceptButton = btnOk;
        this.CancelButton = btnCancel;
    }

    // ИЗМЕНЕНО: Возвращает ProjectTask вместо Task
    public ProjectTask GetTask()
    {
        task.Title = txtTitle.Text;
        task.Description = txtDescription.Text;
        task.ProjectId = cmbProject.SelectedValue != null ? (int)cmbProject.SelectedValue : 0;
        task.EmployeeId = cmbEmployee.SelectedValue != null ? (int)cmbEmployee.SelectedValue : 0;
        task.Priority = cmbPriority.Text;
        task.Status = cmbStatus.Text;
        task.DueDate = dtDueDate.Value;
        return task;
    }
}