using BinarySearch;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchTests
{
    [TestFixture]
	public abstract class BinaryTreeTests<TItem> where TItem : IComparable<TItem>
	{
		public abstract BinarySearchTree<TItem> CreateTree(IEnumerable<TItem> collection);

		public abstract void TestFindValue(TItem value, bool expected);

		public abstract void TestAddValue(TItem value, bool expected);

		public abstract void TestGetRoot();

		public abstract void TestGetMaxValue();

		public abstract void TestGetMinValue();

		public abstract void TestRemoveNode(TItem value, bool expected);
	}
}