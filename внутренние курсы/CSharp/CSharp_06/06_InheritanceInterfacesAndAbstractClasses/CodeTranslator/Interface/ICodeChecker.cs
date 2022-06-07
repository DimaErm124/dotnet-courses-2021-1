namespace CodeTranslator
{
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string code, string codeLanguage);
    }
}