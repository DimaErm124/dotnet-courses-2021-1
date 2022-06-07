using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            CultureInfo enCulture = new CultureInfo("en");
            CultureInfo ruCulture = new CultureInfo("ru");
            CultureInfo invariant = CultureInfo.InvariantCulture;
            
            CompareCultures(enCulture, ruCulture, invariant);
        }

        public static void CompareCultures(params CultureInfo[] cultures)
        {
            CultureComprasion cultureComprasion = new CultureComprasion();

            for (int i = 0; i < cultures.Length - 1; i++)
            {
                for (int j = i + 1; j < cultures.Length; j++)
                {
                    string culturesComprasion = cultureComprasion.CompareTwoCultures(cultures[i], cultures[j]);

                    OutputComprasion(cultures[i], cultures[j], culturesComprasion);
                }
            }
        }

        public static void OutputComprasion(CultureInfo firstCulture, CultureInfo secondCulture, string culturesComprasion)
        {
            Console.WriteLine("  - Comprasion {0} and {1} : \n", firstCulture.NativeName, secondCulture.NativeName);
            Console.WriteLine(culturesComprasion);                
        }
    }
}
