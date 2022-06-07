using GreatestCommonDivisor;
using NUnit.Framework;

namespace GreatestCommonDivisorTests
{
    public class EuclideanMethodGCDTests
    {
        [Test]
        public void TestFindGCD_FirstEqualSecond_Success()
        {
            int expected = 1071;

            int actualEuclidean = GCD.EuclideanMethod(1071, 1071);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_FirstBiggerSecond_Success()
        {
            int expected = 21;

            int actualEuclidean = GCD.EuclideanMethod(1071, 462);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_FirstSmallerSecond_Success()
        {
            int expected = 21;

            int actualEuclidean = GCD.EuclideanMethod(462, 1071);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_OddNumbers_Success()
        {
            int expected = 3;

            int actualEuclidean = GCD.EuclideanMethod(1071, 465);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_EvenNumbers_Success()
        {
            int expected = 6;

            int actualEuclidean = GCD.EuclideanMethod(1074, 462);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_PrimeNumbers_Success()
        {
            int expected = 1;

            int actualEuclidean = GCD.EuclideanMethod(2, 3, 5, 7, 11);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_ThreeNumbers_Success()
        {
            int expected = 7;

            int actualEuclidean = GCD.EuclideanMethod(1071, 462, 14);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_FourNumbers_Success()
        {
            int expected = 2;

            int actualEuclidean = GCD.EuclideanMethod(144,256,222,1002);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_FiveNumbers_Success()
        {
            int expected = 3;

            int actualEuclidean = GCD.EuclideanMethod(27, 81, 465, 303, 342);

            Assert.AreEqual(expected, actualEuclidean);
        }

        [Test]
        public void TestFindGCD_FifteenNumbers_Success()
        {
            int expected = 1;

            int actualEuclidean = GCD.EuclideanMethod(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            Assert.AreEqual(expected, actualEuclidean);
        }
    }
}