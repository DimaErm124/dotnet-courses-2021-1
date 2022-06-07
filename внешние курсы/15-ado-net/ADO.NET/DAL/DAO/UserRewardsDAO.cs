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

        public void Edit(User newUser, List<Reward> rewards)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            this.Remove(newUser.ID);
            this.Add(newUser, rewards);
        }

        public void EditReward(Reward newReward)
        {            
            if (newReward == null)
                throw new ArgumentNullException();

            foreach (var el in _userRewards)
            {
                var oldReward = _userRewards[el.Key].Find(x => x.ID == newReward.ID);

                if (_userRewards[el.Key].Contains(oldReward))
                {
                    _userRewards[el.Key].Remove(oldReward);
                    _userRewards[el.Key].Add(newReward);

                    _userRewards[el.Key].Sort();
                }
            }
        }


        public void Remove(int id)
        {
            _userRewards.Remove(((List<User>)_userRewards.Keys).Find(x=>x.ID==id));
        }

        public void RemoveReward(int id)
        {
            foreach (var el in _userRewards)
            {
                var reward = _userRewards[el.Key].Find(x => x.ID == id);

                if (_userRewards[el.Key].Contains(reward))
                {
                    _userRewards[el.Key].Remove(reward);
                }
            }
        } 
    }
}
