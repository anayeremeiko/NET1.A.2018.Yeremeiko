using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Polynomial
{
    /// <summary>
    /// Describes polynomial.
    /// </summary>
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private static double epsilon = 0.000000001;
        private double[] coefficients;

        static Polynomial()
        {

        }

        /// <summary>
        /// Constructor of polynomial.
        /// </summary>
        /// <param name="coefficients">Coefficients of polynomial.</param>
        /// <exception cref="ArgumentNullException">Coefficients shouldn't be null or empty.</exception>
        /// <exception cref="ArgumentException">Coefficients shouldn't contain Nan or Infinity.</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(coefficients)} shouldn't be null or empty.");
            }

            foreach (double number in coefficients)
            {
                if (double.IsInfinity(number) || double.IsNaN(number))
                {
                    throw new ArgumentException($"{nameof(number)} is invalid value.");
                }
            }

            this.coefficients = new double[coefficients.Length];

            coefficients.CopyTo(this.coefficients, 0);
        }

        public static double Epsilon { get => epsilon; set => epsilon = value; }

        /// <summary>
        /// Access to coefficients of polynomial.
        /// </summary>
        public double[] Coefficients { get => coefficients; private set => coefficients = value; }

        /// <summary>
        /// The degree of polynomial.
        /// </summary>
        /// <returns>The degree of polynomial.</returns>
        /// <exception cref="ArgumentNullException">Coefficients are null.</exception>
        public int Degree
        {
            get
            {
                if (ReferenceEquals(Coefficients, null))
                {
                    throw new ArgumentNullException($"{nameof(Coefficients)} are null.");
                }

                return Coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Coefficient of polynomial at specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Coefficient of polynomial at specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Index need to be non negative and les then degree of polynomial.</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} need to be non negative and les then degree of polynomial.");
                }

                return Coefficients[index];
            }
        }

        /// <summary>
        /// Operator of equality.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">FirstPolynomial shouldn't be null.</exception>
        /// <returns>Equality.</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} shouldn't be null.");
            }

            if (ReferenceEquals(firstPolynomial, secondPolynomial))
            {
                return true;
            }

            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Operator of non equality.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">FirstPolynomial shouldn't be null.</exception>
        /// <returns>Non equality of polynomials.</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} shouldn't be null.");
            }

            if (ReferenceEquals(firstPolynomial, secondPolynomial))
            {
                return false;
            }

            return !firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Operator of adding.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of adding.</returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            double[] newArguments = new double[firstPolynomial.Degree > secondPolynomial.Degree ? firstPolynomial.Coefficients.Length : secondPolynomial.Coefficients.Length];

            for (int i = 0; i < newArguments.Length; i++)
            {
                double first = 0;
                double second = 0;
                if (i <= firstPolynomial.Degree)
                {
                    first = firstPolynomial[i];
                }

                if (i <= secondPolynomial.Degree)
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
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of adding.</returns>
        public static Polynomial Add(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            return firstPolynomial + secondPolynomial;
        }

        /// <summary>
        /// Operator of subtract.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of subtraction.</returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            return firstPolynomial + -secondPolynomial;
        }

        /// <summary>
        /// Negates the specified polynomial.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <returns>Polynomial.</returns>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        public static Polynomial operator -(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            double[] newCoefficients = new double[polynomial.Degree + 1];
            for (int i = 0; i <= polynomial.Degree; i++)
            {
                newCoefficients[i] = -polynomial[i];
            }

            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Negates the specified polynomial.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <returns>Polynomial.</returns>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        public static Polynomial Negate(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            return -polynomial;
        }

        /// <summary>
        /// Operator of subtract.
        /// </summary>
        /// <param name="firstPolynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of subtraction.</returns>
        public static Polynomial Subtract(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(firstPolynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            return firstPolynomial - secondPolynomial;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial operator *(Polynomial polynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(polynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            double[] newArguments = new double[polynomial.Coefficients.Length + secondPolynomial.Coefficients.Length - 1];

            for (int i = 0; i <= polynomial.Degree; i++)
            {
                for (int j = 0; j <= secondPolynomial.Degree; j++)
                {
                    newArguments[i + j] += polynomial[i] * secondPolynomial[j];
                }
            }

            return new Polynomial(newArguments);
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial operator *(Polynomial polynomial, int number)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            double[] newArguments = new double[polynomial.Coefficients.Length];

            for (int i = 0; i <= polynomial.Degree; i++)
            {
                newArguments[i] += polynomial[i] * number;
            }

            return new Polynomial(newArguments);
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial operator *(int number, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            double[] newArguments = new double[polynomial.Coefficients.Length];

            for (int i = 0; i <= polynomial.Degree; i++)
            {
                newArguments[i] += polynomial[i] * number;
            }

            return new Polynomial(newArguments);
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial operator *(double number, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            double[] newArguments = new double[polynomial.Coefficients.Length];

            for (int i = 0; i <= polynomial.Degree; i++)
            {
                newArguments[i] += polynomial[i] * number;
            }

            return new Polynomial(newArguments);
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            double[] newArguments = new double[polynomial.Coefficients.Length];

            for (int i = 0; i <= polynomial.Degree; i++)
            {
                newArguments[i] += polynomial[i] * number;
            }

            return new Polynomial(newArguments);
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The first polynomial.</param>
        /// <param name="secondPolynomial">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomials need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(Polynomial polynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(polynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} and {nameof(secondPolynomial)} need to be not null.");
            }

            return polynomial * secondPolynomial;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(Polynomial polynomial, int number)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            return polynomial * number;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(int number, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            return polynomial * number;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(double number, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            return polynomial * number;
        }

        /// <summary>
        /// Operator of multiplying.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <exception cref="ArgumentNullException">Polynomial need to be not null.</exception>
        /// <returns>Result of multiplying.</returns>
        public static Polynomial Multiply(Polynomial polynomial, double number)
        {
            if (ReferenceEquals(polynomial, null))
            {
                throw new ArgumentNullException($"{nameof(polynomial)} need to be not null.");
            }

            return polynomial * number;
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

            int degree = Degree;
            double result = 0;

            foreach (double coefficient in Coefficients)
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
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals((object) this, obj))
            {
                return true;
            }

            if (!(obj is Polynomial polynomial))
            {
                return false;
            }

            return Equals(polynomial);
        }

        /// <summary>
        /// Equality of two polynomials.
        /// </summary>
        /// <param name="polynomial">The polynomial to compare with.</param>
        /// <returns>Equality.</returns>
        public bool Equals(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
            {
                return false;
            }

            if (ReferenceEquals(this, polynomial))
            {
                return true;
            }

            if (Degree != polynomial.Degree)
            {
                return false;
            }

            for (int i = 0; i <= Degree; i++)
            {
                if (Math.Abs(Coefficients[i] - polynomial[i]) > epsilon)
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
            int hashCode = 0;
            foreach (double number in Coefficients)
            {
                int intNumber = (int)BitConverter.DoubleToInt64Bits(number);
                hashCode += (intNumber >> (Degree + 1)) ^ intNumber;
            }

            return hashCode;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            double[] cloneCoefficients = new double[Degree + 1];
            Coefficients.CopyTo(cloneCoefficients, 0);
            return new Polynomial(cloneCoefficients);
        }

        /// <summary>
        /// String representation of polynomial.
        /// </summary>
        /// <returns>String representation of polynomial.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Polynomial: ");
            int degree = Degree;
            
            foreach (double number in Coefficients)
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
