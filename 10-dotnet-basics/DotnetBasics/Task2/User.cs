using System;

namespace Task2
{
    public class User
    {
        private DateTime _birthday;

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Patronymic { get; private set; }

        public int Age { get { return new DateTime((DateTime.Today - Birthday).Ticks).Year; } }

        public virtual DateTime Birthday
        {
            get { return _birthday; }

            set
            {
                if ((value.Year > DateTime.Now.Year - 7) || (value.Year < DateTime.Now.Year - 80))
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

        public override string ToString()
        {
            return "Name: " + Name + "\n" + "Lastame: " + LastName + "\n" + "Patronymic: " + Patronymic + "\n";
        }
    }
}
