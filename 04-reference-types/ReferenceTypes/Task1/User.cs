using System;

namespace Task1
{
    public class User
    {
        private DateTime _birthday;

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Patronymic { get; private set; }

        public int Age { get { return new DateTime((DateTime.Today - Birthday).Ticks).Year; } }

        public DateTime Birthday 
        { 
            get { return _birthday; }

            private set 
            {
                if ((value > new DateTime(DateTime.Now.Year - 7, DateTime.Now.Month, DateTime.Now.Day)) || (value < new DateTime(DateTime.Now.Year - 80, DateTime.Now.Month, DateTime.Now.Day)))
                    throw new Exception("Invalid birthday!"); 
                else _birthday = value; 
            }
        }

        public User(string name, string lastName, string patronymic, DateTime birthday)
        {            
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            Birthday = birthday;            
        }
    }
}
