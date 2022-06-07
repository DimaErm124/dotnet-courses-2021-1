using System;
using System.Collections.Generic;

namespace Polynomial
{
    public class OneVariablePolynomial
    {
        public double[] Constants { get; private set; }

        public int Degree { get; private set; }

        public int Length { get => Constants.Length; }

        public double this[int degree]
        {
            get
            {
                return Constants[degree];
            }
        }

        public OneVariablePolynomial(params double[] constants)
        {
            if (constants == null || constants.Length == 0)
            {
                throw new ArgumentNullException("No constants for polynomial!");
            }

            Constants = constants;
            Degree = InitDegree();
        }

        public OneVariablePolynomial(OneVariablePolynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException("Polynomial not initialized!");
            }

            Constants = polynomial.Constants;
            Degree = InitDegree();
        }

        public OneVariablePolynomial(string polynomialString)
        {
            if (polynomialString == null)
            {
                throw new ArgumentNullException("Polynomial not initialized!");
            }

            Constants = InitConstants(polynomialString);
            Degree = InitDegree();
        }
        
        private double[] InitConstants(string polynomialString)
        {
            double[] constants = new double[polynomialString.Length];
            int notEmptyElementsCount = 0;

            polynomialString = polynomialString.Replace(" ", "");

            for (int i = 0; i < polynomialString.Length; i++)
            {
                if (polynomialString[i].Equals('-') || i == 0)
                {
                    constants[notEmptyElementsCount] = double.Parse(GetNumberFromString(polynomialString, polynomialString[i].ToString(), ref i));
                    notEmptyElementsCount++;
                }
                if (polynomialString[i].Equals('+'))
                {
                    constants[notEmptyElementsCount] = double.Parse(GetNumberFromString(polynomialString, string.Empty, ref i));
                    notEmptyElementsCount++;
                }
            }

            Array.Resize(ref constants, notEmptyElementsCount);

            return constants;
        }

        private int InitDegree()
        {
            int degree = 0;

            for (int i = 0; i < Constants.Length; i++)
            {
                if (Constants[i] != 0)
                {
                    int oneDegree;

                    if (Constants[i] == 1)
                        oneDegree = i;
                    else
                        oneDegree = 1 + i;

                    if (oneDegree > degree)
                        degree = oneDegree;
                }
            }

            return degree;
        }

        private string GetNumberFromString(string sourceString, string initValue, ref int index)
        {
            string numberString = initValue;
            index++;
            while (true)
            {
                if (!char.IsDigit(sourceString[index]))
                    break;
                numberString += sourceString[index];
                index++;
            }

            return numberString;
        }

        public static OneVariablePolynomial operator +(OneVariablePolynomial polynomialA, OneVariablePolynomial polynomialB)
        {
            var polynomialMax = polynomialA.Length >= polynomialB.Length ? polynomialA : polynomialB;
            var polynomialMin = polynomialA.Length < polynomialB.Length ? polynomialA : polynomialB;

            var constants = new double[polynomialMax.Length];

            for (var i = 0; i < polynomialMin.Length; i++)
            {
                constants[i] = polynomialA[i] + polynomialB[i];
            }

            for (var i = polynomialMin.Length; i < polynomialMax.Length; i++)
            {
                constants[i] = polynomialMax[i];
            }

            return new OneVariablePolynomial(constants);
        }

        public static OneVariablePolynomial operator -(OneVariablePolynomial polynomialA, OneVariablePolynomial polynomialB)
        {
            var polynomialMax = polynomialA.Length >= polynomialB.Length ? polynomialA : polynomialB;
            var polynomialMin = polynomialA.Length < polynomialB.Length ? polynomialA : polynomialB;

            var constants = new double[polynomialMax.Length];

            for (var i = 0; i < polynomialMin.Length; i++)
            {
                constants[i] = polynomialA[i] - polynomialB[i];
            }

            for (var i = polynomialMin.Length; i < polynomialMax.Length; i++)
            {
                constants[i] = polynomialMax[i];
            }

            return new OneVariablePolynomial(constants);
        }

        public static OneVariablePolynomial operator *(OneVariablePolynomial polynomialA, double mult)
        {
            var constants = new double[polynomialA.Length];

            for (var i = 0; i < polynomialA.Length; i++)
            {
                constants[i] = polynomialA[i] * mult;
            }

            return new OneVariablePolynomial(constants);
        }

        public static OneVariablePolynomial operator *(OneVariablePolynomial polynomialA, OneVariablePolynomial polynomialB)
        {
            var matrix = new double[polynomialA.Length, polynomialB.Length];

            for (var foreign = 0; foreign < polynomialA.Length; foreign++)
            {
                for (var inner = 0; inner < polynomialB.Length; inner++)
                {
                    matrix[inner, foreign] = polynomialA[foreign] * polynomialB[inner];
                }
            }

            var constants = new double[polynomialA.Length + polynomialB.Length - 1];

            for (var index = 0; index < constants.Length; index++)
            {
                for (var foreign = 0; foreign < polynomialA.Length; foreign++)
                {
                    for (var inner = 0; inner < polynomialB.Length; inner++)
                    {
                        if (foreign + inner == index)
                        {
                            constants[index] += matrix[inner, foreign];
                        }
                    }
                }
            }

            return new OneVariablePolynomial(constants);
        }

        public static bool operator ==(OneVariablePolynomial polynomialA, OneVariablePolynomial polynomialB)
        {
            if ((object)polynomialA == null)
                return (object)polynomialB == null;

            if ((object)polynomialB == null)
                return (object)polynomialA == null;

            return polynomialA.Equals(polynomialB);
        }

        public static bool operator !=(OneVariablePolynomial polynomialA, OneVariablePolynomial polynomialB)
        {
            return !(polynomialA == polynomialB);
        }

        public override bool Equals(object polynomial)
        {
            if (polynomial == null)
                return false;

            if (this.Length != ((OneVariablePolynomial)polynomial).Length)
                return false;

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != ((OneVariablePolynomial)polynomial)[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            string polynomialString = string.Empty;
            
            for(int i = 0; i < Length; i++)
            {
                polynomialString += this[i].ToString();
            }

            return polynomialString.GetHashCode();
        }

        private string GetMonomialString(string firstString, string secondString, int index)
        {
            if (index > 1)
                return (Constants[index] < 0 ? firstString : secondString) + $"x^{index}";
            else
                return (Constants[index] < 0 ? firstString : secondString) + "x";
        }

        public string ToShortString()
        {
            string polynomial = string.Empty;
            
            if (Degree == 0) return "0";

            for (int i = 1; i < Constants.Length; i++)
                if (Constants[i] != 0)
                {
                    if (Constants[i] == 1 || Constants[i] == -1)
                    {
                        polynomial = GetMonomialString("-", "+", i) + polynomial;
                    }
                    else
                    {
                        polynomial = GetMonomialString(Constants[i].ToString() + "*", "+" + Constants[i] + "*", i) + polynomial;
                    }
                }

            polynomial += Constants[0] == 0 ? (Constants.Length == 1 ? "0" : string.Empty) : (Constants[0] < 0 ? Constants[0].ToString() : ("+" + Constants[0].ToString()));

            if (polynomial.Length == 0) return "0";

            return polynomial[0] == '+' ? polynomial.Remove(0, 1) : polynomial;
        }

        public override string ToString()
        {
            string polynomial = $"{Constants[0]}*x^0";

            for (int i = 1; i < Constants.Length; i++)
            {
                polynomial += (Constants[i] < 0 ? (" - " + Math.Abs(Constants[i]).ToString()) : (" + " + Math.Abs(Constants[i]).ToString())) + $"*x^{i}";
            }

            return polynomial;
        }
    }
}