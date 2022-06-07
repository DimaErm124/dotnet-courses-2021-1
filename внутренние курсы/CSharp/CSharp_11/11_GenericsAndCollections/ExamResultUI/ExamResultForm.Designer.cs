
namespace ExamResultUI
{
    partial class ExamResultForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.StudentsComboBox = new System.Windows.Forms.ComboBox();
            this.StudentLabel = new System.Windows.Forms.Label();
            this.ExamDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ExamDateLabel = new System.Windows.Forms.Label();
            this.ResultNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.CreateExamResultButton = new System.Windows.Forms.Button();
            this.ExamResultErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ResultNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamResultErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(41, 20);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(12, 38);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(349, 23);
            this.TitleTextBox.TabIndex = 2;
            this.TitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTextBox_Validating);
            this.TitleTextBox.Validated += new System.EventHandler(this.TitleTextBox_Validated);
            // 
            // StudentsComboBox
            // 
            this.StudentsComboBox.FormattingEnabled = true;
            this.StudentsComboBox.Location = new System.Drawing.Point(12, 106);
            this.StudentsComboBox.Name = "StudentsComboBox";
            this.StudentsComboBox.Size = new System.Drawing.Size(349, 23);
            this.StudentsComboBox.TabIndex = 4;
            this.StudentsComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.StudentsComboBox_Validating);
            this.StudentsComboBox.Validated += new System.EventHandler(this.StudentsComboBox_Validated);
            // 
            // StudentLabel
            // 
            this.StudentLabel.AutoSize = true;
            this.StudentLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentLabel.Location = new System.Drawing.Point(12, 83);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(63, 20);
            this.StudentLabel.TabIndex = 5;
            this.StudentLabel.Text = "Student:";
            // 
            // ExamDateTimePicker
            // 
            this.ExamDateTimePicker.Location = new System.Drawing.Point(12, 178);
            this.ExamDateTimePicker.Name = "ExamDateTimePicker";
            this.ExamDateTimePicker.Size = new System.Drawing.Size(349, 23);
            this.ExamDateTimePicker.TabIndex = 6;
            this.ExamDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.ExamDateTimePicker_Validating);
            this.ExamDateTimePicker.Validated += new System.EventHandler(this.ExamDateTimePicker_Validated);
            // 
            // ExamDateLabel
            // 
            this.ExamDateLabel.AutoSize = true;
            this.ExamDateLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExamDateLabel.Location = new System.Drawing.Point(12, 155);
            this.ExamDateLabel.Name = "ExamDateLabel";
            this.ExamDateLabel.Size = new System.Drawing.Size(82, 20);
            this.ExamDateLabel.TabIndex = 7;
            this.ExamDateLabel.Text = "Exam date:";
            // 
            // ResultNumericUpDown
            // 
            this.ResultNumericUpDown.Location = new System.Drawing.Point(12, 252);
            this.ResultNumericUpDown.Name = "ResultNumericUpDown";
            this.ResultNumericUpDown.Size = new System.Drawing.Size(349, 23);
            this.ResultNumericUpDown.TabIndex = 8;
            this.ResultNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.ResultNumericUpDown_Validating);
            this.ResultNumericUpDown.Validated += new System.EventHandler(this.ResultNumericUpDown_Validated);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultLabel.Location = new System.Drawing.Point(12, 229);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(52, 20);
            this.ResultLabel.TabIndex = 9;
            this.ResultLabel.Text = "Result:";
            // 
            // CreateExamResultButton
            // 
            this.CreateExamResultButton.Location = new System.Drawing.Point(12, 306);
            this.CreateExamResultButton.Name = "CreateExamResultButton";
            this.CreateExamResultButton.Size = new System.Drawing.Size(349, 41);
            this.CreateExamResultButton.TabIndex = 10;
            this.CreateExamResultButton.Text = "Create";
            this.CreateExamResultButton.UseVisualStyleBackColor = true;
            this.CreateExamResultButton.Click += new System.EventHandler(this.CreateExamResultButton_Click);
            // 
            // ExamResultErrorProvider
            // 
            this.ExamResultErrorProvider.ContainerControl = this;
            // 
            // ExamResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 366);
            this.Controls.Add(this.CreateExamResultButton);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ResultNumericUpDown);
            this.Controls.Add(this.ExamDateLabel);
            this.Controls.Add(this.ExamDateTimePicker);
            this.Controls.Add(this.StudentLabel);
            this.Controls.Add(this.StudentsComboBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExamResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamResultForm";
            this.Load += new System.EventHandler(this.ExamResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamResultErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ComboBox StudentsComboBox;
        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.DateTimePicker ExamDateTimePicker;
        private System.Windows.Forms.Label ExamDateLabel;
        private System.Windows.Forms.NumericUpDown ResultNumericUpDown;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button CreateExamResultButton;
        private System.Windows.Forms.ErrorProvider ExamResultErrorProvider;
    }
}