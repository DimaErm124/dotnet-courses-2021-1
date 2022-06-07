using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

            List<int> list = new List<int>(array);
            LinkedList<int> linklist = new LinkedList<int>(array);

            RemoveEachSecondItem<int>(list);

            RemoveEachSecondItem<int>(linklist);
        }
        

        public static T Move<T>(IEnumerator<T> enumerator, int count)
        {            
            for(int i = 1; i < count; i++)
            {
                enumerator.MoveNext(); 
                enumerator.MoveNext();                               
            }

            enumerator.MoveNext();

            return enumerator.Current;
            
        }

        public static void RemoveEachSecondItem<T>(List<T> list)
        {
            var newList = new List<T>();

            do
            {
                for (int i = 1; i <= list.Count; i+=2)
                {
                    newList.Add(list[i-1]);
                }

                list = newList;

                newList = new List<T>();
            } 
            while (list.Count() != 1);
        }

        public static void RemoveEachSecondItem<T>(LinkedList<T> list)
        {
            var newList = new LinkedList<T>();

            do
            {
                for (int i = 1; i <= list.Count; i ++)
                {
                    var element = Move<T>(list.GetEnumerator(), i);
                    newList.AddLast(element);
                }

                list = newList;

                newList = new LinkedList<T>();
            }
            while (list.Count() != 1);
        }
    }
    
}
