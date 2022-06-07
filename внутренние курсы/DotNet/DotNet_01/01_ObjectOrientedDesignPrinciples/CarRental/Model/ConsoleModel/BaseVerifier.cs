using System.Collections.Generic;

namespace CarRental
{
    public class BaseVerifier : IVerifier
    {
        private readonly IFileHandler<User> _userFileHandler;

        public BaseVerifier(IFileHandler<User> userFileHandler)
        {
            _userFileHandler = userFileHandler;
        }

        public bool Check(string login, string password, out User user)
        {
            List<User> users = _userFileHandler.Read();

            if (users != null && users.Count > 0)
            {
                user = users.Find(x => x.Login == login && x.Password == password);
            }
            else
            {
                user = null;
            }

            if (user != null)
                return true;
            else
                return false;
        }
    }
}