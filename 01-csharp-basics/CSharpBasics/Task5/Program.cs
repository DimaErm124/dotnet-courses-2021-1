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

        private int sum;

        public void Summarize()
        {
            for(int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
        }

        public override string ToString()
        {
            return sum.ToString();
        }
    }
}
