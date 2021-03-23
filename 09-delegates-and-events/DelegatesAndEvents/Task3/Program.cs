using SortLibrary;
using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[] { "aabb", "aaabb", "a", "b", "abbbbbb", "baaa", "aaaba" };

            var strArray = new StringArrayCustomSort(arr, CompareStrings);

            var sortThread = strArray.SortAsync();

            strArray.FinishSorting += FinishSorting;
            Thread.CurrentThread.Name = " 111"; 
            sortThread.Start();
            strArray.Sort();

            Console.WriteLine(strArray);
        }

        public static int CompareStrings(string a, string b)
        {
            return a.Length - b.Length;
        }

        public static void FinishSorting()
        {
            Console.WriteLine("Sorting is end");
        }
    }
}
