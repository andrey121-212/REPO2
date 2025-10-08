using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        private Image currentImage;
        private float zoomFactor = 1.0f;
        private Point dragStart;
        private bool isDragging = false;
        private Point imagePosition = Point.Empty;
        private string currentFileName;

        public Form1()
        {
            InitializeComponent();
            InitializeViewer();
        }

        private void InitializeViewer()
        {
            // Настройка PictureBox
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.BorderStyle = BorderStyle.FixedSingle;

            // Настройка TrackBar для масштабирования
            trackBarZoom.Minimum = 10;  // 10%
            trackBarZoom.Maximum = 500; // 500%
            trackBarZoom.Value = 100;   // 100%
            trackBarZoom.TickFrequency = 50;

            UpdateZoomInfo();
            UpdateControls();
        }

        private void OpenImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff|Все файлы|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Освобождаем предыдущее изображение
                        if (currentImage != null)
                        {
                            currentImage.Dispose();
                            currentImage = null;
                        }

                        // Загружаем новое изображение
                        currentImage = Image.FromFile(openFileDialog.FileName);
                        currentFileName = Path.GetFileName(openFileDialog.FileName);

                        // Сбрасываем масштаб и позицию
                        zoomFactor = 1.0f;
                        imagePosition = Point.Empty;
                        trackBarZoom.Value = 100;

                        UpdateImageDisplay();
                        UpdateZoomInfo();
                        UpdateControls();

                        // Обновляем заголовок окна
                        this.Text = $"Просмотр изображений - {currentFileName}";

                        // Добавляем в список недавних файлов
                        AddToRecentFiles(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateImageDisplay()
        {
            if (currentImage != null)
            {
                // Создаем bitmap с текущим масштабом
                int newWidth = (int)(currentImage.Width * zoomFactor);
                int newHeight = (int)(currentImage.Height * zoomFactor);

                Bitmap scaledImage = new Bitmap(newWidth, newHeight);

                using (Graphics g = Graphics.FromImage(scaledImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(currentImage, 0, 0, newWidth, newHeight);
                }

                picImage.Image = scaledImage;

                // Обновляем информацию о изображении
                UpdateImageInfo();
            }
            else
            {
                picImage.Image = null;
                lblInfo.Text = "Изображение не загружено";
            }
        }

        private void UpdateImageInfo()
        {
            if (currentImage != null)
            {
                string info = $"{currentFileName} | " +
                             $"{currentImage.Width} ? {currentImage.Height} | " +
                             $"{GetImageFormat(currentImage)} | " +
                             $"Масштаб: {zoomFactor * 100:F0}%";
                lblInfo.Text = info;
            }
        }

        private string GetImageFormat(Image image)
        {
            if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return "JPEG";
            else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return "PNG";
            else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return "BMP";
            else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return "GIF";
            else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return "TIFF";
            else
                return "Unknown";
        }

        private void ZoomIn()
        {
            if (currentImage == null) return;

            zoomFactor *= 1.2f;
            if (zoomFactor > 5.0f) zoomFactor = 5.0f; // Максимальный масштаб 500%

            UpdateTrackBarFromZoom();
            UpdateImageDisplay();
            UpdateZoomInfo();
        }

        private void ZoomOut()
        {
            if (currentImage == null) return;

            zoomFactor /= 1.2f;
            if (zoomFactor < 0.1f) zoomFactor = 0.1f; // Минимальный масштаб 10%

            UpdateTrackBarFromZoom();
            UpdateImageDisplay();
            UpdateZoomInfo();
        }

        private void ZoomToFit()
        {
            if (currentImage == null) return;

            // Вычисляем масштаб для полного отображения изображения
            float zoomX = (float)picImage.ClientSize.Width / currentImage.Width;
            float zoomY = (float)picImage.ClientSize.Height / currentImage.Height;
            zoomFactor = Math.Min(zoomX, zoomY);

            // Ограничиваем максимальный масштаб
            if (zoomFactor > 5.0f) zoomFactor = 5.0f;

            UpdateTrackBarFromZoom();
            UpdateImageDisplay();
            UpdateZoomInfo();
        }

        private void ZoomToActualSize()
        {
            if (currentImage == null) return;

            zoomFactor = 1.0f;
            trackBarZoom.Value = 100;
            UpdateImageDisplay();
            UpdateZoomInfo();
        }

        private void UpdateTrackBarFromZoom()
        {
            trackBarZoom.Value = (int)(zoomFactor * 100);
        }

        private void UpdateZoomInfo()
        {
            lblZoom.Text = $"{zoomFactor * 100:F0}%";
        }

        private void UpdateControls()
        {
            bool hasImage = currentImage != null;

            btnZoomIn.Enabled = hasImage;
            btnZoomOut.Enabled = hasImage;
            btnZoomFit.Enabled = hasImage;
            btnZoomActual.Enabled = hasImage;
            trackBarZoom.Enabled = hasImage;
            btnRotateLeft.Enabled = hasImage;
            btnRotateRight.Enabled = hasImage;
            btnSave.Enabled = hasImage;
        }

        private void RotateImage(bool clockwise)
        {
            if (currentImage == null) return;

            try
            {
                Bitmap rotatedImage = new Bitmap(currentImage.Height, currentImage.Width);

                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    if (clockwise)
                    {
                        g.TranslateTransform(currentImage.Height, 0);
                        g.RotateTransform(90);
                    }
                    else
                    {
                        g.TranslateTransform(0, currentImage.Width);
                        g.RotateTransform(-90);
                    }

                    g.DrawImage(currentImage, 0, 0, currentImage.Width, currentImage.Height);
                }

                currentImage.Dispose();
                currentImage = rotatedImage;

                UpdateImageDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при повороте изображения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveImage()
        {
            if (currentImage == null) return;

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp|GIF Image|*.gif";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = currentFileName;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;

                        switch (Path.GetExtension(saveDialog.FileName).ToLower())
                        {
                            case ".png":
                                format = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case ".bmp":
                                format = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case ".gif":
                                format = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                        }

                        currentImage.Save(saveDialog.FileName, format);
                        MessageBox.Show("Изображение успешно сохранено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddToRecentFiles(string filePath)
        {
            // Простая реализация списка недавних файлов
            ToolStripMenuItem recentItem = new ToolStripMenuItem(Path.GetFileName(filePath));
            recentItem.Tag = filePath;
            recentItem.Click += (s, e) => OpenRecentFile(filePath);

            // Добавляем в меню
            recentFilesToolStripMenuItem.DropDownItems.Add(recentItem);

            // Ограничиваем количество
            if (recentFilesToolStripMenuItem.DropDownItems.Count > 5)
            {
                recentFilesToolStripMenuItem.DropDownItems.RemoveAt(0);
            }
        }

        private void OpenRecentFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    if (currentImage != null)
                    {
                        currentImage.Dispose();
                        currentImage = null;
                    }

                    currentImage = Image.FromFile(filePath);
                    currentFileName = Path.GetFileName(filePath);

                    zoomFactor = 1.0f;
                    trackBarZoom.Value = 100;

                    UpdateImageDisplay();
                    UpdateZoomInfo();
                    UpdateControls();

                    this.Text = $"Просмотр изображений - {currentFileName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчики событий
        private void openToolStripMenuItem_Click(object sender, EventArgs e) => OpenImage();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void btnZoomIn_Click(object sender, EventArgs e) => ZoomIn();
        private void btnZoomOut_Click(object sender, EventArgs e) => ZoomOut();
        private void btnZoomFit_Click(object sender, EventArgs e) => ZoomToFit();
        private void btnZoomActual_Click(object sender, EventArgs e) => ZoomToActualSize();
        private void btnRotateLeft_Click(object sender, EventArgs e) => RotateImage(false);
        private void btnRotateRight_Click(object sender, EventArgs e) => RotateImage(true);
        private void btnSave_Click(object sender, EventArgs e) => SaveImage();

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                zoomFactor = trackBarZoom.Value / 100.0f;
                UpdateImageDisplay();
                UpdateZoomInfo();
            }
        }

        private void picImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (currentImage != null)
            {
                if (e.Delta > 0)
                    ZoomIn();
                else
                    ZoomOut();
            }
        }

        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && currentImage != null)
            {
                isDragging = true;
                dragStart = e.Location;
                picImage.Cursor = Cursors.SizeAll;
            }
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && currentImage != null)
            {
                int deltaX = e.X - dragStart.X;
                int deltaY = e.Y - dragStart.Y;

                // Здесь можно реализовать перетаскивание изображения
                // при использовании PictureBox с AutoScroll
            }
        }

        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                picImage.Cursor = Cursors.Default;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Просмотрщик изображений\nВерсия 1.0\n\n" +
                "Возможности:\n" +
                "• Открытие различных форматов изображений\n" +
                "• Масштабирование (10% - 500%)\n" +
                "• Поворот изображений\n" +
                "• Сохранение в разных форматах\n" +
                "• Горячие клавиши и колесо мыши для масштабирования",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentImage != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Add:
                    case Keys.Oemplus:
                        ZoomIn();
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        ZoomOut();
                        break;
                    case Keys.Home:
                        ZoomToFit();
                        break;
                    case Keys.NumPad0:
                        ZoomToActualSize();
                        break;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (currentImage != null)
            {
                currentImage.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}