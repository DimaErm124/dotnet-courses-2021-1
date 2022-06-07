using System;
using System.IO;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            App(@"C:\EPAM\dotnet-courses-2021-1\11-files\Main", "*.txt");
        }

        public static void App(string catalog, string pattern)
        {
            var logger = new Logger(catalog, pattern);

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1 - watch\n2 - pull\n0 - end\n");

                var item = Console.ReadLine();

                if (item == "1")
                {
                    Watch(logger);
                }
                if (item == "2")
                {
                    Pull(logger);
                }
                if (item == "0")
                {
                    break;
                }

            }
        }

        public static void Watch(Logger logger)
        {
            logger.LogEnable(true);

            Console.Clear();

            Console.WriteLine("Watching...");

            Console.ReadLine();

            logger.LogEnable(false);
        }

        public static void Pull(Logger logger)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - end\n");
                Console.WriteLine("Enter date and time ( year/month/day hour:minute ):\n");

                var item = Console.ReadLine();

                if (item == "0")
                {
                    break;
                }
                if (DateTime.TryParse(item, out DateTime dateTime))
                {
                    logger.Pull(dateTime);

                    break;
                }
            }
        }
    }
}
