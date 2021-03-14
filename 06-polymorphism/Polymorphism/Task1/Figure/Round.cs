using System;

namespace Task1
{
    public class Round : Circle, IPlane
    {
        public virtual double Area { get { return Math.PI * Math.Pow(Radius, 2); } }
        
        public Round(double x, double y, double radius) : base(x, y,radius)
        {
        }

        public override string GetPicture()
        {
            return base.GetPicture()
                + "Area: " + Area + "\n";
        }
    }
}
