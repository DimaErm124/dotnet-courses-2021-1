using EntityLibrary;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class RewardDAO : IRewardDAO
    {
        private List<Reward> _rewards;

        public RewardDAO()
        {
            _rewards = new List<Reward>();
        }

        public void Add(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            _rewards.Add(reward);
        }       

        public void Remove(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            _rewards.Remove(reward);
        }
        
        public void Edit(Reward oldReward, Reward newReward)
        {
            if (oldReward == null || newReward == null)
                throw new ArgumentNullException();

            this.Remove(oldReward);
            this.Add(newReward);
            this.Sort();
        }

        public void Sort()
        {
            _rewards.Sort();
        } 
        
        public List<Reward> GetRewards()
        {
            return _rewards;
        }        
    }
}
