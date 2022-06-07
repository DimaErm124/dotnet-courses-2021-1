using System;

namespace CarRental
{
    [Serializable]
    public class Client : IComparable<Client>, IEquatable<Client>
    {
        private string _name;

        private string _surname;

        private int _driverLicense;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Client`s name couldn`t be null or empty!");
                }
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Client`s surname couldn`t be null or empty!");
                }
                _surname = value;
            }
        }

        public int DriverLicense
        {
            get => _driverLicense;
            set
            {
                if (value <= 0 || value.ToString().Length != ModelValues.DriverLicenseSize)
                {
                    if (value <= 0)
                        throw new ArgumentNullException("Number driver license cannot be less than zero!");
                    else
                        throw new ArgumentNullException("Length of number driver license must be equal " + ModelValues.DriverLicenseSize + "!");
                }
                _driverLicense = value;
            }
        }

        public Client() { }

        public Client(string name, string surname, int driverLicense)
        {
            Name = name;
            Surname = surname;
            DriverLicense = driverLicense;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\n"
                + "Surname: " + Surname + "\n"
                + "DriverLicense: " + DriverLicense + "\n";
        }

        public int CompareTo(Client other)
        {
            if (DriverLicense.CompareTo(other.DriverLicense) == 0)
                if (Name.CompareTo(other.Name) == 0)
                    if (Surname.CompareTo(other.Surname) == 0)
                        return 0;
                    else
                        return Surname.CompareTo(other.Surname);
                else
                    return Name.CompareTo(other.Name);
            else
                return DriverLicense.CompareTo(other.DriverLicense);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            Client client = obj as Client;

            if (client == null) 
                return false;
            else 
                return Equals(client);
        }

        public bool Equals(Client other)
        {
            if (other == null)
                return false;

            return DriverLicense.Equals(other.DriverLicense)
                && DriverLicense.Equals(other.DriverLicense)
                && DriverLicense.Equals(other.DriverLicense);
        }
    }
}