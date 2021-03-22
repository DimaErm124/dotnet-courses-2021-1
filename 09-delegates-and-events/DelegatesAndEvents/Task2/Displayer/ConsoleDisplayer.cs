using System;

namespace Task2
{
    public class ConsoleDisplayer : Displayer
    {
        public override void Dislay(string str)
        {
            Console.WriteLine(str);
        }
    }
}