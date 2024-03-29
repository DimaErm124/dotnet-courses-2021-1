﻿namespace PL
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.BirthdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateUserButton = new System.Windows.Forms.Button();
            this.AddOrEditUserErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.UserRewardsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.AddOrEditUserErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(11, 37);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(426, 27);
            this.FirstNameTextBox.TabIndex = 0;
            this.FirstNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.FirstNameTextBox_Validating);
            this.FirstNameTextBox.Validated += new System.EventHandler(this.FirstNameTextBox_Validated);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(11, 101);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(426, 27);
            this.LastNameTextBox.TabIndex = 1;
            this.LastNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.LastNameTextBox_Validating);
            this.LastNameTextBox.Validated += new System.EventHandler(this.LastNameTextBox_Validated);
            // 
            // BirthdateTimePicker
            // 
            this.BirthdateTimePicker.Location = new System.Drawing.Point(11, 171);
            this.BirthdateTimePicker.Name = "BirthdateTimePicker";
            this.BirthdateTimePicker.Size = new System.Drawing.Size(426, 27);
            this.BirthdateTimePicker.TabIndex = 2;
            this.BirthdateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.BirthdateTimePicker_Validating);
            this.BirthdateTimePicker.Validated += new System.EventHandler(this.BirthdateTimePicker_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fisrt name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birthdate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rewards:";
            // 
            // CreateUserButton
            // 
            this.CreateUserButton.Location = new System.Drawing.Point(11, 575);
            this.CreateUserButton.Name = "CreateUserButton";
            this.CreateUserButton.Size = new System.Drawing.Size(426, 48);
            this.CreateUserButton.TabIndex = 10;
            this.CreateUserButton.Text = "Create";
            this.CreateUserButton.UseVisualStyleBackColor = true;
            this.CreateUserButton.Click += new System.EventHandler(this.CreateUserButton_Click);
            // 
            // AddOrEditUserErrorProvider
            // 
            this.AddOrEditUserErrorProvider.ContainerControl = this;
            // 
            // UserRewardsCheckedListBox
            // 
            this.UserRewardsCheckedListBox.FormattingEnabled = true;
            this.UserRewardsCheckedListBox.Location = new System.Drawing.Point(11, 245);
            this.UserRewardsCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserRewardsCheckedListBox.Name = "UserRewardsCheckedListBox";
            this.UserRewardsCheckedListBox.Size = new System.Drawing.Size(426, 312);
            this.UserRewardsCheckedListBox.TabIndex = 11;
            this.UserRewardsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.UserRewardsCheckedListBox_ItemCheck);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 637);
            this.Controls.Add(this.UserRewardsCheckedListBox);
            this.Controls.Add(this.CreateUserButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BirthdateTimePicker);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AddOrEditUserErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.DateTimePicker BirthdateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateUserButton;
        private System.Windows.Forms.ErrorProvider AddOrEditUserErrorProvider;
        private System.Windows.Forms.CheckedListBox UserRewardsCheckedListBox;
    }
}