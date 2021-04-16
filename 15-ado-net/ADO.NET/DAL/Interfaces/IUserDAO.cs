using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAO
    {
        User Add(User user);
        
        void Edit(User oldUser, User newUser);

        void Remove(User user);

        List<User> GetUsers();
    }
}
