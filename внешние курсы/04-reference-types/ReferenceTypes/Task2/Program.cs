using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(3,3,4);

            Console.WriteLine("Radius of round ({0},{1})        - {2}", round.X, round.Y, round.Radius);
            Console.WriteLine("Circumference of round ({0},{1}) - {2}", round.X, round.Y, Math.Round(round.Circumference, 3));
            Console.WriteLine("Area of round ({0},{1})          - {2}", round.X, round.Y, Math.Round(round.Area, 3));
        }
    }
}
