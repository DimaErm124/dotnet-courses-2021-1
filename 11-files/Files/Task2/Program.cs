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
            bool end = false;
            var log = new Log(catalog, pattern);

            while (!end)
            {
                Console.Clear();

                Console.WriteLine("1 - add text\n" +
                                    "2 - pull\n" +
                                    "0 - end");
                var item = Console.ReadLine();

                if (item == "1")
                {
                    ChooseFile(catalog, pattern, log.Push());
                }
                if (item == "2")
                {
                    log.Pull();
                }
                if (item == "0")
                {
                    end = true;
                }

            }
        }

        public static void ChooseFile(string catalog, string pattern, bool push)
        {
            bool end = false;
            while (!end)
            {
                Console.Clear();

                if (!push)
                {
                    Console.WriteLine("Copy no made! Please, relogin.");
                }

                Console.WriteLine("Choose file:");

                var filesNameArray = Directory.GetFiles(catalog, pattern, SearchOption.AllDirectories);

                for (int i = 0; i < filesNameArray.Length; i++)
                {
                    Console.WriteLine("{0} - {1}\n", i + 1, Path.GetFileName(filesNameArray[i]));
                }

                Console.WriteLine("0 - end\n");

                var item = Console.ReadLine();

                if (item == "0")
                {
                    end = true;
                }

                for(int i = 0; i < filesNameArray.Length; i++)
                {
                    if (item == (i + 1).ToString())
                    {
                        Console.Clear();

                        Console.WriteLine("Enter text to add:");
                        var text = Console.ReadLine();

                        AddText(filesNameArray[i], text);

                        end = true;
                    }                    
                }
            }
        }

        public static void AddText(string path, string text)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var bytes = Encoding.Default.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
