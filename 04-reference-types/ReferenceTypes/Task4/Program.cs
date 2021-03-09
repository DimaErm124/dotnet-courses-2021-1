using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public class MyString
    {
        private char[] _charArray;

        public MyString()
        {
            _charArray = string.Empty.ToCharArray();
        }

        public MyString(string sourceString)
        {
            _charArray = sourceString.ToCharArray();
        }

        public MyString(char[] charArray)
        {
            _charArray = charArray;
        }

        public static MyString operator +(MyString ms1, MyString ms2)
        {
            return new MyString(ms1._charArray.Concat(ms2._charArray).ToArray());
        }

        public static MyString operator -(MyString ms1, MyString ms2)
        {
            var regex = new Regex(ms2.ToString());
            return new MyString(regex.Replace(ms1.ToString(), "",1));
        }

        public static bool operator ==(MyString ms1, MyString ms2)
        {
            return ms1._charArray.Equals(ms2._charArray);
        }

        public static bool operator !=(MyString ms1, MyString ms2)
        {
            return !ms1._charArray.Equals(ms2._charArray);
        }

        public override string ToString()
        {
            return new string(_charArray);
        }
    }
}
