using CodeTranslator;
using System;

namespace CodeTranslatorUI
{
    class Program
    {
        private const string VB = nameof(VB);
        private const string CSharp = nameof(CSharp);

        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var arrayConverter = new CodeTranslator.IConvertible[] { new ProgramConverter(), new ProgramHelper() };

            ConvertTo(arrayConverter, VB);
            ConvertTo(arrayConverter, CSharp);
        }

        public static void ConvertTo(CodeTranslator.IConvertible[] arrayConverters, string code)
        {
            for (int i = 0; i < arrayConverters.Length; i++)
            {
                if (arrayConverters[i] is ICodeChecker checker)
                {
                    if (checker.CheckCodeSyntax(code, VB))
                    {
                        Console.WriteLine($" - Convert \"{code}\" to VB:");
                        Console.WriteLine(arrayConverters[i].ConvertToCSharp(code));
                    }
                    else
                    {
                        Console.WriteLine($" - Convert \"{code}\" to VB:");
                        Console.WriteLine(arrayConverters[i].ConvertToVB(code));
                    }
                }
                else
                {
                    Console.WriteLine($" - Convert \"{code}\" to VB and CSharp:");
                    Console.WriteLine(arrayConverters[i].ConvertToCSharp(string.Empty));
                    Console.WriteLine(arrayConverters[i].ConvertToVB(string.Empty));
                }
            }
        }
    }
}