using ProgressionLibrary;
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
            var series = CreateGeometricProgression(4, 1.6);

            PrintSeries(series, 5);
        }

        public static void PrintSeries(ISeries series, int count)
        {
            series.Reset();

            for(int i = 0; i < count; i++)
            {               
                Console.WriteLine(series.Current);
                series.MoveNext();
            }
        }

        public static GeometricProgression CreateGeometricProgression(double start, double ratio)
        {
            GeometricProgression geomSeries = null;

            try
            {
                geomSeries = new GeometricProgression(start, ratio);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return geomSeries;
        }
    }
}
