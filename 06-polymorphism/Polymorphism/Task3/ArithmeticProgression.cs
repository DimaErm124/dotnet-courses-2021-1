using ProgressionLibrary;
using System;

namespace Task3
{
    public class ArithmeticProgression : IIndexableSeries
    {
        private double _start;

        private int currentIndex;

        public int Ratio;

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

        public double Current { get { return Start + Ratio * currentIndex; } }

        public double this[int index] { get { return Start + Ratio * index; }}

        public ArithmeticProgression(double start, int ratio)
        {
            Start = start;
            Ratio = ratio;
            currentIndex = 0;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
