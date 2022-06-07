using System;

namespace NthRoot
{
    public class NewtonsRoot : Root
    {
        private const double LowerBorderEps = 0.11;
        private double _eps;

        public double Eps
        {
            get { return _eps; }
            private set
            {
                if (value <= 0 || value >= LowerBorderEps)
                {
                    throw new Exception($"Accuracy should be more than zero and less than {LowerBorderEps}!");
                }
                _eps = value;
            }
        }

        public NewtonsRoot(double x, int n, double eps) : base(x, n)
        {
            Eps = eps;
        }

        public override void SqrtN()
        {
            var x0 = Number / Power;
            var x1 = NewtonsMethod(Power, Number, x0);

            while (Math.Abs(x1 - x0) > Eps)
            {
                x0 = x1;
                x1 = NewtonsMethod(Power, Number, x0);
            }

            Result = x1;
        }

        public static double NewtonsMethod(double n, double x, double x0)
        {
            return (1 / n) * ((n - 1) * x0 + x / Pow(x0, n - 1));
        }

        public static double Pow(double a, double pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }
    }
}
