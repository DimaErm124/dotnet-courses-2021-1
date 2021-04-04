using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        private int _rewardsCounter;
        private int _usersCounter;

        private List<User> _users;
        private List<Reward> _rewards;
        
        private Dictionary<User, List<Reward>> _rewardDictionary;

        private BindingSource _usersSource;
        private BindingSource _rewardsSource;
        private BindingSource _userRewardsSource;       

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _users = new List<User>();
            _rewards = new List<Reward>();

            _rewardDictionary = new Dictionary<User, List<Reward>>();

            _usersSource = new BindingSource();
            _rewardsSource = new BindingSource();
            _userRewardsSource = new BindingSource();

            _usersSource.DataSource = _users;
            UsersDGV.DataSource = _usersSource;

            _rewardsSource.DataSource = _rewards;
            RewardsDGV.DataSource = _rewardsSource;

            UserRewardsDGV.DataSource = _userRewardsSource;

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
            var form = new AddOrEditUser(_rewards.ToArray(), AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _usersCounter++;

                var user = new User(_usersCounter, form.FirstName, form.LastName, form.Birthdate);

                _users.Add(user);

                _rewardDictionary.Add(user, form.Rewards);

                _usersSource.ResetBindings(false);
            }
        }

        private void AddRewardButton_Click(object sender, EventArgs e)
        {
            var form = new RewardForm(AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _rewardsCounter++;

                _rewards.Add(new Reward(_rewardsCounter, form.Title, form.Description));

                _rewardsSource.ResetBindings(false);
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

            var form = new AddOrEditUser(_rewards.ToArray(), user, _rewardDictionary[user], EditButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _rewardDictionary.Remove(user);

                _users.Remove(user);

                var changingUser = new User(user.ID, form.FirstName, form.LastName, form.Birthdate);

                _users.Add(changingUser);

                _users.Sort();

                _rewardDictionary.Add(changingUser, form.Rewards);

                _usersSource.ResetBindings(false);
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
                _rewards.Remove(reward);

                var changingReward = new Reward(reward.ID, form.Title, form.Description);

                _rewards.Add(changingReward);

                _rewards.Sort();

                ResetRewardsDictionary(reward, changingReward);

                _rewardsSource.ResetBindings(false);
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

            _users.Remove(user);

            _rewardDictionary.Remove(user);

            _usersSource.ResetBindings(false);
        }

        private void DeleteRewardButton_Click(object sender, EventArgs e)
        {
            var reward = (Reward)_rewardsSource.Current;

            if (reward == null)
                return;

            _rewards.Remove(reward);

            DeleteRewardsDictionary(reward);

            _rewardsSource.ResetBindings(false);
        }
        
        private void ResetRewardsDictionary(Reward reward, Reward newReward)
        {
            foreach(var el in _rewardDictionary)
            {
                if (_rewardDictionary[el.Key].Contains(reward))
                {
                    _rewardDictionary[el.Key].Remove(reward);
                    _rewardDictionary[el.Key].Add(newReward);

                    _rewardDictionary[el.Key].Sort();
                }
            }            
        }

        private void DeleteRewardsDictionary(Reward reward)
        {
            foreach (var el in _rewardDictionary)
            {
                if (_rewardDictionary[el.Key].Contains(reward))
                {
                    _rewardDictionary[el.Key].Remove(reward);
                }
            }
        }

        private void UsersDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _userRewardsSource.DataSource = _rewardDictionary[(User)_usersSource.Current];
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
            _userRewardsSource.DataSource = null;
        }

        private void UsersDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_users.Count == 0)
                return;

            var column = UsersDGV.Columns[e.ColumnIndex];

            _usersSource.DataSource = _users.OrderBy(x => column.Name).ToList();
        }
    }
}
