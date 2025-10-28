using StudentManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class MainForm : Form
    {
        private BindingList<Student> students;
        private string dataFilePath = "students.json";

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            if (File.Exists(dataFilePath))
            {
                LoadDataFromFile();
            }
            else
            {
                students = new BindingList<Student>();
            }
            dataGridView.DataSource = students;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new StudentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var student = form.GetStudent();
                    student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
                    students.Add(student);
                    SaveData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var student = dataGridView.SelectedRows[0].DataBoundItem as Student;
                using (var form = new StudentForm(student))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView.Refresh();
                        SaveData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var student = dataGridView.SelectedRows[0].DataBoundItem as Student;
                students.Remove(student);
                SaveData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(search))
            {
                dataGridView.DataSource = students;
            }
            else
            {
                var filtered = students.Where(s =>
                    s.FullName.ToLower().Contains(search) ||
                    s.Group.ToLower().Contains(search)).ToList();
                dataGridView.DataSource = new BindingList<Student>(filtered);
            }
        }

        private void SaveData()
        {
            try
            {
                var json = JsonSerializer.Serialize(students.ToList());
                File.WriteAllText(dataFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void LoadDataFromFile()
        {
            try
            {
                var json = File.ReadAllText(dataFilePath);
                var data = JsonSerializer.Deserialize<List<Student>>(json);
                students = new BindingList<Student>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                students = new BindingList<Student>();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, JsonSerializer.Serialize(students.ToList()));
                    MessageBox.Show("Данные экспортированы");
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataFromFile();
                    dataGridView.DataSource = students;
                    MessageBox.Show("Данные импортированы");
                }
            }
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Group { get; set; }
        public double AverageGrade { get; set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}

public partial class StudentForm : Form
{
    private Student student;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private TextBox txtMiddleName;
    private TextBox txtGroup;
    private NumericUpDown numGrade;
    private Button btnSave;
    private Button btnCancel;

    public StudentForm()
    {
        InitializeComponent();
        student = new Student();
    }

    public StudentForm(Student existingStudent) : this()
    {
        student = existingStudent;
        txtLastName.Text = student.LastName;
        txtFirstName.Text = student.FirstName;
        txtMiddleName.Text = student.MiddleName;
        txtGroup.Text = student.Group;
        numGrade.Value = (decimal)student.AverageGrade;
    }

    private void InitializeComponent()
    {
        this.txtLastName = new TextBox();
        this.txtFirstName = new TextBox();
        this.txtMiddleName = new TextBox();
        this.txtGroup = new TextBox();
        this.numGrade = new NumericUpDown();
        this.btnSave = new Button();
        this.btnCancel = new Button();

        // Form
        this.Text = "Данные студента";
        this.Size = new Size(300, 250);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Controls
        var labels = new[] { "Фамилия:", "Имя:", "Отчество:", "Группа:", "Средний балл:" };
        var controls = new Control[] { txtLastName, txtFirstName, txtMiddleName, txtGroup, numGrade };

        for (int i = 0; i < labels.Length; i++)
        {
            var label = new Label
            {
                Text = labels[i],
                Location = new Point(20, 20 + i * 35),
                Size = new Size(100, 20)
            };
            this.Controls.Add(label);

            controls[i].Location = new Point(120, 20 + i * 35);
            controls[i].Size = new Size(150, 20);
            this.Controls.Add(controls[i]);
        }

        numGrade.DecimalPlaces = 2;
        numGrade.Minimum = 0;
        numGrade.Maximum = 5;

        btnSave.Text = "Сохранить";
        btnSave.Location = new Point(50, 190);
        btnSave.Size = new Size(75, 25);
        btnSave.Click += BtnSave_Click;
        this.Controls.Add(btnSave);

        btnCancel.Text = "Отмена";
        btnCancel.Location = new Point(150, 190);
        btnCancel.Size = new Size(75, 25);
        btnCancel.Click += BtnCancel_Click;
        this.Controls.Add(btnCancel);
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (ValidateData())
        {
            student.LastName = txtLastName.Text;
            student.FirstName = txtFirstName.Text;
            student.MiddleName = txtMiddleName.Text;
            student.Group = txtGroup.Text;
            student.AverageGrade = (double)numGrade.Value;
            DialogResult = DialogResult.OK;
        }
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private bool ValidateData()
    {
        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Введите фамилию");
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("Введите имя");
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtGroup.Text))
        {
            MessageBox.Show("Введите группу");
            return false;
        }
        return true;
    }

    public Student GetStudent() => student;
}