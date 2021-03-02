using ArrayLibrary;
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
            int maxRandomValue = 10;
            int oneSize;            
            int[] array;

            int sumOfNonNegativeElements;

            Console.WriteLine("Enter one size array:");
            oneSize = EnterSizeArray();

            OneDimensionalIntegerArray integerArray =
                new OneDimensionalIntegerArray(oneSize, maxRandomValue);

            integerArray.GenerateArray();

            array = integerArray.Array;

            Console.WriteLine("\nOriginal array:");
            PrintArray(array);

            sumOfNonNegativeElements = GetSumOfNonNegativeElements(array);

            Console.WriteLine("\nSum of non negative elements:");
            Console.WriteLine(sumOfNonNegativeElements);
        }

        public static int GetSumOfNonNegativeElements(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += IsPositive(array, i);
            }

            return sum;
        }

        public static int IsPositive(int[] array, int i)
        {
            if (array[i] > 0)
            {
                return array[i];
            }

            return 0;
        }

        public static int EnterSizeArray()
        {
            int size = 0;
            string stringSize;

            do
            {
                stringSize = Console.ReadLine();
            }
            while (!IsPositiveInteger(stringSize, ref size));

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
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
