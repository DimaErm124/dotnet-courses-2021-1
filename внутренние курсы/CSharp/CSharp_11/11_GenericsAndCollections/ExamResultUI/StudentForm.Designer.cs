
namespace ExamResultUI
{
    partial class StudentForm
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNamelabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.GroupNumberLabel = new System.Windows.Forms.Label();
            this.GroupNumberTextBox = new System.Windows.Forms.TextBox();
            this.CreateStudentButton = new System.Windows.Forms.Button();
            this.StudentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StudentErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 38);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(349, 23);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            this.NameTextBox.Validated += new System.EventHandler(this.NameTextBox_Validated);
            // 
            // FirstNamelabel
            // 
            this.FirstNamelabel.AutoSize = true;
            this.FirstNamelabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FirstNamelabel.Location = new System.Drawing.Point(12, 9);
            this.FirstNamelabel.Name = "FirstNamelabel";
            this.FirstNamelabel.Size = new System.Drawing.Size(52, 20);
            this.FirstNamelabel.TabIndex = 1;
            this.FirstNamelabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Surname:";
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(12, 100);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(349, 23);
            this.SurnameTextBox.TabIndex = 2;
            this.SurnameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SurnameTextBox_Validating);
            this.SurnameTextBox.Validated += new System.EventHandler(this.SurnameTextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(11, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Middle name:";
            // 
            // MiddleNameTextBox
            // 
            this.MiddleNameTextBox.Location = new System.Drawing.Point(11, 163);
            this.MiddleNameTextBox.Name = "MiddleNameTextBox";
            this.MiddleNameTextBox.Size = new System.Drawing.Size(349, 23);
            this.MiddleNameTextBox.TabIndex = 4;
            this.MiddleNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.MiddleNameTextBox_Validating);
            this.MiddleNameTextBox.Validated += new System.EventHandler(this.MiddleNameTextBox_Validated);
            // 
            // GroupNumberLabel
            // 
            this.GroupNumberLabel.AutoSize = true;
            this.GroupNumberLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GroupNumberLabel.Location = new System.Drawing.Point(12, 199);
            this.GroupNumberLabel.Name = "GroupNumberLabel";
            this.GroupNumberLabel.Size = new System.Drawing.Size(74, 20);
            this.GroupNumberLabel.TabIndex = 7;
            this.GroupNumberLabel.Text = "Group №:";
            // 
            // GroupNumberTextBox
            // 
            this.GroupNumberTextBox.Location = new System.Drawing.Point(12, 228);
            this.GroupNumberTextBox.Name = "GroupNumberTextBox";
            this.GroupNumberTextBox.Size = new System.Drawing.Size(349, 23);
            this.GroupNumberTextBox.TabIndex = 6;
            this.GroupNumberTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.GroupNumberTextBox_Validating);
            this.GroupNumberTextBox.Validated += new System.EventHandler(this.GroupNumberTextBox_Validated);
            // 
            // CreateStudentButton
            // 
            this.CreateStudentButton.Location = new System.Drawing.Point(12, 273);
            this.CreateStudentButton.Name = "CreateStudentButton";
            this.CreateStudentButton.Size = new System.Drawing.Size(349, 41);
            this.CreateStudentButton.TabIndex = 8;
            this.CreateStudentButton.Text = "Create";
            this.CreateStudentButton.UseVisualStyleBackColor = true;
            this.CreateStudentButton.Click += new System.EventHandler(this.CreateStudentButton_Click);
            // 
            // StudentErrorProvider
            // 
            this.StudentErrorProvider.ContainerControl = this;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 326);
            this.Controls.Add(this.CreateStudentButton);
            this.Controls.Add(this.GroupNumberLabel);
            this.Controls.Add(this.GroupNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MiddleNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.FirstNamelabel);
            this.Controls.Add(this.NameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.StudentErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label FirstNamelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MiddleNameTextBox;
        private System.Windows.Forms.Label GroupNumberLabel;
        private System.Windows.Forms.TextBox GroupNumberTextBox;
        private System.Windows.Forms.Button CreateStudentButton;
        private System.Windows.Forms.ErrorProvider StudentErrorProvider;
    }
}