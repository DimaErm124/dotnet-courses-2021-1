
namespace AttendanceUI
{
    partial class MainForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.StudentTabPage = new System.Windows.Forms.TabPage();
            this.StudentDataGridView = new System.Windows.Forms.DataGridView();
            this.LectureTabPage = new System.Windows.Forms.TabPage();
            this.LectureDataGridView = new System.Windows.Forms.DataGridView();
            this.MarkTabPage = new System.Windows.Forms.TabPage();
            this.MarksDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.StudentTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).BeginInit();
            this.LectureTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LectureDataGridView)).BeginInit();
            this.MarkTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.StudentTabPage);
            this.MainTabControl.Controls.Add(this.LectureTabPage);
            this.MainTabControl.Controls.Add(this.MarkTabPage);
            this.MainTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTabControl.Location = new System.Drawing.Point(12, 53);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(398, 375);
            this.MainTabControl.TabIndex = 0;
            // 
            // StudentTabPage
            // 
            this.StudentTabPage.Controls.Add(this.StudentDataGridView);
            this.StudentTabPage.Location = new System.Drawing.Point(4, 24);
            this.StudentTabPage.Name = "StudentTabPage";
            this.StudentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StudentTabPage.Size = new System.Drawing.Size(390, 347);
            this.StudentTabPage.TabIndex = 0;
            this.StudentTabPage.Text = "Students";
            this.StudentTabPage.UseVisualStyleBackColor = true;
            // 
            // StudentDataGridView
            // 
            this.StudentDataGridView.AllowUserToAddRows = false;
            this.StudentDataGridView.AllowUserToDeleteRows = false;
            this.StudentDataGridView.AllowUserToResizeColumns = false;
            this.StudentDataGridView.AllowUserToResizeRows = false;
            this.StudentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGridView.Location = new System.Drawing.Point(6, 6);
            this.StudentDataGridView.Name = "StudentDataGridView";
            this.StudentDataGridView.RowTemplate.Height = 25;
            this.StudentDataGridView.Size = new System.Drawing.Size(378, 335);
            this.StudentDataGridView.TabIndex = 1;
            // 
            // LectureTabPage
            // 
            this.LectureTabPage.Controls.Add(this.LectureDataGridView);
            this.LectureTabPage.Location = new System.Drawing.Point(4, 24);
            this.LectureTabPage.Name = "LectureTabPage";
            this.LectureTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LectureTabPage.Size = new System.Drawing.Size(390, 347);
            this.LectureTabPage.TabIndex = 1;
            this.LectureTabPage.Text = "Lectures";
            this.LectureTabPage.UseVisualStyleBackColor = true;
            // 
            // LectureDataGridView
            // 
            this.LectureDataGridView.AllowUserToAddRows = false;
            this.LectureDataGridView.AllowUserToDeleteRows = false;
            this.LectureDataGridView.AllowUserToResizeColumns = false;
            this.LectureDataGridView.AllowUserToResizeRows = false;
            this.LectureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LectureDataGridView.Location = new System.Drawing.Point(6, 6);
            this.LectureDataGridView.Name = "LectureDataGridView";
            this.LectureDataGridView.RowTemplate.Height = 25;
            this.LectureDataGridView.Size = new System.Drawing.Size(378, 335);
            this.LectureDataGridView.TabIndex = 1;
            // 
            // MarkTabPage
            // 
            this.MarkTabPage.Controls.Add(this.MarksDataGridView);
            this.MarkTabPage.Location = new System.Drawing.Point(4, 24);
            this.MarkTabPage.Name = "MarkTabPage";
            this.MarkTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MarkTabPage.Size = new System.Drawing.Size(390, 347);
            this.MarkTabPage.TabIndex = 2;
            this.MarkTabPage.Text = "Marks";
            this.MarkTabPage.UseVisualStyleBackColor = true;
            // 
            // MarksDataGridView
            // 
            this.MarksDataGridView.AllowUserToAddRows = false;
            this.MarksDataGridView.AllowUserToDeleteRows = false;
            this.MarksDataGridView.AllowUserToResizeColumns = false;
            this.MarksDataGridView.AllowUserToResizeRows = false;
            this.MarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MarksDataGridView.Location = new System.Drawing.Point(6, 6);
            this.MarksDataGridView.Name = "MarksDataGridView";
            this.MarksDataGridView.RowTemplate.Height = 25;
            this.MarksDataGridView.Size = new System.Drawing.Size(378, 335);
            this.MarksDataGridView.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(308, 12);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(102, 35);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(142, 35);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(160, 12);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(142, 35);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTabControl.ResumeLayout(false);
            this.StudentTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).EndInit();
            this.LectureTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LectureDataGridView)).EndInit();
            this.MarkTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MarksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage StudentTabPage;
        private System.Windows.Forms.TabPage LectureTabPage;
        private System.Windows.Forms.TabPage MarkTabPage;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.DataGridView StudentDataGridView;
        private System.Windows.Forms.DataGridView LectureDataGridView;
        private System.Windows.Forms.DataGridView MarksDataGridView;
    }
}