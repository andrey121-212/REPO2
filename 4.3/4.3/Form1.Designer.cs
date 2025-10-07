namespace LibraryManagementSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbBookType = new System.Windows.Forms.ComboBox();
            this.lblBookType = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblExtra1 = new System.Windows.Forms.Label();
            this.txtExtra1 = new System.Windows.Forms.TextBox();
            this.lblExtra2 = new System.Windows.Forms.Label();
            this.txtExtra2 = new System.Windows.Forms.TextBox();
            this.lblExtra3 = new System.Windows.Forms.Label();
            this.txtExtra3 = new System.Windows.Forms.TextBox();
            this.chkExtra1 = new System.Windows.Forms.CheckBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.btnRemoveBook = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.txtBorrower = new System.Windows.Forms.TextBox();
            this.lblBorrowDays = new System.Windows.Forms.Label();
            this.txtBorrowDays = new System.Windows.Forms.TextBox();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAvailable = new System.Windows.Forms.Button();
            this.btnShowBorrowed = new System.Windows.Forms.Button();
            this.lblAvailableBooks = new System.Windows.Forms.Label();
            this.lblBorrowedBooks = new System.Windows.Forms.Label();
            this.btnShowOverdue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBookType
            // 
            this.cmbBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookType.FormattingEnabled = true;
            this.cmbBookType.Location = new System.Drawing.Point(150, 20);
            this.cmbBookType.Name = "cmbBookType";
            this.cmbBookType.Size = new System.Drawing.Size(250, 28);
            this.cmbBookType.TabIndex = 0;
            this.cmbBookType.SelectedIndexChanged += new System.EventHandler(this.cmbBookType_SelectedIndexChanged);
            // 
            // lblBookType
            // 
            this.lblBookType.AutoSize = true;
            this.lblBookType.Location = new System.Drawing.Point(20, 23);
            this.lblBookType.Name = "lblBookType";
            this.lblBookType.Size = new System.Drawing.Size(78, 20);
            this.lblBookType.TabIndex = 1;
            this.lblBookType.Text = "Тип книги:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Название:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 57);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 27);
            this.txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 95);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(54, 20);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Автор:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(150, 92);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(250, 27);
            this.txtAuthor.TabIndex = 5;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(20, 130);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(45, 20);
            this.lblISBN.TabIndex = 6;
            this.lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(150, 127);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(250, 27);
            this.txtISBN.TabIndex = 7;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 165);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(76, 20);
            this.lblYear.TabIndex = 8;
            this.lblYear.Text = "Год издания:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(150, 162);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(250, 27);
            this.txtYear.TabIndex = 9;
            this.txtYear.Text = "2023";
            // 
            // lblExtra1
            // 
            this.lblExtra1.AutoSize = true;
            this.lblExtra1.Location = new System.Drawing.Point(20, 200);
            this.lblExtra1.Name = "lblExtra1";
            this.lblExtra1.Size = new System.Drawing.Size(85, 20);
            this.lblExtra1.TabIndex = 10;
            this.lblExtra1.Text = "Доп. инфо:";
            // 
            // txtExtra1
            // 
            this.txtExtra1.Location = new System.Drawing.Point(150, 197);
            this.txtExtra1.Name = "txtExtra1";
            this.txtExtra1.Size = new System.Drawing.Size(250, 27);
            this.txtExtra1.TabIndex = 11;
            // 
            // lblExtra2
            // 
            this.lblExtra2.AutoSize = true;
            this.lblExtra2.Location = new System.Drawing.Point(20, 235);
            this.lblExtra2.Name = "lblExtra2";
            this.lblExtra2.Size = new System.Drawing.Size(85, 20);
            this.lblExtra2.TabIndex = 12;
            this.lblExtra2.Text = "Доп. инфо:";
            // 
            // txtExtra2
            // 
            this.txtExtra2.Location = new System.Drawing.Point(150, 232);
            this.txtExtra2.Name = "txtExtra2";
            this.txtExtra2.Size = new System.Drawing.Size(250, 27);
            this.txtExtra2.TabIndex = 13;
            // 
            // lblExtra3
            // 
            this.lblExtra3.AutoSize = true;
            this.lblExtra3.Location = new System.Drawing.Point(20, 270);
            this.lblExtra3.Name = "lblExtra3";
            this.lblExtra3.Size = new System.Drawing.Size(85, 20);
            this.lblExtra3.TabIndex = 14;
            this.lblExtra3.Text = "Доп. инфо:";
            // 
            // txtExtra3
            // 
            this.txtExtra3.Location = new System.Drawing.Point(150, 267);
            this.txtExtra3.Name = "txtExtra3";
            this.txtExtra3.Size = new System.Drawing.Size(250, 27);
            this.txtExtra3.TabIndex = 15;
            // 
            // chkExtra1
            // 
            this.chkExtra1.AutoSize = true;
            this.chkExtra1.Location = new System.Drawing.Point(150, 300);
            this.chkExtra1.Name = "chkExtra1";
            this.chkExtra1.Size = new System.Drawing.Size(18, 17);
            this.chkExtra1.TabIndex = 16;
            this.chkExtra1.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(20, 330);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(180, 40);
            this.btnAddBook.TabIndex = 17;
            this.btnAddBook.Text = "Добавить книгу";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 20;
            this.lstBooks.Location = new System.Drawing.Point(420, 50);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(600, 204);
            this.lstBooks.TabIndex = 18;
            this.lstBooks.SelectedIndexChanged += new System.EventHandler(this.lstBooks_SelectedIndexChanged);
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Location = new System.Drawing.Point(420, 20);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(95, 20);
            this.lblTotalBooks.TabIndex = 19;
            this.lblTotalBooks.Text = "Всего книг: 0";
            // 
            // btnRemoveBook
            // 
            this.btnRemoveBook.Location = new System.Drawing.Point(220, 330);
            this.btnRemoveBook.Name = "btnRemoveBook";
            this.btnRemoveBook.Size = new System.Drawing.Size(180, 40);
            this.btnRemoveBook.TabIndex = 20;
            this.btnRemoveBook.Text = "Удалить книгу";
            this.btnRemoveBook.UseVisualStyleBackColor = true;
            this.btnRemoveBook.Click += new System.EventHandler(this.btnRemoveBook_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(420, 300);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(600, 150);
            this.txtDetails.TabIndex = 21;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(420, 277);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(162, 20);
            this.lblDetails.TabIndex = 22;
            this.lblDetails.Text = "Детальная информация:";
            // 
            // lblBorrower
            // 
            this.lblBorrower.AutoSize = true;
            this.lblBorrower.Location = new System.Drawing.Point(20, 390);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Size = new System.Drawing.Size(78, 20);
            this.lblBorrower.TabIndex = 23;
            this.lblBorrower.Text = "Читатель:";
            // 
            // txtBorrower
            // 
            this.txtBorrower.Location = new System.Drawing.Point(150, 387);
            this.txtBorrower.Name = "txtBorrower";
            this.txtBorrower.Size = new System.Drawing.Size(250, 27);
            this.txtBorrower.TabIndex = 24;
            // 
            // lblBorrowDays
            // 
            this.lblBorrowDays.AutoSize = true;
            this.lblBorrowDays.Location = new System.Drawing.Point(20, 425);
            this.lblBorrowDays.Name = "lblBorrowDays";
            this.lblBorrowDays.Size = new System.Drawing.Size(124, 20);
            this.lblBorrowDays.TabIndex = 25;
            this.lblBorrowDays.Text = "Количество дней:";
            // 
            // txtBorrowDays
            // 
            this.txtBorrowDays.Location = new System.Drawing.Point(150, 422);
            this.txtBorrowDays.Name = "txtBorrowDays";
            this.txtBorrowDays.Size = new System.Drawing.Size(250, 27);
            this.txtBorrowDays.TabIndex = 26;
            this.txtBorrowDays.Text = "14";
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Location = new System.Drawing.Point(20, 460);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(180, 40);
            this.btnBorrowBook.TabIndex = 27;
            this.btnBorrowBook.Text = "Выдать книгу";
            this.btnBorrowBook.UseVisualStyleBackColor = true;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(220, 460);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(180, 40);
            this.btnReturnBook.TabIndex = 28;
            this.btnReturnBook.Text = "Вернуть книгу";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(420, 470);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 29;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(420, 447);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(85, 20);
            this.lblSearch.TabIndex = 30;
            this.lblSearch.Text = "Поиск книги:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(630, 470);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 27);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAvailable
            // 
            this.btnShowAvailable.Location = new System.Drawing.Point(750, 470);
            this.btnShowAvailable.Name = "btnShowAvailable";
            this.btnShowAvailable.Size = new System.Drawing.Size(130, 27);
            this.btnShowAvailable.TabIndex = 32;
            this.btnShowAvailable.Text = "Доступные";
            this.btnShowAvailable.UseVisualStyleBackColor = true;
            this.btnShowAvailable.Click += new System.EventHandler(this.btnShowAvailable_Click);
            // 
            // btnShowBorrowed
            // 
            this.btnShowBorrowed.Location = new System.Drawing.Point(890, 470);
            this.btnShowBorrowed.Name = "btnShowBorrowed";
            this.btnShowBorrowed.Size = new System.Drawing.Size(130, 27);
            this.btnShowBorrowed.TabIndex = 33;
            this.btnShowBorrowed.Text = "Выданные";
            this.btnShowBorrowed.UseVisualStyleBackColor = true;
            this.btnShowBorrowed.Click += new System.EventHandler(this.btnShowBorrowed_Click);
            // 
            // lblAvailableBooks
            // 
            this.lblAvailableBooks.AutoSize = true;
            this.lblAvailableBooks.Location = new System.Drawing.Point(550, 20);
            this.lblAvailableBooks.Name = "lblAvailableBooks";
            this.lblAvailableBooks.Size = new System.Drawing.Size(80, 20);
            this.lblAvailableBooks.TabIndex = 34;
            this.lblAvailableBooks.Text = "Доступно: 0";
            // 
            // lblBorrowedBooks
            // 
            this.lblBorrowedBooks.AutoSize = true;
            this.lblBorrowedBooks.Location = new System.Drawing.Point(680, 20);
            this.lblBorrowedBooks.Name = "lblBorrowedBooks";
            this.lblBorrowedBooks.Size = new System.Drawing.Size(73, 20);
            this.lblBorrowedBooks.TabIndex = 35;
            this.lblBorrowedBooks.Text = "Выдано: 0";
            // 
            // btnShowOverdue
            // 
            this.btnShowOverdue.Location = new System.Drawing.Point(750, 500);
            this.btnShowOverdue.Name = "btnShowOverdue";
            this.btnShowOverdue.Size = new System.Drawing.Size(270, 27);
            this.btnShowOverdue.TabIndex = 36;
            this.btnShowOverdue.Text = "Показать просроченные";
            this.btnShowOverdue.UseVisualStyleBackColor = true;
            this.btnShowOverdue.Click += new System.EventHandler(this.btnShowOverdue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 543);
            this.Controls.Add(this.btnShowOverdue);
            this.Controls.Add(this.lblBorrowedBooks);
            this.Controls.Add(this.lblAvailableBooks);
            this.Controls.Add(this.btnShowBorrowed);
            this.Controls.Add(this.btnShowAvailable);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnBorrowBook);
            this.Controls.Add(this.txtBorrowDays);
            this.Controls.Add(this.lblBorrowDays);
            this.Controls.Add(this.txtBorrower);
            this.Controls.Add(this.lblBorrower);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.btnRemoveBook);
            this.Controls.Add(this.lblTotalBooks);
            this.Controls.Add(this.lstBooks);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.chkExtra1);
            this.Controls.Add(this.txtExtra3);
            this.Controls.Add(this.lblExtra3);
            this.Controls.Add(this.txtExtra2);
            this.Controls.Add(this.lblExtra2);
            this.Controls.Add(this.txtExtra1);
            this.Controls.Add(this.lblExtra1);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBookType);
            this.Controls.Add(this.cmbBookType);
            this.Name = "Form1";
            this.Text = "Система управления библиотекой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBookType;
        private System.Windows.Forms.Label lblBookType;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblExtra1;
        private System.Windows.Forms.TextBox txtExtra1;
        private System.Windows.Forms.Label lblExtra2;
        private System.Windows.Forms.TextBox txtExtra2;
        private System.Windows.Forms.Label lblExtra3;
        private System.Windows.Forms.TextBox txtExtra3;
        private System.Windows.Forms.CheckBox chkExtra1;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Button btnRemoveBook;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.TextBox txtBorrower;
        private System.Windows.Forms.Label lblBorrowDays;
        private System.Windows.Forms.TextBox txtBorrowDays;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAvailable;
        private System.Windows.Forms.Button btnShowBorrowed;
        private System.Windows.Forms.Label lblAvailableBooks;
        private System.Windows.Forms.Label lblBorrowedBooks;
        private System.Windows.Forms.Button btnShowOverdue;
    }
}