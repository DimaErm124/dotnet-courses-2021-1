using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString1 = new MyString();
            MyString myString2 = new MyString("lo".ToCharArray());

            Console.WriteLine(" {0} + {1} = {2}", myString1, myString2, myString1 + myString2);
            Console.WriteLine(" {0} - {1} = {2}", myString1, myString2, myString1 - myString2);
            Console.WriteLine(" {0} == {1} = {2}", myString1, myString2, myString1 == myString2);
            Console.WriteLine(" {0} != {1} = {2}", myString1, myString2, myString1 != myString2);
        }
    }
}
