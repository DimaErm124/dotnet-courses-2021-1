
namespace ExamResultUI
{
    partial class FilterForm
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
            this.TitleCheckBox = new System.Windows.Forms.CheckBox();
            this.StudentCheckBox = new System.Windows.Forms.CheckBox();
            this.ResultCheckBox = new System.Windows.Forms.CheckBox();
            this.ExamDateCheckBox = new System.Windows.Forms.CheckBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AddStudentFilterButton = new System.Windows.Forms.Button();
            this.StudentFilterLabel = new System.Windows.Forms.Label();
            this.EqualDateRadioButton = new System.Windows.Forms.RadioButton();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.MaxDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EqualDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BetweenDateRadioButton = new System.Windows.Forms.RadioButton();
            this.NumberGroupBox = new System.Windows.Forms.GroupBox();
            this.MinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EqualNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BetweenNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.EqualNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.AddFilterButton = new System.Windows.Forms.Button();
            this.FilterFormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DateGroupBox.SuspendLayout();
            this.NumberGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqualNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterFormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleCheckBox
            // 
            this.TitleCheckBox.AutoSize = true;
            this.TitleCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleCheckBox.Location = new System.Drawing.Point(12, 12);
            this.TitleCheckBox.Name = "TitleCheckBox";
            this.TitleCheckBox.Size = new System.Drawing.Size(57, 24);
            this.TitleCheckBox.TabIndex = 0;
            this.TitleCheckBox.Text = "Title";
            this.TitleCheckBox.UseVisualStyleBackColor = true;
            this.TitleCheckBox.Validated += new System.EventHandler(this.TitleCheckBox_Validated);
            // 
            // StudentCheckBox
            // 
            this.StudentCheckBox.AutoSize = true;
            this.StudentCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentCheckBox.Location = new System.Drawing.Point(12, 45);
            this.StudentCheckBox.Name = "StudentCheckBox";
            this.StudentCheckBox.Size = new System.Drawing.Size(79, 24);
            this.StudentCheckBox.TabIndex = 1;
            this.StudentCheckBox.Text = "Student";
            this.StudentCheckBox.UseVisualStyleBackColor = true;
            this.StudentCheckBox.Validated += new System.EventHandler(this.StudentCheckBox_Validated);
            // 
            // ResultCheckBox
            // 
            this.ResultCheckBox.AutoSize = true;
            this.ResultCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultCheckBox.Location = new System.Drawing.Point(12, 317);
            this.ResultCheckBox.Name = "ResultCheckBox";
            this.ResultCheckBox.Size = new System.Drawing.Size(68, 24);
            this.ResultCheckBox.TabIndex = 2;
            this.ResultCheckBox.Text = "Result";
            this.ResultCheckBox.UseVisualStyleBackColor = true;
            this.ResultCheckBox.Validated += new System.EventHandler(this.ResultCheckBox_Validated);
            // 
            // ExamDateCheckBox
            // 
            this.ExamDateCheckBox.AutoSize = true;
            this.ExamDateCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExamDateCheckBox.Location = new System.Drawing.Point(12, 111);
            this.ExamDateCheckBox.Name = "ExamDateCheckBox";
            this.ExamDateCheckBox.Size = new System.Drawing.Size(98, 24);
            this.ExamDateCheckBox.TabIndex = 3;
            this.ExamDateCheckBox.Text = "Exam date";
            this.ExamDateCheckBox.UseVisualStyleBackColor = true;
            this.ExamDateCheckBox.Validated += new System.EventHandler(this.ExamDateCheckBox_Validated);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(75, 12);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(250, 23);
            this.TitleTextBox.TabIndex = 4;
            this.TitleTextBox.Validated += new System.EventHandler(this.TitleTextBox_Validated);
            // 
            // AddStudentFilterButton
            // 
            this.AddStudentFilterButton.Location = new System.Drawing.Point(97, 45);
            this.AddStudentFilterButton.Name = "AddStudentFilterButton";
            this.AddStudentFilterButton.Size = new System.Drawing.Size(228, 24);
            this.AddStudentFilterButton.TabIndex = 5;
            this.AddStudentFilterButton.Text = "add student filter";
            this.AddStudentFilterButton.UseVisualStyleBackColor = true;
            this.AddStudentFilterButton.Click += new System.EventHandler(this.StudentFilterButton_Click);
            // 
            // StudentFilterLabel
            // 
            this.StudentFilterLabel.AutoSize = true;
            this.StudentFilterLabel.Location = new System.Drawing.Point(30, 78);
            this.StudentFilterLabel.Name = "StudentFilterLabel";
            this.StudentFilterLabel.Size = new System.Drawing.Size(13, 15);
            this.StudentFilterLabel.TabIndex = 7;
            this.StudentFilterLabel.Text = "1";
            // 
            // EqualDateRadioButton
            // 
            this.EqualDateRadioButton.AutoSize = true;
            this.EqualDateRadioButton.Location = new System.Drawing.Point(18, 22);
            this.EqualDateRadioButton.Name = "EqualDateRadioButton";
            this.EqualDateRadioButton.Size = new System.Drawing.Size(54, 19);
            this.EqualDateRadioButton.TabIndex = 8;
            this.EqualDateRadioButton.TabStop = true;
            this.EqualDateRadioButton.Text = "equal";
            this.EqualDateRadioButton.UseVisualStyleBackColor = true;
            this.EqualDateRadioButton.Validated += new System.EventHandler(this.EqualDateRadioButton_Validated);
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Controls.Add(this.MaxDateTimePicker);
            this.DateGroupBox.Controls.Add(this.MinDateTimePicker);
            this.DateGroupBox.Controls.Add(this.EqualDateTimePicker);
            this.DateGroupBox.Controls.Add(this.BetweenDateRadioButton);
            this.DateGroupBox.Controls.Add(this.EqualDateRadioButton);
            this.DateGroupBox.Location = new System.Drawing.Point(22, 131);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(303, 176);
            this.DateGroupBox.TabIndex = 9;
            this.DateGroupBox.TabStop = false;
            // 
            // MaxDateTimePicker
            // 
            this.MaxDateTimePicker.Location = new System.Drawing.Point(28, 130);
            this.MaxDateTimePicker.Name = "MaxDateTimePicker";
            this.MaxDateTimePicker.Size = new System.Drawing.Size(269, 23);
            this.MaxDateTimePicker.TabIndex = 12;
            this.MaxDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.MaxDateTimePicker_Validating);
            this.MaxDateTimePicker.Validated += new System.EventHandler(this.MaxDateTimePicker_Validated);
            // 
            // MinDateTimePicker
            // 
            this.MinDateTimePicker.Location = new System.Drawing.Point(28, 101);
            this.MinDateTimePicker.Name = "MinDateTimePicker";
            this.MinDateTimePicker.Size = new System.Drawing.Size(269, 23);
            this.MinDateTimePicker.TabIndex = 11;
            this.MinDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.MinDateTimePicker_Validating);
            this.MinDateTimePicker.Validated += new System.EventHandler(this.MinDateTimePicker_Validated);
            // 
            // EqualDateTimePicker
            // 
            this.EqualDateTimePicker.Location = new System.Drawing.Point(28, 47);
            this.EqualDateTimePicker.Name = "EqualDateTimePicker";
            this.EqualDateTimePicker.Size = new System.Drawing.Size(269, 23);
            this.EqualDateTimePicker.TabIndex = 10;
            this.EqualDateTimePicker.Validated += new System.EventHandler(this.EqualDateTimePicker_Validated);
            // 
            // BetweenDateRadioButton
            // 
            this.BetweenDateRadioButton.AutoSize = true;
            this.BetweenDateRadioButton.Location = new System.Drawing.Point(18, 76);
            this.BetweenDateRadioButton.Name = "BetweenDateRadioButton";
            this.BetweenDateRadioButton.Size = new System.Drawing.Size(70, 19);
            this.BetweenDateRadioButton.TabIndex = 9;
            this.BetweenDateRadioButton.TabStop = true;
            this.BetweenDateRadioButton.Text = "between";
            this.BetweenDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // NumberGroupBox
            // 
            this.NumberGroupBox.Controls.Add(this.MinNumericUpDown);
            this.NumberGroupBox.Controls.Add(this.MaxNumericUpDown);
            this.NumberGroupBox.Controls.Add(this.EqualNumericUpDown);
            this.NumberGroupBox.Controls.Add(this.BetweenNumberRadioButton);
            this.NumberGroupBox.Controls.Add(this.EqualNumberRadioButton);
            this.NumberGroupBox.Location = new System.Drawing.Point(22, 336);
            this.NumberGroupBox.Name = "NumberGroupBox";
            this.NumberGroupBox.Size = new System.Drawing.Size(303, 101);
            this.NumberGroupBox.TabIndex = 13;
            this.NumberGroupBox.TabStop = false;
            // 
            // MinNumericUpDown
            // 
            this.MinNumericUpDown.Location = new System.Drawing.Point(163, 47);
            this.MinNumericUpDown.Name = "MinNumericUpDown";
            this.MinNumericUpDown.Size = new System.Drawing.Size(51, 23);
            this.MinNumericUpDown.TabIndex = 12;
            this.MinNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.MinNumericUpDown_Validating);
            this.MinNumericUpDown.Validated += new System.EventHandler(this.MinNumericUpDown_Validated);
            // 
            // MaxNumericUpDown
            // 
            this.MaxNumericUpDown.Location = new System.Drawing.Point(246, 47);
            this.MaxNumericUpDown.Name = "MaxNumericUpDown";
            this.MaxNumericUpDown.Size = new System.Drawing.Size(51, 23);
            this.MaxNumericUpDown.TabIndex = 11;
            this.MaxNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.MaxNumericUpDown_Validating);
            this.MaxNumericUpDown.Validated += new System.EventHandler(this.MaxNumericUpDown_Validated);
            // 
            // EqualNumericUpDown
            // 
            this.EqualNumericUpDown.Location = new System.Drawing.Point(28, 47);
            this.EqualNumericUpDown.Name = "EqualNumericUpDown";
            this.EqualNumericUpDown.Size = new System.Drawing.Size(51, 23);
            this.EqualNumericUpDown.TabIndex = 10;
            this.EqualNumericUpDown.Validated += new System.EventHandler(this.EqualNumericUpDown_Validated);
            // 
            // BetweenNumberRadioButton
            // 
            this.BetweenNumberRadioButton.AutoSize = true;
            this.BetweenNumberRadioButton.Location = new System.Drawing.Point(153, 22);
            this.BetweenNumberRadioButton.Name = "BetweenNumberRadioButton";
            this.BetweenNumberRadioButton.Size = new System.Drawing.Size(70, 19);
            this.BetweenNumberRadioButton.TabIndex = 9;
            this.BetweenNumberRadioButton.TabStop = true;
            this.BetweenNumberRadioButton.Text = "between";
            this.BetweenNumberRadioButton.UseVisualStyleBackColor = true;
            // 
            // EqualNumberRadioButton
            // 
            this.EqualNumberRadioButton.AutoSize = true;
            this.EqualNumberRadioButton.Location = new System.Drawing.Point(18, 22);
            this.EqualNumberRadioButton.Name = "EqualNumberRadioButton";
            this.EqualNumberRadioButton.Size = new System.Drawing.Size(54, 19);
            this.EqualNumberRadioButton.TabIndex = 8;
            this.EqualNumberRadioButton.TabStop = true;
            this.EqualNumberRadioButton.Text = "equal";
            this.EqualNumberRadioButton.UseVisualStyleBackColor = true;
            this.EqualNumberRadioButton.Validated += new System.EventHandler(this.EqualNumberRadioButton_Validated);
            // 
            // AddFilterButton
            // 
            this.AddFilterButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddFilterButton.Location = new System.Drawing.Point(12, 454);
            this.AddFilterButton.Name = "AddFilterButton";
            this.AddFilterButton.Size = new System.Drawing.Size(313, 36);
            this.AddFilterButton.TabIndex = 14;
            this.AddFilterButton.Text = "Add";
            this.AddFilterButton.UseVisualStyleBackColor = true;
            this.AddFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
            // 
            // FilterFormErrorProvider
            // 
            this.FilterFormErrorProvider.ContainerControl = this;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 502);
            this.Controls.Add(this.AddFilterButton);
            this.Controls.Add(this.NumberGroupBox);
            this.Controls.Add(this.DateGroupBox);
            this.Controls.Add(this.StudentFilterLabel);
            this.Controls.Add(this.AddStudentFilterButton);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.ExamDateCheckBox);
            this.Controls.Add(this.ResultCheckBox);
            this.Controls.Add(this.StudentCheckBox);
            this.Controls.Add(this.TitleCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterForm";
            this.DateGroupBox.ResumeLayout(false);
            this.DateGroupBox.PerformLayout();
            this.NumberGroupBox.ResumeLayout(false);
            this.NumberGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqualNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterFormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TitleCheckBox;
        private System.Windows.Forms.CheckBox StudentCheckBox;
        private System.Windows.Forms.CheckBox ResultCheckBox;
        private System.Windows.Forms.CheckBox ExamDateCheckBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button AddStudentFilterButton;
        private System.Windows.Forms.Label StudentFilterLabel;
        private System.Windows.Forms.RadioButton EqualDateRadioButton;
        private System.Windows.Forms.GroupBox DateGroupBox;
        private System.Windows.Forms.DateTimePicker MaxDateTimePicker;
        private System.Windows.Forms.DateTimePicker MinDateTimePicker;
        private System.Windows.Forms.DateTimePicker EqualDateTimePicker;
        private System.Windows.Forms.RadioButton BetweenDateRadioButton;
        private System.Windows.Forms.GroupBox NumberGroupBox;
        private System.Windows.Forms.RadioButton BetweenNumberRadioButton;
        private System.Windows.Forms.RadioButton EqualNumberRadioButton;
        private System.Windows.Forms.Button AddFilterButton;
        private System.Windows.Forms.NumericUpDown MinNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown EqualNumericUpDown;
        private System.Windows.Forms.ErrorProvider FilterFormErrorProvider;
    }
}