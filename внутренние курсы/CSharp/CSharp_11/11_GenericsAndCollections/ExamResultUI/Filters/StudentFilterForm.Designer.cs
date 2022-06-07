
namespace ExamResultUI
{
    partial class StudentFilterForm
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
            this.AddFilterButton = new System.Windows.Forms.Button();
            this.GroupNumberGroupBox = new System.Windows.Forms.GroupBox();
            this.MinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EqualNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BetweenNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.EqualNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GroupNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.NameCheckBox = new System.Windows.Forms.CheckBox();
            this.MiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.MiddleNameCheckBox = new System.Windows.Forms.CheckBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameCheckBox = new System.Windows.Forms.CheckBox();
            this.StudentFilterFormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.GroupNumberGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqualNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFilterFormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // AddFilterButton
            // 
            this.AddFilterButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddFilterButton.Location = new System.Drawing.Point(12, 315);
            this.AddFilterButton.Name = "AddFilterButton";
            this.AddFilterButton.Size = new System.Drawing.Size(372, 36);
            this.AddFilterButton.TabIndex = 24;
            this.AddFilterButton.Text = "Add";
            this.AddFilterButton.UseVisualStyleBackColor = true;
            this.AddFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
            // 
            // GroupNumberGroupBox
            // 
            this.GroupNumberGroupBox.Controls.Add(this.MinNumericUpDown);
            this.GroupNumberGroupBox.Controls.Add(this.MaxNumericUpDown);
            this.GroupNumberGroupBox.Controls.Add(this.EqualNumericUpDown);
            this.GroupNumberGroupBox.Controls.Add(this.BetweenNumberRadioButton);
            this.GroupNumberGroupBox.Controls.Add(this.EqualNumberRadioButton);
            this.GroupNumberGroupBox.Location = new System.Drawing.Point(22, 165);
            this.GroupNumberGroupBox.Name = "GroupNumberGroupBox";
            this.GroupNumberGroupBox.Size = new System.Drawing.Size(362, 144);
            this.GroupNumberGroupBox.TabIndex = 23;
            this.GroupNumberGroupBox.TabStop = false;
            // 
            // MinNumericUpDown
            // 
            this.MinNumericUpDown.Location = new System.Drawing.Point(28, 101);
            this.MinNumericUpDown.Name = "MinNumericUpDown";
            this.MinNumericUpDown.Size = new System.Drawing.Size(51, 23);
            this.MinNumericUpDown.TabIndex = 12;
            this.MinNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.MinNumericUpDown_Validating);
            this.MinNumericUpDown.Validated += new System.EventHandler(this.MinNumericUpDown_Validated);
            // 
            // MaxNumericUpDown
            // 
            this.MaxNumericUpDown.Location = new System.Drawing.Point(106, 101);
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
            this.BetweenNumberRadioButton.Location = new System.Drawing.Point(18, 76);
            this.BetweenNumberRadioButton.Name = "BetweenNumberRadioButton";
            this.BetweenNumberRadioButton.Size = new System.Drawing.Size(70, 19);
            this.BetweenNumberRadioButton.TabIndex = 9;
            this.BetweenNumberRadioButton.TabStop = true;
            this.BetweenNumberRadioButton.Text = "between";
            this.BetweenNumberRadioButton.UseVisualStyleBackColor = true;
            this.BetweenNumberRadioButton.Validated += new System.EventHandler(this.NumberRadioButton_Validated);
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
            this.EqualNumberRadioButton.Validated += new System.EventHandler(this.NumberRadioButton_Validated);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(134, 14);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(250, 23);
            this.NameTextBox.TabIndex = 19;
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            this.NameTextBox.Validated += new System.EventHandler(this.NameTextBox_Validated);
            // 
            // GroupNumberCheckBox
            // 
            this.GroupNumberCheckBox.AutoSize = true;
            this.GroupNumberCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GroupNumberCheckBox.Location = new System.Drawing.Point(12, 146);
            this.GroupNumberCheckBox.Name = "GroupNumberCheckBox";
            this.GroupNumberCheckBox.Size = new System.Drawing.Size(90, 24);
            this.GroupNumberCheckBox.TabIndex = 17;
            this.GroupNumberCheckBox.Text = "Group №";
            this.GroupNumberCheckBox.UseVisualStyleBackColor = true;
            this.GroupNumberCheckBox.Validated += new System.EventHandler(this.GroupNumberCheckBox_Validated);
            // 
            // NameCheckBox
            // 
            this.NameCheckBox.AutoSize = true;
            this.NameCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameCheckBox.Location = new System.Drawing.Point(12, 12);
            this.NameCheckBox.Name = "NameCheckBox";
            this.NameCheckBox.Size = new System.Drawing.Size(68, 24);
            this.NameCheckBox.TabIndex = 15;
            this.NameCheckBox.Text = "Name";
            this.NameCheckBox.UseVisualStyleBackColor = true;
            this.NameCheckBox.Validated += new System.EventHandler(this.NameCheckBox_Validated);
            // 
            // MiddleNameTextBox
            // 
            this.MiddleNameTextBox.Location = new System.Drawing.Point(134, 102);
            this.MiddleNameTextBox.Name = "MiddleNameTextBox";
            this.MiddleNameTextBox.Size = new System.Drawing.Size(250, 23);
            this.MiddleNameTextBox.TabIndex = 26;
            this.MiddleNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.MiddleNameTextBox_Validating);
            this.MiddleNameTextBox.Validated += new System.EventHandler(this.MiddleNameTextBox_Validated);
            // 
            // MiddleNameCheckBox
            // 
            this.MiddleNameCheckBox.AutoSize = true;
            this.MiddleNameCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MiddleNameCheckBox.Location = new System.Drawing.Point(12, 102);
            this.MiddleNameCheckBox.Name = "MiddleNameCheckBox";
            this.MiddleNameCheckBox.Size = new System.Drawing.Size(116, 24);
            this.MiddleNameCheckBox.TabIndex = 25;
            this.MiddleNameCheckBox.Text = "Middle name";
            this.MiddleNameCheckBox.UseVisualStyleBackColor = true;
            this.MiddleNameCheckBox.Validated += new System.EventHandler(this.MiddleNameCheckBox_Validated);
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(134, 56);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(250, 23);
            this.SurnameTextBox.TabIndex = 28;
            this.SurnameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SurnameTextBox_Validating);
            this.SurnameTextBox.Validated += new System.EventHandler(this.SurnameTextBox_Validated);
            // 
            // SurnameCheckBox
            // 
            this.SurnameCheckBox.AutoSize = true;
            this.SurnameCheckBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SurnameCheckBox.Location = new System.Drawing.Point(12, 54);
            this.SurnameCheckBox.Name = "SurnameCheckBox";
            this.SurnameCheckBox.Size = new System.Drawing.Size(86, 24);
            this.SurnameCheckBox.TabIndex = 27;
            this.SurnameCheckBox.Text = "Surname";
            this.SurnameCheckBox.UseVisualStyleBackColor = true;
            this.SurnameCheckBox.Validated += new System.EventHandler(this.SurnameCheckBox_Validated);
            // 
            // StudentFilterFormErrorProvider
            // 
            this.StudentFilterFormErrorProvider.ContainerControl = this;
            // 
            // StudentFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 370);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.SurnameCheckBox);
            this.Controls.Add(this.MiddleNameTextBox);
            this.Controls.Add(this.MiddleNameCheckBox);
            this.Controls.Add(this.AddFilterButton);
            this.Controls.Add(this.GroupNumberGroupBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.GroupNumberCheckBox);
            this.Controls.Add(this.NameCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StudentFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentFilterForm";
            this.GroupNumberGroupBox.ResumeLayout(false);
            this.GroupNumberGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EqualNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFilterFormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddFilterButton;
        private System.Windows.Forms.GroupBox GroupNumberGroupBox;
        private System.Windows.Forms.NumericUpDown MinNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown EqualNumericUpDown;
        private System.Windows.Forms.RadioButton BetweenNumberRadioButton;
        private System.Windows.Forms.RadioButton EqualNumberRadioButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.CheckBox GroupNumberCheckBox;
        private System.Windows.Forms.CheckBox NameCheckBox;
        private System.Windows.Forms.TextBox MiddleNameTextBox;
        private System.Windows.Forms.CheckBox MiddleNameCheckBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.CheckBox SurnameCheckBox;
        private System.Windows.Forms.ErrorProvider StudentFilterFormErrorProvider;
    }
}