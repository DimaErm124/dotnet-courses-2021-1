using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> vs = new DynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });

            var enumer = vs.GetEnumerator();

            enumer.MoveNext();
            enumer.MoveNext();

            var cur = enumer.Current;
        }
    }
}
