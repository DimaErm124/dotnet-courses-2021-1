using System;

namespace Task2
{
    public class Ring : Round
    {
        private int _innerRadius;

        public int InnerRadius
        {
            get { return _innerRadius; }
            private set
            {
                if (value <= 0 || value > Radius) 
                { 
                    throw new Exception("Radius must be greater than zero and less than the outer radius!"); 
                } 
                _innerRadius = value; 
            }
        }
        
        public double InnerCircumference { get { return 2 * Math.PI * _innerRadius; } }

        public double InnerArea { get { return Math.PI * Math.Pow(_innerRadius, 2); } }

        public override double Circumference => base.Circumference + InnerCircumference;

        public override double Area => base.Area - InnerArea;

        public Ring(int x, int y, int radius, int innerRadius) : base(x, y, radius)
        {
            InnerRadius = innerRadius;
        }

        public override string ToString()
        {
            return base.ToString()
                + "Inner radius: " + InnerRadius + "\n";
        }
    }
}
