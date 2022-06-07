using System;

namespace BinarySearch
{
    [Serializable]
    public class Node<T> : IComparable<T>
        where T : IComparable<T>
    {
        public T Data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node()
        {
        }

        public Node(T data)
        {
            Data = data;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}