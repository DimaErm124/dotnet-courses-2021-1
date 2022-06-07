using System;

namespace Matrix
{

    public class TwoDimensionalMatrix
    {
        private int _m;
        private int _n;

        private double[,] _matrix;
 
        public double this[int m, int n]
        {
            get
            {
                return _matrix[m, n];
            }
            set
            {
                _matrix[m, n] = value;
            }
        }

        public TwoDimensionalMatrix(int m, int n)
        {
            if (m <= 0)
                throw new ArgumentNullException("Row count should be more than zero!");

            if (n <= 0)
                throw new ArgumentNullException("Column count should be more than zero!");

            _matrix = new double[m, n];
        }
        public TwoDimensionalMatrix(double[] array)
        {
            if (array is null)
                throw new ArgumentNullException("Array is null!");

            _matrix = new double[array.Length, 1];

            for(var i = 0; i < array.Length; i++)
            {
                _matrix[i, 0] = array[i];
            }
        }

        public TwoDimensionalMatrix(double[,] matrix)
        {
            if (matrix is null)
                throw new ArgumentNullException("Matrix is null!");

            _matrix = matrix;
        }

        public int GetRowCount()
        {
            return _matrix.GetUpperBound(0) + 1;
        }

        public int GetColumnCount()
        {
            return _matrix.GetUpperBound(1) + 1;
        }

        public static TwoDimensionalMatrix operator +(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            if (matrixA is null)
                throw new ArgumentNullException("Matrix A is null!");

            if (matrixB is null)
                throw new ArgumentNullException("Matrix B is null!");

            if (matrixA.GetColumnCount() != matrixB.GetColumnCount() || matrixA.GetRowCount() != matrixB.GetRowCount())
                throw new MatrixException($"Matrix B ({matrixB.GetRowCount()}x{matrixB.GetColumnCount()}) must have a size equal to the Matrix A!", matrixB.GetRowCount(), matrixB.GetColumnCount());

            var matrixC = new TwoDimensionalMatrix(matrixA.GetRowCount(), matrixA.GetColumnCount());

            for (var i = 0; i < matrixC.GetRowCount(); i++)
            {
                for (var j = 0; j < matrixC.GetColumnCount(); j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return matrixC;
        }

        public static TwoDimensionalMatrix operator -(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            if (matrixA is null)
                throw new ArgumentNullException("Matrix A is null!");

            if (matrixB is null)
                throw new ArgumentNullException("Matrix B is null!");

            if (matrixA.GetColumnCount() != matrixB.GetColumnCount() || matrixA.GetRowCount() != matrixB.GetRowCount())
                throw new MatrixException($"Matrix B ({matrixB.GetRowCount()}x{matrixB.GetColumnCount()}) must have a size equal to the Matrix A!", matrixB.GetRowCount(), matrixB.GetColumnCount());

            var matrixC = new TwoDimensionalMatrix(matrixA.GetRowCount(), matrixA.GetColumnCount());

            for (var i = 0; i < matrixC.GetRowCount(); i++)
                for (var j = 0; j < matrixC.GetColumnCount(); j++)
                {
                    matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }

            return matrixC;
        }

        public static TwoDimensionalMatrix operator *(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            if (matrixA is null)
                throw new ArgumentNullException("Matrix A is null!");

            if (matrixB is null)
                throw new ArgumentNullException("Matrix B is null!");

            if (matrixA.GetColumnCount() != matrixB.GetRowCount())
                throw new MatrixException($"Matrix B ({matrixB.GetRowCount()}x{matrixB.GetColumnCount()}) must have column count equal row count of the Matrix A!", matrixB.GetRowCount(), matrixB.GetColumnCount());

            var matrixC = new TwoDimensionalMatrix(matrixA.GetRowCount(), matrixB.GetColumnCount());

            for (var i = 0; i < matrixC.GetRowCount(); i++)
                for (var j = 0; j < matrixC.GetColumnCount(); j++)
                    for (var k = 0; k < matrixA.GetColumnCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }

            return matrixC;
        }

        public static TwoDimensionalMatrix operator *(TwoDimensionalMatrix matrix, double number)
        {
            if (matrix is null)
                throw new ArgumentNullException("Matrix is null!");

            for (var i = 0; i < matrix.GetRowCount(); i++)
                for (var j = 0; j < matrix.GetColumnCount(); j++)
                {
                    matrix[i, j] *= number;
                }

            return matrix;
        }

        public static bool operator ==(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            if (matrixA is null)
                throw new ArgumentNullException("Matrix A is null!");

            if (matrixB is null)
                throw new ArgumentNullException("Matrix B is null!");

            if (matrixA.GetRowCount() != matrixB.GetRowCount())
                return false;

            if (matrixA.GetColumnCount() != matrixB.GetColumnCount())
                return false;

            return matrixA.Equals(matrixB);
        }

        public static bool operator !=(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            return !(matrixA == matrixB);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Matrix being compared is null!");

            for (var i = 0; i < GetRowCount(); i++)
                for (var j = 0; j < GetColumnCount(); j++)
                    if (this[i, j] != (obj as TwoDimensionalMatrix)[i, j])
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            var returnString = string.Empty;

            for (var i = 0; i < GetRowCount(); i++)
            {
                for (var j = 0; j < GetColumnCount(); j++)
                    returnString += this[i, j].ToString();

                returnString += '\n';
            }

            return returnString.GetHashCode();
        }

        public override string ToString()
        {
            var returnString = string.Empty;

            for (var i = 0; i < GetRowCount(); i++) 
            {
                for (var j = 0; j < GetColumnCount(); j++)
                    returnString += this[i, j].ToString() + ' ';

                returnString += '\n';
            }

            return returnString;
        }
    }
}