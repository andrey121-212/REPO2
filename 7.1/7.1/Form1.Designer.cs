namespace BatteryDiagnostic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.lblChargeTime = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblBatteryLife = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBarBattery = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblBatteryPresent = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbHealth = new System.Windows.Forms.GroupBox();
            this.lblDesignCapacity = new System.Windows.Forms.Label();
            this.lblFullChargeCapacity = new System.Windows.Forms.Label();
            this.progressBarHealth = new System.Windows.Forms.ProgressBar();
            this.lblHealthPercentage = new System.Windows.Forms.Label();
            this.lblCycleCount = new System.Windows.Forms.Label();
            this.lblBatteryType = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbStatistics = new System.Windows.Forms.GroupBox();
            this.lblTimeOnBattery = new System.Windows.Forms.Label();
            this.lblTimeOnAC = new System.Windows.Forms.Label();
            this.lblEnergyDrained = new System.Windows.Forms.Label();
            this.lblEnergyCharged = new System.Windows.Forms.Label();
            this.btnResetStats = new System.Windows.Forms.Button();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxBattery = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbBatteryStatus.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbHealth.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbStatistics.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattery)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 360);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxBattery);
            this.tabPage1.Controls.Add(this.gbBatteryStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Состояние батареи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbBatteryStatus
            // 
            this.gbBatteryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBatteryStatus.Controls.Add(this.lblChargeTime);
            this.gbBatteryStatus.Controls.Add(this.lblRemainingTime);
            this.gbBatteryStatus.Controls.Add(this.lblBatteryLife);
            this.gbBatteryStatus.Controls.Add(this.lblStatus);
            this.gbBatteryStatus.Controls.Add(this.progressBarBattery);
            this.gbBatteryStatus.Controls.Add(this.lblPercentage);
            this.gbBatteryStatus.Controls.Add(this.lblBatteryPresent);
            this.gbBatteryStatus.Location = new System.Drawing.Point(150, 20);
            this.gbBatteryStatus.Name = "gbBatteryStatus";
            this.gbBatteryStatus.Size = new System.Drawing.Size(420, 300);
            this.gbBatteryStatus.TabIndex = 0;
            this.gbBatteryStatus.TabStop = false;
            this.gbBatteryStatus.Text = "Текущее состояние";
            // 
            // lblChargeTime
            // 
            this.lblChargeTime.AutoSize = true;
            this.lblChargeTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChargeTime.Location = new System.Drawing.Point(20, 180);
            this.lblChargeTime.Name = "lblChargeTime";
            this.lblChargeTime.Size = new System.Drawing.Size(175, 17);
            this.lblChargeTime.TabIndex = 6;
            this.lblChargeTime.Text = "Время до полной зарядки:";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemainingTime.Location = new System.Drawing.Point(20, 150);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(184, 17);
            this.lblRemainingTime.TabIndex = 5;
            this.lblRemainingTime.Text = "Оставшееся время работы:";
            // 
            // lblBatteryLife
            // 
            this.lblBatteryLife.AutoSize = true;
            this.lblBatteryLife.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBatteryLife.Location = new System.Drawing.Point(20, 120);
            this.lblBatteryLife.Name = "lblBatteryLife";
            this.lblBatteryLife.Size = new System.Drawing.Size(150, 17);
            this.lblBatteryLife.TabIndex = 4;
            this.lblBatteryLife.Text = "Расчетное время жизни:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(20, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Статус зарядки:";
            // 
            // progressBarBattery
            // 
            this.progressBarBattery.Location = new System.Drawing.Point(20, 50);
            this.progressBarBattery.Name = "progressBarBattery";
            this.progressBarBattery.Size = new System.Drawing.Size(380, 25);
            this.progressBarBattery.TabIndex = 2;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPercentage.Location = new System.Drawing.Point(20, 20);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(118, 25);
            this.lblPercentage.TabIndex = 1;
            this.lblPercentage.Text = "Заряд: 0%";
            // 
            // lblBatteryPresent
            // 
            this.lblBatteryPresent.AutoSize = true;
            this.lblBatteryPresent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBatteryPresent.Location = new System.Drawing.Point(20, 210);
            this.lblBatteryPresent.Name = "lblBatteryPresent";
            this.lblBatteryPresent.Size = new System.Drawing.Size(135, 17);
            this.lblBatteryPresent.TabIndex = 0;
            this.lblBatteryPresent.Text = "Наличие батареи: Да";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbHealth);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Здоровье батареи";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbHealth
            // 
            this.gbHealth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHealth.Controls.Add(this.lblDesignCapacity);
            this.gbHealth.Controls.Add(this.lblFullChargeCapacity);
            this.gbHealth.Controls.Add(this.progressBarHealth);
            this.gbHealth.Controls.Add(this.lblHealthPercentage);
            this.gbHealth.Controls.Add(this.lblCycleCount);
            this.gbHealth.Controls.Add(this.lblBatteryType);
            this.gbHealth.Location = new System.Drawing.Point(20, 20);
            this.gbHealth.Name = "gbHealth";
            this.gbHealth.Size = new System.Drawing.Size(540, 300);
            this.gbHealth.TabIndex = 0;
            this.gbHealth.TabStop = false;
            this.gbHealth.Text = "Состояние здоровья батареи";
            // 
            // lblDesignCapacity
            // 
            this.lblDesignCapacity.AutoSize = true;
            this.lblDesignCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesignCapacity.Location = new System.Drawing.Point(20, 120);
            this.lblDesignCapacity.Name = "lblDesignCapacity";
            this.lblDesignCapacity.Size = new System.Drawing.Size(203, 17);
            this.lblDesignCapacity.TabIndex = 5;
            this.lblDesignCapacity.Text = "Проектная емкость: 0 мАч (0 Втч)";
            // 
            // lblFullChargeCapacity
            // 
            this.lblFullChargeCapacity.AutoSize = true;
            this.lblFullChargeCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFullChargeCapacity.Location = new System.Drawing.Point(20, 150);
            this.lblFullChargeCapacity.Name = "lblFullChargeCapacity";
            this.lblFullChargeCapacity.Size = new System.Drawing.Size(246, 17);
            this.lblFullChargeCapacity.TabIndex = 4;
            this.lblFullChargeCapacity.Text = "Текущая полная емкость: 0 мАч (0 Втч)";
            // 
            // progressBarHealth
            // 
            this.progressBarHealth.Location = new System.Drawing.Point(20, 50);
            this.progressBarHealth.Name = "progressBarHealth";
            this.progressBarHealth.Size = new System.Drawing.Size(500, 25);
            this.progressBarHealth.TabIndex = 3;
            // 
            // lblHealthPercentage
            // 
            this.lblHealthPercentage.AutoSize = true;
            this.lblHealthPercentage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHealthPercentage.Location = new System.Drawing.Point(20, 20);
            this.lblHealthPercentage.Name = "lblHealthPercentage";
            this.lblHealthPercentage.Size = new System.Drawing.Size(195, 25);
            this.lblHealthPercentage.TabIndex = 2;
            this.lblHealthPercentage.Text = "Здоровье батареи:";
            // 
            // lblCycleCount
            // 
            this.lblCycleCount.AutoSize = true;
            this.lblCycleCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCycleCount.Location = new System.Drawing.Point(20, 90);
            this.lblCycleCount.Name = "lblCycleCount";
            this.lblCycleCount.Size = new System.Drawing.Size(145, 17);
            this.lblCycleCount.TabIndex = 1;
            this.lblCycleCount.Text = "Количество циклов: 0";
            // 
            // lblBatteryType
            // 
            this.lblBatteryType.AutoSize = true;
            this.lblBatteryType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBatteryType.Location = new System.Drawing.Point(20, 180);
            this.lblBatteryType.Name = "lblBatteryType";
            this.lblBatteryType.Size = new System.Drawing.Size(96, 17);
            this.lblBatteryType.TabIndex = 0;
            this.lblBatteryType.Text = "Тип батареи: -";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbStatistics);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Статистика";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbStatistics
            // 
            this.gbStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatistics.Controls.Add(this.lblTimeOnBattery);
            this.gbStatistics.Controls.Add(this.lblTimeOnAC);
            this.gbStatistics.Controls.Add(this.lblEnergyDrained);
            this.gbStatistics.Controls.Add(this.lblEnergyCharged);
            this.gbStatistics.Controls.Add(this.btnResetStats);
            this.gbStatistics.Location = new System.Drawing.Point(20, 20);
            this.gbStatistics.Name = "gbStatistics";
            this.gbStatistics.Size = new System.Drawing.Size(540, 300);
            this.gbStatistics.TabIndex = 0;
            this.gbStatistics.TabStop = false;
            this.gbStatistics.Text = "Статистика использования";
            // 
            // lblTimeOnBattery
            // 
            this.lblTimeOnBattery.AutoSize = true;
            this.lblTimeOnBattery.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimeOnBattery.Location = new System.Drawing.Point(20, 40);
            this.lblTimeOnBattery.Name = "lblTimeOnBattery";
            this.lblTimeOnBattery.Size = new System.Drawing.Size(200, 17);
            this.lblTimeOnBattery.TabIndex = 4;
            this.lblTimeOnBattery.Text = "Общее время от батареи: 0 часов";
            // 
            // lblTimeOnAC
            // 
            this.lblTimeOnAC.AutoSize = true;
            this.lblTimeOnAC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimeOnAC.Location = new System.Drawing.Point(20, 70);
            this.lblTimeOnAC.Name = "lblTimeOnAC";
            this.lblTimeOnAC.Size = new System.Drawing.Size(217, 17);
            this.lblTimeOnAC.TabIndex = 3;
            this.lblTimeOnAC.Text = "Общее время от сети: 0 часов";
            // 
            // lblEnergyDrained
            // 
            this.lblEnergyDrained.AutoSize = true;
            this.lblEnergyDrained.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEnergyDrained.Location = new System.Drawing.Point(20, 100);
            this.lblEnergyDrained.Name = "lblEnergyDrained";
            this.lblEnergyDrained.Size = new System.Drawing.Size(223, 17);
            this.lblEnergyDrained.TabIndex = 2;
            this.lblEnergyDrained.Text = "Потреблено энергии: 0 Втч (0 кВтч)";
            // 
            // lblEnergyCharged
            // 
            this.lblEnergyCharged.AutoSize = true;
            this.lblEnergyCharged.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEnergyCharged.Location = new System.Drawing.Point(20, 130);
            this.lblEnergyCharged.Name = "lblEnergyCharged";
            this.lblEnergyCharged.Size = new System.Drawing.Size(237, 17);
            this.lblEnergyCharged.TabIndex = 1;
            this.lblEnergyCharged.Text = "Заряжено энергии: 0 Втч (0 кВтч)";
            // 
            // btnResetStats
            // 
            this.btnResetStats.Location = new System.Drawing.Point(20, 170);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(150, 30);
            this.btnResetStats.TabIndex = 0;
            this.btnResetStats.Text = "Сбросить статистику";
            this.btnResetStats.UseVisualStyleBackColor = true;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnRefresh);
            this.gbActions.Controls.Add(this.btnSaveReport);
            this.gbActions.Controls.Add(this.btnOptimize);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbActions.Location = new System.Drawing.Point(0, 360);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(584, 70);
            this.gbActions.TabIndex = 1;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(400, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveReport.Location = new System.Drawing.Point(490, 25);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(80, 30);
            this.btnSaveReport.TabIndex = 1;
            this.btnSaveReport.Text = "Отчет";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(20, 25);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(150, 30);
            this.btnOptimize.TabIndex = 0;
            this.btnOptimize.Text = "Оптимизировать";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(469, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Готов";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            this.saveFileDialog1.Title = "Сохранить отчет о батарее";
            // 
            // pictureBoxBattery
            // 
            this.pictureBoxBattery.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBattery.Image")));
            this.pictureBoxBattery.Location = new System.Drawing.Point(20, 50);
            this.pictureBoxBattery.Name = "pictureBoxBattery";
            this.pictureBoxBattery.Size = new System.Drawing.Size(100, 200);
            this.pictureBoxBattery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBattery.TabIndex = 1;
            this.pictureBoxBattery.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 490);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диагностика батареи ноутбука";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbBatteryStatus.ResumeLayout(false);
            this.gbBatteryStatus.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbHealth.ResumeLayout(false);
            this.gbHealth.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbStatistics.ResumeLayout(false);
            this.gbStatistics.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox gbBatteryStatus;
        private Label lblBatteryPresent;
        private ProgressBar progressBarBattery;
        private Label lblPercentage;
        private Label lblStatus;
        private Label lblBatteryLife;
        private Label lblChargeTime;
        private Label lblRemainingTime;
        private GroupBox gbHealth;
        private Label lblBatteryType;
        private ProgressBar progressBarHealth;
        private Label lblHealthPercentage;
        private Label lblCycleCount;
        private Label lblDesignCapacity;
        private Label lblFullChargeCapacity;
        private GroupBox gbStatistics;
        private Label lblTimeOnBattery;
        private Label lblTimeOnAC;
        private Label lblEnergyDrained;
        private Label lblEnergyCharged;
        private Button btnResetStats;
        private GroupBox gbActions;
        private Button btnRefresh;
        private Button btnSaveReport;
        private Button btnOptimize;
        private System.Windows.Forms.Timer timerRefresh;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripProgressBar toolStripProgressBar;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBoxBattery;
    }
}