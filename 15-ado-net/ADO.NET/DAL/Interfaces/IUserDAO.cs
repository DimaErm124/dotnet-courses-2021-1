using EntityLibrary;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAO
    {
        User Add(User user);
        
        void Edit(User newUser);

        void Remove(int id);

        List<User> GetUsers();
    }
}
