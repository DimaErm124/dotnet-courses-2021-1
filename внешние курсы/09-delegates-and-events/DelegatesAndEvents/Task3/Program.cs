using SortLibrary;
using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main thread";
            
            var arr = new string[] { "aabb", "aaabb", "a", "b", "abbbbbb", "baaa", "aaaba" };

            var strArray = new StringArrayCustomSort(arr, CompareStrings);
            var strAsyncArray = new StringArrayCustomSort(arr, CompareStrings);

            var sortThread = strAsyncArray.SortAsync();

            strArray.FinishSorting += FinishSorting;
            strAsyncArray.FinishSorting += FinishSorting;

            sortThread.Start();
            strArray.Sort();

            Console.WriteLine(strArray);
            Console.WriteLine(strAsyncArray);
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

        public static void FinishSorting()
        {
            Console.WriteLine("Sorting is end in " + Thread.CurrentThread.Name);
        }
    }
}
