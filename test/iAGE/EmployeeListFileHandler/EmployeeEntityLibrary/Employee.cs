using System;

namespace EmployeeEntityLibrary
{
    public class Employee
    {
        private int _id;

        private decimal _salaryPerHour;

        public int ID
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _id = value;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal SalaryPerHour
        {
            get => _salaryPerHour;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _salaryPerHour = value;
            }
        }

        public Employee() { }

        public Employee(int id, string firstName, string lastName, decimal salaryPerHour)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            SalaryPerHour = salaryPerHour;
        }

        public override string ToString()
        {
            return $"Id={ID} FirstName={FirstName} LastName={LastName} SalaryPerHour={SalaryPerHour}";
        }
    }
}
