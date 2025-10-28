namespace StudentManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private Button btnExport;
        private Button btnImport;

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
            this.dataGridView = new DataGridView();
            this.txtSearch = new TextBox();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnSearch = new Button();
            this.btnExport = new Button();
            this.btnImport = new Button();

            // Main Form
            this.Text = "Управление списком студентов";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Search Panel
            txtSearch.Location = new Point(12, 12);
            txtSearch.Size = new Size(200, 20);
            this.Controls.Add(txtSearch);

            btnSearch.Text = "Поиск";
            btnSearch.Location = new Point(220, 10);
            btnSearch.Size = new Size(75, 25);
            btnSearch.Click += btnSearch_Click;
            this.Controls.Add(btnSearch);

            // Buttons Panel
            btnAdd.Text = "Добавить";
            btnAdd.Location = new Point(320, 10);
            btnAdd.Size = new Size(75, 25);
            btnAdd.Click += btnAdd_Click;
            this.Controls.Add(btnAdd);

            btnEdit.Text = "Изменить";
            btnEdit.Location = new Point(405, 10);
            btnEdit.Size = new Size(75, 25);
            btnEdit.Click += btnEdit_Click;
            this.Controls.Add(btnEdit);

            btnDelete.Text = "Удалить";
            btnDelete.Location = new Point(490, 10);
            btnDelete.Size = new Size(75, 25);
            btnDelete.Click += btnDelete_Click;
            this.Controls.Add(btnDelete);

            btnExport.Text = "Экспорт";
            btnExport.Location = new Point(575, 10);
            btnExport.Size = new Size(75, 25);
            btnExport.Click += btnExport_Click;
            this.Controls.Add(btnExport);

            btnImport.Text = "Импорт";
            btnImport.Location = new Point(660, 10);
            btnImport.Size = new Size(75, 25);
            btnImport.Click += btnImport_Click;
            this.Controls.Add(btnImport);

            // DataGridView
            dataGridView.Location = new Point(12, 45);
            dataGridView.Size = new Size(760, 400);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            this.Controls.Add(dataGridView);
        }
    }
}