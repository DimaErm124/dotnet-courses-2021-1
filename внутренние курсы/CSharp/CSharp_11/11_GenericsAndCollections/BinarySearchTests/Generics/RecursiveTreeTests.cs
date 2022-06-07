using BinarySearch;
using System;
using System.Collections.Generic;

namespace BinarySearchTests
{
    public abstract class RecursiveTreeTests<TItem> : BinaryTreeTests<TItem> where TItem : IComparable<TItem>
	{
		public override BinarySearchTree<TItem> CreateTree(IEnumerable<TItem> collection)
		{
			return new RecursiveTree<TItem>(collection);
		}
	}
}