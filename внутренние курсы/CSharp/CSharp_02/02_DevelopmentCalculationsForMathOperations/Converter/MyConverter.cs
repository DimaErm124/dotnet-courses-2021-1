using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public class MyConverter : StandartConverter
    {
        private readonly int _size32 = 5;
        
        private readonly int _size64 = 6;

        private readonly char[] _base16Alphabet = {'0','1','2','3','4','5','6','7',
                                                   '8','9','a','b','c','d','e','f'};

        private readonly char[] _crockfordsBase32Alphabet = {'0','1','2','3','4','5','6','7',
                                                             '8','9','A','B','C','D','E','F',
                                                             'G','H','J','K','M','N','P','Q',
                                                             'R','S','T','V','W','X','Y','Z','='};

        private readonly char[] _base64Alphabet = {'A','B','C','D','E','F','G','H',
                                                  'I','J','K','L','M','N','O','P',
                                                  'Q','R','S','T','U','V','W','X',
                                                  'Y','Z','a','b','c','d','e','f',
                                                  'g','h','i','j','k','l','m','n',
                                                  'o','p','q','r','s','t','u','v',
                                                  'w','x','y','z','0','1','2','3',
                                                  '4','5','6','7','8','9','+','/','=' };
        public override string ToConvert(int x)
        {
            return x + " in bin system:  " + ToBin(x) + "\n"
                + x + " in oct system:  " + ToOct(x) + "\n"
                + x + " in hex system:  " + ToHex(x) + "\n"
                + x + " in base 32 system:  " + ToBase32(x) + "\n"
                + x + " in base 64 system:  " + ToBase64(x) + "\n";
        }

        public override string ToBase(int x, BaseSystem toBase)
        {
            switch (toBase)
            {
                case BaseSystem.Hex:
                    return string.Join(string.Empty, ToDefaultBase(x, (int)toBase).Select(x => _base16Alphabet[x]));
                case BaseSystem.Base32:
                    return ToCodingBase(Encoding.Default.GetBytes(x.ToString()), _size32, _crockfordsBase32Alphabet);
                case BaseSystem.Base64:
                    return ToCodingBase(Encoding.Default.GetBytes(x.ToString()), _size64, _base64Alphabet);
                default:
                    if (x < (int)toBase)
                    {
                        return x.ToString();
                    }
                    return string.Join(string.Empty, ToDefaultBase(x, (int)toBase));
            }
        }

        private List<int> ToDefaultBase(int originalNumber, int toBase)
        {
            int number = originalNumber;
            int remain;
            List<int> convertNumber = new List<int>();
            while (number > int.Parse(zero.ToString()))
            {
                remain = number % toBase;
                if (number / toBase > int.Parse(zero.ToString()))
                {
                    convertNumber.Add(remain);
                    number /= toBase;
                }
                else
                {
                    convertNumber.Add(number);
                    convertNumber.Reverse();
                    number /= toBase;
                }
            }
            return convertNumber;
        }

        private string ToCodingBase(byte[] originalNumberBytes, int size, char[] table)
        {
            IEnumerable<string> binaryStrings = originalNumberBytes.Select(x => Convert.ToString(x, (int)BaseSystem.Bin).PadLeft(bitsCount, zero));

            string allBytes = string.Join(string.Empty, binaryStrings);

            int countOfBytes = allBytes.Count();

            string append = GetEnding(countOfBytes, size, table[table.Length - 1]);

            List<string> newList = Enumerable.Range(0, countOfBytes / size).Select(x => allBytes.Substring(x * size, size)).ToList();

            int remOfDivision = countOfBytes % size;

            if (remOfDivision != int.Parse(zero.ToString()))
            {
                newList.Add(allBytes.Substring(countOfBytes / size * size, remOfDivision).PadRight(size, zero));
            }

            return string.Join(string.Empty, newList.Select(x => table[Convert.ToByte(x, (int)BaseSystem.Bin)])) + append;
        }

        private string GetEnding(int count, int size, char endChar)
        {
            string append = string.Empty;
            while (true)
            {
                if (count % size == int.Parse(zero.ToString()))
                    break;
                else
                {
                    count += bitsCount;
                    append += endChar;
                }
            }

            return append;
        }

        public string ToBase32(int x)
        {
            return ToBase(x, BaseSystem.Base32);
        }
    }
}