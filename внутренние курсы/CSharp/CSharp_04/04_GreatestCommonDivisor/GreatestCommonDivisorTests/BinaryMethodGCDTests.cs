using GreatestCommonDivisor;
using NUnit.Framework;

namespace GreatestCommonDivisorTests
{
    public class BinaryMethodGCDTests
    {
        [Test]
        public void TestFindGCD_FirstEqualSecond_Success()
        {
            int expected = 1071;

            int actualBinary = GCD.BinaryMethod(1071, 1071);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_FirstBiggerSecond_Success()
        {
            int expected = 21;

            int actualBinary = GCD.BinaryMethod(1071, 462);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_FirstSmallerSecond_Success()
        {
            int expected = 21;

            int actualBinary = GCD.BinaryMethod(462, 1071);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_OddNumbers_Success()
        {
            int expected = 3;

            int actualBinary = GCD.BinaryMethod(1071, 465);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_EvenNumbers_Success()
        {
            int expected = 6;

            int actualBinary = GCD.BinaryMethod(1074, 462);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_PrimeNumbers_Success()
        {
            int expected = 1;

            int actualBinary = GCD.BinaryMethod(2, 3, 5, 7, 11);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_ThreeNumbers_Success()
        {
            int expected = 7;

            int actualBinary = GCD.BinaryMethod(1071, 462, 14);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_FourNumbers_Success()
        {
            int expected = 2;

            int actualBinary = GCD.BinaryMethod(144, 256, 222, 1002);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_FiveNumbers_Success()
        {
            int expected = 3;

            int actualBinary = GCD.BinaryMethod(27, 81, 465, 303, 342);

            Assert.AreEqual(expected, actualBinary);
        }

        [Test]
        public void TestFindGCD_FifteenNumbers_Success()
        {
            int expected = 1;

            int actualBinary = GCD.BinaryMethod(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            Assert.AreEqual(expected, actualBinary);
        }
    }
}