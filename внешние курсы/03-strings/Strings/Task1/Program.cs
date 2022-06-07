using HandlerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;

            var inputStrings = InputHandler.EnterString(count);            

            float averageWordsLength = StringHandler.FindAverageWordsLengthInString(inputStrings[count-1]);

            Console.WriteLine("Average words length: {0}", averageWordsLength);
        }   
    }
}
