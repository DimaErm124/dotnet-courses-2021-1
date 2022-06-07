using System;

namespace CodeTranslator
{
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {
        public bool CheckCodeSyntax(string code, string codeLanguage)
        {
            if (code.Contains(codeLanguage))
            {
                return true;
            }

            return false;
        }
    }
}