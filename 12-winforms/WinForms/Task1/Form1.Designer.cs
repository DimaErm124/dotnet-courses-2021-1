
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvUserRewards = new System.Windows.Forms.DataGridView();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.AddUserRewardButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.RewardTabPage = new System.Windows.Forms.TabPage();
            this.AddRewardButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRewards)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.UserTabPage.SuspendLayout();
            this.RewardTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(3, 2);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.Size = new System.Drawing.Size(460, 236);
            this.dgvUsers.TabIndex = 0;
            // 
            // dgvUserRewards
            // 
            this.dgvUserRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRewards.Location = new System.Drawing.Point(3, 255);
            this.dgvUserRewards.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUserRewards.Name = "dgvUserRewards";
            this.dgvUserRewards.RowHeadersWidth = 51;
            this.dgvUserRewards.Size = new System.Drawing.Size(460, 171);
            this.dgvUserRewards.TabIndex = 1;
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
            // AddUserRewardButton
            // 
            this.AddUserRewardButton.Location = new System.Drawing.Point(468, 42);
            this.AddUserRewardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddUserRewardButton.Name = "AddUserRewardButton";
            this.AddUserRewardButton.Size = new System.Drawing.Size(192, 36);
            this.AddUserRewardButton.TabIndex = 3;
            this.AddUserRewardButton.Text = "Add reward";
            this.AddUserRewardButton.UseVisualStyleBackColor = true;
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
            this.UserTabPage.Controls.Add(this.dgvUsers);
            this.UserTabPage.Controls.Add(this.AddUserRewardButton);
            this.UserTabPage.Controls.Add(this.dgvUserRewards);
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
            // RewardTabPage
            // 
            this.RewardTabPage.Controls.Add(this.AddRewardButton);
            this.RewardTabPage.Controls.Add(this.dataGridView1);
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
            this.AddRewardButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(460, 434);
            this.dataGridView1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 484);
            this.Controls.Add(this.MainTabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRewards)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.UserTabPage.ResumeLayout(false);
            this.RewardTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvUserRewards;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button AddUserRewardButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage RewardTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddRewardButton;
    }
}

