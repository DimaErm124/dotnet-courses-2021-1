using DAL;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserRewardBL
    {
        private IUserDAO _userDAO;

        private IRewardDAO _rewardDAO;

        private IUserRewardsDAO _userRewardsDAO;

        public UserRewardBL()
        {
            _userDAO = new UserDAO();

            _rewardDAO = new RewardDAO();

            _userRewardsDAO = new UserRewardsDAO();
        }

        public void AddUser(User user, List<Reward> rewards)
        {
            _userDAO.Add(user);

            _userRewardsDAO.Add(user, rewards);
        }

        public void AddReward(Reward reward)
        {
            _rewardDAO.Add(reward);
        }

        public void RemoveUser(User user)
        {
            _userDAO.Remove(user);

            _userRewardsDAO.Remove(user);
        }

        public void RemoveReward(Reward reward)
        {
            _rewardDAO.Remove(reward);

            _userRewardsDAO.RemoveReward(reward);
        }

        public void EditUser(User oldUser, User newUser, List<Reward> rewards)
        {
            _userDAO.Edit(oldUser, newUser);

            _userRewardsDAO.Edit(oldUser, newUser, rewards);
        }

        public void EditReward(Reward oldReward, Reward newReward)
        {
            _rewardDAO.Edit(oldReward, newReward);

            _userRewardsDAO.EditReward(oldReward, newReward);
        }

        public List<User> SortUsersByColumn(string columnName)
        {
            return _userDAO.GetUsers().OrderBy(x => x[columnName]).ToList();
        }

        public List<Reward> SortRewardsByColumn(string columnName)
        {
            return _rewardDAO.GetRewards().OrderBy(x => x[columnName]).ToList();
        }

        public List<User> GetUsers()
        {
            return _userDAO.GetUsers();
        }

        public List<Reward> GetRewards()
        {
            return _rewardDAO.GetRewards();
        }

        public List<Reward> GetUserRewards(User user)
        {
            return _userRewardsDAO[user];
        }

        public IDictionary<User, List<Reward>> GetUsersRewards()
        {
            return _userRewardsDAO.GetUsersRewards();
        }
    }
}
