using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IRewardDAO
    {
        void Add(Reward reward);

        void Remove(Reward reward);

        void Edit(Reward oldReward, Reward newReward);

        List<Reward> GetRewards();
    }

}
