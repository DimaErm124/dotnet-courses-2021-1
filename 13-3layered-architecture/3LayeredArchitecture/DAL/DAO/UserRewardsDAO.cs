using EntityLibrary;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class UserRewardsDAO : IUserRewardsDAO
    {
        private IDictionary<User, List<Reward>> _userRewards;

        public UserRewardsDAO()
        {
            _userRewards = new Dictionary<User, List<Reward>>();
        }

        public List<Reward> this[User user]
        {
            get => _userRewards[user];
        }

        public void Add(User user, List<Reward> rewards)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (_userRewards.ContainsKey(user))
                throw new ArgumentException();

            _userRewards.Add(user, rewards);
        }

        public void Edit(User oldUser, User newUser, List<Reward> rewards)
        {
            if (oldUser == null || newUser == null)
                throw new ArgumentNullException();

            this.Remove(oldUser);
            this.Add(newUser, rewards);
        }

        public void EditReward(Reward oldReward, Reward newReward)
        {
            if (oldReward == null || newReward == null)
                throw new ArgumentNullException();

            foreach (var el in _userRewards)
            {
                if (_userRewards[el.Key].Contains(oldReward))
                {
                    _userRewards[el.Key].Remove(oldReward);
                    _userRewards[el.Key].Add(newReward);

                    _userRewards[el.Key].Sort();
                }
            }
        }


        public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            _userRewards.Remove(user);
        }

        public void RemoveReward(Reward reward)
        {
            foreach (var el in _userRewards)
            {
                if (_userRewards[el.Key].Contains(reward))
                {
                    _userRewards[el.Key].Remove(reward);
                }
            }
        }
        public IDictionary<User, List<Reward>> GetUsersRewards()
        {
            return _userRewards;
        }        
    }
}
