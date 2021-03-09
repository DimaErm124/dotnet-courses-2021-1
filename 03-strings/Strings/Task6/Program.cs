using HandlerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {      
            var inputStrings = InputHandler.EnterString(1);

            Console.WriteLine(CheckingNotation(inputStrings[0]));
        }

        public static string CheckingNotation(string inputString)
        {
            Regex expNotationPattern    = new Regex(@"[-]?\d[.,]\d+[e][+-]\d+");
            Regex normalNotationPattern = new Regex(@"[-]?\d+([.,]\d)?");

            if (expNotationPattern.Match(inputString).Length == inputString.Length)
            {
                return "It is exponential notation";
            }

            if (normalNotationPattern.Match(inputString).Length == inputString.Length)
            {
                return "It is normal notation";
            }

            return "It is not a number";         
            
        }
    }
}
