using System;

namespace PointProcessor
{
    public static class Parser
    {
        private const char Separator = ',';
        private const char Dot = '.';

        private const int IndexX = 0;
        private const int IndexY = 1;

        public static bool TryParsePoint(string line, out Point point)
        {
            if(IsTwoPoint(line))
            {
                point = null;
                return false;
            }

            return ParsePoint(line, out point);
        }

        private static bool IsTwoPoint(string line)
        {
            return string.IsNullOrEmpty(line)
                || !line.Contains(Separator)
                || line.IndexOf(Separator) != line.LastIndexOf(Separator);
        }

        private static bool ParsePoint(string line, out Point point)
        {
            string[] numbers = line.Split(Separator);

            if (!decimal.TryParse(numbers[IndexX].Replace(Dot, Separator), out decimal x)
                | !decimal.TryParse(numbers[IndexY].Replace(Dot, Separator), out decimal y))
            {
                point = null;
                return false;
            }

            point = new Point(x, y);
            return true;
        }

    }
}
