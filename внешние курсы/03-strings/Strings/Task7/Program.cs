using HandlerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = InputHandler.EnterString(1);

            Console.WriteLine("Time is present in the text {0} time.", FindTimeInText(strings[0]));
        }

        public static int FindTimeInText(string sourceString)
        {
            Regex timeInTextPattern = new Regex(@"([1]?[0-9]|[2][1-3])[:][0-5][0-9]");

            var timeInText = timeInTextPattern.Matches(sourceString);

            return timeInText.Count;
        }
    }
}
