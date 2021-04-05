using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class AddOrEditUser : Form
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Reward> Rewards { get; set; }

        public AddOrEditUser(object[] objects, string functionName)
        {
            InitializeComponent();

            Rewards = new List<Reward>();

            UserRewardsCheckedListBox.Items.AddRange(objects);

            CreateUserButton.Text = functionName;

            this.Text = functionName + " new user";
        }

        public AddOrEditUser(object[] objects, User user, IList<Reward> rewards, string functionName)
        {
            InitializeComponent();

            Rewards = new List<Reward>();

            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
            BirthdateTimePicker.Value = user.Birthdate;

            UserRewardsCheckedListBox.Items.AddRange(objects);

            foreach(var reward in rewards)
            {
                UserRewardsCheckedListBox.SetItemChecked(reward.ID - 1, true);
            }

            CreateUserButton.Text = functionName;

            this.Text = functionName + " " + user;
        }
 
        private void FirstNameTextBox_Validated(object sender, EventArgs e)
        {
            FirstName = FirstNameTextBox.Text;
        }

        private void LastNameTextBox_Validated(object sender, EventArgs e)
        {
            LastName = LastNameTextBox.Text;
        }
        
        private void BirthdateTimePicker_Validated(object sender, EventArgs e)
        {
            Birthdate = BirthdateTimePicker.Value;
        }
        
        private void FirstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(FirstNameTextBox, InputHandlerValue.ERROR_EMPTY);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(FirstNameTextBox, InputHandlerValue.ERROR_WHITESPACE);
                e.Cancel = true;
            }
            else if (FirstNameTextBox.Text.Length >= InputHandlerValue.MAX_LENGTH_FIRST_NAME)
            {
                AddOrEditUserErrorProvider.SetError(FirstNameTextBox, InputHandlerValue.ERROR_LENGTH + " " + FirstNameTextBox.Text.Length);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void LastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(LastNameTextBox, InputHandlerValue.ERROR_EMPTY);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(LastNameTextBox, InputHandlerValue.ERROR_WHITESPACE);
                e.Cancel = true;
            }
            else if (LastNameTextBox.Text.Length >= InputHandlerValue.MAX_LENGTH_LAST_NAME)
            {
                AddOrEditUserErrorProvider.SetError(LastNameTextBox, InputHandlerValue.ERROR_LENGTH + " " + LastNameTextBox.Text.Length);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }        

        private void BirthdateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            var today = DateTime.Now;
            var age = today.Year - BirthdateTimePicker.Value.Year - 1
                + ((today.Month > BirthdateTimePicker.Value.Month || (today.Month == BirthdateTimePicker.Value.Month && today.Day >= BirthdateTimePicker.Value.Day)) ? 1 : 0);

            if (BirthdateTimePicker.Value > today)
            {
                AddOrEditUserErrorProvider.SetError(BirthdateTimePicker, InputHandlerValue.ERROR_ZERO_AGE);
                e.Cancel = true;
            }
            else if (age >= InputHandlerValue.MAX_AGE) 
            {
                AddOrEditUserErrorProvider.SetError(BirthdateTimePicker, InputHandlerValue.ERROR_MAX_AGE);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        
        private void UserRewardsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var reward = (Reward)UserRewardsCheckedListBox.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                Rewards.Add(reward);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                Rewards.Remove(reward);
            }
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            AddOrEditUserErrorProvider.Clear();

            if (this.ValidateChildren())
            {
                Rewards.Sort();

                DialogResult = DialogResult.OK;
            }
        }        
    }
}
