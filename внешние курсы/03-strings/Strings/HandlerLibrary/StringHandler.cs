using System;

namespace HandlerLibrary
{
    public class StringHandler
    {
        public static float FindAverageWordsLengthInString(string sourceString)
        {            
            int wordCount = 0;
            int wordsLength = 0;

            sourceString = DeleteLeadingSpaces(sourceString);
            sourceString = DeleteOtherSymbols(sourceString);

            for (int i = 0; i < sourceString.Length; i++)
            {
                if (char.IsLetterOrDigit(sourceString[i]) || IsFractionalNumber(sourceString, i))
                {
                    wordsLength += 1;                   

                    if (IsStringEnd(sourceString, i)) 
                    {
                        wordCount += 1;
                    }
                }
                else if (IsWordEnd(sourceString, i))
                {
                    wordCount += 1;
                }                
            }
            
            return (float)wordsLength / (float)wordCount;
        }

        public static bool IsStringEnd(string str, int index)
        {
            return (index == str.Length - 1) && char.IsLetterOrDigit(str[index]);
        }
        
        public static bool IsFractionalNumber(string str, int index)
        {
            return IsInRange(str, index) &&
                char.IsDigit(str[index - 1]) &&
                char.IsDigit(str[index + 1]) &&
                char.IsPunctuation(str[index]);
        }

        public static bool IsInRange(string str, int index)
        {
            return (str.Length - 1 != index) && (index != 0);
        }

        public static bool IsWordEnd(string str, int index)
        {
            return !IsFractionalNumber(str, index) &&
                ((char.IsSeparator(str[index]) || char.IsPunctuation(str[index])) && char.IsLetterOrDigit(str[index - 1]));
        }

        public static string DeleteLeadingSpaces(string sourceString)
        {
            if (char.IsSeparator(sourceString[0]))
            {
                return DeleteLeadingSpaces(DeleteSymbol(sourceString, 0));
            }

            return sourceString;
        }

        public static string DeleteOtherSymbols(string sourceString)
        {
            for (int i = sourceString.Length-1; i > sourceString.Length; i--) 
            {
                if (char.IsSymbol(sourceString[i]))
                {
                    sourceString = DeleteSymbol(sourceString, i);
                } 
            }

            return sourceString;
        }

        public static string DoubleSymbolsFromSecondString(string firstInputString, string secondInputString)
        {
            string changedString = firstInputString;

            foreach (char el in secondInputString)
            {
                changedString = changedString.Replace(el.ToString(), new string(el, 2));
            }

            return changedString;
        }

        public static string DeleteDuplicateSymbols(string sourceString)
        {
            string changedString = sourceString;

            foreach (var el in changedString)
            {
                if (IsDuplicateSymbol(changedString, el))
                {
                    changedString = DeleteSymbol(changedString, changedString.LastIndexOf(el));
                }
            }

            return changedString;
        }

        public static string DeleteSymbol(string sourceString, int symbolIndex)
        {
            return sourceString.Remove(symbolIndex, 1);
        }

        public static bool IsDuplicateSymbol(string str, char symbol)
        {
            return str.IndexOf(symbol) != str.LastIndexOf(symbol);
        }
    }
}
