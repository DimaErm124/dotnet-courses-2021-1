using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);

            Console.WriteLine("Perimeter of triangle: {0}", triangle.GetPerimeter());
            Console.WriteLine("Area of triangle: {0}", triangle.GetArea());
            OutputTriangleAltitudes(triangle, triangle.A, triangle.B, triangle.C);
            
        }

        public static void OutputTriangleAltitudes(Triangle triangle, params double[] sides)
        {
            for (int i = 0; i < sides.Length; i++)
            {
                Console.WriteLine("Altitude of triangle to side {0}: {1}", sides[i], triangle.GetAltitude(sides[i]));
            }
        }
    }
}
