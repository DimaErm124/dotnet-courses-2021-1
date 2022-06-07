using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    public static class GCD
    {
        public static int EuclideanMethod(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }

        public static int EuclideanMethod(int a, int b, int c)
        {
            return EuclideanMethod(EuclideanMethod(a, b), c);
        }

        public static int EuclideanMethod(int a, int b, int c, int d)
        {
            return EuclideanMethod(EuclideanMethod(a, b), EuclideanMethod(c, d));
        }

        public static int EuclideanMethod(int a, int b, int c, int d, int e)
        {
            return EuclideanMethod(EuclideanMethod(EuclideanMethod(a, b), EuclideanMethod(c, d)), e);
        }

        public static int EuclideanMethod(params int[] numbers)
        {
            int gcd = numbers[0];

            if (numbers.Length > 1)
                for (int i = 1; i < numbers.Length; i++)
                {
                    gcd = EuclideanMethod(gcd, numbers[i]);
                }

            return gcd;
        }

        public static int EuclideanMethod(out double ms, params int[] numbers)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            EuclideanMethod(numbers);
            stopwatch.Stop();

            ms = stopwatch.Elapsed.TotalMilliseconds;

            return EuclideanMethod(numbers);
        }

        public static int BinaryMethod(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            int k = 1;

            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while (a % 2 == 0) 
                    a /= 2;
                while (b % 2 == 0) 
                    b /= 2;
                if (a >= b)
                    a -= b; 
                else 
                    b -= a;
            }

            return b * k;
        }

        public static int BinaryMethod(int a, int b, int c)
        {
            return BinaryMethod(BinaryMethod(a, b), c);
        }

        public static int BinaryMethod(int a, int b, int c, int d)
        {
            return BinaryMethod(BinaryMethod(a, b), BinaryMethod(c, d));
        }

        public static int BinaryMethod(int a, int b, int c, int d, int e)
        {
            return BinaryMethod(BinaryMethod(BinaryMethod(a, b), BinaryMethod(c, d)), e);
        }

        public static int BinaryMethod(params int[] numbers)
        {
            int gcd = numbers[0];

            if (numbers.Length > 1)
                for (int i = 1; i < numbers.Length; i++)
                {
                    gcd = BinaryMethod(gcd, numbers[i]);
                }

            return gcd;
        }

        public static int BinaryMethod(out double ms, params int[] numbers)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            BinaryMethod(numbers);
            stopwatch.Stop();

            ms = stopwatch.Elapsed.TotalMilliseconds;

            return BinaryMethod(numbers);
        }
    }
}
