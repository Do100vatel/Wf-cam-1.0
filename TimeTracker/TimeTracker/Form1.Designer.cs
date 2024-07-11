namespace TimeTracker
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
            cmbCategory = new ComboBox();
            btnStart = new Button();
            btnStop = new Button();
            lblTimer = new Label();
            btnClear = new Button();
            btnSettings = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(139, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 12);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(139, 72);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(220, 72);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(139, 41);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(49, 15);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "00:00:00";
            lblTimer.Click += label1_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(220, 13);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(lblTimer);
            Controls.Add(btnSettings);
            Controls.Add(btnClear);
            Controls.Add(cmbCategory);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private ComboBox cmbCategory;
        private Button btnClear;
        private Button btnSettings;
        private Label lblTimer;
        private Button btnStop;
    }
}
