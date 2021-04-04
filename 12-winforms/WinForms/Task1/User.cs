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
                return today.Year - Birthdate.Year - 1
                    + ((today.Month >= Birthdate.Month && today.Day >= Birthdate.Day) ? 1 : 0);
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
