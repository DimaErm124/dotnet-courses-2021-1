using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class RewardForm : Form
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public RewardForm(string functionName)
        {
            InitializeComponent();

            CreateRewardButton.Text = functionName;

            this.Text = functionName + " new reward";
        }

        public RewardForm(Reward reward, string functionName)
        {
            InitializeComponent();

            TitleTextBox.Text = reward.Title;
            DescriptionRichTextBox.Text = reward.Description;

            CreateRewardButton.Text = functionName;

            this.Text = functionName + " " + reward;
        }

        private void CreateRewardButton_Click(object sender, EventArgs e)
        {
            RewardErrorProvider.Clear();

            if (this.ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
        }
        
        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                RewardErrorProvider.SetError(TitleTextBox, "Empty!");
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                RewardErrorProvider.SetError(TitleTextBox, "Whitespace!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void TitleTextBox_Validated(object sender, EventArgs e)
        {
            Title = TitleTextBox.Text;
        }               

        private void DescriptionRichTextBox_Validated(object sender, EventArgs e)
        {
            Description = DescriptionRichTextBox.Text;
        }
    }
}
