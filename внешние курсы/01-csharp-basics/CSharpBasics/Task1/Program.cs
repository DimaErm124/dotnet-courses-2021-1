using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int a = 0;
            int b = 0;

            InputSide inputSide = new InputSide();

            Console.WriteLine("Hello, User.\n" +
                "This program is designed to find the square of a rectangle.\n" +
                "Need enter two sides to find the square.\n" +
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

            Console.WriteLine("Square of rectangle with sides " + a + "," + b + ": ");
            Console.WriteLine(rectangle.ToString());
        }
    }
    public class InputSide
    {
        private string returningString;

        public void NumberChecking(string stringSide, ref int side)
        {
            if (Int32.TryParse(stringSide, out side))
            {
                if (side > 0)
                {
                    returningString = "Great! You enter a correct number.";
                }
                else
                {
                    if (side < 0)
                    {
                        returningString = "Entered value is less than zero.\n" +
                            "Please, enter only positive integers greater than zero.";
                    }
                    else
                    {
                        returningString = "Entered value is zero.\n" +
                            "Please, enter only positive integers greater than zero.";
                    }
                }

            }
            else
            {
                returningString = "";
            }
        }

        public override string ToString()
        {
            return returningString;
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

        private int square;

        public void SquareCalculate()
        {
            square = sideA * sideB;
        }

        public override string ToString()
        {
            return square.ToString();
        }
    }
}
