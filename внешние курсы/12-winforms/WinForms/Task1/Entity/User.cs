using System;

namespace Task1
{
    public class User : IComparable
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age 
        {
            get
            {
                var today = DateTime.Now;
                return Birthdate.Year - today.Year - 1
                    + ((today.Month >= Birthdate.Month || (today.Month == Birthdate.Month && today.Day >= Birthdate.Day)) ? 1 : 0);
            }
        }

        public object this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "FirstName":
                        return FirstName;
                    case "LastName":
                        return LastName;
                    case "Birthdate":
                        return Birthdate;
                    case "Age":
                        return Age;
                    default:
                        return ID;
                }
            }
        }

        public User(int id, string firstName, string lastName, DateTime birthdate)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public int CompareTo(object obj)
        {
            return ID.CompareTo(((User)obj).ID);
        }
    }
}
