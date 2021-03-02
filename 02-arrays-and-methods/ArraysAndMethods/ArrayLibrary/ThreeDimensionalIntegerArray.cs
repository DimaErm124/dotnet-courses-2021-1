using System;

namespace ArrayLibrary
{
    public class ThreeDimensionalIntegerArray : IntegerArray
    {
        private int _oneDimSize;

        private int _twoDimSize;

        private int _threeDimSize;

        public int[,,] Array { get; private set; }

        public ThreeDimensionalIntegerArray(int oneDimSize, int twoDimSize, int threeDimSize, int maxRandomValue) : base(maxRandomValue)
        {
            _oneDimSize = oneDimSize;
            _twoDimSize = twoDimSize;
            _threeDimSize = threeDimSize;
        }

        public override void GenerateArray()
        {
            Array = new int[_oneDimSize,_twoDimSize,_threeDimSize];

            Random random = new Random();

            for (int i = 0; i < Array.GetLength(0); i++)            
                for (int j = 0; j < Array.GetLength(1); j++)                 
                    for (int k = 0; k < Array.GetLength(2); k++)                    
                        Array[i, j, k] = random.Next(-MaxRandomValue, MaxRandomValue);
                    
                
            
        }
    }
}
