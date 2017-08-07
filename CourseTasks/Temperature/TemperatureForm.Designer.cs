namespace Temperature
{
    partial class TemperatureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelIn = new System.Windows.Forms.Panel();
            this.comboBoxScaleOut = new System.Windows.Forms.ComboBox();
            this.comboBoxScaleIn = new System.Windows.Forms.ComboBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelScaleOut = new System.Windows.Forms.Label();
            this.labelScaleIn = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.textValue = new System.Windows.Forms.TextBox();
            this.panelOut = new System.Windows.Forms.Panel();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.panelIn.SuspendLayout();
            this.panelOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIn
            // 
            this.panelIn.Controls.Add(this.comboBoxScaleOut);
            this.panelIn.Controls.Add(this.comboBoxScaleIn);
            this.panelIn.Controls.Add(this.buttonConvert);
            this.panelIn.Controls.Add(this.labelScaleOut);
            this.panelIn.Controls.Add(this.labelScaleIn);
            this.panelIn.Controls.Add(this.labelValue);
            this.panelIn.Controls.Add(this.textValue);
            this.panelIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIn.Location = new System.Drawing.Point(0, 0);
            this.panelIn.Name = "panelIn";
            this.panelIn.Size = new System.Drawing.Size(465, 110);
            this.panelIn.TabIndex = 0;
            // 
            // comboBoxScaleOut
            // 
            this.comboBoxScaleOut.FormattingEnabled = true;
            this.comboBoxScaleOut.Location = new System.Drawing.Point(301, 40);
            this.comboBoxScaleOut.Name = "comboBoxScaleOut";
            this.comboBoxScaleOut.Size = new System.Drawing.Size(137, 21);
            this.comboBoxScaleOut.TabIndex = 8;
            // 
            // comboBoxScaleIn
            // 
            this.comboBoxScaleIn.FormattingEnabled = true;
            this.comboBoxScaleIn.Location = new System.Drawing.Point(158, 40);
            this.comboBoxScaleIn.Name =  "comboBoxScaleIn";
            this.comboBoxScaleIn.Size = new System.Drawing.Size(137, 21);
            this.comboBoxScaleIn.TabIndex = 7;
   
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(15, 66);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 6;
            this.buttonConvert.Text = "Перевести";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // labelScaleOut
            // 
            this.labelScaleOut.AutoSize = true;
            this.labelScaleOut.Location = new System.Drawing.Point(298, 24);
            this.labelScaleOut.Name = "labelScaleOut";
            this.labelScaleOut.Size = new System.Drawing.Size(82, 13);
            this.labelScaleOut.TabIndex = 5;
            this.labelScaleOut.Text = "В какую шкалу";
            // 
            // labelScaleIn
            // 
            this.labelScaleIn.AutoSize = true;
            this.labelScaleIn.Location = new System.Drawing.Point(155, 24);
            this.labelScaleIn.Name = "labelScaleIn";
            this.labelScaleIn.Size = new System.Drawing.Size(91, 13);
            this.labelScaleIn.TabIndex = 4;
            this.labelScaleIn.Text = "Из какой шкалы";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(12, 24);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(125, 13);
            this.labelValue.TabIndex = 3;
            this.labelValue.Text = "Значение температуры";
            // 
            // textValue
            // 
            this.textValue.Location = new System.Drawing.Point(15, 40);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(137, 20);
            this.textValue.TabIndex = 0;
            // 
            // panelOut
            // 
            this.panelOut.AutoSize = true;
            this.panelOut.Controls.Add(this.textBoxResult);
            this.panelOut.Controls.Add(this.labelResult);
            this.panelOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOut.Location = new System.Drawing.Point(0, 110);
            this.panelOut.Name = "panelOut";
            this.panelOut.Size = new System.Drawing.Size(465, 51);
            this.panelOut.TabIndex = 1;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(77, 0);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 0;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 3);
            this.labelResult.MinimumSize = new System.Drawing.Size(59, 13);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(59, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "Результат";
            // 
            // TemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 161);
            this.Controls.Add(this.panelOut);
            this.Controls.Add(this.panelIn);
            this.MinimumSize = new System.Drawing.Size(481, 200);
            this.Name = "TemperatureForm";
            this.Text = "Перевод температуры";
            this.panelIn.ResumeLayout(false);
            this.panelIn.PerformLayout();
            this.panelOut.ResumeLayout(false);
            this.panelOut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelIn;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label labelScaleOut;
        private System.Windows.Forms.Label labelScaleIn;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.Panel panelOut;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.ComboBox comboBoxScaleOut;
        private System.Windows.Forms.ComboBox comboBoxScaleIn;
    }
}

