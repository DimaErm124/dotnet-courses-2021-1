using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerLibrary
{
    public class InputHandler
    {
        public static string[] EnterString(int count)
        {
            string[] inputStrings = new string[count];

            for (int i = 0; i < inputStrings.Length; i++)
            {
                do
                {
                    Console.WriteLine("Enter {0} string", (i + 1).ToString());
                    inputStrings[i] = Console.ReadLine();
                }
                while (inputStrings[i] == string.Empty);
            }

            return inputStrings;
        }
    }
}
