using System;

namespace Task3
{
    public class Triangle
    {
        private double _a;

        private double _b;

        private double _c;

        public double A
        {
            get { return _a; }
            private set { if (value <= 0) { throw new Exception("Side A must be greater than zero!"); }  _a = value; }
        }

        public double B
        {
            get { return _b; }
            private set { if (value <= 0) { throw new Exception("Side B must be greater than zero!"); }  _b = value; }
        }

        public double C
        {
            get { return _c; }
            private set { if (value <= 0) { throw new Exception("Side C must be greater than zero!"); }  _c = value; }
        }

        public Triangle(double a, double b, double c)
        {
            if (!IsTriangleRule(a, b, c))
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

        public double GetArea()
        {
            return Math.Sqrt(GetSemiperimeter()*(GetSemiperimeter() - _a)*(GetSemiperimeter() - _b)*(GetSemiperimeter() - _c));
        }        

        public double GetAltitude(double side)
        {
            return (2 / side) * GetArea();
        }
        
        public bool IsTriangleRule(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
