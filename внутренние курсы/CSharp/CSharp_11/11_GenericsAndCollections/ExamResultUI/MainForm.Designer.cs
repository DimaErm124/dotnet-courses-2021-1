
namespace ExamResultUI
{
    partial class MainForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ExamResultPage = new System.Windows.Forms.TabPage();
            this.ExamResultFiltersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ExamResultDGV = new System.Windows.Forms.DataGridView();
            this.StudentTabPage = new System.Windows.Forms.TabPage();
            this.StudentFiltersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.StudentsDGV = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LoadFiltersButton = new System.Windows.Forms.Button();
            this.SaveFiltersButton = new System.Windows.Forms.Button();
            this.DeleteFiltersButton = new System.Windows.Forms.Button();
            this.EditFiltersButton = new System.Windows.Forms.Button();
            this.AddFiltersButton = new System.Windows.Forms.Button();
            this.FiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.MainTabControl.SuspendLayout();
            this.ExamResultPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExamResultDGV)).BeginInit();
            this.StudentTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDGV)).BeginInit();
            this.FiltersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ExamResultPage);
            this.MainTabControl.Controls.Add(this.StudentTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 98);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(948, 443);
            this.MainTabControl.TabIndex = 0;
            this.MainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.MainTabControl_Selected);
            // 
            // ExamResultPage
            // 
            this.ExamResultPage.Controls.Add(this.ExamResultFiltersCheckedListBox);
            this.ExamResultPage.Controls.Add(this.ExamResultDGV);
            this.ExamResultPage.Location = new System.Drawing.Point(4, 24);
            this.ExamResultPage.Name = "ExamResultPage";
            this.ExamResultPage.Padding = new System.Windows.Forms.Padding(3);
            this.ExamResultPage.Size = new System.Drawing.Size(940, 415);
            this.ExamResultPage.TabIndex = 0;
            this.ExamResultPage.Text = "  Exam result  ";
            this.ExamResultPage.UseVisualStyleBackColor = true;
            // 
            // ExamResultFiltersCheckedListBox
            // 
            this.ExamResultFiltersCheckedListBox.FormattingEnabled = true;
            this.ExamResultFiltersCheckedListBox.Location = new System.Drawing.Point(540, 6);
            this.ExamResultFiltersCheckedListBox.Name = "ExamResultFiltersCheckedListBox";
            this.ExamResultFiltersCheckedListBox.Size = new System.Drawing.Size(394, 400);
            this.ExamResultFiltersCheckedListBox.TabIndex = 1;
            this.ExamResultFiltersCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ExamResultFiltersCheckedListBox_ItemCheck);
            // 
            // ExamResultDGV
            // 
            this.ExamResultDGV.AllowUserToAddRows = false;
            this.ExamResultDGV.AllowUserToDeleteRows = false;
            this.ExamResultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExamResultDGV.Location = new System.Drawing.Point(6, 6);
            this.ExamResultDGV.Name = "ExamResultDGV";
            this.ExamResultDGV.ReadOnly = true;
            this.ExamResultDGV.RowTemplate.Height = 25;
            this.ExamResultDGV.Size = new System.Drawing.Size(528, 400);
            this.ExamResultDGV.TabIndex = 0;
            // 
            // StudentTabPage
            // 
            this.StudentTabPage.Controls.Add(this.StudentFiltersCheckedListBox);
            this.StudentTabPage.Controls.Add(this.StudentsDGV);
            this.StudentTabPage.Location = new System.Drawing.Point(4, 24);
            this.StudentTabPage.Name = "StudentTabPage";
            this.StudentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StudentTabPage.Size = new System.Drawing.Size(940, 415);
            this.StudentTabPage.TabIndex = 1;
            this.StudentTabPage.Text = "  Students  ";
            this.StudentTabPage.UseVisualStyleBackColor = true;
            // 
            // StudentFiltersCheckedListBox
            // 
            this.StudentFiltersCheckedListBox.FormattingEnabled = true;
            this.StudentFiltersCheckedListBox.Location = new System.Drawing.Point(540, 6);
            this.StudentFiltersCheckedListBox.Name = "StudentFiltersCheckedListBox";
            this.StudentFiltersCheckedListBox.Size = new System.Drawing.Size(394, 400);
            this.StudentFiltersCheckedListBox.TabIndex = 1;
            this.StudentFiltersCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.StudentFiltersCheckedListBox_ItemCheck);
            // 
            // StudentsDGV
            // 
            this.StudentsDGV.AllowUserToAddRows = false;
            this.StudentsDGV.AllowUserToDeleteRows = false;
            this.StudentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsDGV.Location = new System.Drawing.Point(6, 6);
            this.StudentsDGV.Name = "StudentsDGV";
            this.StudentsDGV.RowTemplate.Height = 25;
            this.StudentsDGV.Size = new System.Drawing.Size(528, 400);
            this.StudentsDGV.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(12, 47);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 45);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditButton.Location = new System.Drawing.Point(189, 47);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(171, 45);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(366, 47);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(184, 45);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveButton.Location = new System.Drawing.Point(12, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(261, 29);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoadButton.Location = new System.Drawing.Point(279, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(271, 29);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // LoadFiltersButton
            // 
            this.LoadFiltersButton.Location = new System.Drawing.Point(226, 22);
            this.LoadFiltersButton.Name = "LoadFiltersButton";
            this.LoadFiltersButton.Size = new System.Drawing.Size(168, 23);
            this.LoadFiltersButton.TabIndex = 10;
            this.LoadFiltersButton.Text = "Load";
            this.LoadFiltersButton.UseVisualStyleBackColor = true;
            this.LoadFiltersButton.Click += new System.EventHandler(this.LoadFiltersButton_Click);
            // 
            // SaveFiltersButton
            // 
            this.SaveFiltersButton.Location = new System.Drawing.Point(6, 22);
            this.SaveFiltersButton.Name = "SaveFiltersButton";
            this.SaveFiltersButton.Size = new System.Drawing.Size(214, 23);
            this.SaveFiltersButton.TabIndex = 9;
            this.SaveFiltersButton.Text = "Save";
            this.SaveFiltersButton.UseVisualStyleBackColor = true;
            this.SaveFiltersButton.Click += new System.EventHandler(this.SaveFiltersButton_Click);
            // 
            // DeleteFiltersButton
            // 
            this.DeleteFiltersButton.Location = new System.Drawing.Point(304, 51);
            this.DeleteFiltersButton.Name = "DeleteFiltersButton";
            this.DeleteFiltersButton.Size = new System.Drawing.Size(90, 39);
            this.DeleteFiltersButton.TabIndex = 8;
            this.DeleteFiltersButton.Text = "Delete";
            this.DeleteFiltersButton.UseVisualStyleBackColor = true;
            this.DeleteFiltersButton.Click += new System.EventHandler(this.DeleteFiltersButton_Click);
            // 
            // EditFiltersButton
            // 
            this.EditFiltersButton.Location = new System.Drawing.Point(155, 51);
            this.EditFiltersButton.Name = "EditFiltersButton";
            this.EditFiltersButton.Size = new System.Drawing.Size(143, 39);
            this.EditFiltersButton.TabIndex = 7;
            this.EditFiltersButton.Text = "Edit";
            this.EditFiltersButton.UseVisualStyleBackColor = true;
            this.EditFiltersButton.Click += new System.EventHandler(this.EditFiltersButton_Click);
            // 
            // AddFiltersButton
            // 
            this.AddFiltersButton.Location = new System.Drawing.Point(6, 51);
            this.AddFiltersButton.Name = "AddFiltersButton";
            this.AddFiltersButton.Size = new System.Drawing.Size(143, 39);
            this.AddFiltersButton.TabIndex = 6;
            this.AddFiltersButton.Text = "Add";
            this.AddFiltersButton.UseVisualStyleBackColor = true;
            this.AddFiltersButton.Click += new System.EventHandler(this.AddFiltersButton_Click);
            // 
            // FiltersGroupBox
            // 
            this.FiltersGroupBox.Controls.Add(this.SaveFiltersButton);
            this.FiltersGroupBox.Controls.Add(this.LoadFiltersButton);
            this.FiltersGroupBox.Controls.Add(this.EditFiltersButton);
            this.FiltersGroupBox.Controls.Add(this.AddFiltersButton);
            this.FiltersGroupBox.Controls.Add(this.DeleteFiltersButton);
            this.FiltersGroupBox.Location = new System.Drawing.Point(556, 12);
            this.FiltersGroupBox.Name = "FiltersGroupBox";
            this.FiltersGroupBox.Size = new System.Drawing.Size(400, 100);
            this.FiltersGroupBox.TabIndex = 12;
            this.FiltersGroupBox.TabStop = false;
            this.FiltersGroupBox.Text = "Filters";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 552);
            this.Controls.Add(this.FiltersGroupBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTabControl.ResumeLayout(false);
            this.ExamResultPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExamResultDGV)).EndInit();
            this.StudentTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDGV)).EndInit();
            this.FiltersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ExamResultPage;
        private System.Windows.Forms.DataGridView ExamResultDGV;
        private System.Windows.Forms.TabPage StudentTabPage;
        private System.Windows.Forms.DataGridView StudentsDGV;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.CheckedListBox ExamResultFiltersCheckedListBox;
        private System.Windows.Forms.CheckedListBox StudentFiltersCheckedListBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button LoadFiltersButton;
        private System.Windows.Forms.Button SaveFiltersButton;
        private System.Windows.Forms.Button DeleteFiltersButton;
        private System.Windows.Forms.Button EditFiltersButton;
        private System.Windows.Forms.Button AddFiltersButton;
        private System.Windows.Forms.GroupBox FiltersGroupBox;
    }
}

