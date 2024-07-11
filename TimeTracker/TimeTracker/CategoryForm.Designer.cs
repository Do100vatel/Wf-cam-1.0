namespace TimeTracker
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            txtNewCategory = new TextBox();
            lstCategories = new ListBox();
            btnAddCategory = new Button();
            btnRemoveCategory = new Button();
            SuspendLayout();
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(138, 51);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(42, 23);
            btnAddCategory.TabIndex = 2;
            btnAddCategory.Text = "Add";
            btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // txtNewCategory
            // 
            txtNewCategory.Location = new Point(138, 12);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(100, 23);
            txtNewCategory.TabIndex = 1;
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.ItemHeight = 15;
            lstCategories.Location = new Point(12, 12);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(120, 94);
            lstCategories.TabIndex = 0;
            // 
            // btnRemoveCategory
            // 
            btnRemoveCategory.Location = new Point(198, 51);
            btnRemoveCategory.Name = "btnRemoveCategory";
            btnRemoveCategory.Size = new Size(40, 23);
            btnRemoveCategory.TabIndex = 3;
            btnRemoveCategory.Text = "del";
            btnRemoveCategory.UseVisualStyleBackColor = true;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemoveCategory);
            Controls.Add(btnAddCategory);
            Controls.Add(txtNewCategory);
            Controls.Add(lstCategories);
            Name = "CategoryForm";
            Text = "CategoryForm";
            Load += CategoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddCategory;
        private TextBox txtNewCategory;
        private ListBox lstCategories;
        private Button btnRemoveCategory;
    }
}