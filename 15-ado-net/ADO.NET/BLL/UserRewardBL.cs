using DAL;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BLL
{
    public class UserRewardBL
    {
        private IUserDAO _userDAO;

        private IRewardDAO _rewardDAO;

        private IUserRewardsDAO _userRewardsDAO;

        public UserRewardBL(IUserDAO userDAO, IRewardDAO rewardDAO, IUserRewardsDAO userRewardsDAO)
        {
            _userDAO = userDAO;

            _rewardDAO = rewardDAO;

            _userRewardsDAO = userRewardsDAO;
        }

        public void AddUser(User user, List<Reward> rewards)
        {
            if (user == null)
                throw new ArgumentNullException();

            user = _userDAO.Add(user);

            _userRewardsDAO.Add(user, rewards);
        }

        public void AddReward(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            _rewardDAO.Add(reward);
        }

        public void RemoveUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            _userRewardsDAO.Remove(user);
            
            _userDAO.Remove(user);            
        }

        public void RemoveReward(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            _userRewardsDAO.RemoveReward(reward);
            
            _rewardDAO.Remove(reward);            
        }

        public void EditUser(User oldUser, User newUser, List<Reward> rewards)
        {
            if (oldUser == null || newUser == null)
                throw new ArgumentNullException();

            _userDAO.Edit(oldUser, newUser);

            _userRewardsDAO.Edit(oldUser, newUser, rewards);
        }

        public void EditReward(Reward oldReward, Reward newReward)
        {
            if (oldReward == null || newReward == null)
                throw new ArgumentNullException();

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
            if (user == null)
                throw new ArgumentNullException();

            return _userRewardsDAO[user];
        }
    }
}
