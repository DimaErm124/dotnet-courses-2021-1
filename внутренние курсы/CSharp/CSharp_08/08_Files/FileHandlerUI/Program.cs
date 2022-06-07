using FileHandler;
using System;

namespace FileHandlerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "text.txt";

            Run(path);
        }

        public static void Run(string path)
        {
            string inputString = "[01] Привет мир!";

            FileArray fileArray = null;
            try
            {
                fileArray = FileArray.Create(path, inputString.Length);
                for (int i = 0; i < inputString.Length; i++)
                {
                    fileArray[i] = inputString[i];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fileArray.Dispose();
            }

            OutputString(path, inputString);

            using (fileArray = FileArray.Read(path))
            {
                fileArray[2] = '2';
            }

            OutputString(path, inputString);
        }

        public static void OutputString(string path, string inputString)
        {
            using FileArray fileArray = FileArray.Read(path);
            for (int i = 0; i < inputString.Length; i++)
            {
                Console.Write(fileArray[i]);
            }
            Console.WriteLine();
        }
    }
}