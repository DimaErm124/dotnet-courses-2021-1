using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRewadsDAODB : IUserRewardsDAO
    {
        private readonly string _connectionString;

        public UserRewadsDAODB()
        {
            _connectionString = "";
        }

        public List<Reward> this[User user]
        {
            get
            {
                return GetUserRewards(user);
            }
        }

        public void Add(User user, List<Reward> rewards)
        {
            if (user == null)
                throw new ArgumentNullException();

            foreach (var reward in rewards)
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@userID", user.ID);
                    command.Parameters.AddWithValue("@rewardID", user.ID);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }   

        public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userID", user.ID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void RemoveReward(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@rewardID", reward.ID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        private List<Reward> GetUserRewards(User user)
        {
            var rewards = new List<Reward>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userID", user.ID);

                connection.Open();

                var rewardsString = command.ExecuteReader();

                while (rewardsString.Read())
                {

                    var id = rewardsString.GetInt32(0);
                    var title = rewardsString.GetString(1);
                    var description = rewardsString.GetString(2);

                    var reward = new Reward(id, title, description);

                    rewards.Add(reward);
                }
            }

            return rewards;
        }

        public void Edit(User oldUser, User newUser, List<Reward> rewards)
        {
            throw new System.NotImplementedException();
        }

        public void EditReward(Reward oldReward, Reward newReward)
        {
            throw new System.NotImplementedException();
        }
    }
}
