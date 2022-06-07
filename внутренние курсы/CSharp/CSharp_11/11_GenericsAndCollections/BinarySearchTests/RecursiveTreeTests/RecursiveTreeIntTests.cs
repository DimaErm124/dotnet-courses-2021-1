using NUnit.Framework;

namespace BinarySearchTests
{
    public class RecursiveTreeIntTests : RecursiveTreeTests<int>
    {
        private static readonly int[] _numbers =
        {
            34,0,1,33,105,45,1000,2
        };

        [Test]
        public override void TestGetMaxValue()
        {
            var tree = CreateTree(_numbers);

            var maxData = tree.GetMax();

            Assert.AreEqual(0, maxData.CompareTo(_numbers[6]));
        }

        [Test]
        public override void TestGetMinValue()
        {
            var tree = CreateTree(_numbers);

            var minData = tree.GetMin();

            Assert.AreEqual(0, minData.CompareTo(_numbers[1]));
        }

        [Test]
        public override void TestGetRoot()
        {
            var tree = CreateTree(_numbers);

            var rootData = tree.Root.Data;

            Assert.AreEqual(0, rootData.CompareTo(_numbers[0]));
        }

        [TestCase(28, true)]
        [TestCase(0, false)]
        public override void TestAddValue(int value, bool expected)
        {
            var tree = CreateTree(_numbers);

            try
            {
                tree.Add(value);
                Assert.IsTrue(expected);
            }
            catch
            {
                Assert.IsFalse(expected);
            }
        }

        [TestCase(28, false)]
        [TestCase(0, true)]
        public override void TestFindValue(int value, bool expected)
        {
            var tree = CreateTree(_numbers);

            var node = tree.Find(value);

            if (node == null)
                Assert.IsFalse(expected);
            else
                Assert.IsTrue(expected);
        }

        [TestCase(28, false)]
        [TestCase(0, true)]
        public override void TestRemoveNode(int value, bool expected)
        {
            var tree = CreateTree(_numbers);

            var actual = tree.Remove(value);

            if (actual)
                Assert.IsTrue(expected);
            else
                Assert.IsFalse(expected);
        }
    }
}