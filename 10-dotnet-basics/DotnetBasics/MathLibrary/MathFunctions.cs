using System;

namespace MathLibrary
{
    public static class MathFunctions
    {
        public static long Factorial(int number)
        {
            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static double Power(double x, double y)
        {
            double power = 1;

            for(int i = 1; i <= y; i++)
            {
                power *= x;
            }

            return power;
        }
    }
}
