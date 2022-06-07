using NUnit.Framework;

namespace BinarySearchTests
{
    public class RecursiveTreeStringTests : RecursiveTreeTests<string>
    {
        private static readonly string[] _strings =
        {
            "k","a","b","z","aa"
        };

        [Test]
        public override void TestGetMaxValue()
        {
            var tree = CreateTree(_strings);

            var maxData = tree.GetMax();

            Assert.AreEqual(0, maxData.CompareTo(_strings[3]));
        }

        [Test]
        public override void TestGetMinValue()
        {
            var tree = CreateTree(_strings);

            var minData = tree.GetMin();

            Assert.AreEqual(0, minData.CompareTo(_strings[1]));
        }

        [Test]
        public override void TestGetRoot()
        {
            var tree = CreateTree(_strings);

            var rootData = tree.Root.Data;

            Assert.AreEqual(0, rootData.CompareTo(_strings[0]));
        }

        [TestCase("zz", true)]
        [TestCase("aa", false)]
        public override void TestAddValue(string value, bool expected)
        {
            var tree = CreateTree(_strings);

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

        [TestCase("zz", false)]
        [TestCase("aa", true)]
        public override void TestFindValue(string value, bool expected)
        {
            var tree = CreateTree(_strings);

            var node = tree.Find(value);

            if (node == null)
                Assert.IsFalse(expected);
            else
                Assert.IsTrue(expected);
        }

        [TestCase("zz", false)]
        [TestCase("aa", true)]
        public override void TestRemoveNode(string value, bool expected)
        {
            var tree = CreateTree(_strings);

            var actual = tree.Remove(value);

            if (actual)
                Assert.IsTrue(expected);
            else
                Assert.IsFalse(expected);
        }
    }
}