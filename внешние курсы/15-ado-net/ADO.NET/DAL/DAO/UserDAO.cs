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

        public User Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            _users.Add(user);

            return user;
        }        

        public void Remove(int id)
        {
            _users.Remove(_users.Find(x => x.ID == id));
        }
        
        public void Edit(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException();

            this.Remove(newUser.ID);
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
