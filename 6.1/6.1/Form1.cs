using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        private DataTable booksTable;
        private DataTable rentedBooksTable;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // Инициализация таблицы книг
            booksTable = new DataTable("Books");
            booksTable.Columns.Add("Id", typeof(int));
            booksTable.Columns.Add("Title", typeof(string));
            booksTable.Columns.Add("Author", typeof(string));
            booksTable.Columns.Add("Year", typeof(int));
            booksTable.Columns.Add("Genre", typeof(string));
            booksTable.Columns.Add("IsAvailable", typeof(bool));

            // Инициализация таблицы арендованных книг
            rentedBooksTable = new DataTable("RentedBooks");
            rentedBooksTable.Columns.Add("Id", typeof(int));
            rentedBooksTable.Columns.Add("BookId", typeof(int));
            rentedBooksTable.Columns.Add("BookTitle", typeof(string));
            rentedBooksTable.Columns.Add("RenterName", typeof(string));
            rentedBooksTable.Columns.Add("RentDate", typeof(DateTime));

            // Добавляем тестовые данные
            AddSampleData();
        }

        private void AddSampleData()
        {
            booksTable.Rows.Add(1, "Война и мир", "Лев Толстой", 1869, "Роман", true);
            booksTable.Rows.Add(2, "Преступление и наказание", "Федор Достоевский", 1866, "Роман", true);
            booksTable.Rows.Add(3, "Мастер и Маргарита", "Михаил Булгаков", 1967, "Роман", true);
            booksTable.Rows.Add(4, "1984", "Джордж Оруэлл", 1949, "Антиутопия", true);
            booksTable.Rows.Add(5, "Гарри Поттер и философский камень", "Джоан Роулинг", 1997, "Фэнтези", true);
            booksTable.Rows.Add(6, "Улисс", "Джеймс Джойс", 1922, "Модернизм", true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshBooksGrid();
            RefreshRentedBooksGrid();
            RefreshBooksComboBox();
        }

        private void RefreshBooksGrid()
        {
            dataGridViewBooks.DataSource = booksTable;
            dataGridViewBooks.Columns["Id"].Visible = false;
            dataGridViewBooks.Columns["IsAvailable"].Visible = false;
        }

        private void RefreshRentedBooksGrid()
        {
            dataGridViewRented.DataSource = rentedBooksTable;
            dataGridViewRented.Columns["Id"].Visible = false;
            dataGridViewRented.Columns["BookId"].Visible = false;
        }

        private void RefreshBooksComboBox()
        {
            cmbBooksToRent.DataSource = booksTable.Copy();
            cmbBooksToRent.DisplayMember = "Title";
            cmbBooksToRent.ValueMember = "Id";

            // Фильтруем только доступные книги
            var availableBooks = booksTable.AsEnumerable()
                .Where(row => row.Field<bool>("IsAvailable"))
                .CopyToDataTable();

            cmbBooksToRent.DataSource = availableBooks;
            cmbBooksToRent.DisplayMember = "Title";
            cmbBooksToRent.ValueMember = "Id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dataGridViewBooks.DataSource = booksTable;
                return;
            }

            var filteredRows = booksTable.AsEnumerable()
                .Where(row => row.Field<string>("Title").ToLower().Contains(searchText) ||
                             row.Field<string>("Author").ToLower().Contains(searchText) ||
                             row.Field<string>("Genre").ToLower().Contains(searchText))
                .CopyToDataTable();

            dataGridViewBooks.DataSource = filteredRows;
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (cmbBooksToRent.SelectedValue == null || string.IsNullOrWhiteSpace(txtRenterName.Text))
            {
                MessageBox.Show("Пожалуйста, выберите книгу и введите ваше имя.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = (int)cmbBooksToRent.SelectedValue;
            DataRow bookRow = booksTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id") == bookId);

            if (bookRow != null && bookRow.Field<bool>("IsAvailable"))
            {
                // Помечаем книгу как недоступную
                bookRow["IsAvailable"] = false;

                // Добавляем запись в таблицу арендованных книг
                int newRentId = rentedBooksTable.Rows.Count > 0 ?
                    rentedBooksTable.AsEnumerable().Max(row => row.Field<int>("Id")) + 1 : 1;

                rentedBooksTable.Rows.Add(newRentId, bookId, bookRow["Title"],
                    txtRenterName.Text, DateTime.Now);

                RefreshBooksGrid();
                RefreshRentedBooksGrid();
                RefreshBooksComboBox();

                MessageBox.Show($"Книга '{bookRow["Title"]}' успешно арендована!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRenterName.Clear();
            }
            else
            {
                MessageBox.Show("Эта книга уже арендована.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewRented.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для возврата.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewRented.SelectedRows[0];
            int bookId = (int)selectedRow.Cells["BookId"].Value;

            // Находим книгу в основной таблице и помечаем как доступную
            DataRow bookRow = booksTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id") == bookId);
            if (bookRow != null)
            {
                bookRow["IsAvailable"] = true;
            }

            // Удаляем запись из таблицы арендованных книг
            int rentId = (int)selectedRow.Cells["Id"].Value;
            DataRow rentRow = rentedBooksTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id") == rentId);
            if (rentRow != null)
            {
                rentedBooksTable.Rows.Remove(rentRow);
            }

            RefreshBooksGrid();
            RefreshRentedBooksGrid();
            RefreshBooksComboBox();

            MessageBox.Show("Книга успешно возвращена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}