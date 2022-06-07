using System;
using System.IO;

namespace PointProcessor
{
    public class Processor
    {
        private const char LineBreak = '\n';
        private const int StartPosition = 0;

        public static string ProcessFiles(string[] filenames)
        {
            string returnString = string.Empty;

            foreach (var file in filenames)
            {
                using (FileStream fstream = File.OpenRead(file))
                {
                    var array = new byte[fstream.Length];

                    fstream.Read(array, StartPosition, array.Length);

                    var textFromFile = System.Text.Encoding.Default.GetString(array);

                    var fileStrings = textFromFile.Split(LineBreak);

                    foreach (var str in fileStrings)
                    {
                        returnString += ProcessLine(str) + LineBreak;
                    }
                }
            }

            return returnString;
        }

        public static string ProcessConsole(string inputString)
        {            
            return ProcessLine(inputString);
        }

        public static string ProcessLine(string line)
        {
            Point point;
            bool isParsed = Parser.TryParsePoint(line, out point);

            return Formatter.Format(point);
        }
    }
}
