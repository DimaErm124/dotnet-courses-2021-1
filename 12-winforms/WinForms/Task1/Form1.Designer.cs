
namespace Task1
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvUserRewards = new System.Windows.Forms.DataGridView();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.AddRewardButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.RewardTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRewards)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.UserTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(3, 35);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 29;
            this.dgvUsers.Size = new System.Drawing.Size(526, 282);
            this.dgvUsers.TabIndex = 0;
            // 
            // dgvUserRewards
            // 
            this.dgvUserRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRewards.Location = new System.Drawing.Point(3, 353);
            this.dgvUserRewards.Name = "dgvUserRewards";
            this.dgvUserRewards.RowHeadersWidth = 51;
            this.dgvUserRewards.RowTemplate.Height = 29;
            this.dgvUserRewards.Size = new System.Drawing.Size(526, 232);
            this.dgvUserRewards.TabIndex = 1;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(535, 35);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(219, 48);
            this.AddUserButton.TabIndex = 2;
            this.AddUserButton.Text = "Add user";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // AddRewardButton
            // 
            this.AddRewardButton.Location = new System.Drawing.Point(535, 89);
            this.AddRewardButton.Name = "AddRewardButton";
            this.AddRewardButton.Size = new System.Drawing.Size(219, 48);
            this.AddRewardButton.TabIndex = 3;
            this.AddRewardButton.Text = "Add reward";
            this.AddRewardButton.UseVisualStyleBackColor = true;
            this.AddRewardButton.Click += new System.EventHandler(this.AddRewardButton_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.UserTabPage);
            this.MainTabControl.Controls.Add(this.RewardTabPage);
            this.MainTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(769, 621);
            this.MainTabControl.TabIndex = 4;
            // 
            // UserTabPage
            // 
            this.UserTabPage.Controls.Add(this.label2);
            this.UserTabPage.Controls.Add(this.label1);
            this.UserTabPage.Controls.Add(this.dgvUsers);
            this.UserTabPage.Controls.Add(this.AddRewardButton);
            this.UserTabPage.Controls.Add(this.dgvUserRewards);
            this.UserTabPage.Controls.Add(this.AddUserButton);
            this.UserTabPage.Location = new System.Drawing.Point(4, 29);
            this.UserTabPage.Name = "UserTabPage";
            this.UserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UserTabPage.Size = new System.Drawing.Size(761, 588);
            this.UserTabPage.TabIndex = 0;
            this.UserTabPage.Text = "Users";
            this.UserTabPage.UseVisualStyleBackColor = true;
            this.UserTabPage.Click += new System.EventHandler(this.UserTabPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Users:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RewardTabPage
            // 
            this.RewardTabPage.Location = new System.Drawing.Point(4, 29);
            this.RewardTabPage.Name = "RewardTabPage";
            this.RewardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RewardTabPage.Size = new System.Drawing.Size(761, 588);
            this.RewardTabPage.TabIndex = 1;
            this.RewardTabPage.Text = "Rewards";
            this.RewardTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rewards of user:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.MainTabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRewards)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.UserTabPage.ResumeLayout(false);
            this.UserTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvUserRewards;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button AddRewardButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage RewardTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

