using System;

namespace Task1
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get => new DateTime((DateTime.Now - Birthdate).Ticks).Year; }

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
    }
}
