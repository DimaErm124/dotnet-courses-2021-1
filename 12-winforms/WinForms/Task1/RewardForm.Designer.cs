
namespace Task1
{
    partial class RewardForm
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
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateRewardButton = new System.Windows.Forms.Button();
            this.RewardErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RewardErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(10, 32);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(302, 23);
            this.TitleTextBox.TabIndex = 0;
            this.TitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTextBox_Validating);
            this.TitleTextBox.Validated += new System.EventHandler(this.TitleTextBox_Validated);
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(10, 84);
            this.DescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(302, 246);
            this.DescriptionRichTextBox.TabIndex = 1;
            this.DescriptionRichTextBox.Text = "";
            this.DescriptionRichTextBox.Validated += new System.EventHandler(this.DescriptionRichTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // CreateRewardButton
            // 
            this.CreateRewardButton.Location = new System.Drawing.Point(10, 333);
            this.CreateRewardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateRewardButton.Name = "CreateRewardButton";
            this.CreateRewardButton.Size = new System.Drawing.Size(302, 28);
            this.CreateRewardButton.TabIndex = 4;
            this.CreateRewardButton.Text = "Create";
            this.CreateRewardButton.UseVisualStyleBackColor = true;
            this.CreateRewardButton.Click += new System.EventHandler(this.CreateRewardButton_Click);
            // 
            // RewardErrorProvider
            // 
            this.RewardErrorProvider.ContainerControl = this;
            // 
            // RewardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 370);
            this.Controls.Add(this.CreateRewardButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionRichTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RewardForm";
            this.Text = "RewardForm";
            ((System.ComponentModel.ISupportInitialize)(this.RewardErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateRewardButton;
        private System.Windows.Forms.ErrorProvider RewardErrorProvider;
    }
}