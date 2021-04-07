using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAO
    {
        void Add(User user);
        
        void Edit(User oldUser, User newUser);

        void Remove(User user);

        void Sort();

        List<User> GetUsers();
    }
}
