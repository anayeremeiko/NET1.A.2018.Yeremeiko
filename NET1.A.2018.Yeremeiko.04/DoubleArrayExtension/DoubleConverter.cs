using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleArrayExtension
{
    public class DoubleConverter : ITransformer
    {
        /// <summary>
        /// Converts double to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Number in words.</returns>
        public string Transform(double number)
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
