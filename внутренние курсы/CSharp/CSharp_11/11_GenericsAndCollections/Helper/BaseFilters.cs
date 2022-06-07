using System;
using System.Linq;

namespace Helper
{
    public static class BaseFilters
    {
        public static string GetgMostFrequentlyWord(string inputString)
        {
            return inputString.Split(' ')
                         .Select(x=>x.ToLower())
                         .GroupBy(x => x)
                         .OrderByDescending(x => x.Count())
                         .Select(x => x.Key)
                         .First();
        }

        public static bool ValidatingPinCode(string pinCode)
        {
            if (!int.TryParse(pinCode, out int result) || pinCode.Length > 4)
                return false;

            return pinCode.GroupBy(x => x).All(x => x.Count() < 3);
        }
    }
}