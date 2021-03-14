using System;

namespace Task1
{
    public class Ring : Round
    {
        private double _innerRadius;                

        public double InnerRadius
        {
            get { return _innerRadius; }
            set
            {
                if (value <= 0 || value > base.Radius)
                {
                    throw new Exception("Inner radius must be greater than zero and less than the outer radius!");
                }
                _innerRadius = value;
            }
        }
        
        public override double Radius
        {
            get { return base.Radius; }
            set
            {
                if (value <= InnerRadius)
                {
                    throw new Exception("Outer radius must be greater than inner radius!");
                }
                base.Radius = value;
            }
        }

        public double InnerCircumference { get { return 2 * Math.PI * InnerRadius; } }

        public override double Circumference { get { return base.Circumference + InnerCircumference; } }

        public double InnerArea { get { return Math.PI * Math.Pow(InnerRadius, 2); } }

        public override double Area { get { return base.Area - InnerArea; } }

        public Ring(double x, double y, double radius, double innerRadius) : base(x, y, radius)
        {
            InnerRadius = innerRadius;
        }

        public override string GetPicture()
        {
            return base.GetPicture()
                + "Inner radius: " + InnerRadius + "\n"
                + "Inner circumference: " + InnerCircumference + "\n"
                + "Inner area: " + InnerArea + "\n";
        }
    }
}
