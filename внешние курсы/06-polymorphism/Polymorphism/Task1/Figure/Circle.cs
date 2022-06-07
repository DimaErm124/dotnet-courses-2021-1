using System;

namespace Task1
{
    public class Circle : Figure
    {
        private double _radius;

        public virtual double Radius
        {
            get { return _radius; }
            set 
            { 
                if (value <= 0) 
                { 
                    throw new Exception("Radius must be greater than zero!");
                }
                _radius = value; 
            }
        }

        public virtual double Circumference { get { return 2 * Math.PI * Radius; } }

        public Circle(double x, double y, double radius) : base(x, y)
        {
            Radius = radius;
        }

        public override string GetPicture()
        {
            return base.GetPicture()
                + "Radius: " + Radius + "\n"
                + "Circumference: " + Circumference + "\n";
        }

        public override void Draw(FigureDrawer drawer)
        {
            drawer.Draw(this);
        }        
    }
}
