using BLL;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class MainForm : Form
    {
        private int _rewardsCounter;
        private int _usersCounter;

        private UserRewardBL _userRewardBL;
        
        private BindingSource _usersSource;
        private BindingSource _rewardsSource;
        private BindingSource _userRewardsSource;       

        public MainForm(UserRewardBL userRewardBL)
        {
            InitializeComponent();

            _userRewardBL = userRewardBL;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _usersSource = new BindingSource();
            _rewardsSource = new BindingSource();
            _userRewardsSource = new BindingSource();

            _usersSource.DataSource = _userRewardBL.GetUsers();        
            _rewardsSource.DataSource = _userRewardBL.GetRewards();

            UsersDGV.DataSource = _usersSource;
            RewardsDGV.DataSource = _rewardsSource;
            UserRewardsDGV.DataSource = _userRewardsSource;

            UsersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RewardsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UserRewardsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == UserTabPage) 
            {
                AddUserButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == RewardTabPage)
            {
                AddRewardButton_Click(sender, e);
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var form = new UserForm(_userRewardBL.GetRewards().ToArray(), AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _usersCounter++;

                var user = new User(_usersCounter, form.FirstName, form.LastName, form.Birthdate);

                _userRewardBL.AddUser(user,form.Rewards);

                UpdateUsers();
            }
        }

        private void AddRewardButton_Click(object sender, EventArgs e)
        {
            var form = new RewardForm(AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _rewardsCounter++;

                _userRewardBL.AddReward(new Reward(_rewardsCounter, form.Title, form.Description));

                UpdateRewards();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == UserTabPage)
            {
                EditUserButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == RewardTabPage)
            {
                EditRewardButton_Click(sender, e);
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            var user = (User)_usersSource.Current;

            if (user == null)            
                return;            

            var form = new UserForm(_userRewardBL.GetRewards().ToArray(), user, _userRewardBL.GetUserRewards(user), EditButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var newUser = new User(user.ID, form.FirstName, form.LastName, form.Birthdate);

                _userRewardBL.EditUser(user, newUser, form.Rewards);

                UpdateUsers();
            }
        }

        private void EditRewardButton_Click(object sender, EventArgs e)
        {
            var reward = (Reward)_rewardsSource.Current;

            if (reward == null)            
                return;            

            var form = new RewardForm(reward, EditButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var newReward = new Reward(reward.ID, form.Title, form.Description);

                _userRewardBL.EditReward(newReward);

                UpdateRewards();
            }
        }        
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == UserTabPage)
            {
                DeleteUserButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == RewardTabPage)
            {
                DeleteRewardButton_Click(sender, e);
            }
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            var user = (User)_usersSource.Current;

            if (user == null)
                return;

            _userRewardBL.RemoveUser(user);

            UpdateUsers();
        }

        private void DeleteRewardButton_Click(object sender, EventArgs e)
        {
            var reward = (Reward)_rewardsSource.Current;

            if (reward == null)
                return;

            _userRewardBL.RemoveReward(reward);

            UpdateRewards();
        }

        private void UpdateUsers()
        {
            _usersSource.DataSource = null;

            _usersSource.DataSource = _userRewardBL.GetUsers();
        }

        private void UpdateRewards()
        {
            _rewardsSource.DataSource = null;

            _rewardsSource.DataSource = _userRewardBL.GetRewards();
        }

        private void UsersDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _userRewardsSource.DataSource = _userRewardBL.GetUserRewards((User)_usersSource.Current);
            }
            catch
            {
            }
        }

        private void UsersDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            _userRewardsSource.DataSource = null;
        }

        private void MainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Text == "Rewards")
                _userRewardsSource.DataSource = null;
            else
                _userRewardsSource.DataSource = _userRewardBL.GetUserRewards((User)_usersSource.Current);
        }

        private void UsersDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_usersSource.Count == 0)
                return;

            var column = UsersDGV.Columns[e.ColumnIndex];

            _usersSource.DataSource = _userRewardBL.SortUsersByColumn(column.Name);
        }

        private void RewardsDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_rewardsSource.Count == 0)
                return;

            var column = RewardsDGV.Columns[e.ColumnIndex];

            _rewardsSource.DataSource = _userRewardBL.SortRewardsByColumn(column.Name);
        }
    }
}
