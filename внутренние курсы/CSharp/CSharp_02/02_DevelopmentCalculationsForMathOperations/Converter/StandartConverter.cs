using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class StandartConverter : BaseSystemsConverter
    {
        public override string ToConvert(int x)
        {
            return x + " in bin system:  " + ToBin(x) + "\n"
                + x + " in oct system:  " + ToOct(x) + "\n"
                + x + " in hex system:  " + ToHex(x) + "\n"
                + x + " in base 64 system:  " + ToBase64(x) + "\n";
        }

        public override string ToBase(int x, BaseSystem toBase)
        {
            switch (toBase)
            {
                case BaseSystem.Base64:
                    return Convert.ToBase64String(Encoding.Default.GetBytes(x.ToString()));
                default:
                    return Convert.ToString(x, (int)toBase);
            }
        }

        protected string ToBin(int x)
        {
            return ToBase(x, BaseSystem.Bin).PadLeft(bitsCount, zero);
        }

        protected string ToHex(int x)
        {
            return ToBase(x, BaseSystem.Hex);
        }

        protected string ToOct(int x)
        {
            return ToBase(x, BaseSystem.Oct);
        }

        protected string ToBase64(int x)
        {
            return ToBase(x, BaseSystem.Base64);
        }

        public IDictionary<BaseSystem, bool> ToCompare(StandartConverter converter, int x)
        {
            Dictionary<BaseSystem, bool> compareBaseSystem = new Dictionary<BaseSystem, bool>();

            compareBaseSystem.Add(BaseSystem.Bin, ToBin(x).Equals(converter.ToBin(x)));
            compareBaseSystem.Add(BaseSystem.Oct, ToOct(x).Equals(converter.ToOct(x)));
            compareBaseSystem.Add(BaseSystem.Hex, ToHex(x).Equals(converter.ToHex(x)));
            compareBaseSystem.Add(BaseSystem.Base64, ToBase64(x).Equals(converter.ToBase64(x)));

            return compareBaseSystem;
        }
    }
}