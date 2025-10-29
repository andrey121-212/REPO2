namespace SimpleTaskManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private ListView listTasks;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnComplete;
        private TextBox txtSearch;
        private ComboBox cmbFilter;
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
            this.Text = "Менеджер задач";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Панель поиска и фильтрации
            var searchPanel = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.LightGray };

            var lblSearch = new Label { Text = "Поиск:", Location = new Point(10, 10), Size = new Size(40, 20) };
            txtSearch = new TextBox { Location = new Point(55, 10), Size = new Size(150, 20) };
            txtSearch.TextChanged += txtSearch_TextChanged;

            var lblFilter = new Label { Text = "Фильтр:", Location = new Point(220, 10), Size = new Size(40, 20) };
            cmbFilter = new ComboBox { Location = new Point(265, 10), Size = new Size(120, 20) };
            cmbFilter.Items.AddRange(new string[] { "Все задачи", "Активные", "Завершенные", "Просроченные" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            searchPanel.Controls.AddRange(new Control[] { lblSearch, txtSearch, lblFilter, cmbFilter });
            this.Controls.Add(searchPanel);

            // Панель кнопок
            var buttonPanel = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White };

            btnAdd = new Button { Text = "Добавить", Location = new Point(10, 10), Size = new Size(80, 30) };
            btnEdit = new Button { Text = "Изменить", Location = new Point(100, 10), Size = new Size(80, 30) };
            btnDelete = new Button { Text = "Удалить", Location = new Point(190, 10), Size = new Size(80, 30) };
            btnComplete = new Button { Text = "Выполнено", Location = new Point(280, 10), Size = new Size(80, 30) };

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnComplete.Click += btnComplete_Click;

            buttonPanel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnComplete });
            this.Controls.Add(buttonPanel);

            // Список задач
            listTasks = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            listTasks.Columns.Add("Задача", 200);
            listTasks.Columns.Add("Приоритет", 100);
            listTasks.Columns.Add("Срок", 100);
            listTasks.Columns.Add("Выполнена", 80);

            listTasks.DoubleClick += listTasks_DoubleClick;
            this.Controls.Add(listTasks);

            // Статистика
            lblStats = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightBlue,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblStats);
        }
    }
}