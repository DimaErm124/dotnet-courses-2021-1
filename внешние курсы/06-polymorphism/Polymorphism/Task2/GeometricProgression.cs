using ProgressionLibrary;
using System;

namespace Task2
{
    public class GeometricProgression : ISeries
    {
        private double _ratio;

        private double _start;

        private int currentIndex;

        public double Ratio
        {
            get { return _ratio; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Ratio must be not equal zero!");
                }
                _ratio = value;
            }
        }
        public double Start
        {
            get { return _start; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Element of progression must be not equal zero!");
                }
                _start = value;
            }
        }

        public double Current { get { return Start * Math.Pow(Ratio, currentIndex - 1); } }

        public GeometricProgression(double start, double ratio)
        {
            Start = start;
            Ratio = ratio;
            currentIndex = 1;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = 1;
        }
    }
}
