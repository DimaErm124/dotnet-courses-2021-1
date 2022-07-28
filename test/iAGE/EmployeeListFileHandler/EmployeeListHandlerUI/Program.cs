using CommandLineHandler;
using EmployeeListFileHandler;
using System;

namespace EmployeeListHandlerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EmployeeListOperationCommanLineHandler.Handle(args, new JSONFileHadler("EmployeeList.json")));
        }
    }
}