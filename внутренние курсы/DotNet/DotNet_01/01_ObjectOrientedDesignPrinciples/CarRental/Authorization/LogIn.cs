namespace CarRental
{
    public class LogIn
    {
        private IVerifier _verifier;

        public LogIn(IVerifier verifier)
        {
            _verifier = verifier;
        }

        public bool Enter(string login, string password, out User user)
        {
            return _verifier.Check(login, password, out user);
        }

        public bool EnterByRoles<T>(IRoleVerifier<T> roleVerifier, string login, string password, out T user)
            where T : User
        {
            return roleVerifier.CheckByRoles(login, password, out user);
        }
    }
}