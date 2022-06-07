using System;

namespace PointProcessor
{
    public class Formatter
    {
        public static string Format(Point point)
        {
            if (object.Equals(point,null))
            {
                return null;
            }

            return point.ToString();
        }
    }
}
