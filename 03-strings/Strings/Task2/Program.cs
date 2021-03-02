using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInputString;
            string secondInputString;

            string changedString;

            Console.WriteLine("Enter first string:");
            firstInputString = Console.ReadLine();

            Console.WriteLine("Enter second string:");
            secondInputString = Console.ReadLine();

            changedString = ReplaceAllSymbols(firstInputString, secondInputString);

            Console.WriteLine("Changed string:");
            Console.WriteLine(changedString);
        }

        public static string ReplaceAllSymbols(string firstInputString, string secondInputString)
        {
            string str=firstInputString;

            foreach(char el in secondInputString)
            {
                string duplicateSymbol = el.ToString();
                str = str.Replace(duplicateSymbol, new string(el,2));
            }

            return str;
        }
    }
}
