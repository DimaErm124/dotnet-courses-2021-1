using AbstractFactory;
using System;
using System.Collections.Generic;

namespace CreatorFurnitureUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var basket = new List<string>();
            var buying = true;

            while (buying)
            {
                Console.Clear();
                var factory = MenuFactory();
                basket.Add(MenuProduct(factory));
                buying = Question();
            }

            Console.Clear();
            Console.WriteLine("Your basket:");
            foreach(var el in basket)
            {
                Console.WriteLine($"- {el}");
            }
        }

        public static IFurnitureFactory MenuFactory()
        {
            IFurnitureFactory factory = new TableFactory();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello, what are you want to buy?");
                Console.WriteLine("1. Table");
                Console.WriteLine("2. Chair");
                Console.WriteLine("3. Sofa");
                Console.WriteLine("0. Exit");
                int menu = InputPositiveIntegerNumber("(choose number)");
                if (menu == 0)
                    break;
                if (menu == 1)
                {
                    break;
                }
                if (menu == 2)
                {
                    factory = new ChairFactory();
                    break;
                }
                if (menu == 3)
                {
                    factory = new SofaFactory();
                    break;
                }
            }

            return factory;
        }

        public static string MenuProduct(IFurnitureFactory factory)
        {
            string product = string.Empty;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello, what are you want a type of furniture?");
                Console.WriteLine("1. Wricker furniture");
                Console.WriteLine("2. Office furniture");
                Console.WriteLine("3. Dinning room furniture");
                Console.WriteLine("0. Exit");
                int menu = InputPositiveIntegerNumber("(choose number)");
                if (menu == 0)
                    break;
                if (menu == 1)
                {
                    product = factory.CreateWickerFurniture().ToString();
                    break;
                }
                if (menu == 2)
                {
                    product = factory.CreateOfficeFurniture().ToString();
                    break;
                }
                if (menu == 3)
                {
                    product = factory.CreateDinningRoomFurniture().ToString();
                    break;
                }
            }

            return product;
        }

        public static int InputPositiveIntegerNumber(string invitationString)
        {
            int power;

            while (true)
            {
                Console.WriteLine(invitationString);
                if (int.TryParse(Console.ReadLine(), out power) && power >= 0)
                    break;
            }

            return power;
        }

        public static bool Question()
        {
            bool isAddingProduct = false;
            bool isAnswer = false;
            while (!isAnswer)
            {
                Console.Clear();
                Console.WriteLine("Add more product in basket? y/n");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    isAnswer = true;
                    isAddingProduct = true;

                }
                if (answer == "n")
                {
                    isAnswer = true;
                    isAddingProduct = false;
                }
            }

            return isAddingProduct;
        }
    }
}