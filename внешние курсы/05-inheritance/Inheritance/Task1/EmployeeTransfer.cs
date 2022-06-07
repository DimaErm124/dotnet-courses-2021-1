using System;

namespace Task1
{
    public class EmployeeTransfer: IEmployeeTransfer
    {
        private double _salary;

        private double _newSalary;

        public DateTime TransferDate { get; private set; }

        public string Department { get ; private set; }

        public string Title { get ; private set; }

        public double Salary 
        {
            get => _salary; 
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid salary");
                }
                _salary = value;
            }
        }

        public string NewDepartment { get; private set; }

        public string NewTitle { get; private set; }

        public double NewSalary
        {
            get => _newSalary;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid salary");
                }
                _newSalary = value;
            }
        }


        public EmployeeTransfer(string department, string title, double salary, string newDepartment, string newTitle, double newSalary)
        {
            Department = department;
            Title = title;
            Salary = salary;

            NewDepartment = newDepartment;
            NewTitle = newTitle;
            NewSalary = newSalary;

            TransferDate = DateTime.Now;
        }
    }
}
