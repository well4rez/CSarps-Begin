namespace curse3._2
{
    partial class RedGameForm
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
            checkBox1 = new CheckBox();
            redbut = new Button();
            label2 = new Label();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(79, 311);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(86, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Сетевая";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // redbut
            // 
            redbut.Location = new Point(204, 359);
            redbut.Name = "redbut";
            redbut.Size = new Size(125, 35);
            redbut.TabIndex = 10;
            redbut.Text = "Редактировать";
            redbut.UseVisualStyleBackColor = true;
            redbut.Click += redbut_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 225);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 9;
            label2.Text = "Онлайн игроков";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 158);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 8;
            label1.Text = "Название игры";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(79, 248);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(275, 27);
            numericUpDown1.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 181);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(275, 27);
            textBox1.TabIndex = 6;
            // 
            // RedGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 553);
            Controls.Add(checkBox1);
            Controls.Add(redbut);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Name = "RedGameForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Button redbut;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
    }
}