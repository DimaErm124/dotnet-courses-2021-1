
namespace PL
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
            this.AddButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.RewardTabPage = new System.Windows.Forms.TabPage();
            this.RewardsDGV = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
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
            this.UsersDGV.AllowUserToAddRows = false;
            this.UsersDGV.AllowUserToDeleteRows = false;
            this.UsersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDGV.Location = new System.Drawing.Point(3, 2);
            this.UsersDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsersDGV.Name = "UsersDGV";
            this.UsersDGV.ReadOnly = true;
            this.UsersDGV.RowHeadersWidth = 51;
            this.UsersDGV.Size = new System.Drawing.Size(460, 236);
            this.UsersDGV.TabIndex = 0;
            this.UsersDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDGV_CellEnter);
            this.UsersDGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDGV_CellLeave);
            this.UsersDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UsersDGV_ColumnHeaderMouseClick);
            // 
            // UserRewardsDGV
            // 
            this.UserRewardsDGV.AllowUserToAddRows = false;
            this.UserRewardsDGV.AllowUserToDeleteRows = false;
            this.UserRewardsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserRewardsDGV.Location = new System.Drawing.Point(3, 255);
            this.UserRewardsDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserRewardsDGV.Name = "UserRewardsDGV";
            this.UserRewardsDGV.ReadOnly = true;
            this.UserRewardsDGV.RowHeadersWidth = 51;
            this.UserRewardsDGV.Size = new System.Drawing.Size(460, 171);
            this.UserRewardsDGV.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(498, 35);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(192, 36);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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
            this.MainTabControl.Size = new System.Drawing.Size(482, 466);
            this.MainTabControl.TabIndex = 4;
            this.MainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.MainTabControl_Selected);
            // 
            // UserTabPage
            // 
            this.UserTabPage.Controls.Add(this.UsersDGV);
            this.UserTabPage.Controls.Add(this.UserRewardsDGV);
            this.UserTabPage.Location = new System.Drawing.Point(4, 24);
            this.UserTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserTabPage.Name = "UserTabPage";
            this.UserTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserTabPage.Size = new System.Drawing.Size(474, 438);
            this.UserTabPage.TabIndex = 0;
            this.UserTabPage.Text = "Users";
            this.UserTabPage.UseVisualStyleBackColor = true;
            // 
            // RewardTabPage
            // 
            this.RewardTabPage.Controls.Add(this.RewardsDGV);
            this.RewardTabPage.Location = new System.Drawing.Point(4, 24);
            this.RewardTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardTabPage.Name = "RewardTabPage";
            this.RewardTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardTabPage.Size = new System.Drawing.Size(474, 438);
            this.RewardTabPage.TabIndex = 1;
            this.RewardTabPage.Text = "Rewards";
            this.RewardTabPage.UseVisualStyleBackColor = true;
            // 
            // RewardsDGV
            // 
            this.RewardsDGV.AllowUserToAddRows = false;
            this.RewardsDGV.AllowUserToDeleteRows = false;
            this.RewardsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RewardsDGV.Location = new System.Drawing.Point(3, 2);
            this.RewardsDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RewardsDGV.Name = "RewardsDGV";
            this.RewardsDGV.ReadOnly = true;
            this.RewardsDGV.RowHeadersWidth = 51;
            this.RewardsDGV.Size = new System.Drawing.Size(460, 434);
            this.RewardsDGV.TabIndex = 1;
            this.RewardsDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RewardsDGV_ColumnHeaderMouseClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(498, 423);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(192, 36);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(498, 75);
            this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(192, 36);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 484);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
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
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage RewardTabPage;
        private System.Windows.Forms.DataGridView RewardsDGV;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
    }
}

