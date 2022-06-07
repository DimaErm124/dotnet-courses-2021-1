using System;

namespace Triangle
{
    public class TriangleEntity : IPlane
    {
        private double _sideA;

        private double _sideB;

        private double _sideC;

        public double SideA
        {
            get => _sideA;
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Side A must be more than zero!");
                }
                _sideA = value;
            }
        }
        public double SideB
        {
            get => _sideB;
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Side B must be more than zero!");
                }
                _sideB = value;
            }
        }
        public double SideC
        {
            get => _sideC;
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Side C must be more than zero!");
                }
                _sideC = value;
            }
        }

        public TriangleEntity(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;

            if (!IsTriangleRule(a, b, c))
            {
                throw new Exception("You cannot create a triangle with these sides!");
            }
        }

        public bool IsTriangleRule(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public double GetArea()
        {
            return Math.Sqrt(GetSemiperimeter() * (GetSemiperimeter() - SideA) * (GetSemiperimeter() - SideB) * (GetSemiperimeter() - SideC));
        }

        public double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public double GetSemiperimeter()
        {
            return GetPerimeter() / 2;
        }

        public override string ToString()
        {
            return "Triangle " + SideA + "," + SideB + "," + SideC + "\n" 
                + "Area: " + GetArea() + "\n" 
                + "Perimeter: " + GetPerimeter() + "\n";
        }
    }
}
