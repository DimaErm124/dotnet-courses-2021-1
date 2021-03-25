using System;
using System.IO;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessFile(@"C:\EPAM\dotnet-courses-2021-1\11-files\Files\Task1\disposable_task_file.txt");
        }

        public static void ProcessFile(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var bytes = new byte[fileStream.Length];

                fileStream.Read(bytes, 0, bytes.Length);

                var text = Encoding.Default.GetString(bytes);
                Console.WriteLine(text);

                var stringArray = text.Split();
                GetSquareNumber(stringArray);

                var newText = string.Join(" ", stringArray);
                Console.WriteLine(newText);

                var newBytes = Encoding.Default.GetBytes(newText);

                fileStream.Position = 0;
                fileStream.Write(newBytes, 0, newBytes.Length);
            }

            Console.WriteLine("File overwritten.");
        }

        public static void GetSquareNumber(string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (double.TryParse(stringArray[i],out double result))
                {
                    stringArray[i] = (result * result).ToString();
                }
            }
        }
    }    
}
