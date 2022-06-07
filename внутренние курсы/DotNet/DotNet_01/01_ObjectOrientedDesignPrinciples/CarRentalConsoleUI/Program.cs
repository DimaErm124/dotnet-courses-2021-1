using CarRental;
using System;

namespace CarRentalConsoleUI
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            bool enterMenu = true;

            while (enterMenu)
            {
                Console.WriteLine("1 - Log in");
                Console.WriteLine("2 - Sign up");
                Console.WriteLine("");
                Console.WriteLine("0 - Exit");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        LogInView.Enter();
                        break;
                    case "2":
                        Console.Clear();
                        SignUpView.RegisterView();
                        break;
                    case "0":
                        enterMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please, choose one of them.");
                        break;
                }
            }
        }
    }
}