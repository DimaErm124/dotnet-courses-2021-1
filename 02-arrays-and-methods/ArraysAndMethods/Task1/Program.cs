using ArrayLibrary;
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
            int maxRandomValue = 100;
            int n;
            int[] array;
            int maxV;
            int minV;

            n = EnterSizeArray();

            OneDimensionalIntegerArray integerArray = new OneDimensionalIntegerArray(n, maxRandomValue);

            integerArray.GenerateArray();
            array = integerArray.Array;
            integerArray.SortAndGetMinAndMaxValues(out maxV, out minV);

            PrintArray(array);
        }

        public static int EnterSizeArray()
        {
            int size = 0;
            string stringSize;

            do
            {
                Console.WriteLine("Enter size array:");
                stringSize = Console.ReadLine();
            }

            while (!IsPositiveInteger(stringSize,ref size));

            return size;
        }

        public static bool IsPositiveInteger(string stringSize, ref int size)
        {
            if (int.TryParse(stringSize, out size))
                if (size > 0)
                    return true;

            return false;
        }
        public static void PrintArray(int[] array)
        {
            Console.WriteLine("Sorted array:");
            foreach(int el in array)
            {
                Console.WriteLine(el + "\n");
            }
        }
    }
}
