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

        public void RemoveUser(int id)
        {
            _userRewardsDAO.Remove(id);
            
            _userDAO.Remove(id);            
        }

        public void RemoveReward(int id)
        {
            _userRewardsDAO.RemoveReward(id);
            
            _rewardDAO.Remove(id);            
        }

        public void EditUser(User newUser, List<Reward> rewards)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            _userDAO.Edit(newUser);

            _userRewardsDAO.Edit(newUser, rewards);
        }

        public void EditReward(Reward newReward)
        {
            if (newReward == null)
                throw new ArgumentNullException();

            _rewardDAO.Edit(newReward);

            _userRewardsDAO.EditReward(newReward);
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

        public List<Reward> GetNotChoosingRewards(User user)
        {
            var allRewards = GetRewards();
            var userRewards = GetUserRewards(user);

            if (userRewards.Count == 0)
                return allRewards;

            foreach(var el in userRewards)
            {
                if (allRewards.Contains(allRewards.Find(x => x.ID == el.ID)))
                {
                    allRewards.Remove(allRewards.Find(x => x.ID == el.ID));
                }
            }

            return allRewards;
        }
    }
}
