using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IRewardDAO
    {
        void Add(Reward reward);

        void Remove(int id);

        void Edit(Reward newReward);

        List<Reward> GetRewards();
    }

}
