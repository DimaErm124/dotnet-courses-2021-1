using System.Collections.Generic;

namespace CarRental
{
    public interface IUserHandler
    {
        public List<User> GetAllUsers();
    }
}