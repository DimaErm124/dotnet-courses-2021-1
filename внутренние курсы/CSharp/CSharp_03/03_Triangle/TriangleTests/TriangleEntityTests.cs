using NUnit.Framework;
using System;
using Triangle;

namespace TriangleTests
{
    public class TriangleEntityTests
    {
        private TriangleEntity InitTriangle(double sideA, double sideB, double sideC)
        {
            return new TriangleEntity(sideA, sideB, sideC);
        }

        [Test]
        [TestCase(3, 4, 5, ExpectedResult = "")]
        [TestCase(-3, 4, 5, ExpectedResult = "Side A must be more than zero!")]
        [TestCase(3, -4, 5, ExpectedResult = "Side B must be more than zero!")]
        [TestCase(3, 4, -5, ExpectedResult = "Side C must be more than zero!")]
        [TestCase(1, 2, 3, ExpectedResult = "You cannot create a triangle with these sides!")]
        public string InitTriangle_AsideBsideCside_Bool(double sideA, double sideB, double sideC)
        {
            string error = string.Empty;

            try
            {
                TriangleEntity triangle = new TriangleEntity(sideA, sideB, sideC);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }

        [Test]
        public void GetTriangleArea_3sideA4sideB5sideC_Success()
        {
            const double expected = 6;

            double actual = InitTriangle(3, 4, 5).GetArea();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTrianglePerimeter_3sideA4sideB5sideC_Success()
        {
            const double expected = 12;

            double actual = InitTriangle(3, 4, 5).GetPerimeter();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetToStringTriangle_3sideA4sideB5sideC_Success()
        {
            const string expected = "Triangle 3,4,5\nArea: 6\nPerimeter: 12\n";

            string actual = InitTriangle(3, 4, 5).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}