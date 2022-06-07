using Converter;
using System;

namespace DataIO
{
    public class OutputHandler
    {
        public static void ConversionOutput(int x, params BaseSystemsConverter[] baseSystemsConverters)
        {
            foreach (var converter in baseSystemsConverters)
            {
                Console.WriteLine($"\n{converter.GetType().Name}:\n{converter.ToConvert(x)}");
            }
        }

        public static void CompareOutput(int x, params BaseSystemsConverter[] converters)
        {
            for (var i = 0; i <= converters.Length - 1; i++)
            {
                for (var j = converters.Length - 1; j >= 0; j--)
                {
                    if (i == j)
                    {
                        break;
                    }

                    CompareTwoOutput(x, converters[i] as StandartConverter, converters[j] as StandartConverter);
                }
            }
        }

        public static void CompareTwoOutput(int x, StandartConverter firstConverter, StandartConverter secondConverter)
        {
            var compareBaseSystem = firstConverter.ToCompare(secondConverter, x);

            Console.WriteLine($"\nCompare {firstConverter.GetType().Name} and {secondConverter.GetType().Name} :");
            foreach (var compare in compareBaseSystem)
            {
                Console.Write(compare.Key.ToString() + ": ");
                if (compare.Value)
                    Console.WriteLine("Results are equal.");
                else
                    Console.WriteLine("Results are not equal.");
            }
        }
    }
}