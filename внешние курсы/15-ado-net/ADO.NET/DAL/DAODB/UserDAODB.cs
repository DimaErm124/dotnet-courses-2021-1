﻿using EntityLibrary;
using HandlerValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAODB : IUserDAO
    {
        private readonly string _connectionString;

        public UserDAODB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            int id = 0;

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.INSERT_USER, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@birthdate", user.Birthdate);

                connection.Open();

                id = (int)command.ExecuteScalar();
            }

            user.ID = id;

            return user;
        }

        public void Edit(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.UPDATE_USER, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userID", newUser.ID);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);
                command.Parameters.AddWithValue("@birthdate", newUser.Birthdate);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.DELETE_USER, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userID", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(CommandNameSql.GET_USERS, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                var usersString = command.ExecuteReader();

                while (usersString.Read())
                {               

                    var id = usersString.GetInt32(0);
                    var firstName = usersString.GetString(1);
                    var lastName = usersString.GetString(2);
                    var birthdate = usersString.GetDateTime(3);

                    var user = new User(id, firstName, lastName, birthdate);

                    users.Add(user);
                }
            }

            return users;
        }
    }
}
