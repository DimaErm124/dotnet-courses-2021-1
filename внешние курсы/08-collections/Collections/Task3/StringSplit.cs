using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task3
{
    public class StringSplit
    {
        public string SourceString;

        public IDictionary<string, int> CountStrings;

        public StringSplit(string str)
        {
            SourceString = str;
        }

        public IDictionary<string,int> SplitString()
        {
            var matches = new Regex(@"\b[a-zA-Z]+\b").Matches(SourceString);
            
            var dictionary = new Dictionary<string, int>();
            foreach (Match el in matches)
            {
                try
                {
                    dictionary.Add(el.Value.ToLower(), 1);
                }
                catch
                {
                    dictionary[el.Value.ToLower()]++;
                }
            }

            return dictionary;
        }
    }
}
