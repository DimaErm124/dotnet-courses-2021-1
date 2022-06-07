using EntityLibrary;
using HandlerValue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PL
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
                RewardErrorProvider.SetError(TitleTextBox, ErrorStringValue.ERROR_EMPTY);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                RewardErrorProvider.SetError(TitleTextBox, ErrorStringValue.ERROR_WHITESPACE);
                e.Cancel = true;
            }
            else if (TitleTextBox.Text.Length >= InputHandlerValue.MAX_LENGTH_TITLE)
            {
                RewardErrorProvider.SetError(TitleTextBox, ErrorStringValue.ERROR_LENGTH + " " + TitleTextBox.Text.Length);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        
        private void DescriptionRichTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(DescriptionRichTextBox.Text) 
                && DescriptionRichTextBox.Text.Length >= InputHandlerValue.MAX_LENGTH_DESCRIPTION)
            {
                RewardErrorProvider.SetError(DescriptionRichTextBox, ErrorStringValue.ERROR_LENGTH + " " + DescriptionRichTextBox.Text.Length);
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
