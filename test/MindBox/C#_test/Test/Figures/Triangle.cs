using System;

namespace Figures
{
    public class Triangle : IFlat
    {
        private double _a;

        private double _b;

        private double _c;

        public double A
        {
            get => _a;
            set { if (value <= 0) { throw new Exception("Side A must be greater than zero!"); } _a = value; }
        }

        public double B
        {
            get => _b;
            set { if (value <= 0) { throw new Exception("Side B must be greater than zero!"); } _b = value; }
        }

        public double C
        {
            get => _c;
            set { if (value <= 0) { throw new Exception("Side C must be greater than zero!"); } _c = value; }
        }

        public Triangle(double a, double b, double c)
        {
            if (!IsTriangle(a, b, c))
            {
                throw new Exception("You cannot create a triangle with these sides!");
            }

            A = a;
            B = b;
            C = c;
        }
        public double GetPerimeter()
        {
            return _a + _b + _c;
        }

        public double GetSemiperimeter()
        {
            return GetPerimeter() / 2;
        }

        public double Square()
        {
            return Math.Sqrt(GetSemiperimeter() * (GetSemiperimeter() - _a) * (GetSemiperimeter() - _b) * (GetSemiperimeter() - _c));
        }

        public static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public bool IsRightTriangle()
        {
            return (A * A == B * B + C * C) 
                || (B * B == A * A + C * C) 
                || (C * C == B * B + A * A);
        }
    }
}
