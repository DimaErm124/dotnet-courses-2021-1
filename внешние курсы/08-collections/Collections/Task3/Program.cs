using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello, User; hello, app of split";

            var stringSplit = new StringSplit(str);

            OutputStringSplit(stringSplit.SplitString());
        }

        public static void OutputStringSplit(IDictionary<string,int> dictionary)
        {
            Console.WriteLine("Frequency of occurrencee:");
            foreach (var el in dictionary)
            {
                Console.WriteLine(" {0}: {1}", el.Key, el.Value);
            }
        }
    }
}
