using System;

namespace Task1
{
    public class Rectangle : Figure, IPlane
    {
        private double _a;

        private double _b;

        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0) 
                {
                    throw new Exception("Rectangle side must be more than zero!");
                }
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Rectangle side must be more than zero!");
                }
                _b = value;
            }
        }

        public double Area { get { return A * B; } }

        public Rectangle(double x, double y, double a, double b) : base(x, y)
        {
            A = a;
            B = b;
        }

        public override string GetPicture()
        {
            return base.GetPicture()
                + "A: " + A + "\n"
                + "B: " + B + "\n"
                + "Area: " + Area + "\n";
        }

        public override void Draw(FigureDrawer drawer)
        {
            drawer.Draw(this);
        }
    }
}
