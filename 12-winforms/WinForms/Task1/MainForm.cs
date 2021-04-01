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

        private IList<User> _users;
        private IList<Reward> _rewards;
        
        private IDictionary<User, IList<Reward>> _rewardDictionary;

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

            _rewardDictionary = new Dictionary<User, IList<Reward>>();

            _usersSource = new BindingSource();
            _rewardsSource = new BindingSource();
            _userRewardsSource = new BindingSource();

            _usersSource.DataSource = _users;
            UsersDGV.DataSource = _usersSource;

            _rewardsSource.DataSource = _rewards;
            RewardsDGV.DataSource = _rewardsSource;

            UserRewardsDGV.DataSource = _userRewardsSource;

        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditUser(_rewards.ToArray());

            form.Text = "Add new user";

            if (form.ShowDialog() == DialogResult.OK)
            {
                _usersCounter++;

                var user = new User(_usersCounter, form.FirstName, form.LastName, form.Birthdate);

                _users.Add(user);

                _rewardDictionary.Add(user, form.Rewards);

                _usersSource.ResetBindings(false);
            }

        }
        
        private void EditUserButton_Click(object sender, EventArgs e)
        {
            var user = (User)_usersSource.Current;

            if (user == null)
            {
                return;
            }

            var form = new AddOrEditUser(_rewards.ToArray(), user, _rewardDictionary[user]);

            form.Text = "Edit " + user;

            if (form.ShowDialog() == DialogResult.OK)
            {
                _rewardDictionary.Remove(user);

                _users.Remove(user);

                var changingUser = new User(user.ID, form.FirstName, form.LastName, form.Birthdate);

                _users.Add(changingUser);

                _users = _users.OrderBy(x => x.ID).ToList();

                _rewardDictionary.Add(changingUser, form.Rewards);

                _usersSource.DataSource = _users;
            }
        }
        
        private void AddRewardButton_Click(object sender, EventArgs e)
        {
            var form = new RewardForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _rewardsCounter++;

                _rewards.Add(new Reward(_rewardsCounter, form.Title, form.Description));

                _rewardsSource.ResetBindings(false); 
            }
        }

        private void UsersDGV_Enter(object sender, EventArgs e)
        {
            try
            {
                _userRewardsSource.DataSource = _rewardDictionary[(User)_usersSource.Current];
            }
            catch
            {
            }
        }

        private void UsersDGV_Leave(object sender, EventArgs e)
        {
            _userRewardsSource.DataSource = null;
        }
    }
}
