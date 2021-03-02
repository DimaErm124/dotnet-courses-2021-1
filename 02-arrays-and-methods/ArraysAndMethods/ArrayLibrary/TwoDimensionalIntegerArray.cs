using System;

namespace ArrayLibrary
{
    public class TwoDimensionalIntegerArray : IntegerArray
    {
        private int _oneDimSize;

        private int _twoDimSize;

        public int[,] Array { get; private set; }

        public TwoDimensionalIntegerArray(int oneDimSize,int twoDimSize, int maxRandomValue) : base(maxRandomValue)
        {
            _oneDimSize = oneDimSize;
            _twoDimSize = twoDimSize;
        }

        public override void GenerateArray()
        {
            Array = new int[_oneDimSize,_twoDimSize];

            Random random = new Random();

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] = random.Next(MaxRandomValue);
                }
            }
        }   
    }
}
