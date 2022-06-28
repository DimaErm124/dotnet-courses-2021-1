using System;

namespace Figures
{
    public class Cirсle : IFlat
    {
        private double _r;

        public double R
        {
            get => _r;
            set { if (value <= 0) { throw new Exception("Radius must be greater than zero!"); } _r = value; }
        }

        public Cirсle(double r)
        {
            R = r;
        }

        public double Square()
        {
            return Math.PI * R * R;
        }
    }
}
