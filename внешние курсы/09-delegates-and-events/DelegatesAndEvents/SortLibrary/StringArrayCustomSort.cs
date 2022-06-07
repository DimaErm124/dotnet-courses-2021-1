using System;
using System.Threading;

namespace SortLibrary
{
    public delegate int Comparison(string a, string b);

    public delegate void CallBack();
    public class StringArrayCustomSort
    {
        private string[] _array;

        private Comparison _comparison;

        public event CallBack FinishSorting;

        public StringArrayCustomSort(string[] array, Comparison comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            _comparison = comparison;
            _array = array;
        }

        public void Sort()
        {
            for (int i = 0; i < _array.Length; i++)
            {                
                for (int j = 0; j < _array.Length - 1; j++)
                {                    
                    var comparison = _comparison?.Invoke(_array[j], _array[j + 1]);
                    
                    if (comparison > 0)
                    {                        
                        Transposition(j, j + 1);
                        
                    }
                }
            }

            if (FinishSorting != null)
            {
                FinishSorting();
            }
        }

        public Thread SortAsync()
        {
            var thread = new Thread(Sort);
            thread.Name = "asynchronous thread";
            return thread;
        }


        private void Transposition(int i, int j)
        {
            var temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }

        public override string ToString()
        {
            string outputString = string.Empty;

            foreach (var el in _array)
            {
                outputString += el.ToString() + "\n";
            }

            return outputString;
        }
    }
}

