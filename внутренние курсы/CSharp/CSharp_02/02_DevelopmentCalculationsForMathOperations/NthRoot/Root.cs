using System;

namespace NthRoot
{
    public abstract class Root
    {
        private double _number;

        private int _power;

        public double Number 
        {
            get { return _number; }
            private set 
            {
                if (value <= 0)
                {
                    throw new Exception("Number must be more zero!");
                }
                _number = value;
            } 
        }

        public int Power 
        {
            get { return _power; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Power must be more zero!");
                }
                _power = value;
            }
        }

        public double Result { get; set; }

        public Root(double x, int n)
        {
            Number = x;
            Power = n;
        }

        public abstract void SqrtN();
    }
}
