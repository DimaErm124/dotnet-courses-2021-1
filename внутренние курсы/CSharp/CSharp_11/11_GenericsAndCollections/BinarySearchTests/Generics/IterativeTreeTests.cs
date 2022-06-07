using BinarySearch;
using System;
using System.Collections.Generic;

namespace BinarySearchTests
{
    public abstract class IterativeTreeTests<TItem> : BinaryTreeTests<TItem> where TItem : IComparable<TItem>
	{
		public override BinarySearchTree<TItem> CreateTree(IEnumerable<TItem> collection)
		{
			return new IterativeTree<TItem>(collection);
		}
	}
}