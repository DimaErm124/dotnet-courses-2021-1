namespace PointProcessor
{
    public class InnerFormatter
    {
        private const char Separator = ',';

        private const int IndexX = 0;
        private const int IndexY = 1;

        private const int CountSymbols = 9;
        private const int CountSides = 2;

        public static string Format(string point)
        {
            point = AddingSeparator(FormatPosition(point.Split(Separator)), CountSymbols);

            return point;
        }

        private static string FormatPosition(string[] numberArray)
        {
            if (numberArray[IndexX].Length != numberArray[IndexY].Length)
            {
                if (numberArray[IndexX].Length > numberArray[IndexY].Length)
                    numberArray[IndexY] = numberArray[IndexY].PadRight(numberArray[IndexX].Length);
                else
                    numberArray[IndexX] = numberArray[IndexX].PadLeft(numberArray[IndexY].Length);
            }

            return numberArray[IndexX] + Separator + numberArray[IndexY];
        }

        private static string AddingSeparator(string sourceString, int newStringLength)
        {
            if (sourceString.Length < newStringLength)
            {
                var countWhiteSpaces = (newStringLength - sourceString.Length) / CountSides;
                sourceString = sourceString.PadLeft(countWhiteSpaces + sourceString.Length);
                sourceString = sourceString.PadRight(countWhiteSpaces + sourceString.Length);
            }

            return sourceString;
        }
    }
}
