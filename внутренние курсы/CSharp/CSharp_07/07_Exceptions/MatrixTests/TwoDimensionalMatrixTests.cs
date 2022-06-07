using Matrix;
using NUnit.Framework;

namespace MatrixTests
{
    public class TwoDimensionalMatrixTests
    {
        [Test]
        [TestCase(3, 4, ExpectedResult = true)]
        [TestCase(3, -4, ExpectedResult = false)]
        public bool InitMatrix_RowsAndColumnsNumbers_Bool(int m, int n)
        {
            try
            {
                var matrix = new TwoDimensionalMatrix(m, n);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 1, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 1 }, ExpectedResult = false)]
        public bool TestSum_TwoMatrices_Bool(double[] matrixArrayA, double[] matrixArrayB)
        {
            var matrixA = new TwoDimensionalMatrix(matrixArrayA);
            var matrixB = new TwoDimensionalMatrix(matrixArrayB);

            try
            {
                var matrixC = matrixA + matrixB;
                return true;
            }
            catch
            {
                return false;
            }

        }

        [Test]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 1, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 1 }, ExpectedResult = false)]
        public bool TestDiff_TwoMatrices_Bool(double[] matrixArrayA, double[] matrixArrayB)
        {
            var matrixA = new TwoDimensionalMatrix(matrixArrayA);
            var matrixB = new TwoDimensionalMatrix(matrixArrayB);

            try
            {
                var matrixC = matrixA - matrixB;
                return true;
            }
            catch
            {
                return false;
            }

        }

        [Test]
        [TestCase(new double[] { 1}, new double[] { 2}, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 1, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 1 }, ExpectedResult = false)]
        public bool TestMult_TwoMatrices_Bool(double[] matrixArrayA, double[] matrixArrayB)
        {
            var matrixA = new TwoDimensionalMatrix(matrixArrayA);
            var matrixB = new TwoDimensionalMatrix(matrixArrayB);

            try
            {
                var matrixC = matrixA * matrixB;
                return true;
            }
            catch
            {
                return false;
            }

        }

        [Test]
        [TestCase(new double[] { 1, 2 }, 2, ExpectedResult = true)]
        public bool TestMult_MatrixAndNumber_Bool(double[] matrixArrayA, double number)
        {
            var matrixA = new TwoDimensionalMatrix(matrixArrayA);

            try
            {
                var matrixC = matrixA * number;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}