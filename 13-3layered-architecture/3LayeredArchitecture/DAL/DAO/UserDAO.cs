using EntityLibrary;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class UserDAO : IUserDAO
    {
        private List<User> _users;

        public UserDAO()
        {
            _users = new List<User>();
        }

        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            _users.Add(user);
        }        

        public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            _users.Remove(user);
        }
        
        public void Edit(User oldUser, User newUser)
        {
            if (oldUser == null || newUser == null)
                throw new ArgumentNullException();

            this.Remove(oldUser);
            this.Add(newUser);
            this.Sort();
        }

        public void Sort()
        {
            _users.Sort();
        }
        
        public List<User> GetUsers()
        {
            return _users;
        }        
    }
}
