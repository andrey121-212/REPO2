using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private string currentInput = string.Empty;
        private string firstOperand = string.Empty;
        private string secondOperand = string.Empty;
        private char operation;
        private bool isNewInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    HandleNumberInput(buttonText);
                    break;

                case ".":
                    HandleDecimalPoint();
                    break;

                case "+":
                case "-":
                case "×":
                case "÷":
                    HandleOperation(buttonText);
                    break;

                case "=":
                    CalculateResult();
                    break;

                case "C":
                    ClearCalculator();
                    break;

                case "±":
                    ToggleSign();
                    break;

                case "%":
                    CalculatePercentage();
                    break;
            }
        }

        private void HandleNumberInput(string number)
        {
            if (isNewInput)
            {
                currentInput = number;
                isNewInput = false;
            }
            else
            {
                // Ограничение длины ввода
                if (currentInput.Length < 15)
                {
                    currentInput += number;
                }
            }
            displayTextBox.Text = currentInput;
        }

        private void HandleDecimalPoint()
        {
            if (isNewInput)
            {
                currentInput = "0.";
                isNewInput = false;
            }
            else if (!currentInput.Contains("."))
            {
                currentInput += ".";
            }
            displayTextBox.Text = currentInput;
        }

        private void HandleOperation(string op)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (!string.IsNullOrEmpty(firstOperand))
                {
                    CalculateResult();
                }
                firstOperand = currentInput;
                operation = op switch
                {
                    "+" => '+',
                    "-" => '-',
                    "×" => '*',
                    "÷" => '/',
                    _ => '+'
                };
                currentInput = string.Empty;
                isNewInput = true;
            }
        }

        private void CalculateResult()
        {
            if (!string.IsNullOrEmpty(firstOperand) && !string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    secondOperand = currentInput;
                    double result = PerformCalculation(
                        double.Parse(firstOperand),
                        double.Parse(secondOperand),
                        operation);

                    // Форматирование результата
                    displayTextBox.Text = FormatResult(result);
                    currentInput = result.ToString();
                    firstOperand = string.Empty;
                    isNewInput = true;
                }
                catch (DivideByZeroException)
                {
                    displayTextBox.Text = "Ошибка: Деление на 0";
                    currentInput = string.Empty;
                    firstOperand = string.Empty;
                    isNewInput = true;
                }
                catch (Exception ex)
                {
                    displayTextBox.Text = "Ошибка";
                    currentInput = string.Empty;
                    firstOperand = string.Empty;
                    isNewInput = true;
                }
            }
        }

        private double PerformCalculation(double first, double second, char op)
        {
            return op switch
            {
                '+' => first + second,
                '-' => first - second,
                '*' => first * second,
                '/' => second != 0 ? first / second : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException("Неизвестная операция")
            };
        }

        private string FormatResult(double result)
        {
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                return "Ошибка";
            }

            string resultString = result.ToString();

            // Если число слишком большое для отображения, используем экспоненциальную запись
            if (resultString.Length > 15)
            {
                return result.ToString("G6");
            }

            return resultString;
        }

        private void ClearCalculator()
        {
            currentInput = string.Empty;
            firstOperand = string.Empty;
            secondOperand = string.Empty;
            displayTextBox.Text = "0";
            isNewInput = true;
        }

        private void ToggleSign()
        {
            if (!string.IsNullOrEmpty(currentInput) && currentInput != "0")
            {
                if (currentInput.StartsWith("-"))
                {
                    currentInput = currentInput.Substring(1);
                }
                else
                {
                    currentInput = "-" + currentInput;
                }
                displayTextBox.Text = currentInput;
            }
        }

        private void CalculatePercentage()
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                try
                {
                    double value = double.Parse(currentInput);
                    double percentage = value / 100;
                    currentInput = percentage.ToString();
                    displayTextBox.Text = currentInput;
                }
                catch
                {
                    displayTextBox.Text = "Ошибка";
                    currentInput = string.Empty;
                    isNewInput = true;
                }
            }
        }

        // Обработка ввода с клавиатуры
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0: case Keys.NumPad0: HandleNumberInput("0"); return true;
                case Keys.D1: case Keys.NumPad1: HandleNumberInput("1"); return true;
                case Keys.D2: case Keys.NumPad2: HandleNumberInput("2"); return true;
                case Keys.D3: case Keys.NumPad3: HandleNumberInput("3"); return true;
                case Keys.D4: case Keys.NumPad4: HandleNumberInput("4"); return true;
                case Keys.D5: case Keys.NumPad5: HandleNumberInput("5"); return true;
                case Keys.D6: case Keys.NumPad6: HandleNumberInput("6"); return true;
                case Keys.D7: case Keys.NumPad7: HandleNumberInput("7"); return true;
                case Keys.D8: case Keys.NumPad8: HandleNumberInput("8"); return true;
                case Keys.D9: case Keys.NumPad9: HandleNumberInput("9"); return true;
                case Keys.Decimal: case Keys.OemPeriod: HandleDecimalPoint(); return true;
                case Keys.Add: HandleOperation("+"); return true;
                case Keys.Subtract: HandleOperation("-"); return true;
                case Keys.Multiply: HandleOperation("×"); return true;
                case Keys.Divide: HandleOperation("÷"); return true;
                case Keys.Enter: CalculateResult(); return true;
                case Keys.Escape: ClearCalculator(); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}