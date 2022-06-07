namespace Converter
{
    public abstract class BaseSystemsConverter
    {
        protected readonly int bitsCount = 8;

        protected readonly char zero = '0';

        public abstract string ToConvert(int x);

        public abstract string ToBase(int x, BaseSystem toBase);
    }
}