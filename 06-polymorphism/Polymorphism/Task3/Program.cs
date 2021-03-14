using ProgressionLibrary;
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
            var arithSeries = CreateArithmeticProgression(2.3, 5);
            var list = CreateList(new double[] { 2.3, 4, 5, 6.3, 2 });

            PrintSeries(arithSeries, 5);
            PrintSeries(list, 7);

            PrintIndexable(arithSeries, 5);
            PrintIndexable(list, 7);

        }

        public static void PrintSeries(ISeries series, int count)
        {
            Console.WriteLine("Series: ");

            try
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(series.Current);
                    series.MoveNext();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();            
        }

        public static void PrintIndexable(IIndexable series, int count)
        {
            Console.WriteLine("Indexable: ");

            try
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(series[count]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }

        public static ArithmeticProgression CreateArithmeticProgression(double start, int ratio)
        {
            ArithmeticProgression arithSeries = null;

            try
            {
                arithSeries = new ArithmeticProgression(start, ratio);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return arithSeries;
        }

        public static List CreateList(double[] series)
        {
            List list = null;

            try
            {
                list = new List(series);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }
    }
}
