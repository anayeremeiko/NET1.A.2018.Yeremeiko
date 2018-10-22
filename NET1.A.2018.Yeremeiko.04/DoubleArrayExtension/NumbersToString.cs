using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DoubleExtension;

namespace DoubleArrayExtension
{
    /// <summary>
    /// Contains logic of transforming double number to it's word equivalent.
    /// </summary>
    public static class NumbersToString
    {
        /// <summary>
        /// Converts double numbers to their word equivalent.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>String array containing word equivalent of double numbers.</returns>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static string[] TransformToWords(params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} need not null array");
            }

            string[] stringArray = new string[array.Length];
            int i = 0;
            foreach (double element in array)
            {
                stringArray[i] = ConvertToString(element);
                i++;
            }

            return stringArray;
        }

        /// <summary>
        /// Converts double array to string array in binary format.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The array of numbers in binary format.</returns>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static string[] TransformToIEEEFormat(params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} need not null array");
            }

            string[] stringArray = new string[array.Length];
            int i = 0;
            foreach (double element in array)
            {
                stringArray[i] = element.ToBinary();
                i++;
            }

            return stringArray;
        }

        /// <summary>
        /// Converts double in string format to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Number in words.</returns>
        private static string ConvertToString(double number)
        {
            if (double.IsNaN(number))
            {
                return "not a number ";
            } 

            if (double.IsPositiveInfinity(number))
            {
                return "positive infinity ";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "negative infinity ";
            }

            Dictionary<char, string> matching = new Dictionary<char, string>()
            {
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { '-', "minus" },
                { '.', "point" },
                { 'E', "exponent" },
                { '+', "plus" }
            };

            string result = string.Empty;

            foreach (char symbol in number.ToString(CultureInfo.InvariantCulture))
            {
                result += matching[symbol] + " ";
            }

            return result;
        }
    }
}
