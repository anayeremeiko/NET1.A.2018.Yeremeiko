using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Polynomial
{
    /// <summary>
    /// Describes polynomial.
    /// </summary>
    public sealed class Polynomial
    {
        private readonly double[] arguments;
        private readonly int argumentAmount;

        /// <summary>
        /// Constructor of polynomial.
        /// </summary>
        /// <param name="arguments">Coefficients of polynomial.</param>
        /// <exception cref="ArgumentNullException">Arguments shouldn't be null or empty.</exception>
        /// <exception cref="ArgumentException">Arguments shouldn't contain Nan or Infinity.</exception>
        public Polynomial(params double[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(arguments)} shouldn't be null or empty.");
            }

            foreach (double number in arguments)
            {
                if (double.IsInfinity(number) || double.IsNaN(number))
                {
                    throw new ArgumentException($"{nameof(number)} is invalid value.");
                }
            }

            this.arguments = arguments;
            argumentAmount = this.arguments.Length;
        }

        /// <summary>
        /// Access to arguments of polynomial.
        /// </summary>
        public double[] Arguments => arguments;

        /// <summary>
        /// Coefficient of polynomial at specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Coefficient of polynomial at specified index.</returns>
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

        /// <summary>
        /// Operator of equality.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Equality.</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Operator of non equality.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Non equality of polynomials.</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Operator of adding.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of adding.</returns>
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

        /// <summary>
        /// Operator of adding.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of adding.</returns>
        public static Polynomial Add(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial + secondPolynomial;
        }

        /// <summary>
        /// Operator of subtract.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of subtraction.</returns>
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

        /// <summary>
        /// Operator of subtract.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of subtraction.</returns>
        public static Polynomial Subtract(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial - secondPolynomial;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of multiplying.</returns>
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

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial * secondPolynomial;
        }

        /// <summary>
        /// The degree of polynomial.
        /// </summary>
        /// <returns>The degree of polynomial.</returns>
        public int Degree()
        {
            return argumentAmount - 1;
        }

        /// <summary>
        /// Counts the polynomial value.
        /// </summary>
        /// <param name="unknown">The unknown.</param>
        /// <exception cref="ArgumentException">Unknown shouldn't be NaN or Infinity.</exception>
        /// <returns>The polynomial value.</returns>
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

        /// <summary>
        /// Equality of object and polynomial.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Equality.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial polynomial))
            {
                return false;
            }

            return (object)this == obj ? true : this.Equals(polynomial);
        }

        /// <summary>
        /// Equality of two polynomials.
        /// </summary>
        /// <param name="polynomial">The polynomial to compare with.</param>
        /// <returns>Equality.</returns>
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

        /// <summary>
        /// Counts the hash code for polynomial.
        /// </summary>
        /// <returns>The hash code.</returns>
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

        /// <summary>
        /// String representation of polynomial.
        /// </summary>
        /// <returns>String representation of polynomial.</returns>
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
