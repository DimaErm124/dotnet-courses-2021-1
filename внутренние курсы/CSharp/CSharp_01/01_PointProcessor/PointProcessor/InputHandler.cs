using PointProcessor;
using System;
using System.Collections.Generic;
using System.IO;

namespace PointReader
{
    public class InputHandler
    {
        private const string PositiveAnswer = "y";
        private const string NegativeAnswer = "n";

        public List<string> Files { get; set; }

        public InputHandler()
        {
            Files = new List<string>();
        }

        public void InputCommands(string inputCommand, ref bool isFileReading, ref bool isFile)
        {
            isFileReading = !string.IsNullOrWhiteSpace(inputCommand);

            if (File.Exists(inputCommand))
            {
                isFile = true;
                Files.Add(inputCommand);
            }
        }

        public void InputAnswer(string answer, ref bool isFileReading, ref bool isAnswer)
        {
            if (answer == PositiveAnswer)
            {
                isFileReading = true;
                isAnswer = true;
            }

            if (answer == NegativeAnswer)
            {
                isFileReading = false;
                isAnswer = true;
            }
        }
    }
}
