using HandlerValue;
using System;

namespace EntityLibrary
{
    public class User : IComparable
    {
        private string _firstName;
        
        private string _lastName;
        
        private DateTime _birthdate;

        public int ID { get; set; }

        public string FirstName 
        {
            get { return _firstName; }
            set
            {
                if (value.Length > InputHandlerValue.MAX_LENGTH_FIRST_NAME)
                {
                    throw new ArgumentException();
                }

                _firstName = value;
            } 
        }

        public string LastName 
        {
            get { return _lastName; }
            set
            {
                if (value.Length > InputHandlerValue.MAX_LENGTH_LAST_NAME)
                {
                    throw new ArgumentException();
                }

                _lastName = value;
            }
        }

        public DateTime Birthdate 
        {
            get { return _birthdate; }
            set 
            {
                var today = DateTime.Now;

                if (value > today || value < value.AddYears(-InputHandlerValue.MAX_AGE)) 
                {
                    throw new ArgumentException();
                }

                _birthdate = value;
            } 
        }

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
