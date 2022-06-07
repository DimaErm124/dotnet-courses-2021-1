using System;

namespace NthRoot
{
    public class MathRoot : Root
    {
        public MathRoot(double x, int n) : base(x, n)
        {
        }

        public override void SqrtN()
        {
            Result = Math.Pow(Number, 1.00 / (double)Power);
        }
    }
}
