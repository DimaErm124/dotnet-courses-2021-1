using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class RecursiveTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        public RecursiveTree() : base()
        {

        }

        public RecursiveTree(IEnumerable<T> collection) : base(collection)
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

            RecursiveAdd(data, Root);
        }

        private void RecursiveAdd(T data, Node<T> node)
        {
            if (Compare(data, node) > 0)
            {
                if (node.Left == null)
                    node.Left = new Node<T>(data);
                else
                    RecursiveAdd(data, node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node<T>(data);
                else
                    RecursiveAdd(data, node.Right);
            }
        }

        public override Node<T> Find(T data)
        {
            return Find(data, out Node<T> parent);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return InOrder(Root).GetEnumerator();
        }

        public IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var el in InOrder(node.Left))
                    yield return el;

            yield return node.Data;

            if (node.Right != null)
                foreach (var el in InOrder(node.Right))
                    yield return el;
        }

        protected override Node<T> Find(T data, out Node<T> parent)
        {
            if (IsEmpty)
                throw new ArgumentNullException("Binary tree is empty!");

            parent = null;

            return RecursiveFind(data, Root, out parent);
        }

        private Node<T> RecursiveFind(T data, Node<T> node, out Node<T> parent)
        {
            parent = node;

            if (Compare(data, node) > 0)
                node = node.Left;
            else
                node = node.Right;

            if (node == null || Compare(data, node) == 0)
                return node;
            else
                return RecursiveFind(data, node, out parent);
        }
    }
}