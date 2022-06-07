namespace CarRental
{
    public interface IRoleVerifier<T>
        where T : User
    {
        public bool CheckByRoles(string login, string password, out T user);
    }
}