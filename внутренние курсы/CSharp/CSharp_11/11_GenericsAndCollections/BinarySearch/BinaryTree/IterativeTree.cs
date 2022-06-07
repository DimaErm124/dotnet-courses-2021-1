using System;
using System.Collections.Generic;

namespace BinarySearch
{
    [Serializable]
    public class IterativeTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        public IterativeTree() : base()
        {

        }

        public IterativeTree(IEnumerable<T> collection) : base(collection)
        {

        }

        public override void Add(T data)
        {
            if (IsEmpty)
            {
                Root = new Node<T>(data);
                return;
            }

            if (Find(data) != null)
                throw new InvalidOperationException("Node with this data already exist!");

            Node<T> node = Root;
            Node<T> parent = null;

            while (node != null)
            {
                parent = node;
                if (Compare(data, node) > 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            if (Compare(data, parent) > 0)
                parent.Left = new Node<T>(data);
            else
                parent.Right = new Node<T>(data);
        }

        public override Node<T> Find(T data)
        {
            if (IsEmpty)
                throw new ArgumentNullException("Binary tree is empty!");

            Node<T> node = Root;

            while (node != null && Compare(data, node) != 0)
            {
                if (Compare(data, node) > 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            return node;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> node = Root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Data;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        protected override Node<T> Find(T data, out Node<T> parent)
        {
            if (IsEmpty)
                throw new ArgumentNullException("Binary tree is empty!");

            parent = null;
            Node<T> node = Root;

            while (node != null && Compare(data, node) != 0)
            {
                parent = node;

                if (Compare(data, node) > 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            return node;
        }
    }
}