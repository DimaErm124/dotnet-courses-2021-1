﻿using System;
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

        public IList<Reward> Rewards { get; set; }

        public AddOrEditUser(object[] objects)
        {
            InitializeComponent();

            Rewards = new List<Reward>();

            UserRewardsCheckedListBox.Items.AddRange(objects);
        }

        public AddOrEditUser(object[] objects, User user, IList<Reward> rewards)
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
                AddOrEditUserErrorProvider.SetError(FirstNameTextBox, "Empty!");
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(FirstNameTextBox, "Whitespace!");
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
                AddOrEditUserErrorProvider.SetError(LastNameTextBox, "Empty!");
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                AddOrEditUserErrorProvider.SetError(LastNameTextBox, "Whitespace!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }        

        private void BirthdateTimePicker_Validating(object sender, CancelEventArgs e)
        {    
            if (BirthdateTimePicker.Value >= DateTime.Now)
            {
                AddOrEditUserErrorProvider.SetError(BirthdateTimePicker, "Age less than zero!");
                e.Cancel = true;
            } 
            else if (new DateTime((DateTime.Now - BirthdateTimePicker.Value).Ticks).Year >= 150) 
            {
                AddOrEditUserErrorProvider.SetError(BirthdateTimePicker, "Age more than can be!");
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
                Rewards = Rewards.OrderBy(x => x.ID).ToList();
                DialogResult = DialogResult.OK;
            }
        }        
    }
}
