using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserRewardsDAO
    {
        void Add(User user, List<Reward> rewards);

        void Edit(User newUser, List<Reward> rewards);

        void EditReward(Reward newReward);

        void Remove(int id);

        void RemoveReward(int id);

        List<Reward> this[User user]
        {
            get;
        }
    }
}
