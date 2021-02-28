using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;

            InputSide inputSide = new InputSide();

            Console.WriteLine("Hello, User.\n" +
                "This program is designed to find the square of a rectangle.\n" +
                "Enter two sides to find the square.\n" +
                "Please, enter only positive integers greater than zero.\n");

            do
            {
                Console.WriteLine("Please, enter the first side:");
                string stringA = Console.ReadLine();
                inputSide.NumberChecking(stringA, ref a);
                Console.WriteLine(inputSide.ToString() + "\n");
            }
            while (a <= 0);

            do
            {
                Console.WriteLine("Please, enter the second side:");
                string stringB = Console.ReadLine();
                inputSide.NumberChecking(stringB, ref b);
                Console.WriteLine(inputSide.ToString() + "\n");
            }
            while (b <= 0);

            Rectangle rectangle = new Rectangle(a, b);

            Console.WriteLine(rectangle.ToString());
        }
    }
    public class InputSide
    {
        public string ReturningString { get; set; }

        public void NumberChecking(string stringSide, ref int side)
        {
            if (Int32.TryParse(stringSide, out side))
            {
                if (side > 0)
                {
                    ReturningString = "Great! You enter a normal number";
                }
                else
                {
                    if (side < 0)
                    {
                        ReturningString = "Entered value is less than zero.\n" +
                            "Please, enter only positive integers greater than zero.";
                    }
                    else
                    {
                        ReturningString = "Entered value is zero.\n" +
                            "Please, enter only positive integers greater than zero.";
                    }
                }

            }
            else
            {
                ReturningString = "";
            }
        }

        public override string ToString()
        {
            return ReturningString;
        }

    }

    public class Rectangle
    {
        public Rectangle(int a, int b)
        {
            sideA = a;
            sideB = b;
            SquareCalculate();
        }

        private int sideA;

        private int sideB;

        public int Square { get; set; }

        public void SquareCalculate()
        {
            Square = sideA * sideB;
        }

        public override string ToString()
        {
            return "Square of rectangle with sides " + sideA + "," + sideB + ": " + Square.ToString();
        }
    }
}
