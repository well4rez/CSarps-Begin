namespace curse3._2
{
    partial class GameListForm
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
            refreshBtn = new Button();
            dataGridViewGame = new DataGridView();
            addBtn = new Button();
            delBtn = new Button();
            rBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGame).BeginInit();
            SuspendLayout();
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(650, 48);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(107, 34);
            refreshBtn.TabIndex = 0;
            refreshBtn.Text = "Update";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // dataGridViewGame
            // 
            dataGridViewGame.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGame.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGame.Location = new Point(24, 88);
            dataGridViewGame.Name = "dataGridViewGame";
            dataGridViewGame.RowHeadersWidth = 51;
            dataGridViewGame.Size = new Size(733, 394);
            dataGridViewGame.TabIndex = 1;
            dataGridViewGame.CellClick += dataGridViewGame_CellClick;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(24, 488);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(107, 34);
            addBtn.TabIndex = 0;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // delBtn
            // 
            delBtn.Location = new Point(253, 488);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(107, 34);
            delBtn.TabIndex = 0;
            delBtn.Text = "Delete";
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += delBtn_Click;
            // 
            // rBtn
            // 
            rBtn.Location = new Point(137, 488);
            rBtn.Name = "rBtn";
            rBtn.Size = new Size(110, 34);
            rBtn.TabIndex = 2;
            rBtn.Text = "Redact";
            rBtn.UseVisualStyleBackColor = true;
            rBtn.Click += rBtn_Click;
            // 
            // GameListForm
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rBtn);
            Controls.Add(dataGridViewGame);
            Controls.Add(delBtn);
            Controls.Add(addBtn);
            Controls.Add(refreshBtn);
            Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "GameListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Данные об играх";
            ((System.ComponentModel.ISupportInitialize)dataGridViewGame).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button refreshBtn;
        private DataGridView dataGridViewGame;
        private Button addBtn;
        private Button delBtn;
        private Button redBtn;
        private Button rBtn;
    }
}