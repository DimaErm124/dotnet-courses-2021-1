using BinarySearch;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchTests
{
    public class RecursiveTreeExamResultTests : RecursiveTreeTests<ExamResult>
    {
        private static readonly ExamResult[] _examResults =
        {
            new ExamResult("Math operations",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2017,9,4),5),
            new ExamResult("English articles",new Student("Sam","Johnson","Pots",345),new DateTime(2021,9,4),3),
            new ExamResult("English articles",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2021,9,4),4)
        };

        public static IEnumerable<TestCaseData> AddingData
        {
            get
            {
                yield return new TestCaseData(new ExamResult("English articles", new Student("Sam", "Johnson", "Pots", 345), new DateTime(2021, 9, 4), 3), false);
                yield return new TestCaseData(new ExamResult("Math operations", new Student("Dmitriy", "Ermakov", "Sergeevich", 643), new DateTime(2017, 10, 4), 4), true);
            }
        }

        public static IEnumerable<TestCaseData> FindingAndRemovingData
        {
            get
            {
                yield return new TestCaseData(new ExamResult("English articles", new Student("Sam", "Johnson", "Pots", 345), new DateTime(2021, 9, 4), 3), true);
                yield return new TestCaseData(new ExamResult("Math operations", new Student("Dmitriy", "Ermakov", "Sergeevich", 643), new DateTime(2017, 10, 4), 4), false);
            }
        }

        [Test]
        public override void TestGetMaxValue()
        {
            var tree = CreateTree(_examResults);

            var maxData = tree.GetMax();

            Assert.AreEqual(0, maxData.CompareTo(_examResults[0]));
        }

        [Test]
        public override void TestGetMinValue()
        {
            var tree = CreateTree(_examResults);

            var minData = tree.GetMin();

            Assert.AreEqual(0, minData.CompareTo(_examResults[2]));
        }

        [Test]
        public override void TestGetRoot()
        {
            var tree = CreateTree(_examResults);

            var rootData = tree.Root.Data;

            Assert.AreEqual(0, rootData.CompareTo(_examResults[0]));
        }

        [TestCaseSource(nameof(AddingData))]
        public override void TestAddValue(ExamResult value, bool expected)
        {
            var tree = CreateTree(_examResults);

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

        [TestCaseSource(nameof(FindingAndRemovingData))]
        public override void TestFindValue(ExamResult value, bool expected)
        {
            var tree = CreateTree(_examResults);

            var node = tree.Find(value);

            if (node == null)
                Assert.IsFalse(expected);
            else
                Assert.IsTrue(expected);
        }

        [TestCaseSource(nameof(FindingAndRemovingData))]
        public override void TestRemoveNode(ExamResult value, bool expected)
        {
            var tree = CreateTree(_examResults);

            var actual = tree.Remove(value);

            if (actual)
                Assert.IsTrue(expected);
            else
                Assert.IsFalse(expected);
        }
    }

}