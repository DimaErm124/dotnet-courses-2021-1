using System;
using Triangle;

namespace TriangleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            TriangleEntity triangle;

            while (true)
            {
                double a = InputPositiveDoubleNumber("Enter side A of triangle:");
                double b = InputPositiveDoubleNumber("Enter side B of triangle:");
                double c = InputPositiveDoubleNumber("Enter side C of triangle:");

                try
                {
                    triangle = new TriangleEntity(a, b, c);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(triangle.ToString());
        }

        public static double InputPositiveDoubleNumber(string invitationString)
        {
            double number;

            while (true)
            {
                Console.WriteLine(invitationString);
                if (double.TryParse(Console.ReadLine(), out number) && number > 0)
                    break;
            }

            return number;
        }
    }
}