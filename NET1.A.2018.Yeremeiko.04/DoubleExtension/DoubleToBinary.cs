using System;
using System.Text;

namespace DoubleExtension
{
    /// <summary>
    /// Contains extension to double type.
    /// </summary>
    public static class DoubleToBinary
    {
        /// <summary>
        /// Converts double to binary.
        /// </summary>
        /// <param name="number">The target number.</param>
        /// <returns>Binary representation of target number in IEEE 754.</returns>
        public static string ToBinary(this double number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            if (number < 0.0 || double.IsNaN(number) || double.IsNegativeInfinity(1 / number) || double.IsNegativeInfinity(number))
            {
                binaryNumber.Append('1');
                number *= -1;
            }
            else
            {
                binaryNumber.Append('0');
            }

            if (double.IsNaN(number))
            {
                binaryNumber.Append(string.Empty.PadLeft(12, '1'));
                binaryNumber.Append(string.Empty.PadLeft(51, '0'));
            }
            else if (double.IsInfinity(number))
            {
                binaryNumber.Append(string.Empty.PadLeft(11, '1'));
                binaryNumber.Append(string.Empty.PadLeft(52, '0'));
            }
            else
            {
                binaryNumber.Append(ConvertToBinary(number));
            }
            
            return binaryNumber.ToString();
        }

        /// <summary>
        /// Converts long to binary.
        /// </summary>
        /// <param name="number">The target number.</param>
        /// <returns>String representation of target number.</returns>
        private static string LongToBinary(long number)
        {
            StringBuilder stringNumber = new StringBuilder();
            long remainder;

            while (number > 0)
            {
                remainder = number % 2;
                number /= 2;
                stringNumber.Insert(0, (remainder & 1) == 1 ? 1 : 0);
            }

            return stringNumber.ToString();
        }

        /// <summary>
        /// Converts double to binary.
        /// </summary>
        /// <param name="number">The target number.</param>
        /// <returns>String representation of target number.</returns>
        private static string ConvertToBinary(double number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            int scale = 0;
            bool isEpsilon = double.Epsilon == number;
            bool isZero = 0.0 == number;

            while (number > Math.Pow(2.0, scale))
            {
                scale++;
            }

            int denominator = 0;
            while (number % 1 != 0)
            {
                number *= 10;
                denominator++;
            }

            long numerator = (long)(number * Math.Pow(2.0, 53 - scale));
            long remainder = numerator % (int)Math.Pow(10.0, denominator);
            numerator /= (long)Math.Pow(10.0, denominator);
            if (remainder > Math.Pow(10.0, denominator) / 2)
            {
                scale--;
            }
            else if (remainder == (Math.Pow(10.0, denominator) / 2) && ((numerator & 1) != 0))
            {
                scale--;
            }

            if (isEpsilon || isZero)
            {
                binaryNumber.Append(LongToBinary(scale - 1022).PadLeft(11, '0'));
            }
            else
            {
                binaryNumber.Append(LongToBinary(scale + 1022).PadLeft(11, '0'));
            }
            
            binaryNumber.Append(LongToBinary(numerator).PadLeft(53, '0').Remove(0, 1));
            return binaryNumber.ToString();
        }
    }
}
