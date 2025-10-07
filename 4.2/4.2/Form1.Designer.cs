namespace StudentManagementSystem
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
            this.cmbStudentType = new System.Windows.Forms.ComboBox();
            this.lblStudentType = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lblExtra1 = new System.Windows.Forms.Label();
            this.txtExtra1 = new System.Windows.Forms.TextBox();
            this.lblExtra2 = new System.Windows.Forms.Label();
            this.chkExtra1 = new System.Windows.Forms.CheckBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.btnAddGrade = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowTopStudents = new System.Windows.Forms.Button();
            this.lblAverageGrade = new System.Windows.Forms.Label();
            this.lblCourseFilter = new System.Windows.Forms.Label();
            this.txtCourseFilter = new System.Windows.Forms.TextBox();
            this.btnShowByCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbStudentType
            // 
            this.cmbStudentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudentType.FormattingEnabled = true;
            this.cmbStudentType.Location = new System.Drawing.Point(150, 20);
            this.cmbStudentType.Name = "cmbStudentType";
            this.cmbStudentType.Size = new System.Drawing.Size(250, 28);
            this.cmbStudentType.TabIndex = 0;
            this.cmbStudentType.SelectedIndexChanged += new System.EventHandler(this.cmbStudentType_SelectedIndexChanged);
            // 
            // lblStudentType
            // 
            this.lblStudentType.AutoSize = true;
            this.lblStudentType.Location = new System.Drawing.Point(20, 23);
            this.lblStudentType.Name = "lblStudentType";
            this.lblStudentType.Size = new System.Drawing.Size(100, 20);
            this.lblStudentType.TabIndex = 1;
            this.lblStudentType.Text = "Тип студента:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 60);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(46, 20);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "ФИО:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(150, 57);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(250, 27);
            this.txtFullName.TabIndex = 3;
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(20, 95);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(96, 20);
            this.lblStudentId.TabIndex = 4;
            this.lblStudentId.Text = "ID студента:";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(150, 92);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(250, 27);
            this.txtStudentId.TabIndex = 5;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(20, 130);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(49, 20);
            this.lblCourse.TabIndex = 6;
            this.lblCourse.Text = "Курс:";
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(150, 127);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(250, 27);
            this.txtCourse.TabIndex = 7;
            this.txtCourse.Text = "1";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(20, 165);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(64, 20);
            this.lblGroup.TabIndex = 8;
            this.lblGroup.Text = "Группа:";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(150, 162);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(250, 27);
            this.txtGroup.TabIndex = 9;
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
            // chkExtra1
            // 
            this.chkExtra1.AutoSize = true;
            this.chkExtra1.Location = new System.Drawing.Point(150, 237);
            this.chkExtra1.Name = "chkExtra1";
            this.chkExtra1.Size = new System.Drawing.Size(18, 17);
            this.chkExtra1.TabIndex = 13;
            this.chkExtra1.UseVisualStyleBackColor = true;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(20, 280);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(180, 40);
            this.btnAddStudent.TabIndex = 14;
            this.btnAddStudent.Text = "Добавить студента";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // lstStudents
            // 
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.ItemHeight = 20;
            this.lstStudents.Location = new System.Drawing.Point(420, 50);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(600, 204);
            this.lstStudents.TabIndex = 15;
            this.lstStudents.SelectedIndexChanged += new System.EventHandler(this.lstStudents_SelectedIndexChanged);
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Location = new System.Drawing.Point(420, 20);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(120, 20);
            this.lblTotalStudents.TabIndex = 16;
            this.lblTotalStudents.Text = "Всего студентов:";
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.Location = new System.Drawing.Point(220, 280);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(180, 40);
            this.btnRemoveStudent.TabIndex = 17;
            this.btnRemoveStudent.Text = "Удалить студента";
            this.btnRemoveStudent.UseVisualStyleBackColor = true;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(420, 300);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(600, 200);
            this.txtDetails.TabIndex = 18;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(420, 277);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(162, 20);
            this.lblDetails.TabIndex = 19;
            this.lblDetails.Text = "Детальная информация:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(20, 340);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(79, 20);
            this.lblSubject.TabIndex = 20;
            this.lblSubject.Text = "Предмет:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(150, 337);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(250, 27);
            this.txtSubject.TabIndex = 21;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(20, 375);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(64, 20);
            this.lblGrade.TabIndex = 22;
            this.lblGrade.Text = "Оценка:";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(150, 372);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(250, 27);
            this.txtGrade.TabIndex = 23;
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.Location = new System.Drawing.Point(20, 410);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(180, 40);
            this.btnAddGrade.TabIndex = 24;
            this.btnAddGrade.Text = "Добавить оценку";
            this.btnAddGrade.UseVisualStyleBackColor = true;
            this.btnAddGrade.Click += new System.EventHandler(this.btnAddGrade_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(420, 520);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 25;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(420, 497);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(106, 20);
            this.lblSearch.TabIndex = 26;
            this.lblSearch.Text = "Поиск студента:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(630, 520);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 27);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowTopStudents
            // 
            this.btnShowTopStudents.Location = new System.Drawing.Point(750, 520);
            this.btnShowTopStudents.Name = "btnShowTopStudents";
            this.btnShowTopStudents.Size = new System.Drawing.Size(130, 27);
            this.btnShowTopStudents.TabIndex = 28;
            this.btnShowTopStudents.Text = "Топ студентов";
            this.btnShowTopStudents.UseVisualStyleBackColor = true;
            this.btnShowTopStudents.Click += new System.EventHandler(this.btnShowTopStudents_Click);
            // 
            // lblAverageGrade
            // 
            this.lblAverageGrade.AutoSize = true;
            this.lblAverageGrade.Location = new System.Drawing.Point(600, 20);
            this.lblAverageGrade.Name = "lblAverageGrade";
            this.lblAverageGrade.Size = new System.Drawing.Size(120, 20);
            this.lblAverageGrade.TabIndex = 29;
            this.lblAverageGrade.Text = "Средний балл: 0";
            // 
            // lblCourseFilter
            // 
            this.lblCourseFilter.AutoSize = true;
            this.lblCourseFilter.Location = new System.Drawing.Point(220, 340);
            this.lblCourseFilter.Name = "lblCourseFilter";
            this.lblCourseFilter.Size = new System.Drawing.Size(49, 20);
            this.lblCourseFilter.TabIndex = 30;
            this.lblCourseFilter.Text = "Курс:";
            // 
            // txtCourseFilter
            // 
            this.txtCourseFilter.Location = new System.Drawing.Point(220, 372);
            this.txtCourseFilter.Name = "txtCourseFilter";
            this.txtCourseFilter.Size = new System.Drawing.Size(80, 27);
            this.txtCourseFilter.TabIndex = 31;
            // 
            // btnShowByCourse
            // 
            this.btnShowByCourse.Location = new System.Drawing.Point(220, 410);
            this.btnShowByCourse.Name = "btnShowByCourse";
            this.btnShowByCourse.Size = new System.Drawing.Size(180, 40);
            this.btnShowByCourse.TabIndex = 32;
            this.btnShowByCourse.Text = "Показать по курсу";
            this.btnShowByCourse.UseVisualStyleBackColor = true;
            this.btnShowByCourse.Click += new System.EventHandler(this.btnShowByCourse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 563);
            this.Controls.Add(this.btnShowByCourse);
            this.Controls.Add(this.txtCourseFilter);
            this.Controls.Add(this.lblCourseFilter);
            this.Controls.Add(this.lblAverageGrade);
            this.Controls.Add(this.btnShowTopStudents);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddGrade);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.btnRemoveStudent);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.chkExtra1);
            this.Controls.Add(this.lblExtra2);
            this.Controls.Add(this.txtExtra1);
            this.Controls.Add(this.lblExtra1);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblStudentType);
            this.Controls.Add(this.cmbStudentType);
            this.Name = "Form1";
            this.Text = "Система учета студентов университета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStudentType;
        private System.Windows.Forms.Label lblStudentType;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label lblExtra1;
        private System.Windows.Forms.TextBox txtExtra1;
        private System.Windows.Forms.Label lblExtra2;
        private System.Windows.Forms.CheckBox chkExtra1;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.ListBox lstStudents;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Button btnRemoveStudent;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Button btnAddGrade;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowTopStudents;
        private System.Windows.Forms.Label lblAverageGrade;
        private System.Windows.Forms.Label lblCourseFilter;
        private System.Windows.Forms.TextBox txtCourseFilter;
        private System.Windows.Forms.Button btnShowByCourse;
    }
}