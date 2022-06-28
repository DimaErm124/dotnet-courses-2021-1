using Figures;
using NUnit.Framework;
using System;

namespace FiguresTest
{
    public class TriangleTests
    {
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(0, 4, 5, ExpectedResult = false)]
        [TestCase(1, 2, 3, ExpectedResult = false)]
        [TestCase(3, 6, -4, ExpectedResult = false)]
        public bool Test_CreateTriangle(double a, double b, double c)
        {
            try
            {
                Triangle triangle = new(a, b, c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        public void Test_GetSquare_Success()
        {
            Triangle triangle = new(3, 4, 5);

            double actual = Geometry.GetSquare(triangle);

            double expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(3, 4, 6, ExpectedResult = false)]
        public bool Test_GetIsRightTriangle(double a, double b, double c)
        {
            Triangle triangle = new(a, b, c);

            return triangle.IsRightTriangle();

        }
    }

    public class Cir�leTests
    {
        [TestCase(3, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(-4, ExpectedResult = false)]
        public bool Test_CreateCircle(double r)
        {
            try
            {
                Cir�le cir�le = new(r);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        public void Test_GetSquare_Success()
        {
            Cir�le cir�le = new(4);

            double actual = Math.Round(Geometry.GetSquare(cir�le));

            double expected = 50;

            Assert.AreEqual(expected, actual);
        }
    }
}