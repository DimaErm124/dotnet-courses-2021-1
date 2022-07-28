using EmployeeEntityLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeListFileHandler
{
    public class JSONFileHadler : IRepository
    {
        private string _filePath;

        public JSONFileHadler(string filePath)
        {
            _filePath = filePath;
        }

        public int Add(Employee employee)
        {
            List<Employee> employees = Deserialize();

            employee.ID = employees.Count == 0 ? 1 : employees.Max(x => x.ID) + 1;
            employees.Add(employee);

            if (!Serialize(employees))
                return 0;

            return employee.ID;

        }

        public bool Delete(int ID)
        {
            List<Employee> employees = Deserialize();

            employees.Remove(employees.Find(x => x.ID == ID));

            if (!Serialize(employees))
                return false;

            return true;
        }

        public bool Edit(int ID, Employee employee)
        {
            List<Employee> employees = Deserialize();

            Employee oldEmployee = employees.Find(x => x.ID == employee.ID);

            employee.FirstName = string.IsNullOrEmpty(employee.FirstName) ? oldEmployee.FirstName : employee.FirstName;
            employee.LastName = string.IsNullOrEmpty(employee.LastName) ? oldEmployee.LastName : employee.LastName;
            employee.SalaryPerHour = employee.SalaryPerHour == 0 ? oldEmployee.SalaryPerHour : employee.SalaryPerHour;

            employees.Remove(oldEmployee);

            employees.Add(employee);

            if (!Serialize(employees))
                return false;

            return true;
        }

        public Employee Get(int ID)
        {
            return Deserialize().Find(x => x.ID == ID);
        }

        public List<Employee> GetAll()
        {
            return Deserialize();
        }

        private List<Employee> Deserialize()
        {
            FileStream fs = new(_filePath, FileMode.OpenOrCreate);

            try
            {
                string textFromFile = Read(fs);

                if (string.IsNullOrEmpty(textFromFile))
                    return new List<Employee>();

                return JsonConvert.DeserializeObject<List<Employee>>(textFromFile);
            }
            catch
            {
                fs.Dispose();
                return new List<Employee>();
            }
            finally
            {
                fs.Dispose();
            }

        }

        private bool Serialize(List<Employee> employees)
        {
            FileStream fs = new(_filePath, FileMode.Create);

            try
            {
                string textInFile = JsonConvert.SerializeObject(employees);

                Write(fs, textInFile);

                return true;
            }
            catch
            {
                fs.Dispose();

                return false;
            }
            finally
            {
                fs.Dispose();
            }
        }

        private string Read(FileStream fileStream)
        {
            byte[] buffer = new byte[fileStream.Length];

            fileStream.Read(buffer, 0, buffer.Length);

            return Encoding.Default.GetString(buffer);
        }

        private void Write(FileStream fileStream, string text)
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            fileStream.Position = 0;
            fileStream.Write(buffer, 0, buffer.Length);
        }
    }
}