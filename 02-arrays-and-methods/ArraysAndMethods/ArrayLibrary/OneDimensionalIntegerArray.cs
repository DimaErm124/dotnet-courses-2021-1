using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class OneDimensionalIntegerArray: IntegerArray
    {
        private int _n;

        public int[] Array { get; private set; }

        public OneDimensionalIntegerArray(int n, int maxRandomValue):base(maxRandomValue)
        {
            _n = n;
        }

        public override void GenerateArray()
        {
            Array = new int[_n];

            Random random = new Random();

            for (int i = 0; i < Array.Length; i++)
                Array[i] = random.Next(-MaxRandomValue, MaxRandomValue);  
            
        }

        public int FindMinValue()
        {
            int maxValue = Array[0];

            for (int i = 1; i < Array.Length; i++)            
                if (maxValue < Array[i])                
                    maxValue = Array[i];               

            return maxValue;
        }

        public int FindMaxValue()
        {
            int minValue = Array[0];

            for (int i = 1; i < Array.Length; i++)            
                if (minValue > Array[i])                
                    minValue = Array[i];                
            
            return minValue;
        }

        public void SortArray()
        {
            int arr;

            for (int i = 0; i < Array.Length; i++)            
                for (int j = 0; j < Array.Length - 1; j++)                
                    if (Array[j] > Array[j + 1])
                    {
                        arr = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = arr;
                    }                
            
        }

        public void SortAndGetMinAndMaxValues(out int maxValue, out int minValue)
        {
            maxValue = FindMaxValue();
            minValue = FindMinValue();
            SortArray();
        }
    }
}
