using Converter;
using DataIO;

namespace ConverterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StandartConverter standartConverter = new StandartConverter();
            MyConverter myConverter = new MyConverter();
            Run(myConverter, standartConverter);
        }

        public static void Run(params BaseSystemsConverter[] baseSystemsConverters)
        {
            int x = InputHandler.InputPositiveIntegerNumber("Enter positive integer number:");

            OutputHandler.ConversionOutput(x, baseSystemsConverters);

            OutputHandler.CompareOutput(x, baseSystemsConverters);
        }
    }
}