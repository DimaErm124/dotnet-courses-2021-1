using ArrayLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxRandomValue = 10;
            int oneSize;
            int twoSize;
            int[,] array;

            int sumOfElementsOnEvenPositions;

            Console.WriteLine("Enter one size array:");
            oneSize = EnterSizeArray();

            Console.WriteLine("Enter two size array:");
            twoSize = EnterSizeArray();

            TwoDimensionalIntegerArray integerArray =
                new TwoDimensionalIntegerArray(oneSize, twoSize, maxRandomValue);

            integerArray.GenerateArray();
            array = integerArray.Array;

            Console.WriteLine("\nOriginal array:");
            PrintArray(array);

            sumOfElementsOnEvenPositions = GetSumOfElementsOnEvenPositions(array);

            Console.WriteLine("\nSum of elements on even positions:");
            Console.WriteLine(sumOfElementsOnEvenPositions);
        }

        public static int GetSumOfElementsOnEvenPositions(int[,] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)            
                for (int j = 0; j < array.GetLength(1); j++)                
                    sum += IsEvenPosition(array, i,j);           
            
            return sum;
        }

        public static int IsEvenPosition(int[,] array, int i, int j)
        {
            if ((i + j) % 2 == 0)            
                return array[i,j];        

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

        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)                
                    Console.Write(array[i,j] + " ");
                
                Console.WriteLine("");
            }
        }
    }
}
