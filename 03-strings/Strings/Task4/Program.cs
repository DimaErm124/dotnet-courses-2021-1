using HandlerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            var sourceString = InputHandler.EnterString(count);

            CompareSpeed(sourceString[count-1], new StringBuilder(sourceString[count-1]), 1000);
        }

        public static void CompareSpeed(string str, StringBuilder sb, int count)
        {
            SpeedСalculation speedСalculation = new SpeedСalculation();

            string additionStringTime = speedСalculation.CompareStringAdditionSpeed(str, count);
            string additionStringBuilderTime = speedСalculation.CompareStringBuilderAdditionSpeed(sb, count);

            Console.WriteLine("String:        {0} \nStringBuilder: {1}", additionStringTime, additionStringBuilderTime);
        }
    }
}
