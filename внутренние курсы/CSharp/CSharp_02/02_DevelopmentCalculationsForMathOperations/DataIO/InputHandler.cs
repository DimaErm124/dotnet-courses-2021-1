using System;
using System.Globalization;

namespace DataIO
{
    public class InputHandler
    {
        public static double InputPositiveDoubleNumber(string invitationString)
        {
            double number = 0;
            bool converting = true;

            while (converting)
            {
                Console.WriteLine(invitationString);
                string numberString = Console.ReadLine();

                if (double.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out number) || double.TryParse(numberString, out number))
                    CheckZeroBorber(number, ref converting);
                else
                    Console.WriteLine("Entered string cannot be converted to a number! Please, repeat again.");
            }

            return number;
        }

        public static double InputPositiveDoubleNumberWithRightBorder(string invitationString, double rightBorder)
        {
            double number = 0;
            bool converting = true;

            while (converting)
            {
                Console.WriteLine(invitationString);
                string numberString = Console.ReadLine();

                if (double.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out number) || double.TryParse(numberString, out number))
                    CheckBorbers(number, rightBorder, ref converting);
                else
                    Console.WriteLine("Entered string cannot be converted to a number! Please, repeat again.");
            }

            return number;
        }

        public static int InputPositiveIntegerNumber(string invitationString)
        {
            int number = 0;
            bool converting = true;

            while (converting)
            {
                Console.WriteLine(invitationString);
                string numberString = Console.ReadLine();

                if (int.TryParse(numberString, NumberStyles.Integer, CultureInfo.InvariantCulture, out number)
                    || int.TryParse(numberString, out number))
                    CheckZeroBorber(number, ref converting);
                else
                {
                    if (double.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out double errorInvariantNumber) 
                        || double.TryParse(numberString, out double errorNumber))
                        Console.WriteLine("Entered string is not integer number! Please, enter integer number.");
                    else
                        Console.WriteLine("Entered string cannot be converted to a number! Please, repeat again.");
                }
            }

            return number;
        }

        private static void CheckZeroBorber(double number, ref bool converting)
        {
            if (number > 0)
                converting = false;
            else
                Console.WriteLine("Number smaller than zero! Please, repeat again.");
        }

        private static void CheckBorbers(double number, double rightBorder, ref bool converting)
        {
            if (number > 0 && number < rightBorder)
                converting = false;
            else
            {
                if (number < 0)
                    Console.WriteLine("Number smaller than zero! Please, repeat again.");
                else
                    Console.WriteLine($"Number bigger than {rightBorder} or equal! Please, repeat again.");
            }
        }
    }
}