using NUnit.Framework;
using Polynomial;

namespace PolynomialTests
{
    public class OneVariablePolynomialTests
    {
        [Test]
        [TestCase(null, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(3, 4, ExpectedResult = true)]
        [TestCase(5, 6, 7, ExpectedResult = true)]
        public bool InitPolynomial_Constants_Success(params double[] constants)
        {
            try
            {
                OneVariablePolynomial polynomial = new OneVariablePolynomial(constants);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase("-1 + 10*x^3", ExpectedResult = true)]
        public bool InitPolynomial_PolynomialString_Success(string constants)
        {
            try
            {
                OneVariablePolynomial polynomial = new OneVariablePolynomial(constants);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase(ExpectedResult = false)]
        public bool InitPolynomial_Null_Failure()
        {
            double[] constants = null;
            try
            {
                OneVariablePolynomial polynomial = new OneVariablePolynomial(constants);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, ExpectedResult = 5)]
        public double GetLenght_Polynomial_Success(params double[] constants)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(constants);

            return polynomial.Length;
        }

        [Test]
        [TestCase(1, 0, -4, 10, ExpectedResult = 4)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 0, 0, 0, ExpectedResult = 0)]
        public double GetDegree_Polynomial_Success(params double[] constant)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(constant);

            return polynomial.Degree;
        }

        [Test]
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = -4)]
        [TestCase(3, ExpectedResult = 10)]
        public double GetConstant_Index_Success(int index)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(1, 0, -4, 10);

            return polynomial[index];
        }

        [Test]
        [TestCase(1, 0, -4, 10, ExpectedResult = "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3")]
        public string GetToString_Polynomial_Success(params double[] constants)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(constants);

            return polynomial.ToString();
        }

        [Test]
        [TestCase("0*x^0", ExpectedResult = "0")]
        [TestCase("-0*x^0", ExpectedResult = "0")]
        [TestCase("-0*x^0+0*x^1", ExpectedResult = "0")]
        [TestCase("0*x^0+1*x^1", ExpectedResult = "x")]
        [TestCase("0*x^0-1*x^1", ExpectedResult = "-x")]
        [TestCase("-1*x^0 - 1*x^1", ExpectedResult = "-x-1")]
        [TestCase("0*x^0 + 31*x^1 - 21*x^2", ExpectedResult = "-21*x^2+31*x")]
        [TestCase("-0*x^0 + 1*x^1 - 0*x^2", ExpectedResult = "x")]
        [TestCase("0*x^0 - 0*x^1 - 0*x^2", ExpectedResult = "0")]
        [TestCase("0*x^0 - 0*x^1 - 0*x^2 - 10*x^3", ExpectedResult = "-10*x^3")]
        [TestCase("-15*x^0 + 0*x^1 - 0*x^2 - 0*x^3", ExpectedResult = "-15")]
        [TestCase("-10*x^0 + 0*x^1 - 0*x^2 - 13*x^3", ExpectedResult = "-13*x^3-10")]
        [TestCase("10*x^0 + 11*x^1 + 12*x^2 + 13*x^3 + 14*x^4 + 15*x^5", ExpectedResult = "15*x^5+14*x^4+13*x^3+12*x^2+11*x+10")]
        [TestCase("-10*x^0 - 11*x^1 - 12*x^2 - 13*x^3 - 14*x^4 - 15*x^5", ExpectedResult = "-15*x^5-14*x^4-13*x^3-12*x^2-11*x-10")]
        public string GetToShortString_Polynomial_Success(string polynomialString)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(polynomialString);

            return polynomial.ToShortString();
        }

        [Test]
        [TestCase("1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = true)]
        [TestCase("-10*x^0 - 12*x^1 - 12*x^2 - 13*x^3 - 14*x^4 - 15*x^5", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = false)]
        public bool TestHashCode_TwoPolynomials_Bool(string polynomialStringA, string polynomialStringB)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(polynomialStringA);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(polynomialStringB);

            return polynomialA.GetHashCode() == polynomialB.GetHashCode();
        }

        [Test]
        [TestCase(new double[] { -9, -1, 0, 1, 9}, new double[] { -9, -1, 0, 1, 9 }, ExpectedResult = true)]
        [TestCase(new double[] { -9, -1, 0, 1, 9 }, new double[] { 9, 1, 0, -1, -9 }, ExpectedResult = false)]
        public bool TestHashCode_TwoPolynomialStrings_Bool(double[] constantsA, double[] constantsB)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(constantsA);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(constantsB);

            return polynomialA.GetHashCode() == polynomialB.GetHashCode();
        }

        [Test]
        [TestCase(1, 0, -4, 10, ExpectedResult = true)]
        [TestCase(1, 0, 4, 10, ExpectedResult = false)]
        public bool TestEquality_TwoPolynomial_Bool(params double[] constants)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(1, 0, -4, 10);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(constants);

            return polynomialA == polynomialB;
        }

        [Test]
        [TestCase("0 + 0*x^1 - 0*x^2 + 0*x^3", 0, 0, 0, 0, ExpectedResult = true)]
        [TestCase("0 + 3*x^1 - 0*x^2 + 0*x^3", 0, 3, 0, 0, ExpectedResult = true)]
        [TestCase("0 + 3*x^1 - 0*x^2 + 4*x^3", 0, 3, 4, 0, ExpectedResult = false)]
        public bool TestEquality_PolynomialAndConstants_Bool(string polynomialString, params double[] constants)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(polynomialString);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(constants);

            return polynomialA == polynomialB;
        }

        [Test]
        [TestCase(1, 0, -4, 10, ExpectedResult = true)]
        [TestCase(1, 0, 4, 10, ExpectedResult = false)]
        public bool TestEqual_TwoPolynomials_Bool(params double[] constants)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(1, 0, -4, 10);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(constants);

            return polynomialA.Equals(polynomialB);
        }

        [Test]
        [TestCase("0 + 0*x^1 - 0*x^2 + 0*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "10*x^3-4*x^2+1")]
        [TestCase("1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "20*x^3-8*x^2+2")]
        public string TestSum_TwoPolynomials_Polynomial(string polynomialStringA, string polynomialStringB)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(polynomialStringA);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(polynomialStringB);

            return (polynomialA + polynomialB).ToShortString();
        }

        [Test]
        [TestCase("0 + 0*x^1 - 0*x^2 + 0*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "-10*x^3+4*x^2-1")]
        [TestCase("1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "0")]
        public string TestDiff_TwoPolynomials_Polynomial(string polynomialStringA, string polynomialStringB)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(polynomialStringA);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(polynomialStringB);

            return (polynomialA - polynomialB).ToShortString();
        }

        [Test]
        [TestCase("0 + 0*x^1 - 0*x^2 + 0*x^3", 2, ExpectedResult = "0")]
        [TestCase("1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", 3, ExpectedResult = "30*x^3-12*x^2+3")]
        public string TestMult_PolynomialAndNumber_Polynomial(string polynomialString, double number)
        {
            OneVariablePolynomial polynomial = new OneVariablePolynomial(polynomialString);

            return (polynomial * number).ToShortString();
        }

        [Test]
        [TestCase("0 + 0*x^1 - 0*x^2 + 0*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "0")]
        [TestCase("1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", "1*x^0 + 0*x^1 - 4*x^2 + 10*x^3", ExpectedResult = "100*x^6-80*x^5+16*x^4+20*x^3-8*x^2+1")]
        public string TestMult_TwoPolynomials_Polynomial(string polynomialStringA, string polynomialStringB)
        {
            OneVariablePolynomial polynomialA = new OneVariablePolynomial(polynomialStringA);
            OneVariablePolynomial polynomialB = new OneVariablePolynomial(polynomialStringB);

            return (polynomialA * polynomialB).ToShortString();
        }
    }
}