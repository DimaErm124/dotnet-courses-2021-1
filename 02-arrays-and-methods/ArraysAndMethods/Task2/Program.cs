using ArrayLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxRandomValue = 100;
            int oneSize;
            int twoSize;
            int threeSize;
            int[,,] array;

            Console.WriteLine("Enter one size array:");
            oneSize = EnterSizeArray();

            Console.WriteLine("Enter two size array:");
            twoSize = EnterSizeArray();

            Console.WriteLine("Enter three size array:");
            threeSize = EnterSizeArray();

            ThreeDimensionalIntegerArray integerArray = 
                new ThreeDimensionalIntegerArray(oneSize,twoSize,threeSize, maxRandomValue);

            integerArray.GenerateArray();

            array = integerArray.Array;

            Console.WriteLine("\nOriginal array:");
            PrintArray(array);

            ReplacePositiveElementsWithZero(array);

            Console.WriteLine("\nChanged array:");
            PrintArray(array);
        }

        public static void ReplacePositiveElementsWithZero(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        IsPositive(array, i, j, k);
                    }
                }
            }
        }

        public static void IsPositive(int[,,] array, int i, int j, int k)
        {
            if (array[i, j, k] > 0)
            {
                array[i, j, k] = 0;
            }
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
        public static void PrintArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + "  ");
                    }
                    
                }
                Console.WriteLine("");
            }
        }
    }
}
