
namespace Task1
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
            this.UsersDGV = new System.Windows.Forms.DataGridView();
            this.UserRewardsDGV = new System.Windows.Forms.DataGridView();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.DeleteUserButton = new System.Windows.Forms.Button();
            this.EditUserButton = new System.Windows.Forms.Button();
            this.RewardTabPage = new System.Windows.Forms.TabPage();
            this.AddRewardButton = new System.Windows.Forms.Button();
            this.RewardsDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRewardsDGV)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.UserTabPage.SuspendLayout();
            this.RewardTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RewardsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDGV
            // 
            this.UsersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDGV.Location = new System.Drawing.Point(3, 2);
            this.UsersDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsersDGV.Name = "UsersDGV";
            this.UsersDGV.RowHeadersWidth = 51;
            this.UsersDGV.Size = new System.Drawing.Size(460, 236);
            this.UsersDGV.TabIndex = 0;
            this.UsersDGV.Enter += new System.EventHandler(this.UsersDGV_Enter);
            this.UsersDGV.Leave += new System.EventHandler(this.UsersDGV_Leave);
            // 
            // UserRewardsDGV
            // 
            this.UserRewardsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserRewardsDGV.Location = new System.Drawing.Point(3, 255);
            this.UserRewardsDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserRewardsDGV.Name = "UserRewardsDGV";
            this.UserRewardsDGV.RowHeadersWidth = 51;
            this.UserRewardsDGV.Size = new System.Drawing.Size(460, 171);
            this.UserRewardsDGV.TabIndex = 1;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(468, 2);
            this.AddUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(192, 36);
            this.AddUserButton.TabIndex = 2;
            this.AddUserButton.Text = "Add user";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.UserTabPage);
            this.MainTabControl.Controls.Add(this.RewardTabPage);
            this.MainTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainTabControl.Location = new System.Drawing.Point(10, 9);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(673, 466);
            this.MainTabControl.TabIndex = 4;
            // 
            // UserTabPage
            // 
            this.UserTabPage.Controls.Add(this.DeleteUserButton);
            this.UserTabPage.Controls.Add(this.EditUserButton);
            this.UserTabPage.Controls.Add(this.UsersDGV);
            this.UserTabPage.Controls.Add(this.UserRewardsDGV);
            this.UserTabPage.Controls.Add(this.AddUserButton);
            this.UserTabPage.Location = new System.Drawing.Point(4, 24);
            this.UserTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserTabPage.Name = "UserTabPage";
            this.UserTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserTabPage.Size = new System.Drawing.Size(665, 438);
            this.UserTabPage.TabIndex = 0;
            this.UserTabPage.Text = "Users";
            this.UserTabPage.UseVisualStyleBackColor = true;
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Location = new System.Drawing.Point(468, 390);
            this.DeleteUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(192, 36);
            this.DeleteUserButton.TabIndex = 4;
            this.DeleteUserButton.Text = "Delete user";
            this.DeleteUserButton.UseVisualStyleBackColor = true;
            // 
            // EditUserButton
            // 
            this.EditUserButton.Location = new System.Drawing.Point(468, 43);
            this.EditUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(192, 36);
            this.EditUserButton.TabIndex = 3;
            this.EditUserButton.Text = "Edit user";
            this.EditUserButton.UseVisualStyleBackColor = true;
            this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // RewardTabPage
            // 
            this.RewardTabPage.Controls.Add(this.AddRewardButton);
            this.RewardTabPage.Controls.Add(this.RewardsDGV);
            this.RewardTabPage.Location = new System.Drawing.Point(4, 24);
            this.RewardTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardTabPage.Name = "RewardTabPage";
            this.RewardTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardTabPage.Size = new System.Drawing.Size(665, 438);
            this.RewardTabPage.TabIndex = 1;
            this.RewardTabPage.Text = "Rewards";
            this.RewardTabPage.UseVisualStyleBackColor = true;
            // 
            // AddRewardButton
            // 
            this.AddRewardButton.Location = new System.Drawing.Point(469, 2);
            this.AddRewardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddRewardButton.Name = "AddRewardButton";
            this.AddRewardButton.Size = new System.Drawing.Size(192, 36);
            this.AddRewardButton.TabIndex = 2;
            this.AddRewardButton.Text = "Add reward";
            this.AddRewardButton.UseVisualStyleBackColor = true;
            this.AddRewardButton.Click += new System.EventHandler(this.AddRewardButton_Click);
            // 
            // RewardsDGV
            // 
            this.RewardsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RewardsDGV.Location = new System.Drawing.Point(3, 2);
            this.RewardsDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardsDGV.Name = "RewardsDGV";
            this.RewardsDGV.RowHeadersWidth = 51;
            this.RewardsDGV.Size = new System.Drawing.Size(460, 434);
            this.RewardsDGV.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 484);
            this.Controls.Add(this.MainTabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRewardsDGV)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.UserTabPage.ResumeLayout(false);
            this.RewardTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RewardsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersDGV;
        private System.Windows.Forms.DataGridView UserRewardsDGV;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage RewardTabPage;
        private System.Windows.Forms.DataGridView RewardsDGV;
        private System.Windows.Forms.Button AddRewardButton;
        private System.Windows.Forms.Button DeleteUserButton;
        private System.Windows.Forms.Button EditUserButton;
    }
}

