using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleDrawingApp
{
    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private Graphics graphics;
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing;
        private string currentTool;
        private Color currentColor;
        private int currentThickness;
        private Color fillColor;
        private bool fillShapes;
        private Pen currentPen;
        private Brush currentBrush;

        public Form1()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeTools();
            InitializeColors();
        }

        private void InitializeCanvas()
        {
            // Создаем холст
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvas);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);

            // Настройки по умолчанию
            currentColor = Color.Black;
            currentThickness = 2;
            fillColor = Color.Blue;
            fillShapes = false;

            UpdateCanvas();
        }

        private void InitializeTools()
        {
            // Добавляем инструменты в комбобокс
            cmbTool.Items.Add("Линия");
            cmbTool.Items.Add("Прямоугольник");
            cmbTool.Items.Add("Квадрат");
            cmbTool.Items.Add("Круг");
            cmbTool.Items.Add("Эллипс");
            cmbTool.Items.Add("Кисть");
            cmbTool.Items.Add("Ластик");
            cmbTool.SelectedIndex = 0;
            currentTool = "Линия";

            // Настраиваем толщину
            numThickness.Value = currentThickness;
            UpdatePen();

            // Создаем кисть для заливки
            currentBrush = new SolidBrush(fillColor);
        }

        private void InitializeColors()
        {
            UpdateColorPreview();
        }

        private void UpdatePen()
        {
            currentPen = new Pen(currentColor, currentThickness);
            currentPen.StartCap = LineCap.Round;
            currentPen.EndCap = LineCap.Round;
        }

        private void UpdateColorPreview()
        {
            pnlColor.BackColor = currentColor;
            pnlFillColor.BackColor = fillColor;
        }

        private void UpdateCanvas()
        {
            picCanvas.Image = canvas;
            picCanvas.Refresh();
        }

        private void cmbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTool = cmbTool.SelectedItem.ToString();
            btnFill.Enabled = currentTool != "Линия" && currentTool != "Кисть" && currentTool != "Ластик";
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            currentThickness = (int)numThickness.Value;
            UpdatePen();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = currentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                UpdatePen();
                UpdateColorPreview();
            }
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = fillColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialog.Color;
                currentBrush = new SolidBrush(fillColor);
                UpdateColorPreview();
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            fillShapes = !fillShapes;
            btnFill.BackColor = fillShapes ? SystemColors.ControlDark : SystemColors.Control;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            UpdateCanvas();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
            saveDialog.Title = "Сохранить рисунок";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    canvas.Save(saveDialog.FileName);
                    MessageBox.Show("Рисунок успешно сохранен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;
                endPoint = e.Location;

                // Для кисти и ластика начинаем рисовать сразу
                if (currentTool == "Кисть" || currentTool == "Ластик")
                {
                    DrawFreehand(e.Location);
                }
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (currentTool == "Кисть" || currentTool == "Ластик")
                {
                    // Рисуем кистью или ластиком
                    DrawFreehand(e.Location);
                }
                else
                {
                    // Показываем предварительный просмотр для фигур
                    endPoint = e.Location;
                    ShowPreview();
                }
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                endPoint = e.Location;

                if (currentTool != "Кисть" && currentTool != "Ластик")
                {
                    // Рисуем финальную фигуру
                    DrawFinalShape();
                    UpdateCanvas();
                }
            }
        }

        private void DrawFreehand(Point point)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (currentTool == "Кисть")
                {
                    using (Pen brushPen = new Pen(currentColor, currentThickness))
                    {
                        brushPen.StartCap = LineCap.Round;
                        brushPen.EndCap = LineCap.Round;
                        g.DrawLine(brushPen, startPoint, point);
                    }
                }
                else if (currentTool == "Ластик")
                {
                    using (Pen eraserPen = new Pen(Color.White, currentThickness * 2))
                    {
                        eraserPen.StartCap = LineCap.Round;
                        eraserPen.EndCap = LineCap.Round;
                        g.DrawLine(eraserPen, startPoint, point);
                    }
                }

                startPoint = point;
                UpdateCanvas();
            }
        }

        private void ShowPreview()
        {
            // Создаем временное изображение для предварительного просмотра
            Bitmap tempBitmap = new Bitmap(canvas);
            using (Graphics tempGraphics = Graphics.FromImage(tempBitmap))
            {
                tempGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen previewPen = new Pen(Color.Gray, currentThickness))
                {
                    previewPen.DashStyle = DashStyle.Dash;

                    switch (currentTool)
                    {
                        case "Линия":
                            tempGraphics.DrawLine(previewPen, startPoint, endPoint);
                            break;
                        case "Прямоугольник":
                            DrawRectanglePreview(tempGraphics, previewPen);
                            break;
                        case "Квадрат":
                            DrawSquarePreview(tempGraphics, previewPen);
                            break;
                        case "Круг":
                            DrawCirclePreview(tempGraphics, previewPen);
                            break;
                        case "Эллипс":
                            DrawEllipsePreview(tempGraphics, previewPen);
                            break;
                    }
                }
            }

            picCanvas.Image = tempBitmap;
            picCanvas.Refresh();
        }

        private void DrawFinalShape()
        {
            switch (currentTool)
            {
                case "Линия":
                    graphics.DrawLine(currentPen, startPoint, endPoint);
                    break;
                case "Прямоугольник":
                    DrawRectangle(graphics, startPoint, endPoint);
                    break;
                case "Квадрат":
                    DrawSquare(graphics, startPoint, endPoint);
                    break;
                case "Круг":
                    DrawCircle(graphics, startPoint, endPoint);
                    break;
                case "Эллипс":
                    DrawEllipse(graphics, startPoint, endPoint);
                    break;
            }
        }

        private void DrawRectanglePreview(Graphics g, Pen pen)
        {
            int width = endPoint.X - startPoint.X;
            int height = endPoint.Y - startPoint.Y;
            g.DrawRectangle(pen, startPoint.X, startPoint.Y, width, height);
        }

        private void DrawSquarePreview(Graphics g, Pen pen)
        {
            int size = Math.Min(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            int x = startPoint.X;
            int y = startPoint.Y;

            if (endPoint.X < startPoint.X) x = startPoint.X - size;
            if (endPoint.Y < startPoint.Y) y = startPoint.Y - size;

            g.DrawRectangle(pen, x, y, size, size);
        }

        private void DrawCirclePreview(Graphics g, Pen pen)
        {
            int diameter = Math.Min(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            int x = startPoint.X;
            int y = startPoint.Y;

            if (endPoint.X < startPoint.X) x = startPoint.X - diameter;
            if (endPoint.Y < startPoint.Y) y = startPoint.Y - diameter;

            g.DrawEllipse(pen, x, y, diameter, diameter);
        }

        private void DrawEllipsePreview(Graphics g, Pen pen)
        {
            int width = endPoint.X - startPoint.X;
            int height = endPoint.Y - startPoint.Y;
            g.DrawEllipse(pen, startPoint.X, startPoint.Y, width, height);
        }

        private void DrawRectangle(Graphics g, Point start, Point end)
        {
            int width = end.X - start.X;
            int height = end.Y - start.Y;

            if (fillShapes)
            {
                g.FillRectangle(currentBrush, start.X, start.Y, width, height);
            }
            g.DrawRectangle(currentPen, start.X, start.Y, width, height);
        }

        private void DrawSquare(Graphics g, Point start, Point end)
        {
            int size = Math.Min(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
            int x = start.X;
            int y = start.Y;

            if (end.X < start.X) x = start.X - size;
            if (end.Y < start.Y) y = start.Y - size;

            if (fillShapes)
            {
                g.FillRectangle(currentBrush, x, y, size, size);
            }
            g.DrawRectangle(currentPen, x, y, size, size);
        }

        private void DrawCircle(Graphics g, Point start, Point end)
        {
            int diameter = Math.Min(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
            int x = start.X;
            int y = start.Y;

            if (end.X < start.X) x = start.X - diameter;
            if (end.Y < start.Y) y = start.Y - diameter;

            if (fillShapes)
            {
                g.FillEllipse(currentBrush, x, y, diameter, diameter);
            }
            g.DrawEllipse(currentPen, x, y, diameter, diameter);
        }

        private void DrawEllipse(Graphics g, Point start, Point end)
        {
            int width = end.X - start.X;
            int height = end.Y - start.Y;

            if (fillShapes)
            {
                g.FillEllipse(currentBrush, start.X, start.Y, width, height);
            }
            g.DrawEllipse(currentPen, start.X, start.Y, width, height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавляем подсказки для инструментов
            toolTip1.SetToolTip(cmbTool, "Выберите инструмент для рисования");
            toolTip1.SetToolTip(numThickness, "Установите толщину линии");
            toolTip1.SetToolTip(btnColor, "Выберите цвет рисования");
            toolTip1.SetToolTip(btnFillColor, "Выберите цвет заливки");
            toolTip1.SetToolTip(btnFill, "Включить/выключить заливку фигур");
            toolTip1.SetToolTip(btnClear, "Очистить холст");
            toolTip1.SetToolTip(btnSave, "Сохранить рисунок");
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Дополнительная обработка отрисовки холста
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }
}