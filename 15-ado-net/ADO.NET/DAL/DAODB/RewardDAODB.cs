using EntityLibrary;
using HandlerValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RewardDAODB : IRewardDAO
    {
        private readonly string _connectionString;

        public RewardDAODB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.INSERT_REWARD, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@title", reward.Title);
                command.Parameters.AddWithValue("@description", reward.Description);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Reward oldReward, Reward newReward)
        {
            if (oldReward == null || newReward == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.UPDATE_REWARD, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@rewardID", oldReward.ID);
                command.Parameters.AddWithValue("@title", newReward.Title);
                command.Parameters.AddWithValue("@description", newReward.Description);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        
        public void Remove(Reward reward)
        {
            if (reward == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.DELETE_REWARD, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@rewardID", reward.ID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<Reward> GetRewards()
        {
            var rewards = new List<Reward>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.GET_REWARDS, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                var rewardsString = command.ExecuteReader();

                while (rewardsString.Read())
                {

                    var id = rewardsString.GetInt32(0);
                    var title = rewardsString.GetString(1);
                    string description = String.Empty;
                    if (!rewardsString.IsDBNull(2))
                        description = rewardsString.GetString(2);

                    var reward = new Reward(id, title, description);

                    rewards.Add(reward);
                }
            }

            return rewards;
        }        
    }
}
