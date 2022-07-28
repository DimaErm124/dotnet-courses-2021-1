using EmployeeEntityLibrary;
using System.Collections.Generic;

namespace EmployeeListFileHandler
{
    public interface IRepository
    {
        int Add(Employee employee);

        bool Delete(int ID);

        bool Edit(int ID, Employee employee);

        Employee Get(int ID);

        List<Employee> GetAll();

    }
}