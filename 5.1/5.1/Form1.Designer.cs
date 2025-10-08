namespace SimpleDrawingApp
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.cmbTool = new System.Windows.Forms.ComboBox();
            this.lblTool = new System.Windows.Forms.Label();
            this.lblThickness = new System.Windows.Forms.Label();
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.pnlFillColor = new System.Windows.Forms.Panel();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCanvas.Location = new System.Drawing.Point(150, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(692, 531);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // cmbTool
            // 
            this.cmbTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTool.FormattingEnabled = true;
            this.cmbTool.Location = new System.Drawing.Point(12, 35);
            this.cmbTool.Name = "cmbTool";
            this.cmbTool.Size = new System.Drawing.Size(130, 28);
            this.cmbTool.TabIndex = 1;
            this.cmbTool.SelectedIndexChanged += new System.EventHandler(this.cmbTool_SelectedIndexChanged);
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Location = new System.Drawing.Point(12, 12);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(92, 20);
            this.lblTool.TabIndex = 2;
            this.lblTool.Text = "Инструмент:";
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Location = new System.Drawing.Point(12, 76);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(87, 20);
            this.lblThickness.TabIndex = 3;
            this.lblThickness.Text = "Толщина:";
            // 
            // numThickness
            // 
            this.numThickness.Location = new System.Drawing.Point(12, 99);
            this.numThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(130, 27);
            this.numThickness.TabIndex = 4;
            this.numThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numThickness.ValueChanged += new System.EventHandler(this.numThickness_ValueChanged);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(12, 146);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 30);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Цвет";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(118, 146);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(24, 30);
            this.pnlColor.TabIndex = 6;
            // 
            // btnFillColor
            // 
            this.btnFillColor.Location = new System.Drawing.Point(12, 182);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(100, 30);
            this.btnFillColor.TabIndex = 7;
            this.btnFillColor.Text = "Заливка";
            this.btnFillColor.UseVisualStyleBackColor = true;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // pnlFillColor
            // 
            this.pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFillColor.Location = new System.Drawing.Point(118, 182);
            this.pnlFillColor.Name = "pnlFillColor";
            this.pnlFillColor.Size = new System.Drawing.Size(24, 30);
            this.pnlFillColor.TabIndex = 8;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(12, 218);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(130, 40);
            this.btnFill.TabIndex = 9;
            this.btnFill.Text = "Включить заливку";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 274);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 40);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 123);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(47, 20);
            this.lblColor.TabIndex = 12;
            this.lblColor.Text = "Цвет:";
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(12, 159);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(106, 20);
            this.lblFillColor.TabIndex = 13;
            this.lblFillColor.Text = "Цвет заливки:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 555);
            this.Controls.Add(this.lblFillColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.pnlFillColor);
            this.Controls.Add(this.btnFillColor);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.numThickness);
            this.Controls.Add(this.lblThickness);
            this.Controls.Add(this.lblTool);
            this.Controls.Add(this.cmbTool);
            this.Controls.Add(this.picCanvas);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Простой графический редактор";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.ComboBox cmbTool;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.NumericUpDown numThickness;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Panel pnlFillColor;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}