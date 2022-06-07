
namespace AttendanceUI
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
            this.StudentButton = new System.Windows.Forms.Button();
            this.StudentNameTextBox = new System.Windows.Forms.TextBox();
            this.StudentNameLabel = new System.Windows.Forms.Label();
            this.StudentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StudentErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentButton
            // 
            this.StudentButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentButton.Location = new System.Drawing.Point(55, 85);
            this.StudentButton.Name = "StudentButton";
            this.StudentButton.Size = new System.Drawing.Size(183, 30);
            this.StudentButton.TabIndex = 0;
            this.StudentButton.Text = "button1";
            this.StudentButton.UseVisualStyleBackColor = true;
            this.StudentButton.Click += new System.EventHandler(this.StudentButton_Click);
            // 
            // StudentNameTextBox
            // 
            this.StudentNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentNameTextBox.Location = new System.Drawing.Point(12, 32);
            this.StudentNameTextBox.Name = "StudentNameTextBox";
            this.StudentNameTextBox.Size = new System.Drawing.Size(267, 27);
            this.StudentNameTextBox.TabIndex = 1;
            this.StudentNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.StudentNameTextBox_Validating);
            this.StudentNameTextBox.Validated += new System.EventHandler(this.StudentNameTextBox_Validated);
            // 
            // StudentNameLabel
            // 
            this.StudentNameLabel.AutoSize = true;
            this.StudentNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentNameLabel.Location = new System.Drawing.Point(12, 9);
            this.StudentNameLabel.Name = "StudentNameLabel";
            this.StudentNameLabel.Size = new System.Drawing.Size(52, 20);
            this.StudentNameLabel.TabIndex = 2;
            this.StudentNameLabel.Text = "Name:";
            // 
            // StudentErrorProvider
            // 
            this.StudentErrorProvider.ContainerControl = this;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 145);
            this.Controls.Add(this.StudentNameLabel);
            this.Controls.Add(this.StudentNameTextBox);
            this.Controls.Add(this.StudentButton);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.StudentErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StudentButton;
        private System.Windows.Forms.TextBox StudentNameTextBox;
        private System.Windows.Forms.Label StudentNameLabel;
        private System.Windows.Forms.ErrorProvider StudentErrorProvider;
    }
}