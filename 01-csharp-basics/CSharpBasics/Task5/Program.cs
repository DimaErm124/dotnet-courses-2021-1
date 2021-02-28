using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int number = 1000;

            Summator summator = new Summator(number);

            Console.WriteLine(summator.ToString());
        }
    }

    public class Summator
    {
        public Summator(int n)
        {
            number = n;
            Summarize();
        }

        private int number;

        public int Sum { get; set; }

        public void Summarize()
        {
            for(int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Sum += i;
                }
            }
        }

        public override string ToString()
        {
            return Sum.ToString();
        }
    }
}
