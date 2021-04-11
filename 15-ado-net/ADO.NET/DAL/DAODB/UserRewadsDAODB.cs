using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public class UserRewadsDAODB : IUserRewardsDAO
    {
        public List<Reward> this[User user] => throw new System.NotImplementedException();

        public void Add(User user, List<Reward> rewards)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(User oldUser, User newUser, List<Reward> rewards)
        {
            throw new System.NotImplementedException();
        }

        public void EditReward(Reward oldReward, Reward newReward)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<User, List<Reward>> GetUsersRewards()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveReward(Reward reward)
        {
            throw new System.NotImplementedException();
        }
    }
}
