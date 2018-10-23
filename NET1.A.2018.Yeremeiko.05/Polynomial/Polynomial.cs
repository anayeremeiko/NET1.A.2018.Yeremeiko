using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Polynomial
{
    public sealed class Polynomial
    {
        private readonly double[] arguments;
        private readonly int argumentAmount;

        public Polynomial(params double[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(arguments)} shouldn't be null or empty.");
            }

            this.arguments = arguments;
            argumentAmount = this.arguments.Length;
        }

        public double[] Arguments => arguments;

        public double this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentException($"{nameof(index)} need to be non negative.");
                }

                if (index > argumentAmount - 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range.");
                }

                return Arguments[index];
            }
        }

        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial.Equals(secondPolynomial);
        }

        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !firstPolynomial.Equals(secondPolynomial);
        }

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] newArguments = new double[firstPolynomial.Degree() > secondPolynomial.Degree() ? firstPolynomial.Arguments.Length : secondPolynomial.Arguments.Length];

            for (int i = 0; i < newArguments.Length; i++)
            {
                double first = 0;
                double second = 0;
                if (i <= firstPolynomial.Degree())
                {
                    first = firstPolynomial[i];
                }

                if (i <= secondPolynomial.Degree())
                {
                    second = secondPolynomial[i];
                }

                newArguments[i] = first + second;
            }

            return new Polynomial(newArguments);
        }

        public static Polynomial Add(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial + secondPolynomial;
        }

        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] newArguments = new double[firstPolynomial.Degree() > secondPolynomial.Degree() ? firstPolynomial.Arguments.Length : secondPolynomial.Arguments.Length];

            for (int i = 0; i < newArguments.Length; i++)
            {
                double first = 0;
                double second = 0;
                if (i <= firstPolynomial.Degree())
                {
                    first = firstPolynomial[i];
                }

                if (i <= secondPolynomial.Degree())
                {
                    second = secondPolynomial[i];
                }

                newArguments[i] = first - second;
            }

            return new Polynomial(newArguments);
        }

        public static Polynomial Subtract(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial - secondPolynomial;
        }

        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] newArguments = new double[firstPolynomial.Arguments.Length + secondPolynomial.Arguments.Length - 1];

            for (int i = 0; i <= firstPolynomial.Degree(); i++)
            {
                for (int j = 0; j <= secondPolynomial.Degree(); j++)
                {
                    newArguments[i + j] += firstPolynomial[i] * secondPolynomial[j];
                }
            }

            return new Polynomial(newArguments);
        }

        public static Polynomial Multiply(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial * secondPolynomial;
        }

        public int Degree()
        {
            return argumentAmount - 1;
        }

        public double GetPolynomialValue(double unknown)
        {
            if (double.IsInfinity(unknown) || double.IsNaN(unknown))
            {
                throw new ArgumentException($"{nameof(unknown)} is invalid value.");
            }

            int degree = Degree();
            double result = 0;

            foreach (double coefficient in Arguments)
            {
                result += coefficient * Math.Pow(unknown, degree--);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial polynomial))
            {
                return false;
            }

            return (object)this == obj ? true : this.Equals(polynomial);
        }

        public bool Equals(Polynomial polynomial)
        {
            if (Degree() != polynomial.Degree())
            {
                return false;
            }

            for (int i = 0; i < argumentAmount; i++)
            {
                if (!Arguments[i].Equals(polynomial[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() 
        {
            string[] binaryArguments = DoubleArrayExtension.NumbersToString.TransformToIEEEFormat(Arguments);
            int hashCode = 0;
            foreach (string binaryNumber in binaryArguments)
            {
                int intNumber = (int)Convert.ToInt64(binaryNumber, 2);
                hashCode += (intNumber >> argumentAmount) ^ intNumber;
            }

            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Polynomial: ");
            int degree = Degree();
            
            foreach (double number in Arguments)
            {
                if (degree == 0)
                {
                    result.Append($"{number}");
                    break;
                }

                result.Append($"{number}x^{degree--} + ");
            }

            return result.ToString();
        }
    }
}
