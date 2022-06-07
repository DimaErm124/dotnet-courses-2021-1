using GreatestCommonDivisor;
using System;
using System.Collections.Generic;

namespace GreatestCommonDivisorUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            List<int> numbers = new List<int>();
            while (true)
            {
                int number = InputPositiveIntegerNumber($"Enter {numbers.Count + 1} integer number (empty string - continue):");
                if (number == 0)
                    break;
                numbers.Add(number);
            }

            if (numbers.Count != 0)
            {
                OutputGCD(GCD.EuclideanMethod(out double ms, numbers.ToArray()), "Euclidean method", ms);

                OutputGCD(GCD.BinaryMethod(out ms, numbers.ToArray()), "Binary method", ms);
            }
        }

        public static void OutputGCD(int GCD, string methodName, double timework)
        {
            Console.WriteLine($"{methodName}: {GCD}");
            Console.WriteLine($"Total milliseconds: {timework}\n");
        }

        public static int InputPositiveIntegerNumber(string invitationString)
        {
            int power = 0;

            while (true)
            {
                Console.WriteLine(invitationString);
                string inputString = Console.ReadLine();
                if (inputString.Trim().Equals(string.Empty))
                    break;
                if (int.TryParse(inputString, out power))
                {
                    if (power < 0)
                        power = Math.Abs(power);
                    break;
                }
            }

            return power;
        }
    }
}