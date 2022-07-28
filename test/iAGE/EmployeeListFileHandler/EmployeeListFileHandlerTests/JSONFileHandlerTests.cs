using EmployeeEntityLibrary;
using EmployeeListFileHandler;
using NUnit.Framework;
using System.Linq;

namespace EmployeeListFileHandlerTests
{
    public class JSONFileHandlerTests
    {
        [TestCase(ExpectedResult = true)]
        public bool Test_AddEmployee()
        {
            IRepository repository = new JSONFileHadler("EmployeeListTest.json");

            try
            {
                repository.Add(new Employee());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}