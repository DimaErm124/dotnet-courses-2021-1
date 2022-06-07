using HandlerLibrary;
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
            int count = 2;

            var inputStrings = InputHandler.EnterString(count);

            string changedString = StringHandler.DoubleSymbolsFromSecondString(inputStrings[0], StringHandler.DeleteDuplicateSymbols(inputStrings[1]));

            Console.WriteLine("Changed string: {0}", changedString);
        }        
    }
}
