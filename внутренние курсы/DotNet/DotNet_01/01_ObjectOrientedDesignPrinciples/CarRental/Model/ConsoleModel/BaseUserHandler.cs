using System.Collections.Generic;

namespace CarRental
{
    public class BaseUserHandler : IUserHandler
    {
        private readonly IFileHandler<User> _userFileHandler;

        public BaseUserHandler(IFileHandler<User> userFileHandler)
        {
            _userFileHandler = userFileHandler;
        }

        public List<User> GetAllUsers()
        {
            return _userFileHandler.Read();
        }
    }
}