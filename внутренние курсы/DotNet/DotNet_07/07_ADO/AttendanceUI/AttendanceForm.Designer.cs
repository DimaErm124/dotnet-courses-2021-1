
namespace AttendanceUI
{
    partial class AttendanceForm
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
            this.LectureLabel = new System.Windows.Forms.Label();
            this.MarkLabel = new System.Windows.Forms.Label();
            this.AttendanceButton = new System.Windows.Forms.Button();
            this.StudentLabel = new System.Windows.Forms.Label();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.LectureComboBox = new System.Windows.Forms.ComboBox();
            this.MarkNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AttendanceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MarkNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LectureLabel
            // 
            this.LectureLabel.AutoSize = true;
            this.LectureLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureLabel.Location = new System.Drawing.Point(12, 63);
            this.LectureLabel.Name = "LectureLabel";
            this.LectureLabel.Size = new System.Drawing.Size(60, 20);
            this.LectureLabel.TabIndex = 12;
            this.LectureLabel.Text = "Lecture:";
            // 
            // MarkLabel
            // 
            this.MarkLabel.AutoSize = true;
            this.MarkLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MarkLabel.Location = new System.Drawing.Point(12, 124);
            this.MarkLabel.Name = "MarkLabel";
            this.MarkLabel.Size = new System.Drawing.Size(45, 20);
            this.MarkLabel.TabIndex = 10;
            this.MarkLabel.Text = "Mark:";
            // 
            // AttendanceButton
            // 
            this.AttendanceButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AttendanceButton.Location = new System.Drawing.Point(55, 200);
            this.AttendanceButton.Name = "AttendanceButton";
            this.AttendanceButton.Size = new System.Drawing.Size(183, 30);
            this.AttendanceButton.TabIndex = 9;
            this.AttendanceButton.Text = "button1";
            this.AttendanceButton.UseVisualStyleBackColor = true;
            this.AttendanceButton.Click += new System.EventHandler(this.AttendanceButton_Click);
            // 
            // StudentLabel
            // 
            this.StudentLabel.AutoSize = true;
            this.StudentLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentLabel.Location = new System.Drawing.Point(12, 9);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(63, 20);
            this.StudentLabel.TabIndex = 15;
            this.StudentLabel.Text = "Student:";
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(12, 32);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(267, 28);
            this.StudentComboBox.TabIndex = 16;
            this.StudentComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.StudentComboBox_Validating);
            this.StudentComboBox.Validated += new System.EventHandler(this.StudentComboBox_Validated);
            // 
            // LectureComboBox
            // 
            this.LectureComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureComboBox.FormattingEnabled = true;
            this.LectureComboBox.Location = new System.Drawing.Point(12, 86);
            this.LectureComboBox.Name = "LectureComboBox";
            this.LectureComboBox.Size = new System.Drawing.Size(267, 28);
            this.LectureComboBox.TabIndex = 17;
            this.LectureComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.LectureComboBox_Validating);
            this.LectureComboBox.Validated += new System.EventHandler(this.LectureComboBox_Validated);
            // 
            // MarkNumericUpDown
            // 
            this.MarkNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MarkNumericUpDown.Location = new System.Drawing.Point(12, 147);
            this.MarkNumericUpDown.Name = "MarkNumericUpDown";
            this.MarkNumericUpDown.Size = new System.Drawing.Size(267, 27);
            this.MarkNumericUpDown.TabIndex = 18;
            this.MarkNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.MarkNumericUpDown_Validating);
            this.MarkNumericUpDown.Validated += new System.EventHandler(this.MarkNumericUpDown_Validated);
            // 
            // AttendanceErrorProvider
            // 
            this.AttendanceErrorProvider.ContainerControl = this;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 248);
            this.Controls.Add(this.MarkNumericUpDown);
            this.Controls.Add(this.LectureComboBox);
            this.Controls.Add(this.StudentComboBox);
            this.Controls.Add(this.StudentLabel);
            this.Controls.Add(this.LectureLabel);
            this.Controls.Add(this.MarkLabel);
            this.Controls.Add(this.AttendanceButton);
            this.Name = "AttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceForm";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MarkNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LectureLabel;
        private System.Windows.Forms.Label MarkLabel;
        private System.Windows.Forms.Button AttendanceButton;
        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.ComboBox StudentComboBox;
        private System.Windows.Forms.ComboBox LectureComboBox;
        private System.Windows.Forms.NumericUpDown MarkNumericUpDown;
        private System.Windows.Forms.ErrorProvider AttendanceErrorProvider;
    }
}