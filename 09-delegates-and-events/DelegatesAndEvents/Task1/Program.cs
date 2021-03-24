using SortLibrary;
using System;

namespace Task1
{
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
            if (a.Length == b.Length && !IsOrder(a, b))
            {
                return 1;
            }

            return a.Length - b.Length;
        }

        public static bool IsOrder(string a, string b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i])
                {
                    return true;
                }
                if (a[i] > b[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
