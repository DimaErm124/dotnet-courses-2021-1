using System;

namespace Task1
{
    public delegate int Comparison(string a, string b);

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[] { "aabb", "aaabb", "a", "b", "abbbbbb", "baaa", "aaaba" };

            var strArray = new StringArrayCustomSort(arr, CompareStrings);

            strArray.Sort();

            Console.WriteLine(strArray);
        }

        public static int CompareStrings(string a, string b)
        {
            return a.Length - b.Length;
        }
    }
}
