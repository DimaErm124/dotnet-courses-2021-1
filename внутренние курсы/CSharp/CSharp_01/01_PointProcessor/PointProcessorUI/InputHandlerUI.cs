using PointReader;
using System;

namespace PointProcessorUI
{
    public class InputHandlerUI
    {
        public static void AddMoreFile(InputHandler inputHandler, ref bool isCommandReading, bool isFile)
        {
            if (isFile)
            {
                Answer(inputHandler, ref isCommandReading);
            }
        }

        public static void Answer(InputHandler inputHandler, ref bool isCommandReading)
        {
            bool isAnswer = false;
            while (!isAnswer)
            {
                Console.WriteLine("Add more file? y/n");
                inputHandler.InputAnswer(Console.ReadLine(), ref isCommandReading, ref isAnswer);
            }
        }

        public static void ConsoleInput()
        {
            bool isAddMoreString = true;

            while (isAddMoreString)
            {
                Console.WriteLine("Input points:");
                var inputString = PointProcessor.Processor.ProcessConsole(Console.ReadLine());
                Console.WriteLine(inputString);

                isAddMoreString = !string.IsNullOrWhiteSpace(inputString);
            }
        }
    }
}
