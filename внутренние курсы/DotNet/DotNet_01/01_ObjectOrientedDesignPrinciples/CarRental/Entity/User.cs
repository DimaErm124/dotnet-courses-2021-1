using System;

namespace CarRental
{
    [Serializable]
    public class User
    {
        private string _login;

        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                foreach(char el in value)
                {
                    if (char.IsWhiteSpace(el) || char.IsPunctuation(el))
                    {
                        throw new ArgumentException("Login must not have whitespace or punctuation!");
                    }
                }

                if (value.Length < ModelValues.LoginMinSize 
                    || value.Length > ModelValues.LoginMaxSize)
                {
                    throw new ArgumentException("Login must have size more than " + ModelValues.LoginMinSize + " and less than" + ModelValues.LoginMaxSize);
                }

                _login = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                foreach (char el in value)
                {
                    if (char.IsWhiteSpace(el) || char.IsPunctuation(el))
                    {
                        throw new ArgumentException("Password must not have whitespace or punctuation!");
                    }
                }

                if (value.Length < ModelValues.PasswordMinSize)
                {
                    throw new ArgumentException("Login must have size more than " + ModelValues.PasswordMinSize );
                }

                _password = value;
            }
        }

        public Role Role { get; set; }

        public User() { }

        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return "Login: " + Login + "\n"
                + "Password: " + Password + "\n"
                + "Role: " + Role + "\n";
        }
    }
}