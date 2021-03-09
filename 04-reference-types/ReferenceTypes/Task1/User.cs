using System;

namespace Task1
{
    public class User
    {
        private DateTime _birthday;

        private string _lastName;

        private string _patronymic;

        public string Name { get; private set; }

        public string LastName 
        {
            get { return _lastName; }

            private set { if (value.Equals(Name)){ throw new Exception("Lastname not be equal to name!"); } _lastName = value; } 
        }

        public string Patronymic 
        {
            get { return _patronymic; }
            private set 
            { 
                if (value.Equals(Name)) { throw new Exception("Patronymic not be equal to name!"); }
                if (value.Equals(LastName)) { throw new Exception("Patronymic not be equal to lastname!"); }
                _patronymic = value; 
            }
        }

        public int Age { get { return DateTime.Today.Year - Birthday.Year; } }

        public DateTime Birthday 
        { 
            get { return _birthday; }

            private set { if (value > new DateTime(2015, 12, 31)) throw new Exception("Invalid birthday!"); else _birthday = value; }
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
