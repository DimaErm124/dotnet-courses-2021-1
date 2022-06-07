namespace CodeTranslator
{
    public interface IConvertible
    {
        string ConvertToCSharp(string code);

        string ConvertToVB(string code);
    }
}