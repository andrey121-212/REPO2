using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HangmanGame
{
    public partial class Form1 : Form
    {
        private HangmanGame game;
        private List<Button> letterButtons;
        private int gameTimeInSeconds;
        private Difficulty currentDifficulty;
        private bool isFullScreen = false;
        private FormWindowState previousWindowState;
        private FormBorderStyle previousBorderStyle;
        private bool previousTopMost;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
            this.KeyPreview = true; // Включаем обработку клавиш на форме
        }

        private void InitializeGame()
        {
            letterButtons = new List<Button>();
            currentDifficulty = Difficulty.Medium;
            CreateKeyboard();
        }

        private void CreateKeyboard()
        {
            panelKeyboard.Controls.Clear();
            letterButtons.Clear();

            string russianLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            int buttonWidth = 40;
            int buttonHeight = 40;
            int margin = 5;
            int x = margin;
            int y = margin;

            for (int i = 0; i < russianLetters.Length; i++)
            {
                Button btn = new Button
                {
                    Text = russianLetters[i].ToString(),
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(x, y),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Tag = russianLetters[i]
                };

                btn.Click += LetterButton_Click;

                panelKeyboard.Controls.Add(btn);
                letterButtons.Add(btn);

                x += buttonWidth + margin;

                // Перенос на новую строку после 10 букв
                if ((i + 1) % 10 == 0)
                {
                    x = margin;
                    y += buttonHeight + margin;
                }
            }
        }

        private void StartNewGame()
        {
            game = new HangmanGame(currentDifficulty);
            UpdateDisplay();
            ResetKeyboard();
            gameTimeInSeconds = 0;
            timerGame.Start();
            toolStripStatusLabel.Text = "Угадайте слово! Нажмите F11 для полноэкранного режима";
        }

        private void UpdateDisplay()
        {
            lblWord.Text = game.GetDisplayWord();
            lblAttempts.Text = $"Осталось попыток: {game.RemainingAttempts}";
            lblUsedLetters.Text = $"Использованные: {string.Join(" ", game.UsedLetters)}";
            lblCategory.Text = $"Категория: {game.CurrentCategory}";

            UpdateHangmanImage();
            CheckGameStatus();
        }

        private void UpdateHangmanImage()
        {
            int wrongAttempts = game.MaxAttempts - game.RemainingAttempts;
            DrawHangman(wrongAttempts);
        }

        private void DrawHangman(int wrongAttempts)
        {
            Bitmap bmp = new Bitmap(pictureBoxHangman.Width, pictureBoxHangman.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Pen pen = new Pen(Color.Brown, 4);

                // Основание виселицы
                g.DrawLine(pen, 50, 350, 250, 350); // основание
                g.DrawLine(pen, 150, 350, 150, 50);  // столб
                g.DrawLine(pen, 150, 50, 250, 50);   // перекладина
                g.DrawLine(pen, 250, 50, 250, 100);   // веревка

                if (wrongAttempts >= 1) // Голова
                {
                    g.DrawEllipse(pen, 230, 100, 40, 40);
                }

                if (wrongAttempts >= 2) // Тело
                {
                    g.DrawLine(pen, 250, 140, 250, 240);
                }

                if (wrongAttempts >= 3) // Левая рука
                {
                    g.DrawLine(pen, 250, 160, 210, 200);
                }

                if (wrongAttempts >= 4) // Правая рука
                {
                    g.DrawLine(pen, 250, 160, 290, 200);
                }

                if (wrongAttempts >= 5) // Левая нога
                {
                    g.DrawLine(pen, 250, 240, 210, 300);
                }

                if (wrongAttempts >= 6) // Правая нога
                {
                    g.DrawLine(pen, 250, 240, 290, 300);
                }

                // Добавляем детали для лучшей видимости
                if (wrongAttempts >= 1)
                {
                    // Глаза
                    g.DrawLine(pen, 240, 115, 245, 120);
                    g.DrawLine(pen, 245, 115, 240, 120);
                    g.DrawLine(pen, 255, 115, 260, 120);
                    g.DrawLine(pen, 260, 115, 255, 120);

                    // Рот
                    g.DrawArc(pen, 240, 125, 20, 10, 0, 180);
                }
            }

            pictureBoxHangman.Image = bmp;
        }

        private void CheckGameStatus()
        {
            if (game.IsGameOver)
            {
                timerGame.Stop();
                if (game.IsWon)
                {
                    toolStripStatusLabel.Text = $"Поздравляем! Вы выиграли! Слово: {game.SecretWord}";
                    MessageBox.Show($"Поздравляем! Вы угадали слово: {game.SecretWord}\nВремя: {lblTimer.Text}", "Победа!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    toolStripStatusLabel.Text = $"Игра окончена! Загаданное слово: {game.SecretWord}";
                    MessageBox.Show($"К сожалению, вы проиграли!\nЗагаданное слово: {game.SecretWord}", "Поражение",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                DisableKeyboard();
            }
        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char letter = (char)btn.Tag;

            if (game.GuessLetter(letter))
            {
                btn.BackColor = Color.LightGreen;
                btn.Enabled = false;
            }
            else
            {
                btn.BackColor = Color.LightCoral;
                btn.Enabled = false;
            }

            UpdateDisplay();
        }

        private void ResetKeyboard()
        {
            foreach (Button btn in letterButtons)
            {
                btn.Enabled = true;
                btn.BackColor = SystemColors.Control;
            }
        }

        private void DisableKeyboard()
        {
            foreach (Button btn in letterButtons)
            {
                btn.Enabled = false;
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            if (!game.IsGameOver)
            {
                char hint = game.GetHint();
                if (hint != ' ')
                {
                    toolStripStatusLabel.Text = $"Подсказка: попробуйте букву '{hint}'";
                    // Автоматически нажимаем кнопку с подсказкой
                    var hintButton = letterButtons.FirstOrDefault(b => (char)b.Tag == hint && b.Enabled);
                    if (hintButton != null)
                    {
                        LetterButton_Click(hintButton, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Подсказки закончились!", "Подсказка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            gameTimeInSeconds++;
            TimeSpan time = TimeSpan.FromSeconds(gameTimeInSeconds);
            lblTimer.Text = $"Время: {time:mm\\:ss}";
        }

        // Полноэкранный режим
        private void ToggleFullScreen()
        {
            if (!isFullScreen)
            {
                // Входим в полноэкранный режим
                previousWindowState = this.WindowState;
                previousBorderStyle = this.FormBorderStyle;
                previousTopMost = this.TopMost;

                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;

                menuStrip1.Visible = false;
                statusStrip1.Visible = false;

                isFullScreen = true;
                btnFullScreen.Text = "Обычный режим (F11)";
                fullScreenToolStripMenuItem.Text = "Обычный режим";
            }
            else
            {
                // Выходим из полноэкранного режима
                this.TopMost = previousTopMost;
                this.FormBorderStyle = previousBorderStyle;
                this.WindowState = previousWindowState;

                menuStrip1.Visible = true;
                statusStrip1.Visible = true;

                isFullScreen = false;
                btnFullScreen.Text = "Полный экран (F11)";
                fullScreenToolStripMenuItem.Text = "Полный экран";
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        // Обработка горячих клавиш
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F11:
                    ToggleFullScreen();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    StartNewGame();
                    e.Handled = true;
                    break;
                case Keys.F1:
                    rulesToolStripMenuItem_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.Escape when isFullScreen:
                    ToggleFullScreen();
                    e.Handled = true;
                    break;
            }
        }

        // Адаптация интерфейса при изменении размера
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (isFullScreen && this.WindowState != FormWindowState.Maximized)
            {
                ToggleFullScreen(); // Автоматически выходим из полноэкранного режима
            }
        }

        // Меню обработчики
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Доступные категории:\n• Животные\n• Города\n• Профессии\n• Еда\n• Спорт",
                "Категории", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Easy;
            StartNewGame();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Medium;
            StartNewGame();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Hard;
            StartNewGame();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rules = @"ПРАВИЛА ИГРЫ 'ВИСЕЛИЦА':

1. Компьютер загадывает слово из выбранной категории
2. Вы должны угадать слово, предлагая буквы
3. За каждую неправильную букву рисуется часть виселицы
4. Игра продолжается до:
   • Полного угадывания слова (ПОБЕДА)
   • Завершения рисунка виселицы (ПОРАЖЕНИЕ)

ГОРЯЧИЕ КЛАВИШИ:
• F1 - Правила игры
• F2 - Новая игра
• F11 - Полный экран
• ESC - Выход из полноэкранного режима

СЛОЖНОСТИ:
• Легкая: 8 попыток, короткие слова
• Средняя: 6 попыток, слова средней длины
• Сложная: 4 попытки, длинные слова

УДАЧИ!";
            MessageBox.Show(rules, "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Виселица v2.0\n\nКлассическая игра в слова с поддержкой полноэкранного режима\nРазработано с использованием C# и Windows Forms\n\n© 2024",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Классы игры (остаются без изменений)
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public class WordDictionary
    {
        private readonly Dictionary<string, List<string>> categories;

        public WordDictionary()
        {
            categories = new Dictionary<string, List<string>>
            {
                ["Животные"] = new List<string> { "КОТ", "СОБАКА", "ЛОШАДЬ", "СЛОН", "ТИГР", "ЛЕВ", "МЕДВЕДЬ", "ВОЛК", "ЛИСА", "ЗАЯЦ" },
                ["Города"] = new List<string> { "МОСКВА", "ПАРИЖ", "ЛОНДОН", "БЕРЛИН", "ТОКИО", "РИМ", "ПРАГА", "КИЕВ", "МИНСК", "СОЧИ" },
                ["Профессии"] = new List<string> { "ВРАЧ", "УЧИТЕЛЬ", "ИНЖЕНЕР", "ПРОГРАММИСТ", "ПОВАР", "ПИЛОТ", "СТРОИТЕЛЬ", "ХУДОЖНИК", "МУЗЫКАНТ", "СПОРТСМЕН" },
                ["Еда"] = new List<string> { "ЯБЛОКО", "БАНАН", "ПИЦЦА", "СУП", "САЛАТ", "КОФЕ", "ЧАЙ", "СЫР", "ХЛЕБ", "МОЛОКО" },
                ["Спорт"] = new List<string> { "ФУТБОЛ", "ХОККЕЙ", "ТЕННИС", "БАСКЕТБОЛ", "ПЛАВАНИЕ", "БЕГ", "ЙОГА", "БОКС", "ВОЛЕЙБОЛ", "ГИМНАСТИКА" }
            };
        }

        public KeyValuePair<string, string> GetRandomWord()
        {
            var random = new Random();
            var category = categories.Keys.ElementAt(random.Next(categories.Count));
            var words = categories[category];
            var word = words[random.Next(words.Count)];
            return new KeyValuePair<string, string>(category, word);
        }

        public KeyValuePair<string, string> GetRandomWordByDifficulty(Difficulty difficulty)
        {
            var random = new Random();
            var category = categories.Keys.ElementAt(random.Next(categories.Count));
            var words = categories[category];

            // Фильтрация слов по сложности
            var filteredWords = words.Where(word =>
            {
                return difficulty switch
                {
                    Difficulty.Easy => word.Length <= 5,
                    Difficulty.Medium => word.Length > 5 && word.Length <= 8,
                    Difficulty.Hard => word.Length > 8,
                    _ => true
                };
            }).ToList();

            if (filteredWords.Count == 0)
                filteredWords = words; // Если нет подходящих слов, берем любые

            var word = filteredWords[random.Next(filteredWords.Count)];
            return new KeyValuePair<string, string>(category, word);
        }
    }

    public class HangmanGame
    {
        public string SecretWord { get; private set; }
        public string CurrentCategory { get; private set; }
        public int MaxAttempts { get; private set; }
        public int RemainingAttempts { get; private set; }
        public HashSet<char> UsedLetters { get; private set; }
        public HashSet<char> GuessedLetters { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsWon { get; private set; }

        private readonly WordDictionary dictionary;
        private readonly Difficulty difficulty;

        public HangmanGame(Difficulty difficulty)
        {
            this.difficulty = difficulty;
            dictionary = new WordDictionary();
            UsedLetters = new HashSet<char>();
            GuessedLetters = new HashSet<char>();

            SetDifficulty();
            StartNewGame();
        }

        private void SetDifficulty()
        {
            MaxAttempts = difficulty switch
            {
                Difficulty.Easy => 8,
                Difficulty.Medium => 6,
                Difficulty.Hard => 4,
                _ => 6
            };
        }

        public void StartNewGame()
        {
            var wordData = dictionary.GetRandomWordByDifficulty(difficulty);
            CurrentCategory = wordData.Key;
            SecretWord = wordData.Value;

            RemainingAttempts = MaxAttempts;
            UsedLetters.Clear();
            GuessedLetters.Clear();
            IsGameOver = false;
            IsWon = false;
        }

        public bool GuessLetter(char letter)
        {
            if (IsGameOver || UsedLetters.Contains(letter))
                return false;

            letter = char.ToUpper(letter);
            UsedLetters.Add(letter);

            if (SecretWord.Contains(letter))
            {
                GuessedLetters.Add(letter);
                CheckWinCondition();
                return true;
            }
            else
            {
                RemainingAttempts--;
                CheckLoseCondition();
                return false;
            }
        }

        private void CheckWinCondition()
        {
            IsWon = SecretWord.All(c => GuessedLetters.Contains(c) || c == ' ');
            IsGameOver = IsWon;
        }

        private void CheckLoseCondition()
        {
            if (RemainingAttempts <= 0)
            {
                IsGameOver = true;
                IsWon = false;
            }
        }

        public string GetDisplayWord()
        {
            return string.Join(" ", SecretWord.Select(c =>
                GuessedLetters.Contains(c) ? c.ToString() : "_"));
        }

        public char GetHint()
        {
            var unknownLetters = SecretWord.Where(c => !GuessedLetters.Contains(c) && char.IsLetter(c));
            if (unknownLetters.Any())
            {
                var random = new Random();
                return unknownLetters.ElementAt(random.Next(unknownLetters.Count()));
            }
            return ' ';
        }
    }
}