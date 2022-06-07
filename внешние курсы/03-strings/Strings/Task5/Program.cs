using HandlerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;

            var regexHTMLtag = new Regex(@"<.*?>");

            var inputString = InputHandler.EnterString(count);

            Console.WriteLine("Replacement: \n{0}", regexHTMLtag.Replace(inputString[count - 1], "_"));
        }
    }
}
