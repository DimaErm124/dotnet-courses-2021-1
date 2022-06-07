using PointReader;
using System;

namespace PointProcessorUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler inputHandler = new InputHandler();

            Run(inputHandler);
        }

        public static void Run(InputHandler inputHandler)
        {
            bool isCommandReading = true;
            bool isFile = false;

            while (isCommandReading)
            {
                Console.WriteLine("Input file name with path:");
                inputHandler.InputCommands(Console.ReadLine(), ref isCommandReading, ref isFile);

                InputHandlerUI.AddMoreFile(inputHandler, ref isCommandReading, isFile);
            }

            if (inputHandler.Files.Count != 0)
                Console.WriteLine(PointProcessor.Processor.ProcessFiles(inputHandler.Files.ToArray()));
            else
                InputHandlerUI.ConsoleInput();
        }

        
    }
}
