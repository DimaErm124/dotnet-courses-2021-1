using System;

namespace Task2
{
    public class Round
    {
        private int _radius;

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius 
        { 
            get { return _radius; }
            private set { if (value <= 0) { throw new Exception("Radius must be greater than zero!"); }   _radius = value; } 
        }

        public double Circumference { get { return 2 * Math.PI * _radius; } }

        public double Area { get { return Math.PI * Math.Pow(_radius, 2); } }

        public Round(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
