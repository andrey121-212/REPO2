using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    // Интерфейс Студент
    public interface IStudent
    {
        string FullName { get; set; }
        string StudentId { get; set; }
        int Course { get; set; }
        string Group { get; set; }
        double CalculateAverageGrade();
        string GetCourseInfo();
        string GetStudentInfo();
        void AddGrade(string subject, int grade);
        Dictionary<string, List<int>> Grades { get; }
    }

    // Базовый класс студента
    public abstract class BaseStudent : IStudent
    {
        public string FullName { get; set; }
        public string StudentId { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public Dictionary<string, List<int>> Grades { get; protected set; }

        public BaseStudent(string fullName, string studentId, int course, string group)
        {
            FullName = fullName;
            StudentId = studentId;
            Course = course;
            Group = group;
            Grades = new Dictionary<string, List<int>>();
        }

        public abstract double CalculateAverageGrade();

        public virtual string GetCourseInfo()
        {
            return $"{Course} курс, группа {Group}";
        }

        public virtual string GetStudentInfo()
        {
            return $"{FullName} (ID: {StudentId}) - {GetCourseInfo()} - Средний балл: {CalculateAverageGrade():F2}";
        }

        public void AddGrade(string subject, int grade)
        {
            if (grade < 1 || grade > 5)
                throw new ArgumentException("Оценка должна быть от 1 до 5");

            if (!Grades.ContainsKey(subject))
            {
                Grades[subject] = new List<int>();
            }
            Grades[subject].Add(grade);
        }

        protected double CalculateAverageForSubject(string subject)
        {
            if (Grades.ContainsKey(subject) && Grades[subject].Count > 0)
            {
                double sum = 0;
                foreach (var grade in Grades[subject])
                {
                    sum += grade;
                }
                return sum / Grades[subject].Count;
            }
            return 0;
        }
    }

    // Студент 1 курса
    public class FirstYearStudent : BaseStudent
    {
        public FirstYearStudent(string fullName, string studentId, string group)
            : base(fullName, studentId, 1, group)
        {
        }

        public override double CalculateAverageGrade()
        {
            if (Grades.Count == 0) return 0;

            double totalSum = 0;
            int totalCount = 0;

            foreach (var subject in Grades.Keys)
            {
                totalSum += CalculateAverageForSubject(subject) * GetSubjectWeight(subject);
                totalCount += Grades[subject].Count;
            }

            return totalCount > 0 ? totalSum / totalCount : 0;
        }

        private double GetSubjectWeight(string subject)
        {
            // Базовые предметы имеют стандартный вес
            return 1.0;
        }

        public override string GetCourseInfo()
        {
            return $"1 курс (бакалавриат), группа {Group} - Изучение базовых дисциплин";
        }
    }

    // Студент 2-3 курса
    public class MiddleYearStudent : BaseStudent
    {
        public string Specialization { get; set; }

        public MiddleYearStudent(string fullName, string studentId, int course, string group, string specialization)
            : base(fullName, studentId, course, group)
        {
            if (course < 2 || course > 3)
                throw new ArgumentException("Курс должен быть 2 или 3");
            Specialization = specialization;
        }

        public override double CalculateAverageGrade()
        {
            if (Grades.Count == 0) return 0;

            double totalSum = 0;
            int totalCount = 0;

            foreach (var subject in Grades.Keys)
            {
                double weight = GetSubjectWeight(subject);
                totalSum += CalculateAverageForSubject(subject) * weight * Grades[subject].Count;
                totalCount += Grades[subject].Count;
            }

            return totalCount > 0 ? totalSum / totalCount : 0;
        }

        private double GetSubjectWeight(string subject)
        {
            // Профильные предметы имеют больший вес
            if (IsCoreSubject(subject))
                return 1.2;
            return 1.0;
        }

        private bool IsCoreSubject(string subject)
        {
            string[] coreSubjects = { "Программирование", "Базы данных", "Алгоритмы", "Сети" };
            return Array.Exists(coreSubjects, s => s.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }

        public override string GetCourseInfo()
        {
            return $"{Course} курс (бакалавриат), группа {Group} - Профилизация: {Specialization}";
        }

        public override string GetStudentInfo()
        {
            return $"{base.GetStudentInfo()} - Специализация: {Specialization}";
        }
    }

    // Студент 4 курса (выпускник)
    public class FinalYearStudent : BaseStudent
    {
        public string ThesisTopic { get; set; }
        public bool HasInternship { get; set; }

        public FinalYearStudent(string fullName, string studentId, string group, string thesisTopic, bool hasInternship)
            : base(fullName, studentId, 4, group)
        {
            ThesisTopic = thesisTopic;
            HasInternship = hasInternship;
        }

        public override double CalculateAverageGrade()
        {
            if (Grades.Count == 0) return 0;

            double totalSum = 0;
            int totalCount = 0;
            int thesisBonus = 0;

            foreach (var subject in Grades.Keys)
            {
                double weight = GetSubjectWeight(subject);
                double subjectAverage = CalculateAverageForSubject(subject);

                if (subject.Equals("Дипломная работа", StringComparison.OrdinalIgnoreCase))
                {
                    thesisBonus = (int)(subjectAverage * 0.5); // Бонус за диплом
                }

                totalSum += subjectAverage * weight * Grades[subject].Count;
                totalCount += Grades[subject].Count;
            }

            double average = totalCount > 0 ? (totalSum / totalCount) + thesisBonus : 0;
            return Math.Min(average, 5.0); // Не больше 5.0
        }

        private double GetSubjectWeight(string subject)
        {
            // Дипломная работа и профильные предметы имеют больший вес
            if (subject.Equals("Дипломная работа", StringComparison.OrdinalIgnoreCase))
                return 2.0;
            else if (IsCoreSubject(subject))
                return 1.3;
            return 1.0;
        }

        private bool IsCoreSubject(string subject)
        {
            string[] coreSubjects = { "Спецкурс", "Проектирование", "Исследование" };
            return Array.Exists(coreSubjects, s => s.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }

        public override string GetCourseInfo()
        {
            string internshipInfo = HasInternship ? "с практикой" : "без практики";
            return $"4 курс (выпускной), группа {Group} - Диплом: '{ThesisTopic}' ({internshipInfo})";
        }

        public override string GetStudentInfo()
        {
            return $"{base.GetStudentInfo()} - Тема диплома: {ThesisTopic}";
        }
    }

    // Магистрант
    public class MastersStudent : BaseStudent
    {
        public string ResearchArea { get; set; }
        public bool IsResearcher { get; set; }

        public MastersStudent(string fullName, string studentId, string group, string researchArea, bool isResearcher)
            : base(fullName, studentId, 5, group) // 5 курс для магистратуры
        {
            ResearchArea = researchArea;
            IsResearcher = isResearcher;
        }

        public override double CalculateAverageGrade()
        {
            if (Grades.Count == 0) return 0;

            double totalSum = 0;
            int totalCount = 0;
            double researchBonus = IsResearcher ? 0.3 : 0;

            foreach (var subject in Grades.Keys)
            {
                double weight = GetSubjectWeight(subject);
                totalSum += CalculateAverageForSubject(subject) * weight * Grades[subject].Count;
                totalCount += Grades[subject].Count;
            }

            double average = totalCount > 0 ? (totalSum / totalCount) + researchBonus : 0;
            return Math.Min(average, 5.0);
        }

        private double GetSubjectWeight(string subject)
        {
            if (IsResearchSubject(subject))
                return 1.5;
            else if (IsCoreSubject(subject))
                return 1.2;
            return 1.0;
        }

        private bool IsResearchSubject(string subject)
        {
            string[] researchSubjects = { "Научное исследование", "Диссертация", "Публикация" };
            return Array.Exists(researchSubjects, s => s.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsCoreSubject(string subject)
        {
            string[] coreSubjects = { "Методология", "Анализ", "Проект" };
            return Array.Exists(coreSubjects, s => s.Equals(subject, StringComparison.OrdinalIgnoreCase));
        }

        public override string GetCourseInfo()
        {
            string researcherInfo = IsResearcher ? "научный сотрудник" : "магистрант";
            return $"Магистратура ({Course} курс), группа {Group} - Направление: {ResearchArea} ({researcherInfo})";
        }

        public override string GetStudentInfo()
        {
            return $"{base.GetStudentInfo()} - Область исследований: {ResearchArea}";
        }
    }

    // Основная форма приложения
    public partial class Form1 : Form
    {
        private List<IStudent> students;
        private IStudent selectedStudent;

        public Form1()
        {
            InitializeComponent();
            students = new List<IStudent>();
            InitializeCourseComboBox();
            LoadSampleData();
            RefreshStudentsList();
        }

        private void InitializeCourseComboBox()
        {
            cmbStudentType.Items.Add("1 курс (Бакалавриат)");
            cmbStudentType.Items.Add("2-3 курс (Бакалавриат)");
            cmbStudentType.Items.Add("4 курс (Выпускник)");
            cmbStudentType.Items.Add("Магистратура");
            cmbStudentType.SelectedIndex = 0;
        }

        private void LoadSampleData()
        {
            // Примеры студентов
            var student1 = new FirstYearStudent("Иванов Иван Иванович", "B2024001", "БИ-01");
            student1.AddGrade("Математика", 5);
            student1.AddGrade("Программирование", 4);
            student1.AddGrade("Физика", 3);
            students.Add(student1);

            var student2 = new MiddleYearStudent("Петров Петр Петрович", "B2023001", 2, "БИ-21", "Разработка ПО");
            student2.AddGrade("Программирование", 5);
            student2.AddGrade("Базы данных", 4);
            student2.AddGrade("Алгоритмы", 5);
            students.Add(student2);

            var student3 = new FinalYearStudent("Сидорова Анна Сергеевна", "B2021001", "БИ-41",
                "Разработка системы управления вузом", true);
            student3.AddGrade("Дипломная работа", 5);
            student3.AddGrade("Спецкурс", 4);
            students.Add(student3);

            var student4 = new MastersStudent("Козлов Алексей Дмитриевич", "M2024001", "МИ-01",
                "Искусственный интеллект", true);
            student4.AddGrade("Научное исследование", 5);
            student4.AddGrade("Методология", 4);
            students.Add(student4);
        }

        private void cmbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInputFields();
        }

        private void UpdateInputFields()
        {
            lblExtra1.Visible = false;
            txtExtra1.Visible = false;
            lblExtra2.Visible = false;
            chkExtra1.Visible = false;

            string studentType = cmbStudentType.SelectedItem.ToString();

            switch (studentType)
            {
                case "1 курс (Бакалавриат)":
                    // Дополнительные поля не нужны
                    break;

                case "2-3 курс (Бакалавриат)":
                    lblExtra1.Text = "Специализация:";
                    lblExtra1.Visible = true;
                    txtExtra1.Visible = true;
                    break;

                case "4 курс (Выпускник)":
                    lblExtra1.Text = "Тема диплома:";
                    lblExtra2.Text = "Прошел практику:";
                    lblExtra1.Visible = true;
                    txtExtra1.Visible = true;
                    lblExtra2.Visible = true;
                    chkExtra1.Visible = true;
                    chkExtra1.Text = "Да";
                    break;

                case "Магистратура":
                    lblExtra1.Text = "Область исследований:";
                    lblExtra2.Text = "Научный сотрудник:";
                    lblExtra1.Visible = true;
                    txtExtra1.Visible = true;
                    lblExtra2.Visible = true;
                    chkExtra1.Visible = true;
                    chkExtra1.Text = "Да";
                    break;
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                IStudent student = CreateStudentFromInput();
                if (student != null)
                {
                    students.Add(student);
                    RefreshStudentsList();
                    ClearInputFields();
                    MessageBox.Show("Студент успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IStudent CreateStudentFromInput()
        {
            string fullName = txtFullName.Text;
            string studentId = txtStudentId.Text;
            string group = txtGroup.Text;

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Все основные поля должны быть заполнены");

            string studentType = cmbStudentType.SelectedItem.ToString();

            switch (studentType)
            {
                case "1 курс (Бакалавриат)":
                    return new FirstYearStudent(fullName, studentId, group);

                case "2-3 курс (Бакалавриат)":
                    string specialization = txtExtra1.Text;
                    int course = int.Parse(txtCourse.Text);
                    if (course < 2 || course > 3)
                        throw new ArgumentException("Курс должен быть 2 или 3");
                    return new MiddleYearStudent(fullName, studentId, course, group, specialization);

                case "4 курс (Выпускник)":
                    string thesisTopic = txtExtra1.Text;
                    bool hasInternship = chkExtra1.Checked;
                    return new FinalYearStudent(fullName, studentId, group, thesisTopic, hasInternship);

                case "Магистратура":
                    string researchArea = txtExtra1.Text;
                    bool isResearcher = chkExtra1.Checked;
                    return new MastersStudent(fullName, studentId, group, researchArea, isResearcher);

                default:
                    throw new ArgumentException("Неизвестный тип студента");
            }
        }

        private void RefreshStudentsList()
        {
            lstStudents.Items.Clear();
            double totalAverage = 0;
            int studentCount = students.Count;

            foreach (var student in students)
            {
                lstStudents.Items.Add(student.GetStudentInfo());
                totalAverage += student.CalculateAverageGrade();
            }

            lblTotalStudents.Text = $"Всего студентов: {studentCount}";
            lblAverageGrade.Text = studentCount > 0 ? $"Средний балл: {totalAverage / studentCount:F2}" : "Средний балл: 0.00";
        }

        private void ClearInputFields()
        {
            txtFullName.Clear();
            txtStudentId.Clear();
            txtGroup.Clear();
            txtCourse.Text = "1";
            txtExtra1.Clear();
            chkExtra1.Checked = false;
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex >= 0 && lstStudents.SelectedIndex < students.Count)
            {
                students.RemoveAt(lstStudents.SelectedIndex);
                RefreshStudentsList();
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex >= 0 && lstStudents.SelectedIndex < students.Count)
            {
                selectedStudent = students[lstStudents.SelectedIndex];
                DisplayStudentDetails(selectedStudent);
            }
        }

        private void DisplayStudentDetails(IStudent student)
        {
            txtDetails.Clear();
            txtDetails.AppendText($"=== ИНФОРМАЦИЯ О СТУДЕНТЕ ===\r\n");
            txtDetails.AppendText($"ФИО: {student.FullName}\r\n");
            txtDetails.AppendText($"ID: {student.StudentId}\r\n");
            txtDetails.AppendText($"{student.GetCourseInfo()}\r\n");
            txtDetails.AppendText($"Средний балл: {student.CalculateAverageGrade():F2}\r\n");
            txtDetails.AppendText($"\r\n=== ОЦЕНКИ ===\r\n");

            if (student.Grades.Count > 0)
            {
                foreach (var subject in student.Grades.Keys)
                {
                    double subjectAverage = 0;
                    foreach (var grade in student.Grades[subject])
                    {
                        subjectAverage += grade;
                    }
                    subjectAverage /= student.Grades[subject].Count;

                    txtDetails.AppendText($"{subject}: ");
                    foreach (var grade in student.Grades[subject])
                    {
                        txtDetails.AppendText($"{grade} ");
                    }
                    txtDetails.AppendText($"(средний: {subjectAverage:F2})\r\n");
                }
            }
            else
            {
                txtDetails.AppendText("Оценки отсутствуют\r\n");
            }
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите студента для добавления оценки", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string subject = txtSubject.Text;
            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show("Введите название предмета", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int grade = int.Parse(txtGrade.Text);
                selectedStudent.AddGrade(subject, grade);
                RefreshStudentsList();
                DisplayStudentDetails(selectedStudent);
                txtSubject.Clear();
                txtGrade.Clear();
                MessageBox.Show("Оценка добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении оценки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                RefreshStudentsList();
                return;
            }

            lstStudents.Items.Clear();
            foreach (var student in students)
            {
                if (student.FullName.ToLower().Contains(searchTerm) ||
                    student.StudentId.ToLower().Contains(searchTerm) ||
                    student.Group.ToLower().Contains(searchTerm))
                {
                    lstStudents.Items.Add(student.GetStudentInfo());
                }
            }
        }

        private void btnShowTopStudents_Click(object sender, EventArgs e)
        {
            var sortedStudents = new List<IStudent>(students);
            sortedStudents.Sort((s1, s2) => s2.CalculateAverageGrade().CompareTo(s1.CalculateAverageGrade()));

            lstStudents.Items.Clear();
            for (int i = 0; i < Math.Min(5, sortedStudents.Count); i++)
            {
                lstStudents.Items.Add($"{i + 1}. {sortedStudents[i].GetStudentInfo()}");
            }
        }

        private void btnShowByCourse_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCourseFilter.Text, out int course) && course >= 1 && course <= 5)
            {
                lstStudents.Items.Clear();
                foreach (var student in students)
                {
                    if (student.Course == course)
                    {
                        lstStudents.Items.Add(student.GetStudentInfo());
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите корректный номер курса (1-5)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}