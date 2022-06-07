using System;
using System.Globalization;

namespace Task3
{
    public class CultureComprasion
    {
        private Random _random;

        private DateTime _date;

        public CultureComprasion()
        {
            _random = new Random();

            _date = DateTime.Now;
        }

        public string CompareTwoCultures(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareDateTimeFormat(firstCulture, secondCulture) 
                + CompareNumberFormat(firstCulture, secondCulture);
        }


        public string CompareDateTimeFormat(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareDate(firstCulture, secondCulture) 
                + CompareTime(firstCulture, secondCulture);
        }

        public string CompareNumberFormat(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareSymbol(firstCulture, secondCulture)
                + CompareNumber(firstCulture, secondCulture)
                + ComparePercent(firstCulture, secondCulture)
                + CompareCurrency(firstCulture, secondCulture);
        }


        public string CompareSymbol(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.PositiveSign, secondCulture.NumberFormat.PositiveSign, "Positive sign")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.NegativeSign, secondCulture.NumberFormat.NegativeSign, "Negative sign")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.NaNSymbol, secondCulture.NumberFormat.NaNSymbol, "NaN symbol")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.PositiveInfinitySymbol, secondCulture.NumberFormat.PositiveInfinitySymbol, "Infinity symbol")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.NegativeInfinitySymbol, secondCulture.NumberFormat.NegativeInfinitySymbol, "Negative infinity symbol")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.CurrencySymbol, secondCulture.NumberFormat.CurrencySymbol, "Currency symbol")
            + CompareSymbolString(firstCulture, secondCulture, firstCulture.NumberFormat.PercentSymbol, secondCulture.NumberFormat.PercentSymbol, "Percent symbol");
        }

        public string CompareNumber(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareNumberString(firstCulture,
                                       secondCulture,
                                       firstCulture.NumberFormat.NumberNegativePattern.ToString(),
                                       secondCulture.NumberFormat.NumberNegativePattern.ToString(),
                                       "Number negative pattern",
                                       "N",
                                       _random.Next(-100, 0))
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.NumberDecimalSeparator,
                                  secondCulture.NumberFormat.NumberDecimalSeparator,
                                  "Number decimal separator",
                                  "N",
                                  _random.NextDouble())
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.NumberGroupSeparator,
                                  secondCulture.NumberFormat.NumberGroupSeparator,
                                  "Number group separator",
                                  "N",
                                  _random.Next(1000, 10000));
        }

        public string CompareCurrency(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareNumberString(firstCulture,
                                       secondCulture,
                                       firstCulture.NumberFormat.CurrencyPositivePattern.ToString(),
                                       secondCulture.NumberFormat.CurrencyPositivePattern.ToString(),
                                       "Currency positive pattern",
                                       "C",
                                       _random.Next(0, 100))
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.CurrencyNegativePattern.ToString(),
                                  secondCulture.NumberFormat.CurrencyNegativePattern.ToString(),
                                  "Currency negative pattern",
                                  "C",
                                  _random.Next(-100, 0))
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.CurrencyDecimalSeparator,
                                  secondCulture.NumberFormat.CurrencyDecimalSeparator,
                                  "Currency decimal separator",
                                  "C",
                                  _random.NextDouble())
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.CurrencyGroupSeparator,
                                  secondCulture.NumberFormat.CurrencyGroupSeparator,
                                  "Currency group separator",
                                  "C",
                                  _random.Next(1000, 10000));
             
        }

        public string ComparePercent(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareNumberString(firstCulture,
                                       secondCulture,
                                       firstCulture.NumberFormat.PercentPositivePattern.ToString(),
                                       secondCulture.NumberFormat.PercentPositivePattern.ToString(),
                                       "Percent positive pattern",
                                       "P",
                                       _random.Next(0, 100))
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.PercentNegativePattern.ToString(),
                                  secondCulture.NumberFormat.PercentNegativePattern.ToString(),
                                  "Percent negative pattern",
                                  "P",
                                  _random.Next(-100, 0))
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.PercentDecimalSeparator,
                                  secondCulture.NumberFormat.PercentDecimalSeparator,
                                  "Percent decimal separator",
                                  "P",
                                  _random.NextDouble())
            + CompareNumberString(firstCulture,
                                  secondCulture,
                                  firstCulture.NumberFormat.PercentGroupSeparator,
                                  secondCulture.NumberFormat.PercentGroupSeparator,
                                  "Percent group separator",
                                  "P",
                                  _random.Next(1000, 10000));
        }


        public string CompareDate(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareDateTimeString(firstCulture,
                                         secondCulture,
                                         firstCulture.DateTimeFormat.ShortDatePattern,
                                         secondCulture.DateTimeFormat.ShortDatePattern,
                                         "Short date pattern",
                                         "d")
            + CompareDateTimeString(firstCulture,
                                    secondCulture,
                                    firstCulture.DateTimeFormat.LongDatePattern,
                                    secondCulture.DateTimeFormat.LongDatePattern,
                                    "Long date pattern",
                                    "D");
        }

        public string CompareTime(CultureInfo firstCulture, CultureInfo secondCulture)
        {
            return CompareDateTimeString(firstCulture,
                                         secondCulture,
                                         firstCulture.DateTimeFormat.ShortTimePattern,
                                         secondCulture.DateTimeFormat.ShortTimePattern,
                                         "Short time pattern",
                                         "t") 
                + CompareDateTimeString(firstCulture,
                                        secondCulture,
                                        firstCulture.DateTimeFormat.LongTimePattern,
                                        secondCulture.DateTimeFormat.LongTimePattern,
                                        "Long time pattern",
                                        "T");
        }    


        public string CompareDateTimeString(CultureInfo firstCulture, CultureInfo secondCulture, string firstFormatString, string secondFormatString, string formatName, string formatOutput)
        {
            if (!firstFormatString.Equals(secondFormatString))
            {
                return formatName + " " + TruncateName(firstCulture.NativeName) + " not equal " + TruncateName(secondCulture.NativeName) + "\n"
                    + "  " + TruncateName(firstCulture.NativeName) + ": " + _date.ToString(formatOutput, firstCulture) + "\n"
                    + "  " + TruncateName(secondCulture.NativeName) + ": " + _date.ToString(formatOutput, secondCulture) + "\n";
            }
            return formatName + " " + TruncateName(firstCulture.NativeName) + " equal " + TruncateName(secondCulture.NativeName) + "\n";
        }

        public string CompareSymbolString(CultureInfo firstCulture, CultureInfo secondCulture, string firstFormatString, string secondFormatString, string formatName)
        {
            if (!firstFormatString.Equals(secondFormatString))
            {
                return formatName + " " + TruncateName(firstCulture.NativeName) + " not equal " + TruncateName(secondCulture.NativeName) + "\n"
                    + "  " + TruncateName(firstCulture.NativeName) + ": " + firstFormatString.ToString(firstCulture) + "\n"
                    + "  " + TruncateName(secondCulture.NativeName) + ": " + secondFormatString.ToString(secondCulture) + "\n";
            }
            return formatName+" " + TruncateName(firstCulture.NativeName) + " equal " + TruncateName(secondCulture.NativeName) + "\n";
        }

        public string CompareNumberString(CultureInfo firstCulture, CultureInfo secondCulture, string firstFormatString, string secondFormatString, string formatName, string formatOutput, double number)
        {
            if (!firstFormatString.Equals(secondFormatString)) 
            {
                return formatName + " " + TruncateName(firstCulture.NativeName) + " not equal " + TruncateName(secondCulture.NativeName) + "\n"
                    + "  " + TruncateName(firstCulture.NativeName) + ": " + number.ToString(formatOutput, firstCulture) + "\n"
                    + "  " + TruncateName(secondCulture.NativeName) + ": " + number.ToString(formatOutput, secondCulture) + "\n";
            }
            return formatName + " " + TruncateName(firstCulture.NativeName) + " equal " + TruncateName(secondCulture.NativeName) + "\n";
        }
         
        public string TruncateName(string Name)
        {
            int spaceIndex = 0;

            for(int i = 0; i < Name.Length; i++)
            {
                if (Name[i] == ' ')
                {
                    spaceIndex = i;
                    break;
                }
            }

            if (spaceIndex == 0)
            {
                return Name;
            }
            return Name.Substring(0, spaceIndex);
        }
    }
}
