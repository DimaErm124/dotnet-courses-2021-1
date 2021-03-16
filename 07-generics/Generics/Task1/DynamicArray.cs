using System;
using System.Linq;

namespace Task1
{
    public class DynamicArray<T> 
        where T: new()
    {
        private T[] _array;

        private int _capacity;

        public int Length { get; private set; }

        public int Capacity 
        {
            get { return _capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity must be more than zero!");
                }
                _capacity = value;
            } 
        }

        public T this[int index] 
        { 
            get
            {
                if (index>=_array.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return _array[index];
            } 
        }

        public DynamicArray()
        {
            Capacity = 8;
            _array = new T[Capacity];
        }

        public DynamicArray(int capacity)
        {
            Capacity = capacity;
            _array = new T[Capacity];
        }

        public DynamicArray(T[] array)
        {            
            Length = GetLenght(array);

            if (Length == array.Length)
                IncreaseArray(array);
            else
                _array = array;
        }

        public void Add(T item)
        {
            if (Capacity == Length)
            {
                IncreaseArray(_array);
            }

            _array[Length] = item;

            Length++;
        }

        public void AddRange(T[] range)
        {
            if (Capacity != Length)
            {
                Array.Resize<T>(ref _array, Length);
            }          
            
            _array = _array.Concat<T>(range).ToArray();

            Length = _array.Length;

            IncreaseArray(_array);

            Capacity = _array.Length;
        }

        public bool Remove(T item)
        {
            int indexItem = Array.IndexOf<T>(_array, item);

            if (indexItem >= 0)
            {
                T[] firstArray = _array;
                T[] secondArray = new T[Capacity - indexItem - 1];

                Array.Copy(_array, indexItem + 1, secondArray, 0, Capacity - indexItem - 1);

                Array.Resize<T>(ref firstArray, indexItem);

                _array = firstArray.Concat(secondArray).ToArray();

                Length--;
            }

            return false;
        }

        public void Insert(T item, int index)
        {
            if (index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Capacity == Length)
            {
                IncreaseArray(_array);
            }

            T[] firstArray = _array;
            T[] secondArray = new T[Capacity - index];

            Array.Copy(_array, index-1, secondArray, 0, Capacity - index);

            Array.Resize<T>(ref firstArray, index);

            firstArray[index - 1] = item;

            _array = firstArray.Concat(secondArray).ToArray();

            Length++;
        }

        private int GetLenght(T[] array)
        {
            int i = 0;

            foreach(T el in array)
            {
                if (el == null)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }

            IncreaseArray(array);

            return array.Length;
        }

        private void IncreaseArray(T[] array)
        {
            _array = array.Concat<T>(new T[array.Length]).ToArray();
            Capacity = _array.Length;
        }

        public override string ToString()
        {
            string str = string.Empty;

            foreach(T el in _array)
            {
                str += el.ToString()+"  ";
            }

            return str;
        }
    }
}
