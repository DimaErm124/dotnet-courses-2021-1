using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearch
{
    [Serializable]
    public abstract class BinarySearchTree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public Node<TItem> Root { get; set; }

        public bool IsEmpty
        {
            get
            {
                if (Root == null || Root.Data == null)
                    return true;
                else
                    return false;
            }
        }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(IEnumerable<TItem> collection)
        {
            foreach (var el in collection)
            {
                Add(el);
            }
        }

        public abstract void Add(TItem data);

        public void AddRange(IEnumerable<TItem> data)
        {
            foreach (var el in data)
            {
                Add(el);
            }
        }

        public abstract Node<TItem> Find(TItem data);

        protected abstract Node<TItem> Find(TItem data, out Node<TItem> parent);

        public abstract IEnumerator<TItem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TItem GetMax()
        {
            var maxNode = Root;

            if (maxNode != null)
                while (maxNode.Right != null)
                    maxNode = maxNode.Right;

            return maxNode.Data;
        }

        public TItem GetMin()
        {
            var minNode = Root;

            if (minNode != null)
                while (minNode.Left != null)
                    minNode = minNode.Left;

            return minNode.Data;
        }

        protected int Compare(TItem data, Node<TItem> node)
        {
            return node.CompareTo(data);
        }

        public bool Remove(TItem data)
        {
            if (data == null)
                throw new ArgumentNullException("Node to remove is null!");

            var node = Find(data, out Node<TItem> parent);

            if (node == null)
                return false;

            if (node.Left == null && node.Right == null)
            {
                RemoveNodeHavingNoChildren(node, parent);
            }
            else if (node.Left != null && node.Right != null)
            {
                RemoveNodeHavingBothChildren(node, parent);
            }
            else
            {
                RemoveNodeHavingOneChild(node, parent);
            }

            return true;
        }

        private void RemoveNodeHavingNoChildren(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            if (parent != null)
                if (IsLeftNodeOrNull(parent, nodeToRemove))
                    parent.Left = null;
                else
                    parent.Right = null;
            else
                Root = null;
        }

        private void RemoveNodeHavingOneChild(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            if (nodeToRemove.Left is null)
            {
                if (parent != null)
                    if (IsLeftNodeOrNull(parent, nodeToRemove))
                        parent.Left = nodeToRemove.Right;
                    else
                        parent.Right = nodeToRemove.Right;
                else
                    Root = nodeToRemove.Right;
            }
            else
            {
                if (parent != null)
                    if (IsLeftNodeOrNull(parent, nodeToRemove))
                        parent.Left = nodeToRemove.Left;
                    else
                        parent.Right = nodeToRemove.Left;
                else
                    Root = nodeToRemove.Left;
            }
        }

        private void RemoveNodeHavingBothChildren(Node<TItem> nodeToRemove, Node<TItem> parent)
        {
            if (parent != null)
                if (IsLeftNodeOrNull(parent, nodeToRemove))
                {
                    parent.Left = nodeToRemove.Right;
                    parent.Left.Right = nodeToRemove.Left;
                }
                else
                {
                    parent.Right = nodeToRemove.Right;
                    parent.Right.Right = nodeToRemove.Left;
                }
            else
            {
                Root.Data = Root.Left.Data;
                if (Root.Left.Left == null && Root.Left.Right == null)
                    Root.Left = null;
                else
                    RemoveRootWithBothChildren(Root.Left);
            }
        }

        private void RemoveRootWithBothChildren(Node<TItem> node)
        {
            if (node.Right != null)
            {
                node.Data = node.Right.Data;

                if (node.Right.Left == null && node.Right.Right == null)
                    node.Right = null;
                else
                    RemoveRootWithBothChildren(node.Right);
            }
            else if (node.Left != null)
            {
                node.Data = node.Left.Data;

                if (node.Left.Left == null && node.Left.Right == null)
                    node.Left = null;
                else
                    RemoveRootWithBothChildren(node.Left);
            }
        }

        private bool IsLeftNodeOrNull(Node<TItem> parent, Node<TItem> nodeToRemove)
        {
            return parent.Left != null && Compare(nodeToRemove.Data, parent.Left) == 0;
        }
    }
}
