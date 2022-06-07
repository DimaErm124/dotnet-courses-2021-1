using NUnit.Framework;
using System;
using Vector;

namespace VectorTests
{
    public class ThreeDimensionalVectorTests
    {
        [Test]
        public void GetX_Success()
        {
            double expected = 1;
            ThreeDimensionalVector vector = new ThreeDimensionalVector(1, 2, 3);

            double actual = vector.X;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetY_Success()
        {
            double expected = 2;
            ThreeDimensionalVector vector = new ThreeDimensionalVector(1, 2, 3);

            double actual = vector.Y;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetZ_Success()
        {
            double expected = 3;
            ThreeDimensionalVector vector = new ThreeDimensionalVector(1, 2, 3);

            double actual = vector.Z;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(1, 2, 3, 0, 0, 0)]
        [TestCase(0, 0, 0, -4, -5, -6)]
        public void TestSum_TwoVectors_Vector(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            ThreeDimensionalVector expected = new ThreeDimensionalVector(xa + xb, ya + yb, za + zb);
            ThreeDimensionalVector actual = vectorA + vectorB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void TestSum_FirstVectorSecondNull_FirstVector(int x, int y, int z)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector vectorB = null;
            ThreeDimensionalVector actual = vectorA + vectorB;

            Assert.AreEqual(vectorA, actual);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(1, 2, 3, 0, 0, 0)]
        [TestCase(0, 0, 0, -4, -5, -6)]
        public void TestDiff_TwoVectors_Vector(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            ThreeDimensionalVector expected = new ThreeDimensionalVector(xa - xb, ya - yb, za - zb);
            ThreeDimensionalVector actual = vectorA - vectorB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void TestDiff_FirstVectorSecondNull_FirstVector(int x, int y, int z)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector vectorB = null;
            ThreeDimensionalVector actual = vectorA - vectorB;

            Assert.AreEqual(vectorA, actual);
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void TestDiff_FirstNullSecondVector_FirstVector(int x, int y, int z)
        {
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector vectorA = null;
            ThreeDimensionalVector actual = vectorA - vectorB;

            Assert.AreEqual(new ThreeDimensionalVector(-x,-y,-z), actual);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, ExpectedResult = 32)]
        [TestCase(1, 2, 3, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(-1, -2, -3, -4, -5, -6, ExpectedResult = 32)]
        [TestCase(-1, 2, -3, 4, -5, 6, ExpectedResult = -32)]
        public double TestDotProduct_TwoVectors_Product(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            return vectorA * vectorB;
        }

        [Test]
        [TestCase(1, 2, 3,ExpectedResult =false)]
        public bool TestDotProduct_VectorAndNull_Product(int x, int y, int z)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector vectorB = null;

            try
            {
                double actual = vectorA * vectorB;
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, -3, 6, -3)]
        [TestCase(1, 2, 3, 0, 0, 0, 0, 0, 0)]
        [TestCase(-1, -2, -3, -4, -5, -6, -3, 6, -3)]
        [TestCase(-1, 2, -3, 4, -5, 6, -3, -6, -3)]
        public void TestCrossProduct_TwoVectors_Vector(int xa, int ya, int za, int xb, int yb, int zb, int x, int y, int z)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            ThreeDimensionalVector expected = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector actual = vectorA & vectorB;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 2, 3, ExpectedResult = false)]
        public bool TestCrossProduct_VectorAndNull_Product(int x, int y, int z)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(x, y, z);
            ThreeDimensionalVector vectorB = null;

            try
            {
                ThreeDimensionalVector actual = vectorA & vectorB;
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase(1, 2, 3, 1, 2, 3, ExpectedResult = true)]
        [TestCase(1, 2, 3, 3, 2, 1, ExpectedResult = false)]
        [TestCase(1, -2, -3, 1, -2, 3, ExpectedResult = false)]
        public bool TestEquality_TwoVectors_Bool(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            return vectorA == vectorB;
        }

        [Test]
        [TestCase(1, 2, 3, 1, 2, 3, ExpectedResult = true)]
        [TestCase(1, 2, 3, 3, 2, 1, ExpectedResult = false)]
        [TestCase(1, -2, -3, 1, -2, 3, ExpectedResult = false)]
        public bool TestEqual_TwoVectors_Bool(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            return vectorA.Equals(vectorB);
        }

        [Test]
        [TestCase(1, 2, 3, ExpectedResult = "(1,2,3)")]
        [TestCase(-1, 2, -3, ExpectedResult = "(-1,2,-3)")]
        public string GetToString_Vector_String(int x, int y, int z)
        {
            ThreeDimensionalVector vector = new ThreeDimensionalVector(x, y, z);

            return vector.ToString();
        }

        [Test]
        [TestCase(1, 2, 3, 1, 2, 3, ExpectedResult = true)]
        [TestCase(-1, 2, 3, 1, 2, 3, ExpectedResult = false)]
        [TestCase(1, 2, 3, 3, 2, 1, ExpectedResult = false)]
        public bool TestHashCode_TwoVectors_Bool(int xa, int ya, int za, int xb, int yb, int zb)
        {
            ThreeDimensionalVector vectorA = new ThreeDimensionalVector(xa, ya, za);
            ThreeDimensionalVector vectorB = new ThreeDimensionalVector(xb, yb, zb);

            return vectorA.GetHashCode() == vectorB.GetHashCode();
        }
    }
}