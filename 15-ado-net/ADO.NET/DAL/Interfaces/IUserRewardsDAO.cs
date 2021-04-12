using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserRewardsDAO
    {
        void Add(User user, List<Reward> rewards);

        void Edit(User oldUser, User newUser, List<Reward> rewards);

        void EditReward(Reward oldReward, Reward newReward);

        void Remove(User user);

        void RemoveReward(Reward reward);

        List<Reward> this[User user]
        {
            get;
        }
    }
}
