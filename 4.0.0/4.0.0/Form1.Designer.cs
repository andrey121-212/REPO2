namespace _4._0._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbShapeType = new System.Windows.Forms.ComboBox();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.txtParam1 = new System.Windows.Forms.TextBox();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.txtParam2 = new System.Windows.Forms.TextBox();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.txtParam3 = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimeter = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtPerimeter = new System.Windows.Forms.TextBox();
            this.lblShapeType = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbShapeType
            // 
            this.cmbShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShapeType.FormattingEnabled = true;
            this.cmbShapeType.Location = new System.Drawing.Point(150, 20);
            this.cmbShapeType.Name = "cmbShapeType";
            this.cmbShapeType.Size = new System.Drawing.Size(200, 28);
            this.cmbShapeType.TabIndex = 0;
            this.cmbShapeType.SelectedIndexChanged += new System.EventHandler(this.cmbShapeType_SelectedIndexChanged);
            // 
            // lblParam1
            // 
            this.lblParam1.AutoSize = true;
            this.lblParam1.Location = new System.Drawing.Point(30, 70);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(60, 20);
            this.lblParam1.TabIndex = 1;
            this.lblParam1.Text = "Парам1";
            // 
            // txtParam1
            // 
            this.txtParam1.Location = new System.Drawing.Point(150, 67);
            this.txtParam1.Name = "txtParam1";
            this.txtParam1.Size = new System.Drawing.Size(200, 27);
            this.txtParam1.TabIndex = 2;
            // 
            // lblParam2
            // 
            this.lblParam2.AutoSize = true;
            this.lblParam2.Location = new System.Drawing.Point(30, 110);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(60, 20);
            this.lblParam2.TabIndex = 3;
            this.lblParam2.Text = "Парам2";
            // 
            // txtParam2
            // 
            this.txtParam2.Location = new System.Drawing.Point(150, 107);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(200, 27);
            this.txtParam2.TabIndex = 4;
            // 
            // lblParam3
            // 
            this.lblParam3.AutoSize = true;
            this.lblParam3.Location = new System.Drawing.Point(30, 150);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(60, 20);
            this.lblParam3.TabIndex = 5;
            this.lblParam3.Text = "Парам3";
            // 
            // txtParam3
            // 
            this.txtParam3.Location = new System.Drawing.Point(150, 147);
            this.txtParam3.Name = "txtParam3";
            this.txtParam3.Size = new System.Drawing.Size(200, 27);
            this.txtParam3.TabIndex = 6;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(30, 200);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 40);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(30, 270);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(79, 20);
            this.lblArea.TabIndex = 8;
            this.lblArea.Text = "Площадь:";
            // 
            // lblPerimeter
            // 
            this.lblPerimeter.AutoSize = true;
            this.lblPerimeter.Location = new System.Drawing.Point(30, 310);
            this.lblPerimeter.Name = "lblPerimeter";
            this.lblPerimeter.Size = new System.Drawing.Size(84, 20);
            this.lblPerimeter.TabIndex = 9;
            this.lblPerimeter.Text = "Периметр:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(150, 267);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(200, 27);
            this.txtArea.TabIndex = 10;
            // 
            // txtPerimeter
            // 
            this.txtPerimeter.Location = new System.Drawing.Point(150, 307);
            this.txtPerimeter.Name = "txtPerimeter";
            this.txtPerimeter.ReadOnly = true;
            this.txtPerimeter.Size = new System.Drawing.Size(200, 27);
            this.txtPerimeter.TabIndex = 11;
            // 
            // lblShapeType
            // 
            this.lblShapeType.AutoSize = true;
            this.lblShapeType.Location = new System.Drawing.Point(30, 23);
            this.lblShapeType.Name = "lblShapeType";
            this.lblShapeType.Size = new System.Drawing.Size(96, 20);
            this.lblShapeType.TabIndex = 12;
            this.lblShapeType.Text = "Тип фигуры:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(30, 350);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(171, 20);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Введите параметры фигуры";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(200, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblShapeType);
            this.Controls.Add(this.txtPerimeter);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblPerimeter);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtParam3);
            this.Controls.Add(this.lblParam3);
            this.Controls.Add(this.txtParam2);
            this.Controls.Add(this.lblParam2);
            this.Controls.Add(this.txtParam1);
            this.Controls.Add(this.lblParam1);
            this.Controls.Add(this.cmbShapeType);
            this.Name = "Form1";
            this.Text = "Калькулятор геометрических фигур";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbShapeType;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.TextBox txtParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.TextBox txtParam2;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.TextBox txtParam3;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimeter;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtPerimeter;
        private System.Windows.Forms.Label lblShapeType;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
    }
}