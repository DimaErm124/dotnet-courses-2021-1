﻿using EntityLibrary;
using HandlerValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRewardsDAODB : IUserRewardsDAO
    {
        private readonly string _connectionString;

        public UserRewardsDAODB(string connectionString)
        {
            _connectionString = connectionString;
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
                using (var command = new SqlCommand(CommandNameSql.INSERT_REWARD_OF_USER, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@userID", user.ID);
                    command.Parameters.AddWithValue("@rewardID", reward.ID);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }   
        
        public void Edit(User oldUser, User newUser, List<Reward> rewards)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            this.Remove(newUser);
            this.Add(newUser, rewards);
            
        }

        public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.DELETE_REWARDS_OF_USER, connection))
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
            using (var command = new SqlCommand(CommandNameSql.DELETE_REWARD_OF_USER, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@rewardID", reward.ID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        private List<Reward> GetUserRewards(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var rewards = new List<Reward>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.GET_REWARDS_OF_USER, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userID", user.ID);

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

        public void EditReward(Reward oldReward, Reward newReward)
        {
        }
    }
}
