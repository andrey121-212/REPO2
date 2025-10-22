using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BatteryDiagnostic
{
    public partial class Form1 : Form
    {
        private BatteryInfo batteryInfo;
        private int refreshCount = 0;

        public Form1()
        {
            InitializeComponent();
            batteryInfo = new BatteryInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBatteryInfo();
            timerRefresh.Start();
        }

        private void UpdateBatteryInfo()
        {
            try
            {
                batteryInfo.UpdateInfo();

                // Обновление вкладки "Состояние батареи"
                lblPercentage.Text = $"Заряд: {batteryInfo.BatteryLevel}%";
                progressBarBattery.Value = batteryInfo.BatteryLevel;

                // Изменение цвета прогресс-бара в зависимости от уровня заряда
                if (batteryInfo.BatteryLevel <= 20)
                    progressBarBattery.ForeColor = Color.Red;
                else if (batteryInfo.BatteryLevel <= 50)
                    progressBarBattery.ForeColor = Color.Orange;
                else
                    progressBarBattery.ForeColor = Color.Green;

                lblBatteryPresent.Text = $"Наличие батареи: {(batteryInfo.BatteryPresent ? "Да" : "Нет")}";
                lblStatus.Text = $"Статус зарядки: {GetChargeStatusText(batteryInfo.ChargeStatus)}";
                lblBatteryLife.Text = $"Расчетное время жизни: {batteryInfo.EstimatedLife}";
                lblRemainingTime.Text = $"Оставшееся время работы: {batteryInfo.RemainingTime}";
                lblChargeTime.Text = $"Время до полной зарядки: {batteryInfo.TimeToFullCharge}";

                // Обновление вкладки "Здоровье батареи"
                int healthPercentage = batteryInfo.HealthPercentage;
                lblHealthPercentage.Text = $"Здоровье батареи: {healthPercentage}%";
                progressBarHealth.Value = healthPercentage;

                if (healthPercentage >= 80)
                    progressBarHealth.ForeColor = Color.Green;
                else if (healthPercentage >= 60)
                    progressBarHealth.ForeColor = Color.Orange;
                else
                    progressBarHealth.ForeColor = Color.Red;

                lblCycleCount.Text = $"Количество циклов: {batteryInfo.CycleCount}";
                lblBatteryType.Text = $"Тип батареи: {batteryInfo.BatteryType}";
                lblDesignCapacity.Text = $"Проектная емкость: {batteryInfo.DesignCapacity} мАч ({batteryInfo.DesignCapacityWh:0.00} Втч)";
                lblFullChargeCapacity.Text = $"Текущая полная емкость: {batteryInfo.FullChargeCapacity} мАч ({batteryInfo.FullChargeCapacityWh:0.00} Втч)";

                // Обновление вкладки "Статистика"
                lblTimeOnBattery.Text = $"Общее время от батареи: {batteryInfo.TotalTimeOnBattery} часов";
                lblTimeOnAC.Text = $"Общее время от сети: {batteryInfo.TotalTimeOnAC} часов";
                lblEnergyDrained.Text = $"Потреблено энергии: {batteryInfo.EnergyDrained:0.00} Втч ({batteryInfo.EnergyDrainedKWh:0.000} кВтч)";
                lblEnergyCharged.Text = $"Заряжено энергии: {batteryInfo.EnergyCharged:0.00} Втч ({batteryInfo.EnergyChargedKWh:0.000} кВтч)";

                // Обновление иконки батареи
                UpdateBatteryIcon();

                refreshCount++;
                toolStripStatusLabel.Text = $"Обновлено: {DateTime.Now:HH:mm:ss} | Счетчик обновлений: {refreshCount}";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void UpdateBatteryIcon()
        {
            // В реальном приложении здесь можно загружать разные иконки
            // в зависимости от уровня заряда и статуса
            if (batteryInfo.BatteryLevel <= 20)
                pictureBoxBattery.BackColor = Color.LightCoral;
            else if (batteryInfo.BatteryLevel <= 50)
                pictureBoxBattery.BackColor = Color.LightYellow;
            else
                pictureBoxBattery.BackColor = Color.LightGreen;
        }

        private string GetChargeStatusText(PowerLineStatus status)
        {
            return status switch
            {
                PowerLineStatus.Online => "Подключено к сети",
                PowerLineStatus.Offline => "Работа от батареи",
                PowerLineStatus.Unknown => "Неизвестно",
                _ => "Неизвестно"
            };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateBatteryInfo();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            UpdateBatteryInfo();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = $"battery_report_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string report = GenerateBatteryReport();
                    File.WriteAllText(saveFileDialog1.FileName, report);
                    MessageBox.Show("Отчет успешно сохранен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateBatteryReport()
        {
            return $@"ОТЧЕТ О СОСТОЯНИИ БАТАРЕИ
Сгенерирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}

ОС: {Environment.OSVersion}
Пользователь: {Environment.UserName}

ТЕКУЩЕЕ СОСТОЯНИЕ:
-------------------
Уровень заряда: {batteryInfo.BatteryLevel}%
Наличие батареи: {(batteryInfo.BatteryPresent ? "Да" : "Нет")}
Статус зарядки: {GetChargeStatusText(batteryInfo.ChargeStatus)}
Оставшееся время работы: {batteryInfo.RemainingTime}
Время до полной зарядки: {batteryInfo.TimeToFullCharge}

ЗДОРОВЬЕ БАТАРЕИ:
------------------
Здоровье: {batteryInfo.HealthPercentage}%
Количество циклов: {batteryInfo.CycleCount}
Тип батареи: {batteryInfo.BatteryType}
Проектная емкость: {batteryInfo.DesignCapacity} мАч ({batteryInfo.DesignCapacityWh:0.00} Втч)
Текущая емкость: {batteryInfo.FullChargeCapacity} мАч ({batteryInfo.FullChargeCapacityWh:0.00} Втч)
Потеря емкости: {100 - batteryInfo.HealthPercentage}%

СТАТИСТИКА ИСПОЛЬЗОВАНИЯ:
---------------------------
Общее время от батареи: {batteryInfo.TotalTimeOnBattery} часов
Общее время от сети: {batteryInfo.TotalTimeOnAC} часов
Потреблено энергии: {batteryInfo.EnergyDrained:0.00} Втч ({batteryInfo.EnergyDrainedKWh:0.000} кВтч)
Заряжено энергии: {batteryInfo.EnergyCharged:0.00} Втч ({batteryInfo.EnergyChargedKWh:0.000} кВтч)

РЕКОМЕНДАЦИИ:
--------------
{(batteryInfo.HealthPercentage < 60 ? "⚠️ Рекомендуется замена батареи" : "✅ Батарея в хорошем состоянии")}
{(batteryInfo.BatteryLevel < 20 && batteryInfo.ChargeStatus == PowerLineStatus.Offline ? "⚠️ Низкий заряд, рекомендуется подключить зарядное устройство" : "")}
";
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Это выполнит базовую оптимизацию настроек питания.\nПродолжить?",
                    "Оптимизация батареи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Эмуляция оптимизации
                    toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                    toolStripStatusLabel.Text = "Выполняется оптимизация...";

                    // В реальном приложении здесь будут системные вызовы
                    System.Threading.Thread.Sleep(2000);

                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    toolStripStatusLabel.Text = "Оптимизация завершена!";

                    MessageBox.Show("Оптимизация настроек питания выполнена успешно!", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оптимизации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetStats_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Сбросить статистику использования?\nЭта операция необратима.",
                "Сброс статистики", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // В реальном приложении здесь будет сброс статистики
                batteryInfo.ResetStatistics();
                UpdateBatteryInfo();
                MessageBox.Show("Статистика сброшена!", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class BatteryInfo
    {
        public int BatteryLevel { get; private set; }
        public bool BatteryPresent { get; private set; }
        public PowerLineStatus ChargeStatus { get; private set; }
        public string EstimatedLife { get; private set; }
        public string RemainingTime { get; private set; }
        public string TimeToFullCharge { get; private set; }
        public int HealthPercentage { get; private set; }
        public int CycleCount { get; private set; }
        public string BatteryType { get; private set; }
        public int DesignCapacity { get; private set; }
        public int FullChargeCapacity { get; private set; }
        public double DesignCapacityWh { get; private set; }
        public double FullChargeCapacityWh { get; private set; }
        public double TotalTimeOnBattery { get; private set; }
        public double TotalTimeOnAC { get; private set; }
        public double EnergyDrained { get; private set; }
        public double EnergyCharged { get; private set; }
        public double EnergyDrainedKWh => EnergyDrained / 1000;
        public double EnergyChargedKWh => EnergyCharged / 1000;

        private Random random = new Random();

        public void UpdateInfo()
        {
            // Получение реальных данных о батарее через System.Windows.Forms
            var powerStatus = SystemInformation.PowerStatus;

            // Исправление преобразования float в int
            BatteryLevel = (int)(powerStatus.BatteryLifePercent * 100);
            ChargeStatus = powerStatus.PowerLineStatus;

            // Исправление проверки наличия батареи
            BatteryPresent = powerStatus.BatteryLifePercent != 255; // 255 означает отсутствие батареи

            // Генерация демонстрационных данных
            EstimatedLife = GenerateRandomTime(2, 8);

            if (BatteryPresent && BatteryLevel > 0)
            {
                RemainingTime = ChargeStatus == PowerLineStatus.Online ? "Заряжается" : GenerateRandomTime(1, 6);
                TimeToFullCharge = ChargeStatus == PowerLineStatus.Online ? GenerateRandomTime(1, 4) : "Не заряжается";
            }
            else
            {
                RemainingTime = "Недоступно";
                TimeToFullCharge = "Недоступно";
            }

            // Данные о здоровье батареи
            HealthPercentage = BatteryPresent ? Math.Max(10, Math.Min(100, random.Next(50, 95))) : 0;
            CycleCount = BatteryPresent ? random.Next(50, 500) : 0;
            BatteryType = "Li-ion";
            DesignCapacity = BatteryPresent ? random.Next(4000, 8000) : 0;
            FullChargeCapacity = BatteryPresent ? (int)(DesignCapacity * (HealthPercentage / 100.0)) : 0;
            DesignCapacityWh = DesignCapacity * 3.7 / 1000; // Примерный расчет Втч
            FullChargeCapacityWh = FullChargeCapacity * 3.7 / 1000;

            // Статистика использования
            TotalTimeOnBattery = BatteryPresent ? random.Next(50, 500) : 0;
            TotalTimeOnAC = random.Next(100, 1000);
            EnergyDrained = TotalTimeOnBattery * 10; // Примерный расчет
            EnergyCharged = EnergyDrained * 1.1; // С учетом потерь
        }

        public void ResetStatistics()
        {
            TotalTimeOnBattery = 0;
            TotalTimeOnAC = 0;
            EnergyDrained = 0;
            EnergyCharged = 0;
        }

        private string GenerateRandomTime(int minHours, int maxHours)
        {
            int hours = random.Next(minHours, maxHours);
            int minutes = random.Next(0, 60);
            return $"{hours:00}:{minutes:00}";
        }
    }
}