using MathLibrary;
using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 3;
            double x = 2;
            double y = 4;

            Console.WriteLine("{0}! = {1}", number, MathFunctions.Factorial(number));
            Console.WriteLine("{0}^{1} = {2}", x, y, MathFunctions.Power(x, y));
        }
    }
}
