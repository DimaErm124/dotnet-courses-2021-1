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
            Ring ring = CreateRing(3, 3, 4, 2);

            OutputRing(ring);
        }

        public static Ring CreateRing(int x, int y, int radius, int innerRadius)
        {
            Ring ring = null;

            try
            {
                ring = new Ring(x, y, radius, innerRadius);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ring;
        }

        public static void OutputRing(Ring ring)
        {
            try
            {
                Console.WriteLine(ring.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
