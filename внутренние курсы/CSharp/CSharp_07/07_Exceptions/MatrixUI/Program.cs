using Matrix;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace MatrixUI
{
    class Program
    {
        const string MatrixExceptionPath = "D:\\matrix_exception_json.txt";
        
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var matrices = GetMatrices();

            for (int a = 0; a < matrices.Length; a++)
                for (int b = a; b < matrices.Length; b++)
                    if (a != b)
                    {
                        ActionsToMatrices(matrices[a], matrices[b], a, b);
                    }
        }

        public static void ActionsToMatrices(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB, int matrixANumber, int matrixBNumber)
        {
            Console.WriteLine("Matrix A ({0}):", matrixANumber + 1);
            Console.WriteLine(matrixA.ToString());
            Console.WriteLine("Matrix B ({0}):", matrixBNumber + 1);
            Console.WriteLine(matrixB.ToString());

            SumTwoMatrix(matrixA, matrixB);
            DiffTwoMatrix(matrixA, matrixB);
            MultTwoMatrix(matrixA, matrixB);
        }

        public static void SumTwoMatrix(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            try
            {
                Console.WriteLine("Sum:\n{0}\n", (matrixA + matrixB).ToString());
            }
            catch (MatrixException e)
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(MatrixException));
                Serialize(e, jsonSerializer);
                Deserialize(e, jsonSerializer);

                Console.WriteLine("Sum:\n{0}\n", e.Message);
            }
        }

        public static void DiffTwoMatrix(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            try
            {
                Console.WriteLine("Diff:\n{0}\n", (matrixA - matrixB).ToString());
            }
            catch (MatrixException e)
            {
                Console.WriteLine("Diff:\n{0}\n", e.Message);
            }
        }

        public static void MultTwoMatrix(TwoDimensionalMatrix matrixA, TwoDimensionalMatrix matrixB)
        {
            try
            {
                Console.WriteLine("Mult:\n{0}\n", (matrixA * matrixB).ToString());
            }
            catch (MatrixException e)
            {
                Console.WriteLine("Mult:\n{0}\n", e.Message);
            }
        }

        public static void Serialize(MatrixException ex, DataContractJsonSerializer jsonSerializer)
        {
            using (var buffer = File.Create(MatrixExceptionPath))
            {
                jsonSerializer.WriteObject(buffer, ex);
            }
        }

        public static void Deserialize(MatrixException ex, DataContractJsonSerializer jsonSerializer)
        {
            using (var buffer = File.OpenRead(MatrixExceptionPath))
            {
                jsonSerializer.ReadObject(buffer);
            }
        }

        public static TwoDimensionalMatrix[] GetMatrices()
        {
            int matrixCount = InputHandler.InputPositiveIntegerNumber("Enter matrix count (positive integer number): ");

            TwoDimensionalMatrix[] matrices = new TwoDimensionalMatrix[matrixCount];

            for (int i = 0; i < matrixCount; i++)
            {
                int m = InputHandler.InputPositiveIntegerNumber($" {i + 1}) Enter the number of rows in the matrix (positive integer number): ");
                int n = InputHandler.InputPositiveIntegerNumber($" {i + 1}) Enter the number of columns in the matrix (positive integer number): ");
                matrices[i] = new TwoDimensionalMatrix(m, n);

                for (int row = 0; row < m; row++)
                    for (int column = 0; column < n; column++)
                    {
                        matrices[i][row, column] = InputHandler.InputDoubleNumber($"Enter [{row + 1},{column + 1}] element of matrix {m}x{n} (number):");
                    }
            }

            return matrices;
        }
    }
}