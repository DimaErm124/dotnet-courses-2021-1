using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Task2
{
    public class Employee : User, IEmployeeTransfer, IEquatable<Employee>
    {
        private double _salary;

        public long Identificator { get; private set; }

        public string Department { get; private set; }

        public string Title { get; private set; }

        public override DateTime Birthday
        {
            get => base.Birthday;
            set
            {
                if ((new DateTime((DateTime.Now - value).Ticks)).Year < 18)
                    throw new Exception("Invalid birthday!");
                else
                    base.Birthday = value;
            }
        }

        public DateTime EmploymentDate { get; set; }

        public DateTime Experience { get { return new DateTime((DateTime.Now - EmploymentDate).Ticks); } }

        public virtual double Salary
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

        public List<EmployeeTransfer> EmployeeTransfers { get; private set; }

        public Employee(string name, string lastName, string patronymic, DateTime birthday, long identificator) : base(name, lastName, patronymic, birthday)
        {
            Identificator = identificator;
            EmploymentDate = DateTime.Now;
            EmployeeTransfers = new List<EmployeeTransfer>();
        }

        public Employee(string name, string lastName, string patronymic, DateTime birthday, long identificator, DateTime employmentDate) : base(name, lastName, patronymic, birthday)
        {
            Identificator = identificator;
            EmploymentDate = employmentDate;
            EmployeeTransfers = new List<EmployeeTransfer>();
        }

        public void TransferEmployee(string newDepartment, string newTitle, double newSalary)
        {
            EmployeeTransfers.Add(new EmployeeTransfer(Department, Title, Salary, newDepartment, newTitle, newSalary));

            Department = newDepartment;
            Title = newTitle;
            Salary = newSalary;
        }

        public override string ToString()
        {
            return base.ToString()
                + "Employment date: " + EmploymentDate.ToString() + "\n"
                + "Actually department: " + Department.ToString() + "\n"
                + "Actually title: " + Title.ToString() + "\n"
                + "Actually salary: " + Salary.ToString("C", new CultureInfo("en")) + "\n"
                + "Experience: " + Experience.ToString() + "\n"
                + "Count of employee transfers: " + EmployeeTransfers.Count.ToString() + "\n";
        }

        public bool Equals(Employee other)
        {
            if (other == null)
                return false;

            return other.Identificator == Identificator;
        }
    }
}
