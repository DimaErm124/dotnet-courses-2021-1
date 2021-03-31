
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.RewardTabPage = new System.Windows.Forms.TabPage();
            this.AddRewardButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.dgvUsers.Location = new System.Drawing.Point(3, 3);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.Size = new System.Drawing.Size(526, 315);
            this.dgvUsers.TabIndex = 0;
            // 
            // dgvUserRewards
            // 
            this.dgvUserRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRewards.Location = new System.Drawing.Point(3, 340);
            this.dgvUserRewards.Name = "dgvUserRewards";
            this.dgvUserRewards.RowHeadersWidth = 51;
            this.dgvUserRewards.Size = new System.Drawing.Size(526, 228);
            this.dgvUserRewards.TabIndex = 1;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(535, 3);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(219, 48);
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
            this.MainTabControl.Location = new System.Drawing.Point(11, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(769, 621);
            this.MainTabControl.TabIndex = 4;
            // 
            // UserTabPage
            // 
            this.UserTabPage.Controls.Add(this.button2);
            this.UserTabPage.Controls.Add(this.button1);
            this.UserTabPage.Controls.Add(this.dgvUsers);
            this.UserTabPage.Controls.Add(this.dgvUserRewards);
            this.UserTabPage.Controls.Add(this.AddUserButton);
            this.UserTabPage.Location = new System.Drawing.Point(4, 29);
            this.UserTabPage.Name = "UserTabPage";
            this.UserTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.UserTabPage.Size = new System.Drawing.Size(761, 588);
            this.UserTabPage.TabIndex = 0;
            this.UserTabPage.Text = "Users";
            this.UserTabPage.UseVisualStyleBackColor = true;
            // 
            // RewardTabPage
            // 
            this.RewardTabPage.Controls.Add(this.AddRewardButton);
            this.RewardTabPage.Controls.Add(this.dataGridView1);
            this.RewardTabPage.Location = new System.Drawing.Point(4, 29);
            this.RewardTabPage.Name = "RewardTabPage";
            this.RewardTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.RewardTabPage.Size = new System.Drawing.Size(761, 588);
            this.RewardTabPage.TabIndex = 1;
            this.RewardTabPage.Text = "Rewards";
            this.RewardTabPage.UseVisualStyleBackColor = true;
            // 
            // AddRewardButton
            // 
            this.AddRewardButton.Location = new System.Drawing.Point(536, 3);
            this.AddRewardButton.Name = "AddRewardButton";
            this.AddRewardButton.Size = new System.Drawing.Size(219, 48);
            this.AddRewardButton.TabIndex = 2;
            this.AddRewardButton.Text = "Add reward";
            this.AddRewardButton.UseVisualStyleBackColor = true;
            this.AddRewardButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(526, 579);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Edit user";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete user";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.MainTabControl);
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
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage RewardTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddRewardButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

