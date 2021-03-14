using ProgressionLibrary;
using System;

namespace Task3
{
    public class List : IIndexableSeries
    {
        private double[] _series;

        private int currentIndex;

        public double[] Series
        {
            get { return _series; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Series is null");
                }
                _series = value;
            }
        }
        public double Current 
        {
            get
            {
                if (currentIndex >= Series.Length)
                {
                    throw new Exception("Index out of range!");
                }
                return Series[currentIndex];
            }
        }

        public double this[int index] 
        { 
            get
            {
                if (index >= Series.Length)
                {
                    throw new Exception("Index out of range!");
                }
                return Series[index]; 
            } 
        }

        public List(double[] series)
        {
            Series = series;
            currentIndex = 0;
        }

        public bool MoveNext()
        {
            currentIndex = (currentIndex < Series.Length - 1) ? (currentIndex + 1) : 0;
            return true;
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
