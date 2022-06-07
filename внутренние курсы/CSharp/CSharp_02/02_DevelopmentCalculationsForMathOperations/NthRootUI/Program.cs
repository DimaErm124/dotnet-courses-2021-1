using DataIO;
using NthRoot;
using System;

namespace NthRootUI
{
    class Program
    {
        const double EpsRightBorder = 0.11;

        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            double x = InputHandler.InputPositiveIntegerNumber("Enter a number (positive integer):");
            int n = InputHandler.InputPositiveIntegerNumber("Enter a power (positive integer number):");
            double eps = InputHandler.InputPositiveDoubleNumberWithRightBorder("Enter an accuracy (positive number):", EpsRightBorder);

            try
            {
                NewtonsRoot newtonsRoot = new NewtonsRoot(x, n, eps);
                MathRoot mathRoot = new MathRoot(x, n);

                newtonsRoot.SqrtN();
                mathRoot.SqrtN();

                Console.WriteLine($"Newton method root:{newtonsRoot.Result}\nSystem math root:  {mathRoot.Result}");
                if (newtonsRoot.Result - mathRoot.Result < eps)
                    Console.WriteLine($"Results are equal with accuracy {eps}.");
                else
                    Console.WriteLine($"Results are not equal with accuracy {eps}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}