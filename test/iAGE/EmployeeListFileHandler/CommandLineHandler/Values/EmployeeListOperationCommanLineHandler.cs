using EmployeeEntityLibrary;
using EmployeeListFileHandler;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CommandLineHandler
{
    public static class EmployeeListOperationCommanLineHandler
    {
        public static string Handle(string[] args, IRepository handler)
        {
            string outputString = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains(OperationValue.Add))
                {
                    outputString += Add(args, ref i, handler);
                }
                else if (args[i].Contains(OperationValue.Delete))
                {
                    outputString += Delete(args, ref i, handler);
                }
                else if (args[i].Contains(OperationValue.Edit))
                {
                    outputString += Edit(args, ref i, handler);
                }
                else if (args[i].Contains(OperationValue.GetAll))
                {
                    outputString += GetAll(handler);
                }
                else if (args[i].Contains(OperationValue.Get))
                {
                    outputString += Get(args, ref i, handler);
                }                

                outputString += '\n';
            }

            return outputString;
        }

        private static string Add(string[] args, ref int i, IRepository handler)
        {
            Employee employee = new();

            for (i++; i < args.Length; i++)
            {
                if (args[i].Contains('-'))
                {
                    i--;
                    break;
                }

                if (args[i].Contains(PropertyNameValue.FirstName))
                    employee.FirstName = GetValue(args[i]);
                if (args[i].Contains(PropertyNameValue.LastName))
                    employee.LastName = GetValue(args[i]);
                if (args[i].Contains(PropertyNameValue.SalaryPerHour) && decimal.TryParse(GetValue(args[i]), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal salary))
                    employee.SalaryPerHour = salary;
            }

            int result = handler.Add(employee);

            if (result == 0)
                return ResultOperationStringValue.AddEmployeeError;

            return ResultOperationStringValue.AddEmployeeSuccess;
        }

        private static string Edit(string[] args, ref int i, IRepository handler)
        {
            Employee employee = new();

            for (i++; i < args.Length; i++)
            {
                if (args[i].Contains('-'))
                {
                    i--;
                    break;
                }
                if (args[i].Contains(PropertyNameValue.Id) && int.TryParse(GetValue(args[i]), out int editId))
                    employee.ID = editId;
                if (args[i].Contains(PropertyNameValue.FirstName))
                    employee.FirstName = GetValue(args[i]);
                if (args[i].Contains(PropertyNameValue.LastName))
                    employee.LastName = GetValue(args[i]);
                if (args[i].Contains(PropertyNameValue.SalaryPerHour) && decimal.TryParse(GetValue(args[i]), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal salary))
                    employee.SalaryPerHour = salary;
            }

            bool result = handler.Edit(employee.ID, employee);

            if (!result)
                return ResultOperationStringValue.EditEmployeeError;

            return ResultOperationStringValue.EditEmployeeSuccess;
        }

        private static string Delete(string[] args, ref int i, IRepository handler)
        {
            i++;

            if (!int.TryParse(GetValue(args[i]), out int deleteId))
            {
                return ResultOperationStringValue.DeleteEmployeeError;
            }

            bool result = handler.Delete(deleteId);

            if (!result)
                return ResultOperationStringValue.DeleteEmployeeError;

            return ResultOperationStringValue.DeleteEmployeeSuccess;
        }

        private static string Get(string[] args, ref int i, IRepository handler)
        {
            i++;

            if (!int.TryParse(GetValue(args[i]), out int getId))
            {
                return ResultOperationStringValue.GetEmployeeError;
            }

            Employee result = handler.Get(getId);

            if (result == null)
                return ResultOperationStringValue.GetEmployeeError;

            return result.ToString();

        }

        private static string GetAll(IRepository handler)
        {
            List<Employee> result = handler.GetAll();

            if (result == null)
                return ResultOperationStringValue.GetAllEmployeeError;

            string resultString = string.Empty;

            foreach(Employee employee in result)
            {
                resultString += employee.ToString() + '\n';
            }
            return resultString;
        }

        private static string GetValue(string parameter)
        {
            return parameter.Substring(parameter.IndexOf(':') + 1, parameter.Length - parameter.IndexOf(':') - 1);
        }
    }
}
