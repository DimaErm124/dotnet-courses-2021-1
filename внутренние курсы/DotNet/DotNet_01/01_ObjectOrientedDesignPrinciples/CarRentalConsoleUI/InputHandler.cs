using CarRental;
using System;

namespace CarRentalConsoleUI
{
    public static class InputHandler
    {
        public static string InputLogin(string instruction, int minSize, int maxSize)
        {
            string str = string.Empty;

            bool input = false;

            while (!input)
            {
                input = !input;

                Console.WriteLine(instruction);
                str = Console.ReadLine();

                foreach (char el in str)
                {
                    if (char.IsWhiteSpace(el) || char.IsPunctuation(el))
                    {
                        input = !input;
                        Console.WriteLine("Login must not have whitespace or punctuation!");
                    }
                }

                if (str.Length < ModelValues.LoginMinSize || str.Length > ModelValues.LoginMaxSize)
                {
                    input = !input;
                    Console.WriteLine("Login must have size more than " + ModelValues.LoginMinSize);
                }
            }

            return str;
        }

        public static string InputPassword(string instruction, int minSize)
        {
            string str = string.Empty;

            bool input = false;

            while (!input)
            {
                input = !input;

                Console.WriteLine(instruction);
                str = Console.ReadLine();

                foreach (char el in str)
                {
                    if (char.IsWhiteSpace(el) || char.IsPunctuation(el))
                    {
                        input = !input;
                        Console.WriteLine("Password must not have whitespace or punctuation!");
                    }
                }

                if (str.Length < ModelValues.PasswordMinSize)
                {
                    input = !input;
                    Console.WriteLine("Password must have size more than " + ModelValues.PasswordMinSize);
                }
            }

            return str;
        }

        public static int InputPositiveIntegerNumber(string instruction)
        {
            int number = -1;

            bool input = false;

            while (!input)
            {
                Console.WriteLine(instruction);
                string str = Console.ReadLine();

                if (str == "00")
                {
                    input = !input;
                }

                if (int.TryParse(str, out number) && number > 0)
                {
                    input = !input;
                }
            }

            return number;
        }

        public static string InputStringWithConcreteSize(string instruction, int size)
        {
            string str = string.Empty;

            bool input = false;

            while (!input)
            {
                Console.WriteLine(instruction);
                str = Console.ReadLine();

                if (str == "00")
                {
                    input = !input;
                }

                if (str.Length == size)
                {
                    input = !input;
                }
            }

            return str;
        }

        public static int InputPositiveIntegerWithConcreteSize(string instruction, int size)
        {
            int number = -1;

            bool input = false;

            while (!input)
            {
                Console.WriteLine(instruction);
                string str = Console.ReadLine();

                if (str == "00")
                {
                    input = !input;
                }

                if (int.TryParse(str, out number) && number > 0 && str.Length == ModelValues.DriverLicenseSize)
                {
                    input = !input;
                }
            }

            return number;
        }

        public static double InputPositiveDoubleNumber(string instruction)
        {
            double number = -1;

            bool input = false;

            while (!input)
            {
                Console.WriteLine(instruction);
                string str = Console.ReadLine();

                if (str == "00")
                {
                    input = !input;
                }

                if (double.TryParse(str, out number) && number > 0)
                {
                    input = !input;
                }
            }

            return number;
        }

        public static DateTime InputDateTime(string instruction)
        {
            DateTime date = new DateTime();

            bool input = false;

            while (!input)
            {
                Console.WriteLine(instruction);
                string str = Console.ReadLine();

                if (str == "00")
                {
                    input = !input;
                }

                if (DateTime.TryParse(str, out date) && date < DateTime.Now)
                {
                    input = !input;
                }
            }

            return date;
        }

        public static bool IsIntegerBounds(string lowerBoundString, string upperBoundString, ref int lowerBound, ref int upperBound)
        {
            return int.TryParse(lowerBoundString, out lowerBound)
                    && int.TryParse(upperBoundString, out upperBound)
                    && lowerBound > 0
                    && upperBound > 0
                    && lowerBound <= upperBound;
        }

        public static bool IsDoubleBounds(string lowerBoundString, string upperBoundString, ref double lowerBound, ref double upperBound)
        {
            return double.TryParse(lowerBoundString, out lowerBound)
                    && double.TryParse(upperBoundString, out upperBound)
                    && lowerBound > 0
                    && upperBound > 0
                    && lowerBound <= upperBound;
        }

        public static bool IsDateBounds(string lowerBoundString, string upperBoundString, ref DateTime lowerBound, ref DateTime upperBound)
        {
            return DateTime.TryParse(lowerBoundString, out lowerBound)
                    && DateTime.TryParse(upperBoundString, out upperBound)
                    && lowerBound < DateTime.Now
                    && upperBound < DateTime.Now
                    && lowerBound <= upperBound;
        }

    }

}