using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = CreateEmployee("John", "Smith", "Johnson", new DateTime(1998, 10, 13));

            AddEmployeeTransfer(employee, "", "",600);

            OutputEmployee(employee);
        }

        public static Employee CreateEmployee(string name, string lastName, string patronymic, DateTime birthday)
        {
            Employee employee = null;

            try
            {
                employee = new Employee(name, lastName, patronymic, birthday);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return employee;
        }

        public static void AddEmployeeTransfer(Employee employee,string newDepartment, string newTitle, double newSalary)
        {
            try
            {
                employee.TransferEmployee(newDepartment, newTitle, newSalary);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void OutputEmployee(Employee employee)
        {
            try
            {
                Console.WriteLine(employee.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
