using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string currentFilePath;
        private bool isModified;
        private Font currentFont;
        private Color currentColor;

        // Диалоги поиска и замены
        private Form findDialog;
        private Form replaceDialog;

        public Form1()
        {
            InitializeComponent();
            InitializeEditor();
            CreateFindDialog();
            CreateReplaceDialog();
        }

        private void InitializeEditor()
        {
            currentFilePath = null;
            isModified = false;
            currentFont = new Font("Consolas", 10);
            currentColor = Color.Black;

            txtEditor.Font = currentFont;
            txtEditor.ForeColor = currentColor;

            UpdateTitle();
            UpdateStatusBar();
        }

        #region Диалог поиска
        private void CreateFindDialog()
        {
            findDialog = new Form();
            findDialog.Text = "Поиск";
            findDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            findDialog.MaximizeBox = false;
            findDialog.MinimizeBox = false;
            findDialog.StartPosition = FormStartPosition.CenterParent;
            findDialog.ClientSize = new Size(335, 140);
            findDialog.ShowInTaskbar = false;

            // Создаем элементы управления
            Label lblFind = new Label() { Text = "Искать текст:", Location = new Point(12, 15), AutoSize = true };
            TextBox txtSearch = new TextBox() { Location = new Point(123, 12), Size = new Size(200, 27), Name = "txtSearch" };
            CheckBox chkMatchCase = new CheckBox() { Text = "С учетом регистра", Location = new Point(16, 45), AutoSize = true, Name = "chkMatchCase" };
            RadioButton rdoUp = new RadioButton() { Text = "Вверх", Location = new Point(16, 75), AutoSize = true, Name = "rdoUp" };
            RadioButton rdoDown = new RadioButton() { Text = "Вниз", Location = new Point(96, 75), AutoSize = true, Checked = true, Name = "rdoDown" };
            Button btnFind = new Button() { Text = "Найти", Location = new Point(167, 75), Size = new Size(75, 30), Name = "btnFind" };
            Button btnCancel = new Button() { Text = "Отмена", Location = new Point(248, 75), Size = new Size(75, 30), Name = "btnCancel" };

            // Добавляем обработчики событий
            btnFind.Click += BtnFind_Click;
            btnCancel.Click += BtnFindCancel_Click;
            findDialog.AcceptButton = btnFind;
            findDialog.CancelButton = btnCancel;

            // Добавляем элементы на форму
            findDialog.Controls.AddRange(new Control[] { lblFind, txtSearch, chkMatchCase, rdoUp, rdoDown, btnFind, btnCancel });
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = (TextBox)findDialog.Controls["txtSearch"];
            CheckBox chkMatchCase = (CheckBox)findDialog.Controls["chkMatchCase"];
            RadioButton rdoDown = (RadioButton)findDialog.Controls["rdoDown"];

            string searchText = txtSearch.Text;
            bool matchCase = chkMatchCase.Checked;
            bool searchDown = rdoDown.Checked;

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FindText(searchText, matchCase, searchDown);
            findDialog.Hide();
        }

        private void BtnFindCancel_Click(object sender, EventArgs e)
        {
            findDialog.Hide();
        }
        #endregion

        #region Диалог замены
        private void CreateReplaceDialog()
        {
            replaceDialog = new Form();
            replaceDialog.Text = "Замена";
            replaceDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            replaceDialog.MaximizeBox = false;
            replaceDialog.MinimizeBox = false;
            replaceDialog.StartPosition = FormStartPosition.CenterParent;
            replaceDialog.ClientSize = new Size(335, 150);
            replaceDialog.ShowInTaskbar = false;

            // Создаем элементы управления
            Label lblFind = new Label() { Text = "Искать текст:", Location = new Point(12, 15), AutoSize = true };
            TextBox txtSearch = new TextBox() { Location = new Point(123, 12), Size = new Size(200, 27), Name = "txtSearch" };
            Label lblReplace = new Label() { Text = "Заменить на:", Location = new Point(12, 48), AutoSize = true };
            TextBox txtReplace = new TextBox() { Location = new Point(123, 45), Size = new Size(200, 27), Name = "txtReplace" };
            CheckBox chkMatchCase = new CheckBox() { Text = "С учетом регистра", Location = new Point(16, 78), AutoSize = true, Name = "chkMatchCase" };
            Button btnReplace = new Button() { Text = "Заменить", Location = new Point(87, 108), Size = new Size(75, 30), Name = "btnReplace" };
            Button btnReplaceAll = new Button() { Text = "Заменить все", Location = new Point(168, 108), Size = new Size(95, 30), Name = "btnReplaceAll" };
            Button btnCancel = new Button() { Text = "Отмена", Location = new Point(269, 108), Size = new Size(75, 30), Name = "btnCancel" };

            // Добавляем обработчики событий
            btnReplace.Click += BtnReplace_Click;
            btnReplaceAll.Click += BtnReplaceAll_Click;
            btnCancel.Click += BtnReplaceCancel_Click;
            replaceDialog.AcceptButton = btnReplace;
            replaceDialog.CancelButton = btnCancel;

            // Добавляем элементы на форму
            replaceDialog.Controls.AddRange(new Control[] {
                lblFind, txtSearch, lblReplace, txtReplace,
                chkMatchCase, btnReplace, btnReplaceAll, btnCancel
            });
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = (TextBox)replaceDialog.Controls["txtSearch"];
            TextBox txtReplace = (TextBox)replaceDialog.Controls["txtReplace"];
            CheckBox chkMatchCase = (CheckBox)replaceDialog.Controls["chkMatchCase"];

            string searchText = txtSearch.Text;
            string replaceText = txtReplace.Text;
            bool matchCase = chkMatchCase.Checked;

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Замена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReplaceText(searchText, replaceText, matchCase);
        }

        private void BtnReplaceAll_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = (TextBox)replaceDialog.Controls["txtSearch"];
            TextBox txtReplace = (TextBox)replaceDialog.Controls["txtReplace"];
            CheckBox chkMatchCase = (CheckBox)replaceDialog.Controls["chkMatchCase"];

            string searchText = txtSearch.Text;
            string replaceText = txtReplace.Text;
            bool matchCase = chkMatchCase.Checked;

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Замена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReplaceAllText(searchText, replaceText, matchCase);
        }

        private void BtnReplaceCancel_Click(object sender, EventArgs e)
        {
            replaceDialog.Hide();
        }
        #endregion

        #region Функции поиска и замены
        private void FindText(string searchText, bool matchCase, bool searchDown)
        {
            int start = txtEditor.SelectionStart;
            if (!searchDown && start > 0) start--;

            StringComparison comparison = matchCase ?
                StringComparison.CurrentCulture :
                StringComparison.CurrentCultureIgnoreCase;

            string content = txtEditor.Text;
            int index = -1;

            if (searchDown)
            {
                index = content.IndexOf(searchText, start, comparison);
            }
            else
            {
                if (start >= 0)
                {
                    index = content.LastIndexOf(searchText, Math.Min(start, content.Length - 1), comparison);
                }
            }

            if (index >= 0)
            {
                txtEditor.Select(index, searchText.Length);
                txtEditor.ScrollToCaret();
                txtEditor.Focus();
            }
            else
            {
                MessageBox.Show($"Текст '{searchText}' не найден.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReplaceText(string searchText, string replaceText, bool matchCase)
        {
            StringComparison comparison = matchCase ?
                StringComparison.CurrentCulture :
                StringComparison.CurrentCultureIgnoreCase;

            string content = txtEditor.Text;
            int index = content.IndexOf(searchText, txtEditor.SelectionStart, comparison);

            if (index >= 0)
            {
                txtEditor.Select(index, searchText.Length);
                txtEditor.SelectedText = replaceText;
                txtEditor.Select(index, replaceText.Length);
                txtEditor.ScrollToCaret();
                txtEditor.Focus();
            }
            else
            {
                MessageBox.Show($"Текст '{searchText}' не найден.", "Замена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReplaceAllText(string searchText, string replaceText, bool matchCase)
        {
            StringComparison comparison = matchCase ?
                StringComparison.CurrentCulture :
                StringComparison.CurrentCultureIgnoreCase;

            string content = txtEditor.Text;
            int count = 0;
            int index = 0;

            while ((index = content.IndexOf(searchText, index, comparison)) >= 0)
            {
                txtEditor.Select(index, searchText.Length);
                txtEditor.SelectedText = replaceText;
                content = txtEditor.Text;
                index += replaceText.Length;
                count++;
            }

            MessageBox.Show($"Заменено {count} вхождений.", "Замена", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowFindDialog()
        {
            TextBox txtSearch = (TextBox)findDialog.Controls["txtSearch"];
            txtSearch.Text = txtEditor.SelectedText;
            txtSearch.SelectAll();
            findDialog.Show(this);
        }

        private void ShowReplaceDialog()
        {
            TextBox txtSearch = (TextBox)replaceDialog.Controls["txtSearch"];
            txtSearch.Text = txtEditor.SelectedText;
            txtSearch.SelectAll();
            replaceDialog.Show(this);
        }
        #endregion

        #region Основные функции редактора
        private void UpdateTitle()
        {
            string fileName = currentFilePath != null ? Path.GetFileName(currentFilePath) : "Безымянный";
            string modified = isModified ? "*" : "";
            this.Text = $"{fileName}{modified} - Текстовый редактор";
        }

        private void UpdateStatusBar()
        {
            int line = GetCurrentLine();
            int column = GetCurrentColumn();
            int totalLines = txtEditor.Lines.Length;
            int totalChars = txtEditor.TextLength;

            lblStatus.Text = $"Строка: {line}, Колонка: {column} | Строк: {totalLines} | Символов: {totalChars}";
        }

        private int GetCurrentLine()
        {
            int cursorPosition = txtEditor.SelectionStart;
            return txtEditor.GetLineFromCharIndex(cursorPosition) + 1;
        }

        private int GetCurrentColumn()
        {
            int cursorPosition = txtEditor.SelectionStart;
            int currentLine = txtEditor.GetLineFromCharIndex(cursorPosition);
            int firstCharOfLine = txtEditor.GetFirstCharIndexFromLine(currentLine);
            return cursorPosition - firstCharOfLine + 1;
        }

        private void UpdateModifiedStatus(bool modified)
        {
            isModified = modified;
            UpdateTitle();
        }

        private bool ConfirmSave()
        {
            if (isModified)
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить изменения в файле?",
                    "Текстовый редактор",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    return SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void NewFile()
        {
            if (!ConfirmSave()) return;

            txtEditor.Clear();
            currentFilePath = null;
            UpdateModifiedStatus(false);
            UpdateStatusBar();
        }

        private void OpenFile()
        {
            if (!ConfirmSave()) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string content = File.ReadAllText(filePath);

                        txtEditor.Text = content;
                        currentFilePath = filePath;
                        UpdateModifiedStatus(false);
                        UpdateStatusBar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool SaveFile()
        {
            if (currentFilePath == null)
            {
                return SaveFileAs();
            }

            try
            {
                File.WriteAllText(currentFilePath, txtEditor.Text);
                UpdateModifiedStatus(false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool SaveFileAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, txtEditor.Text);

                        currentFilePath = filePath;
                        UpdateModifiedStatus(false);
                        UpdateStatusBar();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return false;
        }

        private void ChangeFont()
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = currentFont;
                fontDialog.Color = currentColor;
                fontDialog.ShowColor = true;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFont = fontDialog.Font;
                    currentColor = fontDialog.Color;

                    txtEditor.Font = currentFont;
                    txtEditor.ForeColor = currentColor;
                }
            }
        }

        private void ChangeBackgroundColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = txtEditor.BackColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    txtEditor.BackColor = colorDialog.Color;
                }
            }
        }

        private void WordWrapToggle()
        {
            txtEditor.WordWrap = !txtEditor.WordWrap;
            wordWrapToolStripMenuItem.Checked = txtEditor.WordWrap;
        }

        private void ShowStatistics()
        {
            string text = txtEditor.Text;
            int chars = text.Length;
            int words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int lines = txtEditor.Lines.Length;
            int paragraphs = text.Split(new[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            string stats = $"Статистика документа:\n\n" +
                          $"Символов: {chars}\n" +
                          $"Слов: {words}\n" +
                          $"Строк: {lines}\n" +
                          $"Абзацев: {paragraphs}";

            MessageBox.Show(stats, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Обработчики событий
        private void newToolStripMenuItem_Click(object sender, EventArgs e) => NewFile();
        private void openToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => SaveFileAs();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => txtEditor.Cut();
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => txtEditor.Copy();
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => txtEditor.Paste();
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => txtEditor.SelectAll();
        private void findToolStripMenuItem_Click(object sender, EventArgs e) => ShowFindDialog();
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e) => ShowReplaceDialog();
        private void fontToolStripMenuItem_Click(object sender, EventArgs e) => ChangeFont();
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e) => ChangeBackgroundColor();
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e) => WordWrapToggle();
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e) => ShowStatistics();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Текстовый редактор\nВерсия 3.0\n\nПростой и удобный текстовый редактор.",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            UpdateModifiedStatus(true);
            UpdateStatusBar();
        }

        private void txtEditor_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateStatusBar();
        }

        private void txtEditor_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateStatusBar();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmSave())
            {
                e.Cancel = true;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e) => NewFile();
        private void openToolStripButton_Click(object sender, EventArgs e) => OpenFile();
        private void saveToolStripButton_Click(object sender, EventArgs e) => SaveFile();
        private void cutToolStripButton_Click(object sender, EventArgs e) => txtEditor.Cut();
        private void copyToolStripButton_Click(object sender, EventArgs e) => txtEditor.Copy();
        private void pasteToolStripButton_Click(object sender, EventArgs e) => txtEditor.Paste();
        #endregion
    }
}