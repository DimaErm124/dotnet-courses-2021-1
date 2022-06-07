using HandlerValue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PLmvc.Models
{
    public class UserViewModel
    {
        private string _firstName;

        private string _lastName;

        private DateTime _birthdate;

        public int ID { get; set; }

        [Required]
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

        [Required]
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

        [Required]
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
                return today.Year - Birthdate.Year - 1
                    + ((today.Month >= Birthdate.Month || (today.Month == Birthdate.Month && today.Day >= Birthdate.Day)) ? 1 : 0);
            } 
        }

        public IEnumerable<int> Rewards { get; set; }
    }
}
