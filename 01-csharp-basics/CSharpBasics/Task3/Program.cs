using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int n = 0;

            InputNumber inputNumber = new InputNumber();

            Console.WriteLine("Hello, User.\n" +
                "This program is designed to construct image from stars.\n" +
                "Need enter number of stars.\n" +
                "Please, enter only positive integers greater than zero.\n");

            do
            {
                Console.WriteLine("Please, enter number:");
                string stringNumber = Console.ReadLine();
                inputNumber.NumberChecking(stringNumber, ref n);
                Console.WriteLine(inputNumber.ToString());
            }
            while (n <= 0);

            ImageСonstructor imageСonstructor = new ImageСonstructor(n);

            Console.WriteLine(imageСonstructor.ToString());
        }
    }

    public class InputNumber
    {
        public string ReturningString { get; set; }

        public void NumberChecking(string stringSide, ref int side)
        {
            if (Int32.TryParse(stringSide, out side))
            {
                if (side > 0)
                {
                    ReturningString = "Great! You enter a correct number.";
                }
                else
                {
                    if (side < 0)
                    {
                        ReturningString = "Entered value is less than zero.\n" +
                            "Please, enter only positive integers greater than zero.\n";
                    }
                    else
                    {
                        ReturningString = "Entered value is zero.\n" +
                            "Please, enter only positive integers greater than zero.\n";
                    }
                }

            }
            else
            {
                ReturningString = "Entered value is not number or not integer number.\n" +
                            "Please, enter only positive integers greater than zero.\n";
            }
        }

        public override string ToString()
        {
            return ReturningString;
        }

    }

    public class ImageСonstructor
    {
        public ImageСonstructor(int n)
        {
            number = n;
            ImageConstruct();
        }

        private int number;

        public string Image { get; set; }

        public void ImageConstruct()
        {
            for (int i = 1; i <= number; i++)
            {
                for (int j = number; j > i; j--)
                {
                    Image += " ";
                }
                for (int j = 0; j < i; j++)
                {
                    Image += "*";
                }
                for (int j = 1; j < i; j++)
                {
                    Image += "*";
                }
                if (i < number)
                {
                    Image += "\n";
                }
            }
        }

        public override string ToString()
        {
            return Image;
        }
    }
}
