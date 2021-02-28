using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int n = 0;

            InputNumber inputNumber = new InputNumber();

            Console.WriteLine("Hello, User.\n" +
                "This program is designed to construct triangles from stars.\n" +
                "Need enter number of triangles.\n" +
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
                            "Please, enter only positive integers greater than zero.\n";
                    }
                    else
                    {
                        returningString = "Entered value is zero.\n" +
                            "Please, enter only positive integers greater than zero.\n";
                    }
                }

            }
            else
            {
                returningString = "Entered value is not number or not integer number.\n" +
                            "Please, enter only positive integers greater than zero.\n";
            }
        }

        public override string ToString()
        {
            return returningString;
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

        private string image;

        public void ImageConstruct()
        {
            for (int n = 1; n <= number; n++)  
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 2*number; j > i; j--) 
                    {
                        image += " ";
                    }
                    for (int j = 0; j < i; j++)
                    {
                        image += "*";
                    }
                    for (int j = 1; j < i; j++)
                    {
                        image += "*";
                    }
                    if (n < number || i < number)
                    {
                        image += "\n";
                    }
                } 
            }
        }

        public override string ToString()
        {
            return image;
        }
    }
}
