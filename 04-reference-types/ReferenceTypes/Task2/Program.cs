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

    public class Round
    {
        private int _radius;

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius 
        { 
            get { return _radius; }
            private set { if (value <= 0) { throw new Exception("Radius must be greater than zero!"); }   _radius = value; } 
        }

        public double Circumference { get { return 2 * Math.PI * _radius; } }

        public double Area { get { return Math.PI * Math.Pow(_radius, 2); } }

        public Round(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
