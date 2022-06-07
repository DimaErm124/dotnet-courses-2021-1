using System;

namespace MatrixUI
{
    public class InputHandler
    {
        public static double InputDoubleNumber(string invitationString)
        {
            double number;

            while (true)
            {
                Console.WriteLine(invitationString);
                if (double.TryParse(Console.ReadLine(), out number))
                    break;
            }

            return number;
        }

        public static int InputPositiveIntegerNumber(string invitationString)
        {
            int power;

            while (true)
            {
                Console.WriteLine(invitationString);
                if (int.TryParse(Console.ReadLine(), out power) && power > 0)
                    break;
            }

            return power;
        }
    }

}