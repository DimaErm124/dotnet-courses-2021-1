namespace CodeTranslator
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string code)
        {
            return "CSharpConverter";
        }

        public string ConvertToVB(string code)
        {
            return "VBConverter";
        }
    }
}