
namespace AttendanceUI
{
    partial class LectureForm
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
            this.LectureDateLabel = new System.Windows.Forms.Label();
            this.LectureButton = new System.Windows.Forms.Button();
            this.TopicLabel = new System.Windows.Forms.Label();
            this.TopicTextBox = new System.Windows.Forms.TextBox();
            this.LectureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LectureErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LectureErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LectureDateLabel
            // 
            this.LectureDateLabel.AutoSize = true;
            this.LectureDateLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureDateLabel.Location = new System.Drawing.Point(12, 70);
            this.LectureDateLabel.Name = "LectureDateLabel";
            this.LectureDateLabel.Size = new System.Drawing.Size(94, 20);
            this.LectureDateLabel.TabIndex = 5;
            this.LectureDateLabel.Text = "Lecture date:";
            // 
            // LectureButton
            // 
            this.LectureButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureButton.Location = new System.Drawing.Point(55, 146);
            this.LectureButton.Name = "LectureButton";
            this.LectureButton.Size = new System.Drawing.Size(183, 30);
            this.LectureButton.TabIndex = 3;
            this.LectureButton.Text = "button1";
            this.LectureButton.UseVisualStyleBackColor = true;
            this.LectureButton.Click += new System.EventHandler(this.LectureButton_Click);
            // 
            // TopicLabel
            // 
            this.TopicLabel.AutoSize = true;
            this.TopicLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TopicLabel.Location = new System.Drawing.Point(12, 9);
            this.TopicLabel.Name = "TopicLabel";
            this.TopicLabel.Size = new System.Drawing.Size(48, 20);
            this.TopicLabel.TabIndex = 7;
            this.TopicLabel.Text = "Topic:";
            // 
            // TopicTextBox
            // 
            this.TopicTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TopicTextBox.Location = new System.Drawing.Point(12, 32);
            this.TopicTextBox.Name = "TopicTextBox";
            this.TopicTextBox.Size = new System.Drawing.Size(267, 27);
            this.TopicTextBox.TabIndex = 6;
            this.TopicTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TopicTextBox_Validating);
            this.TopicTextBox.Validated += new System.EventHandler(this.TopicTextBox_Validated);
            // 
            // LectureDateTimePicker
            // 
            this.LectureDateTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LectureDateTimePicker.Location = new System.Drawing.Point(12, 93);
            this.LectureDateTimePicker.Name = "LectureDateTimePicker";
            this.LectureDateTimePicker.Size = new System.Drawing.Size(267, 27);
            this.LectureDateTimePicker.TabIndex = 8;
            this.LectureDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.LectureDateTimePicker_Validating);
            this.LectureDateTimePicker.Validated += new System.EventHandler(this.LectureDateTimePicker_Validated);
            // 
            // LectureErrorProvider
            // 
            this.LectureErrorProvider.ContainerControl = this;
            // 
            // LectureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 195);
            this.Controls.Add(this.LectureDateTimePicker);
            this.Controls.Add(this.TopicLabel);
            this.Controls.Add(this.TopicTextBox);
            this.Controls.Add(this.LectureDateLabel);
            this.Controls.Add(this.LectureButton);
            this.Name = "LectureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LectureForm";
            this.Load += new System.EventHandler(this.LectureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LectureErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LectureDateLabel;
        private System.Windows.Forms.Button LectureButton;
        private System.Windows.Forms.Label TopicLabel;
        private System.Windows.Forms.TextBox TopicTextBox;
        private System.Windows.Forms.DateTimePicker LectureDateTimePicker;
        private System.Windows.Forms.ErrorProvider LectureErrorProvider;
    }
}