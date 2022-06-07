namespace CarRental
{
    public class BaseRoleVerifier<T> : IRoleVerifier<T>
        where T : User
    {
        private readonly IFileHandler<T> _fileHandler;

        public BaseRoleVerifier(IFileHandler<T> clientFileHandler)
        {
            _fileHandler = clientFileHandler;
        }

        public bool CheckByRoles(string login, string password, out T user)
        {
            user = _fileHandler.Read().Find(x => x.Login == login && x.Password == password);

            if (user != null)
                return true;
            else
                return false;
        }
    }
}