using System;
using System.Windows.Forms;

namespace _4._0._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeShapeComboBox();
        }

        private void InitializeShapeComboBox()
        {
            cmbShapeType.Items.Add("Круг");
            cmbShapeType.Items.Add("Прямоугольник");
            cmbShapeType.Items.Add("Треугольник");
            cmbShapeType.SelectedIndex = 0;
        }

        private void cmbShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInputFields();
        }

        private void UpdateInputFields()
        {
            // Скрываем все поля ввода
            lblParam1.Visible = false;
            txtParam1.Visible = false;
            lblParam2.Visible = false;
            txtParam2.Visible = false;
            lblParam3.Visible = false;
            txtParam3.Visible = false;

            string selectedShape = cmbShapeType.SelectedItem.ToString();

            switch (selectedShape)
            {
                case "Круг":
                    lblParam1.Text = "Радиус:";
                    lblParam1.Visible = true;
                    txtParam1.Visible = true;
                    break;
                case "Прямоугольник":
                    lblParam1.Text = "Ширина:";
                    lblParam2.Text = "Высота:";
                    lblParam1.Visible = true;
                    txtParam1.Visible = true;
                    lblParam2.Visible = true;
                    txtParam2.Visible = true;
                    break;
                case "Треугольник":
                    lblParam1.Text = "Сторона A:";
                    lblParam2.Text = "Сторона B:";
                    lblParam3.Text = "Сторона C:";
                    lblParam1.Visible = true;
                    txtParam1.Visible = true;
                    lblParam2.Visible = true;
                    txtParam2.Visible = true;
                    lblParam3.Visible = true;
                    txtParam3.Visible = true;
                    break;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                IShape shape = CreateShapeFromInput();
                if (shape != null)
                {
                    double area = shape.CalculateArea();
                    double perimeter = shape.CalculatePerimeter();

                    txtArea.Text = area.ToString("F2");
                    txtPerimeter.Text = perimeter.ToString("F2");
                    lblResult.Text = $"{shape.GetShapeName()} рассчитан успешно!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IShape CreateShapeFromInput()
        {
            string selectedShape = cmbShapeType.SelectedItem.ToString();

            switch (selectedShape)
            {
                case "Круг":
                    double radius = double.Parse(txtParam1.Text);
                    if (radius <= 0) throw new ArgumentException("Радиус должен быть положительным числом");
                    return new Circle(radius);

                case "Прямоугольник":
                    double width = double.Parse(txtParam1.Text);
                    double height = double.Parse(txtParam2.Text);
                    if (width <= 0 || height <= 0) throw new ArgumentException("Ширина и высота должны быть положительными числами");
                    return new Rectangle(width, height);

                case "Треугольник":
                    double sideA = double.Parse(txtParam1.Text);
                    double sideB = double.Parse(txtParam2.Text);
                    double sideC = double.Parse(txtParam3.Text);
                    Triangle triangle = new Triangle(sideA, sideB, sideC);
                    if (!triangle.IsValidTriangle()) throw new ArgumentException("Треугольник с такими сторонами не существует");
                    return triangle;

                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtParam1.Clear();
            txtParam2.Clear();
            txtParam3.Clear();
            txtArea.Clear();
            txtPerimeter.Clear();
            lblResult.Text = "Введите параметры фигуры";
        }
    }
}