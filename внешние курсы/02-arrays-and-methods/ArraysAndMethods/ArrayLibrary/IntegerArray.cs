namespace ArrayLibrary
{
    public abstract class IntegerArray
    {
        private int _maxRandomValue;

        public int MaxRandomValue { get=>_maxRandomValue; }
        
        public IntegerArray(int maxRandomValue)
        {
            _maxRandomValue = maxRandomValue;
        }
        public abstract void GenerateArray();
    }
}
