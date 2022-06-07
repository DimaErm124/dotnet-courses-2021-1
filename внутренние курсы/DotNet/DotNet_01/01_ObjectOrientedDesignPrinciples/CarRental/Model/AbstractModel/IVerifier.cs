namespace CarRental
{
    public interface IVerifier
    {
        public bool Check(string login, string password, out User user);
    }
}