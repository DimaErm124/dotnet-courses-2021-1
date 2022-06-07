using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int?> dynamicIntArray = CreateArray<int?>();
            Console.WriteLine("Create dynamic array: {0}", dynamicIntArray);

            Add<int?>(dynamicIntArray, 5);

            AddRange<int?>(dynamicIntArray, new int?[] { 4, 5, 6, 2 });

            Insert<int?>(dynamicIntArray, 3, 7);
            Insert<int?>(dynamicIntArray, 3, 2);

            Remove<int?>(dynamicIntArray, 5);

            DynamicArray<char> dynamicCharArray = CreateArray<char>();
            Console.WriteLine("Create dynamic array: {0}", dynamicCharArray);

            Add<char>(dynamicCharArray, 'h');

            AddRange<char>(dynamicCharArray, new char[] { 'e','l','l','o' });

            Insert<char>(dynamicCharArray, 'X', 7);
            Insert<char>(dynamicCharArray, 'X', 2);

            Remove<char>(dynamicCharArray, 'l');
            Remove<char>(dynamicCharArray, 'h');
        }

        public static DynamicArray<T> CreateArray<T>(T[] array = null) 
            where T:new()
        {
            DynamicArray<T> dynamicArray = new DynamicArray<T>();

            try
            {
                dynamicArray = new DynamicArray<T>(array);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
             
            return dynamicArray;

        }

        public static void Add<T>(DynamicArray<T> dynamicArray, T item) 
            where T : new()
        {
            Console.WriteLine("Add {0}:", item);

            try
            {
                dynamicArray.Add(item);
                Console.WriteLine(dynamicArray);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AddRange<T>(DynamicArray<T> dynamicArray, T[] range)
            where T : new()
        {
            Console.WriteLine("Add range:");
            try
            {
                dynamicArray.AddRange(range);
                Console.WriteLine(dynamicArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Insert<T>(DynamicArray<T> dynamicArray, T item, int index)
            where T : new()
        {
            Console.WriteLine("Insert {0} on {1}:", item, index);
            try
            {
                dynamicArray.Insert(item, index);
                Console.WriteLine(dynamicArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Remove<T>(DynamicArray<T> dynamicArray, T item)
            where T : new()
        {
            Console.WriteLine("Remove {0}:", item);
            try
            {
                dynamicArray.Remove(item);
                Console.WriteLine(dynamicArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
