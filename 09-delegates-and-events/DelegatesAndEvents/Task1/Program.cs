using System;

namespace Task1
{
    public delegate int Comparison(string a, string b);

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new string[] { "aabb", "aaabb", "a", "b", "abbbbbb", "baaa", "aaaba" };

            var strArray = new StringArrayCustomSort(arr, Compare);

            strArray.Sort();

            Console.WriteLine(strArray);
        }

        public static int Compare(string a, string b)
        {
            return a.Length - b.Length;
        }
    }

    public class StringArrayCustomSort
    {
        private string[] _array;

        private Comparison _comparison;

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
                    if (comparison == 0)
                    {
                        Order(j, j + 1);
                    }
                }
            }
        }

        private void Order(int i, int j)
        {
            if (!IsOrder(i, j))
            {
                Transposition(i, j);
            }
        }

        private bool IsOrder(int i, int j)
        {
            for (int t = 0; t < _array[i].Length; t++)
            {
                if (_array[i][t] > _array[j][t])
                {
                    return false;
                }
            }
            return true;
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
